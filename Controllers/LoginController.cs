using Generic_Repository_pattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Generic_Repository_pattern.Controllers
{
    public class LoginController : Controller
    {
        private IAllRepository<Login> obj;
        public LoginController()
        {
            obj = new AllRepository<Login>();
        }

        public ActionResult Index()
        {
            return View(from m in obj.GetModel() select m);
        }

        public ActionResult display(int id)
        {
            var book = obj.GetByModel(id);
            return View(book);
        }

        public ActionResult insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult insert(Login login)
        {
            obj.insertModel(login);
            obj.save();
            return RedirectToAction("Index");
        }

        public ActionResult update(int id)
        {
            var book = obj.GetByModel(id);
            return View(book);
        }
        [HttpPost]
        public ActionResult update(Login login)
        {
            obj.updateModel(login);
            obj.save();
            return RedirectToAction("Index");
        }

        public ActionResult delete(int id)
        {
            obj.deleteModel(id);
            obj.save();
            return RedirectToAction("Index");
        }
    }
}