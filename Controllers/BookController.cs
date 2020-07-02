using Generic_Repository_pattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Generic_Repository_pattern.Controllers
{
    public class BookController : Controller
    {
        private IAllRepository<Book> obj;
        private IFamousBook famous;
        public BookController()
        {
            obj = new AllRepository<Book>();
            famous = new FamousBookRepository();
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
        public ActionResult insert(Book book)
        {
            obj.insertModel(book);
            obj.save();
            return RedirectToAction("Index");
        }

        public ActionResult update(int id)
        {
            var book = obj.GetByModel(id);
            return View(book);
        }
        [HttpPost]
        public ActionResult update(Book book)
        {
            obj.updateModel(book);
            obj.save();
            return RedirectToAction("Index");
        }

        public ActionResult delete(int id)
        {
            obj.deleteModel(id);
            obj.save();
            return RedirectToAction("Index");
        }

        public ActionResult getFamousBookList(string name)
        {
            var list = famous.GetBooksByAuthor(name);
            return View(list);
        }
    }
}