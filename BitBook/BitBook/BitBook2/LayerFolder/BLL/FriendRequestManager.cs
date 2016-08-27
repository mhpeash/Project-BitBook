using BitBook2.LayerFolder.DAL;
using BitBook2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitBook2.LayerFolder.BLL
{
    public class FriendRequestManager
    {
        FriendRequestGateway friendRequestGateway = new FriendRequestGateway();
        public int SendRequest(Friend friend)
        {
            return friendRequestGateway.SendRequest(friend);
        }
        public int ConfirmRequest(Friend friend)
        {
            return friendRequestGateway.ConfirmRequest(friend);
        }
        public int CancelRequest(Friend friend)
        {
            return friendRequestGateway.CancelRequest(friend);
        }
        public List<Friend> AllFriendRequest(int userId)
        {
            return friendRequestGateway.AllFriendRequest(userId);
        }
        public List<Friend> AllFriend(int userId)
        {
            return friendRequestGateway.AllFriend(userId);
        }
    }
}