using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BitBook2.LayerFolder.DAL;
using BitBook2.Models;

namespace BitBook2.LayerFolder.BLL
{
    public class UserProfileManager
    {
        UserProfileGateway aGateway=new UserProfileGateway();

        public int Save(UserProfile auserProfile)
        {
            return aGateway.Save(auserProfile);
        }

        public List<UserProfile> GetUserStatusById(int userId)
        {
            return aGateway.GetUserStatusById(userId);
        }

        public int DeleteByStatusId(int statusId)
        {
            return aGateway.Delete(statusId);
        }

        public UserAccount GetUserById(int id)
        {
            return aGateway.GetUserById(id);
        }

        public int Update(UserAccount account)
        {
            return aGateway.Update(account);
        }

        public AdditionalInfo GetUserAdditionalInfo(int Id)
        {
            return aGateway.GetUserAdditionalInfo(Id);
        }

        public int UpdateCoverPhoto(AdditionalInfo additionalInfo)
        {
            return aGateway.UpdateCoverPhoto(additionalInfo);
        }

        public int UpdateProfilePhoto(AdditionalInfo additionalInfo)
        {
            return aGateway.UpdateProfilePhoto(additionalInfo);
        }

        public int AddAdditionalInfo(AdditionalInfo additionalInfo)
        {
            return aGateway.AddAdditionalInfo(additionalInfo);
        }

        public AdditionalInfo GetAdditionalInfoByUserId(int id)
        {
            return aGateway.GetAdditionalInfoByUserId(id);
        }

        public int UpdateEditionalInfo(AdditionalInfo additionalInfo)
        {
            return aGateway.UpdateAdditionalInfo(additionalInfo);
        }
    }

  

}