using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Data.SqlClient;

namespace WebFramework.Models
{
    public class Login
    {
        /* UPDATED : CONNECTION STRINGS */
        public static bool CheckLogin(string userName, string password)
        {
            SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Chris\\Documents\\webFrameworkDB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            //SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Chris\\Documents\\TestDB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            conn.Open();

            SqlCommand checkUser = new SqlCommand("SELECT count(*) from Login where Username = @username and Password = @password", conn);

            checkUser.Parameters.AddWithValue("@username", userName);
            checkUser.Parameters.AddWithValue("@password", password);

            int temp = Convert.ToInt32(checkUser.ExecuteScalar().ToString());

            if (temp == 1)
            {                
                return true;
            }

            else
            {
                return false;
            }
        }

        //public static void CreateUser(string Username1, string Password1)
        //{
        //    SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Chris\\Documents\\TestDB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        //    conn.Open();

        //    SqlCommand createUser = new SqlCommand("INSERT into Login(Username, Password) values (@username, @password)", conn);

        //    createUser.Parameters.AddWithValue("@username", Username1);
        //    createUser.Parameters.AddWithValue("@password", Password1);

        //    createUser.ExecuteNonQuery();
        //    conn.Close();
        //}
        
    }

    
}