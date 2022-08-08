using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoMvc.Models;
namespace DemoMvc.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Users (int id)
        {
            Garments garment = new Garments();
           Users user = garment.users.Single(usr => usr.UID == id);

            return View(user);
        }

        public ActionResult Index( string DepName)
        {
            Garments garment = new Garments();
           List< Users> userc = garment.users.Where(use => use.Department == DepName).ToList();

            return View(userc);
        }
        public ActionResult Dep()
        {
            Garments garment = new Garments();
            List<Departments> departments = garment.departments.ToList();

            return View(departments);
        }

    }
}
