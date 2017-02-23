using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NationBuilder.Models
{
    public class Nation
    {
        [Key]
        public int Id { get; set; }
        public virtual ApplicationUser AppUser { get; set; }
        public int Turn { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public virtual Government Government { get; set; }
        public virtual List<Structure> Structures { get; set; }
        public int Economy { get; set; }
        public int Resources { get; set; }
        public int Population { get; set; }
        public int ApprovalRating { get; set; }
    }
}
