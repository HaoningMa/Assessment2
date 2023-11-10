using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assessment2.Data;
using Assessment2.Models;
using Assessment2.ViewModels;
using PagedList;

namespace Assessment2.Controllers
{
    public class CustomController : Controller
    {
        private Assessment2Context db = new Assessment2Context();

        // GET: Custom
        public ActionResult Index(string area, string search, string sortBy, int? page)
        {        
            ProductindexViewModel viewModel = new ProductindexViewModel();
            var customs = db.Customs.Include(p => p.Place);
            if (!String.IsNullOrEmpty(search))
            {
                customs = customs.Where(p => p.Name.Contains(search) ||
                p.Address.Contains(search) ||
                p.Place.Name.Contains(search));
                viewModel.Search = search;
            }
            viewModel.CatsWithCount = from matchingProducts in customs
                                      where matchingProducts.PlaceID != null
                                      group matchingProducts by
                                     matchingProducts.Place.Name into
                                      catGroup
                                      select new CategoryWithCount()
                                      {
                                          CategoryName = catGroup.Key,
                                          ProductCount = catGroup.Count()
                                      };
            if (!String.IsNullOrEmpty(area))
            {
                customs = customs.Where(p => p.Place.Name == area);
                viewModel.Category = area;
            }
            switch (sortBy)
            {
                case "Address_nearest":
                    customs = customs.OrderBy(p => p.Address);
                    break;
                case "Address_furthest":
                    customs = customs.OrderByDescending(p => p.Address);
                    break;
                default:
                    customs = customs.OrderBy(p => p.Name);
                    break;
            }
            viewModel.SortBy = sortBy;
            viewModel.Sorts = new Dictionary<string, string>
             {
                 {"Distance near to far", "Address_nearest" },
                 {"Distance far to near", "Address_furthest" }
             };
            const int PageItems = 3;
            int currentPage = (page ?? 1);
            viewModel.Products = customs.ToPagedList(currentPage, PageItems);
            return View(viewModel);
        }

        // GET: Custom/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Custom custom = db.Customs.Find(id);
            if (custom == null)
            {
                return HttpNotFound();
            }
            return View(custom);
        }

        // GET: Custom/Create
        public ActionResult Create()
        {
            ViewBag.PlaceID = new SelectList(db.Areas, "ID", "Name");
            return View();
        }

        // POST: Custom/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Address,PlaceID")] Custom custom)
        {
            if (ModelState.IsValid)
            {
                db.Customs.Add(custom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlaceID = new SelectList(db.Areas, "ID", "Name", custom.PlaceID);
            return View(custom);
        }

        // GET: Custom/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Custom custom = db.Customs.Find(id);
            if (custom == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlaceID = new SelectList(db.Areas, "ID", "Name", custom.PlaceID);
            return View(custom);
        }

        // POST: Custom/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Address,PlaceID")] Custom custom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(custom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlaceID = new SelectList(db.Areas, "ID", "Name", custom.PlaceID);
            return View(custom);
        }

        // GET: Custom/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Custom custom = db.Customs.Find(id);
            if (custom == null)
            {
                return HttpNotFound();
            }
            return View(custom);
        }

        // POST: Custom/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Custom custom = db.Customs.Find(id);
            db.Customs.Remove(custom);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
