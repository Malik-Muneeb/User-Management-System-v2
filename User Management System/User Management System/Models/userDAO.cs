using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace User_Management_System.Models
{
    public class userDAO
    {
        public bool save(user obj)
        {
            String connString = @"Data Source=.\SQLEXPRESS2012; Initial Catalog=Assignment4; Integrated Security=True; Persist Security Info=True;";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                String sqlQuery = "";
                if(obj.txtId>0)
                {
                    sqlQuery = String.Format(@"Update dbo.users Set name='{0}',login='{1}', password='{2}',email='{3}',
                              gender='{4}',address='{5}',age='{6}',nic='{7}',dob='{8}',iscricket='{9}',hockey='{10}',
                              chess='{11}',imagename='{12}' Where userid='{13}'",obj.txtName,obj.txtLogin,obj.txtPassword,
                               obj.txtEmail,obj.cmbGender,obj.txtAddress,obj.txtAge,obj.txtCnic,obj.dateDob,obj.chkCricket,
                               obj.chkHockey,obj.chkChess,obj.userImage,obj.txtId);
                }
                else
                {
                    sqlQuery = String.Format(@"INSERT INTO dbo.users(name, login,
                password,email,gender,address,age,nic,dob,iscricket,hockey,chess,imagename,createdon) 
                VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}'
                ,'{12}','{13}')", obj.txtName, obj.txtLogin, obj.txtPassword, obj.txtEmail, obj.cmbGender,
                obj.txtAddress, obj.txtAge, obj.txtCnic, obj.dateDob, obj.chkCricket, obj.chkHockey, obj.chkChess, obj.userImage, DateTime.Now);
                }
                

                SqlCommand command = new SqlCommand(sqlQuery, conn);
                int rowAffected = command.ExecuteNonQuery();
                Console.WriteLine("{0} Row Affected", rowAffected);
                return true;
            }
        }

        public bool isUserExistByEmail(String email)
        {
            String connString = @"Data Source=.\SQLEXPRESS2012; Initial Catalog=Assignment4; Integrated Security=True; Persist Security Info=True;";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                String sqlQuery = String.Format(@"Select * from dbo.users where email=@Email");

                SqlCommand command = new SqlCommand(sqlQuery, conn);
                command.Parameters.AddWithValue("@Email", email);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    return true;
            }
            return false;
        }

        public bool isUserExistByLogin(String login)
        {
            String connString = @"Data Source=.\SQLEXPRESS2012; Initial Catalog=Assignment4; Integrated Security=True; Persist Security Info=True;";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                String sqlQuery = String.Format(@"Select * from dbo.users where login=@Login");
                SqlCommand command = new SqlCommand(sqlQuery, conn);
                command.Parameters.AddWithValue("@Login", login);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    return true;
            }
            return false;
        }

        public user getUserByEmail(String email)
        {
            String connString = @"Data Source=.\SQLEXPRESS2012; Initial Catalog=Assignment4; Integrated Security=True; Persist Security Info=True;";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                String sqlQuery = String.Format(@"Select * from dbo.users where email=@Email");

                SqlCommand command = new SqlCommand(sqlQuery, conn);
                SqlParameter param = command.Parameters.AddWithValue("@Email", email);
                if (email == null)
                {
                    param.Value = DBNull.Value;
                }
                SqlDataReader reader = command.ExecuteReader();
                user userObj = new user();
                if (reader.Read())
                {
                    userObj.txtId = reader.GetInt32(reader.GetOrdinal("userid"));
                    userObj.txtName = reader.GetString(reader.GetOrdinal("name"));
                    userObj.txtLogin = reader.GetString(reader.GetOrdinal("login"));
                    userObj.txtPassword = reader.GetString(reader.GetOrdinal("password"));
                    userObj.txtEmail = reader.GetString(reader.GetOrdinal("email"));
                    userObj.cmbGender = reader.GetString(reader.GetOrdinal("gender"));
                    userObj.txtAddress = reader.GetString(reader.GetOrdinal("address"));
                    userObj.txtAge = reader.GetInt32(reader.GetOrdinal("age"));
                    userObj.txtCnic = reader.GetString(reader.GetOrdinal("nic"));
                    userObj.dateDob = reader.GetDateTime(reader.GetOrdinal("dob"));
                    userObj.chkCricket = reader.GetBoolean(reader.GetOrdinal("iscricket"));
                    userObj.chkHockey = reader.GetBoolean(reader.GetOrdinal("hockey"));
                    userObj.chkChess = reader.GetBoolean(reader.GetOrdinal("chess"));
                    userObj.userImage = reader.GetString(reader.GetOrdinal("imagename"));
                }
                return userObj;
            }
        }

        public List<user> getAllUsers()
        {
            String connString = @"Data Source=.\SQLEXPRESS2012; Initial Catalog=Assignment4; Integrated Security=True; Persist Security Info=True;";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                String sqlQuery = "Select * from dbo.users";
                SqlCommand command = new SqlCommand(sqlQuery, conn);
                SqlDataReader reader = command.ExecuteReader();
                List<user> userList = new List<user>();

                while (reader.Read() == true)
                {
                    user userObj = new user();
                    userObj.txtId = reader.GetInt32(reader.GetOrdinal("userid"));
                    userObj.txtName = reader.GetString(reader.GetOrdinal("name"));
                    userObj.txtLogin = reader.GetString(reader.GetOrdinal("login"));
                    userObj.txtPassword = reader.GetString(reader.GetOrdinal("password"));
                    userObj.txtEmail = reader.GetString(reader.GetOrdinal("email"));
                    userObj.cmbGender = reader.GetString(reader.GetOrdinal("gender"));
                    userObj.txtAddress = reader.GetString(reader.GetOrdinal("address"));
                    userObj.txtAge = reader.GetInt32(reader.GetOrdinal("age"));
                    userObj.txtCnic = reader.GetString(reader.GetOrdinal("nic"));
                    userObj.dateDob = reader.GetDateTime(reader.GetOrdinal("dob"));
                    userObj.chkCricket = reader.GetBoolean(reader.GetOrdinal("iscricket"));
                    userObj.chkHockey = reader.GetBoolean(reader.GetOrdinal("hockey"));
                    userObj.chkChess = reader.GetBoolean(reader.GetOrdinal("chess"));
                    userObj.userImage = reader.GetString(reader.GetOrdinal("imagename"));

                    userList.Add(userObj);
                }
                return userList;
            }
        }

        public String validateUser(user userObj)
        {
            String connString = @"Data Source=.\SQLEXPRESS2012; Initial Catalog=Assignment4; Integrated Security=True; Persist Security Info=True;";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                String sqlQuery = String.Format(@"Select * from dbo.users where login=@Login and password=@Password");
                SqlCommand command = new SqlCommand(sqlQuery, conn);
                SqlParameter param = command.Parameters.AddWithValue("@Login", userObj.txtLogin);
                if (userObj.txtLogin == null)
                    param.Value = DBNull.Value;
                param = command.Parameters.AddWithValue("@Password", userObj.txtPassword);
                if (userObj.txtPassword == null)
                    param.Value = DBNull.Value;
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    if(reader.Read())
                        return reader.GetString(reader.GetOrdinal("email"));
                }
            }
            return null;
        }
    }
}