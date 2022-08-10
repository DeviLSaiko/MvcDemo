using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoMvc.Models;
using Database1;
using System.Data.Entity.Infrastructure;

namespace DemoMvc.Controllers
{
    public class HomeController : Controller
    {
        GarmentsProDb garment = new GarmentsProDb();
        public ActionResult Users (int id)
        {
            
           Users user = garment.users.Single(usr => usr.UID == id);

            return View(user);
        }

        public ActionResult Index( string DepName)
        {
           
           List< Users> userc = garment.users.Where(use => use.Department == DepName).ToList();

            return View(userc);
        }
        public ActionResult Dep()
        {
             
            List<Departments> departments = garment.departments.ToList();

            return View(departments);
        }
        public ActionResult Admin()
        {

            LogicDb Admin = new LogicDb();

           List<Db> Dbb = Admin.db.ToList();


            return View(Dbb);
        }
        [HttpGet]
        public ActionResult AdminAdd()
        {
            return View();
        }

        [HttpPost]
        [ActionName("AdminAdd")]
        public ActionResult AdminAddD(Db AdminDb)
        {
            if(ModelState.IsValid)
            {
                LogicDb DbBasee = new LogicDb();
                DbBasee.AdminInsert(AdminDb);

                return RedirectToAction("Admin");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            LogicDb EditAdmin = new LogicDb();
            Db AdminDb = EditAdmin.db.Single(Admin => Admin.ID == id);

            return View(AdminDb);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit1(int id)
        {
            LogicDb AdminLogics = new LogicDb();

            Db AdminDb = AdminLogics.db.Single(x => x.ID == id);

            UpdateModel(AdminDb);

            if(ModelState.IsValid)
            {
                AdminLogics.AdminUpdate(AdminDb);

                return RedirectToAction("Admin");
            }

            return View();
        }
        public ActionResult Delete(int id)
        {
            LogicDb AdminLogics = new LogicDb();
             AdminLogics.AdminDelete(id);

            return RedirectToAction("Admin");
        }


    }
}
