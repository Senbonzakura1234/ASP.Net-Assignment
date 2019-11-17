using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP.NET_Project.Models;
using LinqKit;

namespace ASP.NET_Project.Controllers
{
    public class ProductsController : Controller
    {
        private readonly MyDbContext _db = new MyDbContext();

        // GET: Products
        public ActionResult Index(string searchTerm, string advanceName, double? advancePriceFrom, double? advancePriceTo,
                int? advanceCheckValue)
        {
            var predicate = PredicateBuilder.New<Product>(true);

            var products = from p in _db.Products select p;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                Debug.WriteLine("okay");
                predicate = predicate.Or(f => f.Name.Contains(searchTerm));
                ViewBag.searchTerm = searchTerm;
            }

            if (advanceCheckValue == 0)
            {
                if (!string.IsNullOrEmpty(advanceName))
                {
                    Debug.WriteLine("okay");
                    predicate = predicate.Or(f => f.Name.Contains(advanceName));
                    ViewBag.advanceName = advanceName;
                }

                if (advancePriceFrom >= 0 && advancePriceTo >= 0)
                {
                    predicate = advancePriceTo > 0 ? 
                        predicate.Or(f => f.Price <= advancePriceTo && f.Price >= advancePriceFrom) :
                        predicate.Or(f =>  f.Price >= advancePriceFrom);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(advanceName))
                {
                    Debug.WriteLine("okay");
                    predicate = predicate.And(f => f.Name.Contains(advanceName));
                    ViewBag.advanceName = advanceName;
                }

                if (advancePriceFrom >= 0 && advancePriceTo >= 0)
                {
                    predicate = advancePriceTo > 0 ?
                        predicate.And(f => f.Price <= advancePriceTo && f.Price >= advancePriceFrom) :
                        predicate.And(f => f.Price >= advancePriceFrom);
                }
            }
            
            var data = _db.Products.AsExpandable().Where(predicate);
            return View(data);
        }

        public ActionResult AjaxProducts(string advanceName, double? advancePriceFrom, double? advancePriceTo,
            int? advanceCheckValue)
        {
            var predicate = PredicateBuilder.New<Product>(true);

            if (advanceCheckValue == 0)
            {
                if (!string.IsNullOrEmpty(advanceName))
                {
                    Debug.WriteLine("okay");
                    predicate = predicate.Or(f => f.Name.Contains(advanceName));
                    ViewBag.advanceName = advanceName;
                }

                if (advancePriceFrom >= 0 && advancePriceTo >= 0)
                {
                    predicate = advancePriceTo > 0 ?
                        predicate.Or(f => f.Price <= advancePriceTo && f.Price >= advancePriceFrom) :
                        predicate.Or(f => f.Price >= advancePriceFrom);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(advanceName))
                {
                    Debug.WriteLine("okay");
                    predicate = predicate.And(f => f.Name.Contains(advanceName));
                    ViewBag.advanceName = advanceName;
                }

                if (advancePriceFrom >= 0 && advancePriceTo >= 0)
                {
                    predicate = advancePriceTo > 0 ?
                        predicate.And(f => f.Price <= advancePriceTo && f.Price >= advancePriceFrom) :
                        predicate.And(f => f.Price >= advancePriceFrom);
                }
            }

            var data = _db.Products.AsExpandable().Where(predicate);
            return PartialView("_AjaxProducts", data);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = _db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from over-posting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Price,InStoke")] Product product)
        {
            if (!ModelState.IsValid) return View(product);
            _db.Products.Add(product);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = _db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from over-posting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price,InStoke")] Product product)
        {
            if (!ModelState.IsValid) return View(product);
            _db.Entry(product).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = _db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = _db.Products.Find(id);
            if (product != null) _db.Products.Remove(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
