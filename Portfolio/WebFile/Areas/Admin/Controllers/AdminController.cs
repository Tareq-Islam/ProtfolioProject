using CML;
using DAL.DBClass;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebFile.Areas.Admin.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        CategoryDb cDb = new CategoryDb();
        Cpmdb pDb = new Cpmdb();
        #region Counter
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;

        public AdminController()
        {
        }

        public AdminController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }
        #endregion

        // GET: Admin/Admin
        public ActionResult Index()
        {

            ViewBag.Roles = RoleManager.Roles.Count();
            ViewBag.Users = UserManager.Users.Count();
            ViewBag.Project = pDb.GetAll().Count();
            ViewBag.Categories = cDb.GetAll().Count();



            return View();
        }
    }
}