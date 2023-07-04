using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace umbraco.Controllers
{
    public class HomeController : Controller
    {
        testdbEntities _context = new testdbEntities();
        public ActionResult Index()
        {
            var listofData = _context.Cards.ToList();
            return View(listofData);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create( Card model)
        {
            if (model.name == null)
            {
                ViewBag.Message = "Card name must not be empty";
                return View();

            }

            if (model.content == null)
            {
                ViewBag.Message = "Card content must not be empty";
                return View();

            }
            var data = _context.Cards.Where(x => x.name == model.name).FirstOrDefault();
            if (data != null)
            {
                ViewBag.Message = "Card " + model.name + " already existed";
                return View();
            }
            else
            {
                _context.Cards.Add(model);
                _context.SaveChanges();
                ViewBag.Message = "Create card successfully";
                return RedirectToAction("index");
            }

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.Cards.Where(x => x.id == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Card model)
        {
            if (model.name == null)
            {
                ViewBag.Message = "Card name must not be empty";
                return View();

            }

            if (model.content == null)
            {
                ViewBag.Message = "Card content must not be empty";
                return View();

            }

            var data = _context.Cards.Where(x => x.id == model.id).FirstOrDefault();
            if (data != null)
            {
                var card_name = _context.Cards.Where(x => x.name == model.name).FirstOrDefault();
                if (card_name != null && card_name.id != model.id)
                {
                    ViewBag.Message = "Card " + model.name + " already existed";
                    return View();
                }else
                {
                    data.name = model.name;
                    data.content = model.content;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("index");
        }

        public ActionResult Detail(int id)
        {
            var data = _context.Cards.Where(x => x.id == id).FirstOrDefault();
            return View(data);
        }

        public ActionResult Delete(int id)
        {
            var data = _context.Cards.Where(x => x.id == id).FirstOrDefault();
            _context.Cards.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "Card deleted successfully";
            return RedirectToAction("index");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }


}