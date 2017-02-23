using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using NationBuilder.Models;

namespace NationBuilder.Controllers
{

    [Authorize]
    public class AdminController : Controller
    {
        private INationRepository nationRepo;

        public AdminController(INationRepository repo = null)
        {

            if (repo == null)
            {
                nationRepo = new EFNationRepository();
            }
            else
            {
                nationRepo = repo;
            }
        }
        public IActionResult Index()
        {
            ViewBag.Governments = nationRepo.Governments;
            ViewBag.Structures = nationRepo.Structures;
            ViewBag.Events = nationRepo.Events;
            return View();
        }

        //Government Routes
        public IActionResult AddGovernment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGovernment(Government newGovernment)
        {
            nationRepo.Save(newGovernment);
            return RedirectToAction("Index");
        }

        public IActionResult EditGovernment()
        {
            return View();
        }

        public IActionResult EditGovernment(Government updatedGovernment)
        {
            nationRepo.Edit(updatedGovernment);
            return RedirectToAction("Index");
        }

        //Event Routes
        public IActionResult AddEvent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEvent(Event newEvent)
        {
            nationRepo.Save(newEvent);
            return RedirectToAction("Index");
        }

        public IActionResult EditEvent()
        {
            return View();
        }

        public IActionResult EditEvent(Event updatedEvent)
        {
            nationRepo.Edit(updatedEvent);
            return RedirectToAction("Index");
        }

        //Structure Routes
        public IActionResult AddStructure()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStructure(Structure newStructure)
        {
            nationRepo.Save(newStructure);
            return RedirectToAction("Index");
        }

        public IActionResult EditStructure()
        {
            return View();
        }

        public IActionResult EditStructure(Structure updatedStructure)
        {
            nationRepo.Edit(updatedStructure);
            return RedirectToAction("Index");
        }
    }
}
