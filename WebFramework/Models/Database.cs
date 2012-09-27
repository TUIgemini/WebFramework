using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebFramework.Models
{
    public class Database
    {

        private static SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\bc\\Desktop\\WebFramework\\WebFramework\\webFrameworkDB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");

        public static List<string> GetPage(string page)
        {            
            List<string> Contents = new List<string>();

            //SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Chris\\Documents\\TestDB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        //    SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Chris\\Documents\\webFrameworkDB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            conn.Open();

            SqlCommand comm = new SqlCommand("SELECT * FROM ContentPage WHERE Title = @page", conn);
            SqlParameter rPage = new SqlParameter();
            rPage.ParameterName = "@page";
            rPage.Value = page;
            comm.Parameters.Add(rPage);
            SqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            {
                Contents.Add(reader[1].ToString());
                Contents.Add(reader[2].ToString());
                Contents.Add(reader[3].ToString());                
            }

            reader.Close();
            conn.Close();
           
            return Contents;
        }

        public static List<string> GetAbout()
        {
            List<string> Contents = new List<string>();

          //  SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Chris\\Documents\\TestDB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            conn.Open();

            SqlCommand comm = new SqlCommand("SELECT * FROM AboutPage", conn);            
            SqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            {
                Contents.Add(reader[1].ToString());
                Contents.Add(reader[2].ToString());
                Contents.Add(reader[3].ToString());
            }

            reader.Close();
            conn.Close();

            return Contents;
        }

        public static List<string> GetContact()
        {
            List<string> Contents = new List<string>();

            //SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Chris\\Documents\\TestDB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            conn.Open();

            SqlCommand comm = new SqlCommand("SELECT * FROM ContactPage", conn);
            SqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            { 
                Contents.Add(reader[1].ToString());
                Contents.Add(reader[2].ToString());
                Contents.Add(reader[3].ToString());
                Contents.Add(reader[4].ToString());
            }

            reader.Close();
            conn.Close();

            return Contents;
        }

        public static void CreateContact(string title, string name, string email, string content)
        {
            //SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Chris\\Documents\\TestDB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            conn.Open();

            SqlCommand delete = new SqlCommand("DELETE FROM ContactPage", conn);

            delete.ExecuteNonQuery();

            SqlCommand comm = new SqlCommand("INSERT into ContactPage(PageTitle, Name, Email, Contents) values (@pagetitle, @name, @email, @contents)", conn);

            comm.Parameters.AddWithValue("@pagetitle", title);
            comm.Parameters.AddWithValue("@name", name);
            comm.Parameters.AddWithValue("@email", email);
            comm.Parameters.AddWithValue("@contents", content);

            comm.ExecuteNonQuery();

            conn.Close();
        }

        public static void CreateAbout(string title, string name, string content)
        {
            //SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Chris\\Documents\\TestDB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            conn.Open();
          
            SqlCommand delete = new SqlCommand("DELETE FROM AboutPage", conn);           

            delete.ExecuteNonQuery();

            SqlCommand comm = new SqlCommand("INSERT into AboutPage(PageTitle, Name, Contents) values (@pagetitle, @name, @contents)", conn);

            comm.Parameters.AddWithValue("@pagetitle", title);
            comm.Parameters.AddWithValue("@name", name);
            comm.Parameters.AddWithValue("@contents", content);

            comm.ExecuteNonQuery();

            conn.Close();            
        }

        public static List<string> GetGroups()
        {
            List<string> Contents = new List<string>();

            //SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Chris\\Documents\\TestDB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            conn.Open();

            SqlCommand comm = new SqlCommand("SELECT Groups FROM Groups", conn);
                       
            SqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            {
                Contents.Add(reader[0].ToString());
            }

            reader.Close();
            conn.Close();

            return Contents;
        }

        public static List<string> ListPages(string group)
        {
            List<string> Contents = new List<string>();

            //SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Chris\\Documents\\TestDB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            conn.Open();

            SqlCommand comm = new SqlCommand("SELECT Title FROM ContentPage WHERE Groups = @group", conn);
            SqlParameter rGroup = new SqlParameter();
            rGroup.ParameterName = "@group";
            rGroup.Value = group;
            comm.Parameters.Add(rGroup);
            SqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            {
                Contents.Add(reader[0].ToString());
            }

            reader.Close();
            conn.Close();

            return Contents;
        }

        public static bool AddPage(string title, string group, string content)
        {
            //SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Chris\\Documents\\TestDB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            conn.Open();

            SqlCommand checkGroup = new SqlCommand("SELECT count(*) from Groups where Groups = @groups", conn);
            SqlParameter rGroup = new SqlParameter();
            rGroup.ParameterName = "@groups";
            rGroup.Value = group;
            checkGroup.Parameters.Add(rGroup);

            int temp = Convert.ToInt32(checkGroup.ExecuteScalar().ToString());

            checkGroup.Parameters.AddWithValue("@groups", group);

            conn.Close();

            if (temp == 1)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        

        /*COME BACK AND CHECK---------------------------------------------------------------------------------------------------////*/

        public static bool CheckGroups(string group)
        {
            //SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Chris\\Documents\\TestDB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            conn.Open();

            SqlCommand checkGroup = new SqlCommand("SELECT count(*) from ContentPage where Groups = @groups", conn);
            SqlParameter rGroup = new SqlParameter();
            rGroup.ParameterName = "@groups";
            rGroup.Value = group;
            checkGroup.Parameters.Add(rGroup);

            int temp = Convert.ToInt32(checkGroup.ExecuteScalar().ToString());

            checkGroup.Parameters.AddWithValue("@groups", group);
            conn.Close();
            if (temp > 1)
            {
                return true;
            }

            else
            {
                return false;
            }
            
        }
       
    }
}