using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BitBook2.Models;

namespace BitBook2.LayerFolder.DAL
{
    public class UserProfileGateway
    {
        string connectionString = @"Data Source=DESKTOP-1FDNDJJ\SQLEXPRESS;Initial Catalog=BitBook;Integrated Security=true";
        public int Save(UserProfile auserProfile)
        {
            //string connectionString = @"Data Source=DESKTOP-AGFJ699\SQLSERVER;Initial Catalog=BitBook;Integrated Security=true";

            SqlConnection connection = new SqlConnection(connectionString);
            // write insert command 


            string query = "INSERT INTO Profile(UserId,Status) VALUES('" + auserProfile.UserId + "','" + auserProfile.Status + "')";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();
            return rowAffected;
        }


        public int AddAdditionalInfo(AdditionalInfo additionalInfo)
        {
            //string connectionString = @"Data Source=DESKTOP-AGFJ699\SQLSERVER;Initial Catalog=BitBook;Integrated Security=true";

            SqlConnection connection = new SqlConnection(connectionString);
            // write insert command 




            string query = "INSERT INTO AdditionalInfo(UserId,ProfilePhoto,CoverPhoto,Gender,Education,Location) VALUES('" + additionalInfo.UserId + "','Images/nerd.png ','Images/Cover (1).jpg','" + additionalInfo.Gender + "','" + additionalInfo.Education + "','" + additionalInfo .Location+ "')";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();
            return rowAffected;
        }




        public List<UserProfile> GetUserStatusById(int userId)
        {
            //string connectionString = @"Data Source=DESKTOP-AGFJ699\SQLSERVER;Initial Catalog=BitBook;Integrated Security=true";

           
            // write insert command 
        

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM Profile WHERE UserId=" + userId;

            SqlCommand command = new SqlCommand(query, connection);

            List<UserProfile> statuslist=new List<UserProfile>();
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                UserProfile aProfile = new UserProfile();
                aProfile.Status = reader["Status"].ToString();
                aProfile.StatusId = Convert.ToInt32(reader["StatusId"].ToString());

              //  aProfile.UserId = Convert.ToInt32(reader["UserId"].ToString());
                statuslist.Add(aProfile);

            }
            connection.Close();

            return statuslist;
            
        }

        public int Delete(int statusId)
        {
            //string connectionString = @"Data Source=DESKTOP-AGFJ699\SQLSERVER;Initial Catalog=BitBook;Integrated Security=true";

            SqlConnection connection = new SqlConnection(connectionString);
            // write insert command 


            string query = "DELETE FROM  Profile WHERE StatusId=" + statusId;

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();
            return rowAffected;
        }

        public UserAccount GetUserById(int id)
        {
            //string connectionString = @"Data Source=DESKTOP-AGFJ699\SQLSERVER;Initial Catalog=BitBook;Integrated Security=true";

            SqlConnection connection = new SqlConnection(connectionString);
         

            string query = "SELECT * FROM UserAccount WHERE UserId=" + id;

            SqlCommand command = new SqlCommand(query, connection);

            UserAccount aacAccount = null;

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                aacAccount = new UserAccount();
                    aacAccount.UserId = Convert.ToInt32(reader["UserId"].ToString());
                    aacAccount.FirstNale = reader["FirstNale"].ToString();
                    aacAccount.LastName=reader["LastName"].ToString();
                    aacAccount.Email=reader["Email"].ToString();
                    aacAccount.UserName=reader["UserName"].ToString();
                    aacAccount.Password = reader["Password"].ToString();
                    aacAccount.ConfirmPassword = reader["ConfirmPassword"].ToString();

                   
              

            }
            connection.Close();

