using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using NationBuilder.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

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

        [HttpPost]
        public IActionResult NextTurn(int id)
        {
            Nation nation = nationRepo.NationsIncludeRelated.FirstOrDefault(n => n.Id == id);
            List<Event> allEvents = nationRepo.Events.ToList();
            Event thisEvent = allEvents[new Random().Next(allEvents.Count)];

            Dictionary<string, int> turnModifiers = new Dictionary<string, int>();
            turnModifiers["Economy"] = nation.Government.EconomyModifier;
            turnModifiers["Resources"] = nation.Government.ResourcesModifier;
            turnModifiers["Population"] = nation.Government.PopulationModifier;
            turnModifiers["Approval"] = nation.Government.ApprovalModifier;

            List<Structure> allStructures = new List<Structure> { };

            foreach (NationStructure ns in nation.NationsStructures)
            {
                turnModifiers["Economy"] += ns.Structure.EconomyModifier;
                turnModifiers["Resources"] += ns.Structure.ResourcesModifier;
                turnModifiers["Population"] += ns.Structure.PopulationModifier;
                turnModifiers["Approval"] += ns.Structure.ApprovalModifier;
                allStructures.Append(ns.Structure);
            }

            nation.Turn++;
            nation.Economy += thisEvent.EconomyModifier + turnModifiers["Economy"];
            nation.Resources += thisEvent.ResourcesModifier + turnModifiers["Resources"];
            nation.Population += thisEvent.PopulationModifier + turnModifiers["Population"];
            nation.ApprovalRating += thisEvent.ApprovalModifier + turnModifiers["Approval"];
            nationRepo.Edit(nation);

            Dictionary<string, object> result = new Dictionary<string, object>();
            result["Event"] = thisEvent;
            result["Nation"] = nation;
            result["TurnModifiers"] = turnModifiers;
            result["Structures"] = allStructures;

            return Json(result);
        }
    }
}
