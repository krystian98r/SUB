using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUB.Models
{
    /// <summary>
    /// Klasa użytkownika z dodatku Tożsamość rozszerzona o połączenie z portfelem
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Identity.IdentityUser" />
    public class AspNetUsers : IdentityUser
    {
        public Portfel Portfel { get; set; }
        public int PortfelId { get; set; }
    }
}
