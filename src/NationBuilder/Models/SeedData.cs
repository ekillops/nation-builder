using NationBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NationBuilder.Migrations
{
    public class SeedData
    {
        public static List<Government> SeedGovernments = new List<Government>()
        {
            new Government()
            {
                Name = "Dictatorship",
                Description = "Old reliable governmental body.",
                EconomyModifier = 1,
                ResourcesModifier = 1,
                PopulationModifier = -1,
                ApprovalModifier = -1
            },
            new Government()
            {
                Name = "Theocracy",
                Description = "Faith-based governance.",
                EconomyModifier = -1,
                ResourcesModifier = -1,
                PopulationModifier = 1,
                ApprovalModifier = 1
            }
        };

        public static List<Structure> SeedStructures = new List<Structure>()
        {
            new Structure()
            {
                Name = "Propaganda Center",
                Description = "Make your people think they're happy.\nCost:\nEconomy: 3, Resources: 3",
                EconomyModifier = 0,
                ResourcesModifier = 0,
                PopulationModifier = 0,
                ApprovalModifier = 1,
                EconomyCost = 3,
                ResourcesCost = 3,
                PopulationCost = 0,
                ApprovalCost = 0
            },
            new Structure()
            {
                Name = "Monument to you!",
                Description = "Demand the peoples respect.\nCost:\nEconomy: 4, Resources: 4",
                EconomyModifier = 0,
                ResourcesModifier = 0,
                PopulationModifier = 0,
                ApprovalModifier = 3,
                EconomyCost = 4,
                ResourcesCost = 4,
                PopulationCost = 0,
                ApprovalCost = 0
            }
        };

        public static List<Event> SeedEvents = new List<Event>()
        {
            new Event()
            {
                Name = "False Flag",
                Description = "Your people need to know why they need you.",
                EconomyModifier = 0,
                ResourcesModifier = -1,
                PopulationModifier = -1,
                ApprovalModifier = 1
            }
        };
    }
}
