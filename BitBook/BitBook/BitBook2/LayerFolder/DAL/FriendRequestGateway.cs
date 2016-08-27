using BitBook2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BitBook2.LayerFolder.DAL
{
    public class FriendRequestGateway
    {
        string connectionString = @"Data Source=DESKTOP-1FDNDJJ\SQLEXPRESS;Initial Catalog=BitBook;Integrated Security=true";
        public int SendRequest(Friend friend)
        {
            //string connectionString = @"Data Source=DESKTOP-AGFJ699\SQLSERVER;Initial Catalog=BitBook;Integrated Security=true";

            SqlConnection connection = new SqlConnection(connectionString);
            // write insert command 

            //string query = "Insert into Friend values('"+friend.UserId+"','"+friend.FriendId+"','"+friend.temp+"')";

            string query = "INSERT INTO Friend VALUES('" + friend.UserId + "','" + friend.FriendId + "','" + friend.temp + "')";
            // execute insert command
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();
            return rowAffected;
        }
        public int ConfirmRequest(Friend friend)
        {

            //string connectionString = @"Data Source=DESKTOP-AGFJ699\SQLSERVER;Initial Catalog=BitBook;Integrated Security=true";

            SqlConnection connection = new SqlConnection(connectionString);
            // write insert command 

            //string query = "Insert into Friend values('"+friend.UserId+"','"+friend.FriendId+"','"+friend.temp+"')";

            string query = "UPDATE Friend SET temp='" + friend.temp + "'WHERE FriendId=" + friend.UserId + " AND UserId=" + friend.FriendId;
            // execute insert command
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();
            return rowAffected;
        }


          public int CancelRequest(Friend friend)
           {

            //string connectionString = @"Data Source=DESKTOP-AGFJ699\SQLSERVER;Initial Catalog=BitBook;Integrated Security=true";

            SqlConnection connection = new SqlConnection(connectionString);
            // write insert command 

            //string query = "Insert into Friend values('"+friend.UserId+"','"+friend.FriendId+"','"+friend.temp+"')";

            string query = "UPDATE Friend SET temp='" + friend.temp + "'WHERE FriendId=" + friend.UserId + " AND UserId=" + friend.FriendId;
            // execute insert command
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();
            return rowAffected;
        }
        public List<Friend> AllFriendRequest(int userId)
        {
            //string connectionString = @"Data Source=DESKTOP-AGFJ699\SQLSERVER;Initial Catalog=BitBook;Integrated Security=true";


            // write insert command 


            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select UserAccount.FirstNale,UserAccount.UserId,Friend.FriendId from UserAccount join Friend ON UserAccount.UserId=Friend.UserId where Friend.temp=1 and Friend.FriendId='" + userId + "'";
            SqlCommand command = new SqlCommand(query, connection);

            List<Friend> Friendlist = new List<Friend>();
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Friend aFriend = new Friend();
                aFriend.Friendname = reader["FirstNale"].ToString();
                aFriend.FriendId = Convert.ToInt32(reader["UserId"].ToString());
                aFriend.UserId = Convert.ToInt32(reader["FriendId"].ToString());
                Friendlist.Add(aFriend);

            }
            connection.Close();

            return Friendlist;
        }
        public List<Friend> AllFriend(int userId)
        {
            //string connectionString = @"Data Source=DESKTOP-AGFJ699\SQLSERVER;Initial Catalog=BitBook;Integrated Security=true";


            // write insert command 


            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select UserAccount.FirstNale,UserAccount.UserId,Friend.FriendId from UserAccount join Friend ON UserAccount.UserId=Friend.UserId where Friend.temp=2 and Friend.FriendId='" + userId + "'";
            SqlCommand command = new SqlCommand(query, connection);

            List<Friend> Friendlist = new List<Friend>();
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Friend aFriend = new Friend();
                aFriend.Friendname = reader["FirstNale"].ToString();
                aFriend.FriendId = Convert.ToInt32(reader["UserId"].ToString());
                aFriend.UserId = Convert.ToInt32(reader["FriendId"].ToString());
                Friendlist.Add(aFriend);

            }
            connection.Close();

            return Friendlist;
        }
    }
}