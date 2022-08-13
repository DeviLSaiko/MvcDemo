using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DemoMvc.Models;
using OrdersProject;
using System.Reflection;
using PagedList;

namespace DemoMvc.Controllers
{
    public class OrdersController : Controller
    {
        private GarmentsProDb db = new GarmentsProDb();

        public object ModalState { get; private set; }

        public ActionResult OrdersList(string SearchBy, string Search, int? page)
        {

            if (SearchBy == "ClientName")
            {
                return View(db.Orders.Where(x => x.ClientName.Contains(Search) || Search == null).ToList().ToPagedList(page ?? 1, 7));
            }
            else
            {
                return View(db.Orders.Where(x => x.Status.ToString() == Search || Search == null).ToList().ToPagedList(page ?? 1, 7));
            }
        }
        public ActionResult CreateOrder()
        {
            return View();
        }

        [HttpPost, ActionName("CreateOrder")]

        public ActionResult CreateOrderr(Orders CreateOrder)
        {
            if (ModelState.IsValid)
            {
                OrdersDbLogics OrdersLogic = new OrdersDbLogics();
                OrdersLogic.CreateOrder(CreateOrder);
            }

            return RedirectToAction("OrdersList");

        }

        [HttpGet]
        public ActionResult UpdateOrder(int id)
        {
            OrdersDbLogics OrderLogic = new OrdersDbLogics();
            Orders orders = OrderLogic.ordersList.Single(x => x.OID == id);

            return View(orders);
        }

        [HttpPost, ActionName("UpdateOrder")]
        public ActionResult UpdateOrderR(int id)
        {
            OrdersDbLogics Logics = new OrdersDbLogics();

            Orders rders = Logics.ordersList.Single(x => x.OID == id);

            UpdateModel(rders);

            if (ModelState.IsValid)
            {
                Logics.UpdateOrder(rders);

                return RedirectToAction("OrdersList");
            }

            return View();

        }
        public ActionResult Delete(int id)
        {
            OrdersDbLogics AdminLogics = new OrdersDbLogics();
            AdminLogics.DeleteOrder(id);

            return RedirectToAction("OrdersList");
        }
    }
}
