using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CML;
using DAL.DBClass;
using WebFile.Areas.Admin.Models.ViewModel;

namespace WebFile.Areas.Admin.Controllers
{
  
    public class ProductController : Controller
    {
        private Cpmdb db = new Cpmdb();
        private  CategoryDb cdb = new CategoryDb();
        // GET: Admin/Product
        public ActionResult Index()
        {
           var model = db.GetAll();
            return View(model);
        }
        public ActionResult Details(long? Id)
        {
            var model = db.Get(Id);
            return View(model);
        }
        public ActionResult Delete(long? Id)
        {
            if (Id > 0)
            {
                db.Remove(Id);
                RedirectToAction("Index");
            }
            
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
           ViewBag.CategoryId = new SelectList(cdb.GetAll(), "CategoryID", "CatName");
            

            return View();
        }
        [HttpPost]
        public ActionResult Create(CategoryProductMediaRModel cpmvm, HttpPostedFileBase file)
        {
           
            cpmvm.FilePathOrLink = PathGen.PathGena(file);
            if (cpmvm.IsThumbnail == true)
            {
                string fileName = Path.GetFileName(file.FileName);
                ThumGen.Crop(320, 240, file.InputStream, Path.Combine(Server.MapPath("/img/thumb/") + fileName));
            }
            db.Add(cpmvm);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(long? Id)
        {
            var model = db.Get(Id);
            
            ViewBag.CategoryId = new SelectList(cdb.GetAll(), "CategoryID", "CatName");
            return View(model);
           


           
        }
        [HttpPost]
        public ActionResult Edit(CategoryProductMediaRModel cpmvm, HttpPostedFileBase file)
        {
            if (cpmvm.IsThumbnail == true)
            {
                string fileName = Path.GetFileName(file.FileName);
                ThumGen.Crop(320, 240, file.InputStream, Path.Combine(Server.MapPath("/img/thumb/") + fileName));
            }
            cpmvm.FilePathOrLink = PathGen.PathGena(file);
            db.Update(cpmvm);
            return RedirectToAction("Index");
        }
    }
}