using CML;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebFile.Areas.Admin.Models;

namespace WebFile.Areas.Admin.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        #region Manager
        private ApplicationRoleManager _roleManager;
        public RoleController()
        {
        }

        public RoleController( ApplicationRoleManager roleManager)
        {
            
            RoleManager = roleManager;
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
        // GET: Admin/Role
        
        public ActionResult Index()
        {
            var role = RoleManager.Roles.ToList();
          
           
            
            return View(role);
        }
        public async Task<ActionResult> Details(string Id)
        {
            var model = await RoleManager.FindByIdAsync(Id);
            return View(model);
        }
        [HttpGet]
        public async Task<ActionResult> Create() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IdentityRole newRole)
        {
         
            
            var model = await RoleManager.CreateAsync(newRole);

            return RedirectToAction("Index", "Role");
        }
        [HttpGet]
        public async Task<ActionResult> Edit(string Id)
        {
            var model = await RoleManager.FindByIdAsync(Id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(IdentityRole updateRole)
        {
            
            var model = await RoleManager.FindByIdAsync(updateRole.Id);
            model.Name = updateRole.Name;
            
            if (model != null)
            {
                var Update = await RoleManager.UpdateAsync(model);
                return RedirectToAction("Index", "Role");
            }

            return View();
        }
        [HttpGet]
        public async Task<ActionResult> Delete(string Id)
        {
            if (Id != null)
            {
                var role = await RoleManager.FindByIdAsync(Id);
                var delete = await RoleManager.DeleteAsync(role);
                return RedirectToAction("Index", "Role");
            }
            return View();
        }
    }
}