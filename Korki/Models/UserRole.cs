using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korki.Models
{
    public class UserRole : IdentityUserRole<int>
    {
        public int Key { get; set; }
        public RoleType RoleType { get; set; }
        public string Name => RoleType.ToString();
    }

    public enum RoleType
    {
        User,
        Tutor,
    }
}
