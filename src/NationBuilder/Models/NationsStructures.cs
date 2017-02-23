using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NationBuilder.Models
{
    [Table("NationsStuctures")]
    public class NationStructure
    {
        [Key]
        public int Id { get; set; }
        public virtual Nation Nation { get; set; }
        public virtual Structure Structure { get; set; }
    }
}
