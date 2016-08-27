using BitBook2.LayerFolder.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitBook2.Controllers
{
    public class HomeController : Controller
    {
        StatusManager statusManager = new StatusManager();
        // GET: Home
        public ActionResult Index()
        {
            var status = statusManager.GetAllStatus();

            return View(status);
        }
        public JsonResult IsUserExists(string UserName)
        {
            BitBookEntities db = new BitBookEntities();
            return Json(!db.UserAccounts.Any(x => x.UserName == UserName), JsonRequestBehavior.AllowGet);
        } 
    }
}