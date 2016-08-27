using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitBook2.LayerFolder.BLL;
using BitBook2.Models;
using System.Web.Security;

namespace BitBook2.Controllers
{

    public class UserAccountController : Controller
    {
        StatusManager statusManager = new StatusManager();
        BitBookEntities db = new BitBookEntities();
        UserProfileManager aManager=new UserProfileManager();
        FriendRequestManager friendRequestManager = new FriendRequestManager(); 
       //Search
        public ActionResult Index(string searchBy, string search)
        {
            if (searchBy == "Email")
            {
                return View(db.UserAccounts.Where(x => x.Email == search).ToList());
            }
            else
            {
                return View(db.UserAccounts.Where(x => x.FirstNale.Contains(search)).ToList());
            }
        }
        //Status
        public ActionResult Index2()
        {
            var status = statusManager.GetAllStatus();

            return View(status);
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            if (ModelState.IsValid)
            {
                using (BitBookEntities db = new BitBookEntities())
                {
                    db.UserAccounts.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
            }
            return View();
            //return RedirectToAction("Login");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using (BitBookEntities db = new BitBookEntities())
            {
                var loggedInUser = db.UserAccounts.FirstOrDefault(c=>c.UserName==user.UserName && c.Password==user.Password);
                //var usr = db.UserAccounts.Single(u => u.UserName == user.UserName && u.Password == user.Password);
                if (loggedInUser == null)
                {
                   
                    ViewBag.Message = "Invalid UserName or Password";

                }
                else
                {
                    //FormsAuthentication.SetAuthCookie(user.UserName, false);
                    Session["UserId"] = loggedInUser.UserId.ToString();
                    Session["Username"] = loggedInUser.UserName.ToString();
                    return RedirectToAction("LoggedIn");
                }
            }
            return View();
        }
        public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {

           
                List<UserProfile> Userstatus = aManager.GetUserStatusById( Convert.ToInt32(Session["UserId"]));
               AdditionalInfo info=  aManager.GetUserAdditionalInfo(Convert.ToInt32(Session["UserId"]));
                ViewBag.AdditionalInfo = info;
                return View(Userstatus);

                
            }
            else
            {
                return RedirectToAction("LogIn");
            }
        }
        [HttpPost]
        public ActionResult LoggedIn(UserProfile profile)
        {
            if (Session["UserId"] != null)
            {

               
                AdditionalInfo info = aManager.GetUserAdditionalInfo(Convert.ToInt32(Session["UserId"]));
                ViewBag.AdditionalInfo = info;

                profile.UserId = Convert.ToInt32(Session["UserId"]);
                aManager.Save(profile); 
                List<UserProfile> Userstatus = aManager.GetUserStatusById(profile.UserId);
                return View(Userstatus);

            }
            else
            {
                return RedirectToAction("LogIn");
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn");
          
        }

        public ActionResult SendRequest(int id)
        {
            //bool IsSend = false;
            BitBookEntities BitBookContext = new BitBookEntities();
            Friend friend=new Friend();
            friend.UserId=Convert.ToInt32(Session["UserId"]);
            friend.FriendId = id;
            friend.temp = 1;

           friendRequestManager.SendRequest(friend);
           return View();
        }
        public ActionResult ConfirmRequest(int id)
        {
            BitBookEntities BitBookContext = new BitBookEntities();
            Friend friend = new Friend();
            friend.UserId = Convert.ToInt32(Session["UserId"]);
            friend.FriendId = id;
            friend.temp = 2;
            friendRequestManager.ConfirmRequest(friend);
            return View();
        }
        public ActionResult CancelRequest(int id)
        {
            BitBookEntities BitBookContext = new BitBookEntities();
            Friend friend = new Friend();
            friend.UserId = Convert.ToInt32(Session["UserId"]);
            friend.FriendId = id;
            friend.temp = 0;
            friendRequestManager.CancelRequest(friend);
            return View();
        }
  
 
        public  ActionResult AllFriendRequest()
        {
            int UserId = Convert.ToInt32(Session["UserId"]);
            var friends = friendRequestManager.AllFriendRequest(UserId);
            return View(friends);
        }
        public ActionResult AllFriend()
        {
            int UserId = Convert.ToInt32(Session["UserId"]);
            var friends = friendRequestManager.AllFriend(UserId);
            return View(friends);
        }
        public ActionResult Details()
        {
            var id = Convert.ToInt32(Session["UserId"]);
            BitBookEntities BitBookContext = new BitBookEntities();
            UserAccount UserAccount = BitBookContext.UserAccounts.Single(x => x.UserId == id);

            return View(UserAccount);
        }
        public ActionResult Details2(int id)
        {
            BitBookEntities BitBookContext = new BitBookEntities();
            UserAccount UserAccount = BitBookContext.UserAccounts.Single(x => x.UserId == id);

            return View(UserAccount);
        }
      
        public ActionResult Delete()
        {
            
            aManager.DeleteByStatusId(Convert.ToInt32(Session["StatusId"]));
            return RedirectToAction("LoggedIn");
        }

        public ActionResult Edit()
        {
            int id = Convert.ToInt32(Session["UserId"]);
            var  info=aManager.GetUserById(id);
            return View(info);
        }

        [HttpPost]
        public ActionResult Edit( UserAccount account)
        {
            account.UserId = Convert.ToInt32(Session["UserId"]);
            aManager.Update(account);
            ViewBag.Message = "Update Saved";
            return RedirectToAction("LoggedIn");
            //return View();
        }


        public ActionResult EditAdditionalInfo()
        {
            int id = Convert.ToInt32(Session["UserId"]);
            AdditionalInfo  additionalInfo= aManager.GetAdditionalInfoByUserId(id);

            return View(additionalInfo);
        }

        [HttpPost]
        public ActionResult EditAdditionalInfo(AdditionalInfo additionalInfo)
        {
            additionalInfo.UserId = Convert.ToInt32(Session["UserId"]);
            aManager.UpdateEditionalInfo(additionalInfo);
            ViewBag.Message = "Update Saved";
          return  RedirectToAction("LoggedIn");
           // return View();
        }



        public ActionResult ChangeCoverPhoto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangeCoverPhoto(HttpPostedFileBase file)
        {
           
            try
            {
                /*Geting the file name*/
                string filename = System.IO.Path.GetFileName(file.FileName);

                /*Saving the file in server folder*/
                file.SaveAs(Server.MapPath("~/images/" + filename));

                string filepathtosave = "images/" + filename;
            
                AdditionalInfo aiInfo=new AdditionalInfo();
                aiInfo.UserId = Convert.ToInt32(Session["UserId"]);
                aiInfo.CoverPhoto = filepathtosave;


                aManager.UpdateCoverPhoto(aiInfo);

                ViewBag.Message = "File Uploaded successfully.";
                return RedirectToAction("LoggedIn");
            }
            catch
            {
                ViewBag.Message = "Error while uploading the files.";
            }
            return View();

        }

        public ActionResult ChangeProfilePhoto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangeProfilePhoto(HttpPostedFileBase file)
        {

            try
            {
    
                string filename = System.IO.Path.GetFileName(file.FileName);
                
                file.SaveAs(Server.MapPath("~/Images/" + filename));
                string filepathtosave = "Images/" + filename;
        
                AdditionalInfo aiInfo = new AdditionalInfo();
                aiInfo.UserId = Convert.ToInt32(Session["UserId"]);
                aiInfo.ProfilePhoto = filepathtosave;


                aManager.UpdateProfilePhoto(aiInfo);

                ViewBag.Message = "File Uploaded successfully.";
                return RedirectToAction("LoggedIn");
            }
            catch
            {
                ViewBag.Message = "Error while uploading the files.";
            }
            return View();

        }

        public ActionResult AdditionalInfocreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdditionalInfocreate(AdditionalInfo additionalInfo)
        {

            additionalInfo.UserId = Convert.ToInt32(Session["UserId"]);
            aManager.AddAdditionalInfo(additionalInfo);
            ViewBag.Message = "Additional Info Saved";
            return RedirectToAction("LoggedIn");
            //return View();
        }
        public ActionResult Send()
        {
            return View();
        }

    }
}