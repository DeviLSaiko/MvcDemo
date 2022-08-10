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

namespace DemoMvc.Controllers
{
    public class OrdersController : Controller
    {
        private GarmentsProDb db = new GarmentsProDb();

        public object ModalState { get; private set; }

        public ActionResult OrdersList()
        {
            List<Orders> orders = db.Orders.ToList();
            return View(orders);
        }
        public ActionResult CreateOrder()
        {
            return View();
        }

        [HttpPost, ActionName("CreateOrder")]

        public ActionResult CreateOrderr(Orders CreateOrder)
        {
            if(ModelState.IsValid)
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

        [HttpPost , ActionName("UpdateOrder")]
        public ActionResult UpdateOrderR(int id)
        {
            OrdersDbLogics Logics = new OrdersDbLogics();

            Orders rders = Logics.ordersList.Single(x => x.OID == id);

            UpdateModel(rders);

            if (ModelState.IsValid)
            {
                Logics.UpdateOrder (rders);

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
