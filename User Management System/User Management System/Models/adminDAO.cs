using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace User_Management_System.Models
{
    public class adminDAO
    {
        public bool validateAdmin(admin adminObj)
        {
            String connString = @"Data Source=.\SQLEXPRESS2012; Initial Catalog=Assignment4; Integrated Security=True; Persist Security Info=True;";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                String sqlQuery = String.Format(@"Select * from dbo.admin where login=@Login and password=@Password");
                SqlCommand command = new SqlCommand(sqlQuery, conn);
                SqlParameter param = command.Parameters.AddWithValue("@Login", adminObj.txtLogin);
                if (adminObj.txtLogin == null)
                    param.Value = DBNull.Value;
                param = command.Parameters.AddWithValue("@Password", adminObj.txtPassword);
                if (adminObj.txtPassword == null)
                    param.Value = DBNull.Value;
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    return true;
            }
            return false;
        }
    }
}