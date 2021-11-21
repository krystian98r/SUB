using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUB.Models
{
    public class AspNetUsers : IdentityUser
    {
        public Portfel Portfel { get; set; }
    }
}
