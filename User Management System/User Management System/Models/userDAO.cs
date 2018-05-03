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
                String sqlQuery = String.Format(@"INSERT INTO dbo.users(name, login,
                password,email,gender,address,age,nic,dob,iscricket,hockey,chess,imagename,createdon) 
                VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}'
                ,'{12}','{13}')", obj.txtName, obj.txtLogin, obj.txtPassword, obj.txtEmail, obj.cmbGender,
                obj.txtAddress, obj.txtAge, obj.txtCnic, obj.dateDob, obj.chkCricket, obj.chkHockey, obj.chkChess, obj.userImage, DateTime.Now);

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
                if(reader.HasRows)
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
                command.Parameters.AddWithValue("@Email", email);
                SqlDataReader reader = command.ExecuteReader();
                user userObj = new user();
                if (reader.Read())
                {
                    userObj.txtName = reader.GetString(reader.GetOrdinal("name"));
                    userObj.userImage = reader.GetString(reader.GetOrdinal("imagename"));
                }
                return userObj;
            }
        }
    }
}