            return aacAccount;
        }

        public int Update(UserAccount account)
        {
            //string connectionString = @"Data Source=DESKTOP-AGFJ699\SQLSERVER;Initial Catalog=BitBook;Integrated Security=true";

            SqlConnection connection = new SqlConnection(connectionString);
            // write insert command 

            string query = "UPDATE UserAccount SET FirstNale='" + account.FirstNale + "',LastName='" + account.LastName + "',Email='" + account.Email + "',UserName='" + account.UserName + "',Password='" + account.Password + "' WHERE UserId=" + account.UserId;

            // execute insert command
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();
            return rowAffected;
        }

        public AdditionalInfo GetUserAdditionalInfo(int Id)
        {
            //string connectionString = @"Data Source=DESKTOP-AGFJ699\SQLSERVER;Initial Catalog=BitBook;Integrated Security=true";


            // write insert command 


            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM AdditionalInfo WHERE UserId=" + Id;

            SqlCommand command = new SqlCommand(query, connection);

            AdditionalInfo additional = null;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                additional=new AdditionalInfo();
                additional.UserId = Convert.ToInt32(reader["UserId"].ToString());
                additional.Gender = reader["Gender"].ToString();
                additional.CoverPhoto = reader["CoverPhoto"].ToString();
                additional.ProfilePhoto = reader["ProfilePhoto"].ToString();
                additional.Education = reader["Education"].ToString();
                additional.Location = reader["Location"].ToString();

            }
            connection.Close();

            return additional;

        }



        public int UpdateCoverPhoto(AdditionalInfo additionalInfo)
        {
            //string connectionString = @"Data Source=DESKTOP-AGFJ699\SQLSERVER;Initial Catalog=BitBook;Integrated Security=true";

            SqlConnection connection = new SqlConnection(connectionString);
            // write insert command 

            string query = "UPDATE AdditionalInfo SET CoverPhoto='" + additionalInfo.CoverPhoto + "' WHERE UserId=" + additionalInfo.UserId;

            // execute insert command
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();
            return rowAffected;
        }



        public int UpdateProfilePhoto(AdditionalInfo additionalInfo)
        {
            //string connectionString = @"Data Source=DESKTOP-AGFJ699\SQLSERVER;Initial Catalog=BitBook;Integrated Security=true";

            SqlConnection connection = new SqlConnection(connectionString);
            // write insert command 

            string query = "UPDATE AdditionalInfo SET ProfilePhoto='" + additionalInfo.ProfilePhoto + "' WHERE UserId=" + additionalInfo.UserId;

            // execute insert command
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();
            return rowAffected;
        }


        public AdditionalInfo GetAdditionalInfoByUserId(int id)
        {
            //string connectionString = @"Data Source=DESKTOP-AGFJ699\SQLSERVER;Initial Catalog=BitBook;Integrated Security=true";

            SqlConnection connection = new SqlConnection(connectionString);


            string query = "SELECT * FROM AdditionalInfo WHERE UserId=" + id;

            SqlCommand command = new SqlCommand(query, connection);

            AdditionalInfo aInfo = null;

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
              aInfo=new AdditionalInfo();

              aInfo.UserId = Convert.ToInt32(reader["UserId"].ToString());

              aInfo.ProfilePhoto = reader["ProfilePhoto"].ToString();
              aInfo.CoverPhoto = reader["CoverPhoto"].ToString();
              aInfo.Gender = reader["Gender"].ToString();
              aInfo.Education = reader["Education"].ToString();
              aInfo.Location = reader["Location"].ToString();




            }
            connection.Close();

            return aInfo;
        }

        public int UpdateAdditionalInfo(AdditionalInfo additionalInfo)
        {
            //string connectionString = @"Data Source=DESKTOP-AGFJ699\SQLSERVER;Initial Catalog=BitBook;Integrated Security=true";

            SqlConnection connection = new SqlConnection(connectionString);
            // write insert command 

            string query = "UPDATE AdditionalInfo SET Gender='" + additionalInfo.Gender + "',Education='" + additionalInfo.Education + "',Location='" + additionalInfo.Location + "' WHERE UserId=" + additionalInfo.UserId;

            // execute insert command
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();
            return rowAffected;
 
            
        }
    }



}