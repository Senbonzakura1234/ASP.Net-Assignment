using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP.NET_Project.Models;
using LinqKit;

namespace ASP.NET_Project.Controllers
{
    public class OrdersController : Controller
    {
        private readonly MyDbContext _db = new MyDbContext();

        // GET: Orders
        public ActionResult Index()
        {
            var predicate = PredicateBuilder.New<Order>(true);
            predicate = predicate.And(f => f.OrderStatus != Order.OrderStatusEnum.Deleted);
            var data = _db.Orders.AsExpandable().Where(predicate);
            return View(data);
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var order = _db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            var orderItemList = _db.OrderItems.Where(f => f.OrderId == id).ToList();
            ViewBag.orderItemList = orderItemList;
            return View(order);
        }

        // GET: Orders/Create
        //public ActionResult Create()
        //{
        //    ViewBag.CustomerId = new SelectList(_db.Customers, "Id", "Fullname");
        //    return View();
        //}

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,CustomerId,PaymentTypeId,TotalPrice,ShipName,ShipAddress,ShipPhone,CreatedAt,UpdatedAt,DeletedAt,OrderStatus")] Order order)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _db.Orders.Add(order);
        //        _db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.CustomerId = new SelectList(_db.Customers, "Id", "Fullname", order.CustomerId);
        //    return View(order);
        //}

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var order = _db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(_db.Customers, "Id", "Fullname", order.CustomerId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerId,PaymentTypeId,TotalPrice,ShipName,ShipAddress,ShipPhone,CreatedAt,UpdatedAt,DeletedAt,OrderStatus")] Order order)
        {
            if (!ModelState.IsValid) return View(order);
            if (order.OrderStatus == Order.OrderStatusEnum.Deleted)
            {
                order.DeletedAt = DateTime.Now.Ticks;
            }
            else
            {
                order.UpdatedAt = DateTime.Now.Ticks;
            }

            _db.Entry(order).State = EntityState.Modified;
            _db.SaveChanges();
            ViewBag.CustomerId = new SelectList(_db.Customers, "Id", "Fullname", order.CustomerId);
            return RedirectToAction("Index");
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var order = _db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var order = _db.Orders.Find(id);
            if (order == null) return RedirectToAction("Index");
            order.OrderStatus = Order.OrderStatusEnum.Deleted;
            order.DeletedAt = DateTime.Now.Ticks;
            //_db.Orders.Remove(order);
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
