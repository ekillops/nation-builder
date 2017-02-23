using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using NationBuilder.Models;
using Microsoft.AspNetCore.Identity;

namespace NationBuilder.Controllers
{
    [Authorize]
    public class NationController : Controller
    {
        private INationRepository nationRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        public NationController(UserManager<ApplicationUser> userManager, INationRepository repo = null)
        {
            _userManager = userManager;
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
            return RedirectToAction("Index", "Account");
        }

        public IActionResult Create()
        {
            ViewBag.Governments = nationRepo.Governments.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Nation newNation, int governmentId)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ApplicationUser user = nationRepo.Users.FirstOrDefault(u => u.Id == userId);

            newNation.AppUser = user;
            newNation.Government = nationRepo.Governments.FirstOrDefault(g => g.Id == governmentId);

            newNation = nationRepo.Save(newNation);
            return RedirectToAction("Details", "Nation", new { id = newNation.Id });
        }

        public IActionResult Details(int id)
        {
            Nation nation = nationRepo.NationsIncludeRelated.FirstOrDefault(n => n.Id == id);
            return View(nation);
        }
    }
}
