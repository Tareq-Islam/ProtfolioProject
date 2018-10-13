using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CML;
using DAL.DBClass;
using DAL.DBModel;

namespace WebFile.Areas.Admin.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
       private CategoryDb db = new CategoryDb();

        // GET: Admin/Categories
        public ActionResult Index()
        {
            //var model = await db.Category.ToListAsync();
            var model = db.GetAll();
            return View(model);
        }

        // GET: Admin/Categories/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryModel category = db.Get(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Admin/Categories/Create
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                db.Add(category);
               
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Admin/Categories/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryModel category = db.Get(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryModel category)
        {
            if (ModelState.IsValid)
            {
               db.Update(category);
               
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Admin/Categories/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryModel category = db.Get(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
           
            db.Remove(id);
            
            return RedirectToAction("Index");
        }

       
    }
}
