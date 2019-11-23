using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NET_Project.Models;
using ASP.NET_Project.ViewModels;
using LinqKit;

namespace ASP.NET_Project.Controllers
{
    public class HomePageController : Controller
    {
        private readonly MyDbContext _db = new MyDbContext();

        // GET: HomePage
        public ActionResult Index()
        {
            //var predicate = PredicateBuilder.New<Product>(true);


            //var data = _db.Products.AsExpandable().Where(predicate);
            //var lsProducts = new List<ProductViewModel>();
            //var productViewModel = new ProductViewModel();
            //var brandsList = productViewModel.BrandsList;
            //ViewBag.brandsList = brandsList;
            //foreach (var product in data)
            //{
            //    lsProducts.Add(new ProductViewModel(
            //        product.Id,
            //        product.Name,
            //        product.Description,
            //        product.Price,
            //        product.InStoke,
            //        product.CategoryId,
            //        product.BrandId,
            //        product.Picture
            //    ));
            //}

            return View();
        }

        //public ActionResult Search(string searchTerm, string advanceName, double? advancePriceFrom,
        //    double? advancePriceTo,
        //    int? advanceCheckValue)
        //{
        //    var predicate = PredicateBuilder.New<Product>(true);


        //    if (!string.IsNullOrEmpty(searchTerm))
        //    {
        //        Debug.WriteLine("okay");
        //        predicate = predicate.Or(f => f.Name.Contains(searchTerm));
        //        ViewBag.searchTerm = searchTerm;
        //    }

        //    if (advanceCheckValue == 0)
        //    {
        //        if (!string.IsNullOrEmpty(advanceName))
        //        {
        //            Debug.WriteLine("okay");
        //            predicate = predicate.Or(f => f.Name.Contains(advanceName));
        //            ViewBag.advanceName = advanceName;
        //        }

        //        if (advancePriceFrom >= 0 && advancePriceTo >= 0)
        //        {
        //            predicate = advancePriceTo > 0
        //                ? predicate.Or(f => f.Price <= advancePriceTo && f.Price >= advancePriceFrom)
        //                : predicate.Or(f => f.Price >= advancePriceFrom);
        //        }
        //    }
        //    else
        //    {
        //        if (!string.IsNullOrEmpty(advanceName))
        //        {
        //            Debug.WriteLine("okay");
        //            predicate = predicate.And(f => f.Name.Contains(advanceName));
        //            ViewBag.advanceName = advanceName;
        //        }

        //        if (advancePriceFrom >= 0 && advancePriceTo >= 0)
        //        {
        //            predicate = advancePriceTo > 0
        //                ? predicate.And(f => f.Price <= advancePriceTo && f.Price >= advancePriceFrom)
        //                : predicate.And(f => f.Price >= advancePriceFrom);
        //        }
        //    }

        //    var data = _db.Products.AsExpandable().Where(predicate);
        //    var lsProducts = new List<ProductViewModel>();
        //    var productViewModel = new ProductViewModel();
        //    var brandsList = productViewModel.BrandsList;
        //    ViewBag.brandsList = brandsList;
        //    foreach (var product in data)
        //    {
        //        lsProducts.Add(new ProductViewModel(
        //            product.Id,
        //            product.Name,
        //            product.Description,
        //            product.Price,
        //            product.InStoke,
        //            product.CategoryId,
        //            product.BrandId,
        //            product.Picture
        //        ));
        //    }
        //    return View(lsProducts);
        //}
    }
}