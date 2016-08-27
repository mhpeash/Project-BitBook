using BitBook2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BitBook2.LayerFolder.DAL
{
    public class StatusGateway
    {
        string connectionString = @"Data Source=DESKTOP-1FDNDJJ\SQLEXPRESS;Initial Catalog=BitBook;Integrated Security=true";
        public List<AllStatus> GetAllStatus()
        {
            //string connectionString = @"Data Source=DESKTOP-AGFJ699\SQLSERVER;Initial Catalog=BitBook;Integrated Security=true";


            // write insert command 


            SqlConnection connection = new SqlConnection(connectionString);

            //string query = "select UserAccount.FirstNale,Profile.Status from UserAccount join Profile ON Profile.UserId=UserAccount.UserId";
            //string query = "select UserAccount.UserId,UserAccount.FirstNale,Profile.Status from UserAccount join Profile ON Profile.UserId=UserAccount.UserId";
            string query = "select DISTINCT UserAccount.UserId,UserAccount.FirstNale,Profile.Status from UserAccount join Profile ON Profile.UserId=UserAccount.UserId join Friend ON Profile.UserId=Friend.UserId where temp='" + 2 + "'";
            SqlCommand command = new SqlCommand(query, connection);

            List<AllStatus> statuslist = new List<AllStatus>();
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                AllStatus aStatus = new AllStatus();
                //aStatus.StatusId = Convert.ToInt32(reader["StatusId"].ToString());
                aStatus.UserName = reader["FirstNale"].ToString();
                aStatus.Status = reader["Status"].ToString();
                aStatus.UserId = Convert.ToInt32(reader["UserId"].ToString());
                statuslist.Add(aStatus);

            }
            connection.Close();

            return statuslist;
        }

    }
}