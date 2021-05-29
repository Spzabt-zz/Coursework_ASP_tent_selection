using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Coursework.Models;

namespace Coursework.Controllers
{
    public class HomeController : Controller
    {
        private readonly TentContext _tentContext = new TentContext();

        public ActionResult Index()
        {
            IEnumerable<Tent> tents = _tentContext.Tents;

            ViewBag.Tents = tents;

            return View();
        }

        [HttpGet]
        public ActionResult Select(int id)
        {
            ViewBag.Id = id;
            var param = _tentContext.Tents.Find(id);
            ViewBag.Name = param.Name;
            ViewBag.SelectedItem = param.Name;
            ViewBag.TentSelectionDiscount = param.Discount;

            return View();
        }

        [HttpPost]
        public string Select(TentSelection selection/*, Tent tent*/)
        {
            selection.DateTime = DateTime.Now;
            var param = _tentContext.Tents.Find(selection.TentId);
            selection.TentSelectionDiscount = param.CalculateDiscountByName(selection.Fio, param.Price);
            selection.TentSelectionDiscount = param.CalculateDiscountByCorrectEmail(selection.Email, param.Price);

            _tentContext.TentSelections.Add(selection);
            _tentContext.SaveChanges();
            return $"User {selection.Fio} successfully has chosen {selection.SelectedItem}";
        }

        public ActionResult ShowSelections()
        {
            IEnumerable<TentSelection> tentSelections = _tentContext.TentSelections;
            ViewBag.TentSelections = tentSelections;


            return View();
        }

        [HttpGet]
        public ActionResult DeleteTent(int id)
        {
            try
            {
                ViewBag.Id = id;
                var tentSelection = _tentContext.TentSelections.Find(id);
                ViewBag.DateTime = tentSelection?.DateTime;
                ViewBag.Email = tentSelection?.Email;
                ViewBag.Fio = tentSelection?.Fio;
                ViewBag.Address = tentSelection?.Address;
                ViewBag.SelectedItem = tentSelection?.SelectedItem;
                ViewBag.TentSelectionId = id;
            }
            catch (NullReferenceException ex)
            {
                return View("Error", new HandleErrorInfo(ex, "DeleteTent", "DeleteTent"));
            }
            return View();
        }

        [HttpPost]
        public ActionResult DeleteTent(TentSelection tentSelection)
        {
            try
            {
                _tentContext.TentSelections.Remove(_tentContext.TentSelections.Single(a => a.TentSelectionId == tentSelection.TentSelectionId));
                _tentContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "ShowSelections", "DeleteTent"));
            }
        }

        public ActionResult ShowTentCharacteristic(int id)
        {
            ViewBag.Id = id;
            var tent = _tentContext.Tents.Find(id);
            ViewBag.Name = tent.Name;
            ViewBag.Producer = tent.Producer;
            ViewBag.Price = tent.Price;
            ViewBag.Capacity = tent.Capacity;
            ViewBag.Weight = tent.Weight;
            ViewBag.WaterProof = tent.WaterProof;
            switch (tent)
            {
                case CampingTent camping:
                    ViewBag.MosquitoNet = camping.ShowInfo();
                    break;
                case ExpeditionaryTent expeditionary:
                    ViewBag.RoomCount = expeditionary.ShowInfo();
                    break;
                case MountainHikingTent mountain:
                    ViewBag.VentilationSystem = mountain.ShowInfo();
                    break;
            }

            return View();
        }
    }
}