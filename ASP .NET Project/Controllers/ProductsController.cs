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
using ASP.NET_Project.ViewModels;
using LinqKit;
using PagedList;

namespace ASP.NET_Project.Controllers
{
    public class ProductsController : Controller
    {
        private readonly MyDbContext _db = new MyDbContext();

        // GET: Products
        [HandleError]
        public ActionResult Index(int? advanceBrand, int? advanceCategory, string advanceName, double? advancePriceFrom, double? advancePriceTo, int? page)
        {
            var predicate = PredicateBuilder.New<Product>(true);
            Debug.WriteLine(advanceBrand);
            

            if (!string.IsNullOrEmpty(advanceName))
            {
                page = 1;
                Debug.WriteLine("okay");
                predicate = predicate.And(f => f.Name.Contains(advanceName));
                ViewBag.advanceName = advanceName;
            }


            if (advancePriceFrom >= 0 && advancePriceTo >= 0)
            {
                page = 1;
                predicate = advancePriceTo > 0 ?
                    predicate.And(f => f.Price <= advancePriceTo && f.Price >= advancePriceFrom) :
                    predicate.And(f => f.Price >= advancePriceFrom);
            }

            if (advanceBrand != null && advanceBrand > 0)
            {
                page = 1;
                predicate = predicate.And(f => f.BrandId == advanceBrand);
            }
            if (advanceCategory != null && advanceCategory > 0)
            {
                page = 1;
                predicate = predicate.And(f => f.CategoryId == advanceCategory);
            }

            

            var data = _db.Products.AsExpandable().Where(predicate);
            var lsProducts = new List<ProductViewModel>();
            var productViewModel = new ProductViewModel();
            var brandsList = productViewModel.BrandsList;
            var categoriesList = productViewModel.CategoriesList;
            ViewBag.brandsList = brandsList;
            ViewBag.categoriesList = categoriesList;
            foreach (var product in data)
            {
                lsProducts.Add(new ProductViewModel(
                    product.Id,
                    product.Name,
                    product.Description,
                    product.Price,
                    product.InStoke,
                    product.CategoryId,
                    product.BrandId,
                    product.Picture
                    ));
            }
            const int pageSize = 4;
            var pageNumber = (page ?? 1);
            return View(lsProducts.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult AjaxProducts(int? advanceBrand,int? advanceCategory, string advanceName, double? advancePriceFrom, double? advancePriceTo, int? page)
        {
            var predicate = PredicateBuilder.New<Product>(true);
            Debug.WriteLine(advanceBrand);
            if (!string.IsNullOrEmpty(advanceName))
            {
                page = 1;
                Debug.WriteLine("okay");
                predicate = predicate.And(f => f.Name.Contains(advanceName));
                ViewBag.advanceName = advanceName;
            }


            if (advancePriceFrom >= 0 && advancePriceTo >= 0)
            {
                page = 1;
                predicate = advancePriceTo > 0 ?
                    predicate.And(f => f.Price <= advancePriceTo && f.Price >= advancePriceFrom) :
                    predicate.And(f => f.Price >= advancePriceFrom);
            }
            if (advanceBrand != null && advanceBrand > 0)
            {
                page = 1;
                predicate = predicate.And(f => f.BrandId == advanceBrand);
            }

            if (advanceCategory != null && advanceCategory > 0)
            {
                page = 1;
                predicate = predicate.And(f => f.CategoryId == advanceCategory);
            }
            var data = _db.Products.AsExpandable().Where(predicate);
            var lsProducts = new List<ProductViewModel>();
            foreach (var product in data)
            {
                lsProducts.Add(new ProductViewModel(
                    product.Id,
                    product.Name,
                    product.Description,
                    product.Price,
                    product.InStoke,
                    product.CategoryId,
                    product.BrandId,
                    product.Picture
                ));
            }
            const int pageSize = 4;
            var pageNumber = (page ?? 1);
            return PartialView("_AjaxProducts", lsProducts.ToPagedList(pageNumber, pageSize));
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
            var data = new ProductViewModel(
                product.Id,
                product.Name,
                product.Description,
                product.Price,
                product.InStoke,
                product.CategoryId,
                product.BrandId,
                product.Picture
            );
            return View(data);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            var data = new ProductEditViewModel();
            return View(data);
        }

        // POST: Products/Create
        // To protect from over-posting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Price,InStoke,CateId,BrandId,Picture")] ProductEditViewModel productEdit)
        {
            if (!ModelState.IsValid) return View(productEdit);
            var product = new Product
            {
                Name = productEdit.Name,
                CategoryId = productEdit.CateId,
                BrandId = productEdit.BrandId,
                Description = productEdit.Description,
                InStoke = productEdit.InStoke,
                Price = productEdit.Price,
                Picture = productEdit.Picture
            };
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
            var data = new ProductEditViewModel(
                product.Id,
                product.Name,
                product.Description,
                product.Price,
                product.InStoke,
                product.CategoryId,
                product.BrandId,
                product.Picture
            );
            return View(data);
        }

        // POST: Products/Edit/5
        // To protect from over-posting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price,InStoke,CateId,BrandId,Picture")] ProductEditViewModel productEdit)
        {
            if (!ModelState.IsValid) return View(productEdit);
            var product = new Product
            {
                Id = productEdit.Id,
                Name = productEdit.Name,
                CategoryId = productEdit.CateId,
                BrandId = productEdit.BrandId,
                Description = productEdit.Description,
                InStoke = productEdit.InStoke,
                Price = productEdit.Price,
                Picture = productEdit.Picture
            };
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
