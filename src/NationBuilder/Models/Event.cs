using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NationBuilder.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int EconomyModifier { get; set; }
        public int ResourcesModifier { get; set; }
        public int PopulationModifier { get; set; }
        public int ApprovalModifier { get; set; }
    }
}
