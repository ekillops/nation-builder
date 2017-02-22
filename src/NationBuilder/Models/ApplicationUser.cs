using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace NationBuilder.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public virtual List<Nation> Nations { get; set; }
    }
}
