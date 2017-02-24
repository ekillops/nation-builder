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
            List<Structure> builtStructures = new List<Structure> { };
            foreach (NationStructure ns in nation.NationsStructures)
            {
                builtStructures.Append(ns.Structure);
            }
            ViewBag.BuiltStructures = builtStructures;
            ViewBag.AllStructures = nationRepo.Structures.ToList();
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

            List<Structure> builtStructures = new List<Structure> { };

            foreach (NationStructure ns in nation.NationsStructures)
            {
                turnModifiers["Economy"] += ns.Structure.EconomyModifier;
                turnModifiers["Resources"] += ns.Structure.ResourcesModifier;
                turnModifiers["Population"] += ns.Structure.PopulationModifier;
                turnModifiers["Approval"] += ns.Structure.ApprovalModifier;
                builtStructures.Append(ns.Structure);
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
            result["BuiltStructures"] = builtStructures;
            
            return Json(result);
        }

        public IActionResult StructurePurchase(int id)
        {
            //Nation nation = nationRepo.NationsIncludeRelated.FirstOrDefault(n => n.Id == id);

            //List<Structure> builtStructures = new List<Structure> { };
            //List<int> unbuiltStructureIds = nationRepo.Structures.Select(s => s.Id).ToList();

            //foreach (NationStructure ns in nation.NationsStructures)
            //{
            //    builtStructures.Append(ns.Structure);
            //    unbuiltStructureIds.Remove(ns.Structure.Id);
            //}

            //foreach (int structureId in allStructures)
            //{
            //    if (!(nation.NationsStructures.Contains(structureId)))
            //    {
            //        unbuiltStructures.Append(structure);
            //    }
            //}
            ViewBag.NationId = id;
            List<Structure> allStructures = nationRepo.Structures.ToList();
            return View(allStructures);
        }

        [HttpPost]
        public IActionResult StructurePurchase(int id, int NationId)
        {
            Nation nation = nationRepo.Nations.FirstOrDefault(n => n.Id == NationId);
            Structure structure = nationRepo.Structures.FirstOrDefault(s => s.Id == id);
            NationStructure newPurchase = new NationStructure() { Nation = nation, Structure = structure };
            newPurchase = nationRepo.Save(newPurchase);
            nation.Economy += newPurchase.Structure.EconomyCost;
            nation.Resources += newPurchase.Structure.ResourcesCost;
            nation.Population += newPurchase.Structure.PopulationCost;
            nation.ApprovalRating += newPurchase.Structure.ApprovalCost;
            nationRepo.Edit(nation);

            List<Structure> builtStructures = new List<Structure> { };
            List<Structure> unbuiltStructures = new List<Structure> { };

            List<Structure> allStructures = nationRepo.Structures.ToList();
            foreach (NationStructure ns in nation.NationsStructures)
            {
                builtStructures.Append(ns.Structure);
            }
            foreach (Structure structureInstance in allStructures)
            {
                if (!builtStructures.Contains(structureInstance))
                {
                    unbuiltStructures.Append(structureInstance);
                }
            }

            return View(unbuiltStructures);
        }
    }
}
