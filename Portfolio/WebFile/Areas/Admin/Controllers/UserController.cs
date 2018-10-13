using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using WebFile.Models;
using CML;

namespace WebFile.Areas.Admin.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        #region Manager
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;

        public UserController()
        {
        }

        public UserController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
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
      
        // GET: Admin/User
        public ActionResult Index()
        {
            var user = UserManager.Users.ToList();
           
            return View(user);

        }
        public async Task<ActionResult> Details(string Id)
        {
            var model = await UserManager.FindByIdAsync(Id);
            return View(model);
        }
        [HttpGet]
        public  ActionResult Create()
        {
            ViewBag.RoleList = new MultiSelectList(RoleManager.Roles.ToList(), "Id", "Name");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ApplicationUser newUser, string[] Id)
        {
           
            var model = await UserManager.CreateAsync(newUser);
            var userID = UserManager.FindByEmailAsync(newUser.Email);
            if (Id != null)
            {
                string id = Convert.ToString(userID.Id);
                await UserManager.AddToRolesAsync(id, Id);
            }
            return RedirectToAction("Index", "User");
        }
        [HttpGet]
        public async Task<ActionResult> Edit(string Id)
        {
            ViewBag.RoleList = new MultiSelectList(RoleManager.Roles.ToList(), "Id", "Name");
            var model = await UserManager.FindByIdAsync(Id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ApplicationUser updateUser, string ID)
        {

           var role = await RoleManager.FindByIdAsync(ID);
            var RoleId = role.Id;

            var model = await UserManager.FindByIdAsync(updateUser.Id);
            model.UserName = updateUser.UserName;
            model.PhoneNumber = updateUser.PhoneNumber;
            model.Email = updateUser.Email;
            model.PasswordHash = updateUser.PasswordHash;

            if (updateUser != null && RoleId.Length != null)
            {
              var Update = await UserManager.UpdateAsync(model);
                var UserRole = await UserManager.AddToRoleAsync(updateUser.Id, RoleId);
              return RedirectToAction("Index", "User");
            }

            return View();
        }
        
        public async Task<ActionResult> Delete(string Id)
        {
            if (Id != null)
            {
                var user = await UserManager.FindByIdAsync(Id);
                var delete = await UserManager.DeleteAsync(user);
                return RedirectToAction("Index", "User");
            }
            return View();
        }
    }
}