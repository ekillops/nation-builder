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
                Description = "Make your people think they're happy.",
                EconomyModifier = 0,
                ResourcesModifier = 0,
                PopulationModifier = 0,
                ApprovalModifier = 1
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
