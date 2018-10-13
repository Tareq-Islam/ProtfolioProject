using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CML;
using DAL.DBClass;
using WebFile.Models;

namespace WebFile.Controllers
{
    public class HomeController : Controller
    {
        CategoryDb cDb = new CategoryDb();
        Cpmdb pDb = new Cpmdb();
        
        public ActionResult Index()
        {
            ViewBag.Products = pDb.GetAll();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactViewModel cvm)
        {
            string script = string.Empty;
            if (ModelState.IsValid)
            {
              string mess =  SendMail.sendMail(new mailModel { Name = cvm.Name, Email = cvm.Email, Message= cvm.Message, Subject = cvm.Subject});

                return Content("<html><head></head><body><script>"+mess+"</script></body></html>");
               
              
            }

            return Content(script);
        }

        public ActionResult Portfolio()
        {
            ViewBag.Message = "Portfolio.";
           
            ViewBag.Products = pDb.GetAll();

            ViewBag.Categories = cDb.GetAll();

            return View();
        }

        public ActionResult Service()
        {
            return View();
        }
    }
}