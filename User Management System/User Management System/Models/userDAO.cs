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
                ,'{12}','{13}')", obj.name, obj.login, obj.password, obj.email, obj.gender,
                obj.address, obj.age, obj.nic, obj.dob, obj.isCricket, obj.isHockey, obj.isChess, obj.imageName, DateTime.Now);

                SqlCommand command = new SqlCommand(sqlQuery, conn);
                int rowAffected = command.ExecuteNonQuery();
                Console.WriteLine("{0} Row Affected", rowAffected);
                return true;
            }
        }
    }
}