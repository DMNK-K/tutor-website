using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Korki.Models
{
    public class User : IdentityUser<int>
    {
        //this gimmick with id is just so it matches naming scheme in all the other places here,
        //which is both letters capital
        private int _id;
        public int ID { get => _id; set => _id = value; } 
        public override int Id { get => ID; set => ID = value; }

        //base NormalizedEmail is has both get & set, but I want NormalizedEmail to be
        //tied to the actual Email at all times, with no possibility of them becoming different/desynced
        //so hence the overriding with an empty set
        public override string NormalizedEmail { get => Email.ToLower(); set { } }
        //same with NormalizedUserName
        public override string NormalizedUserName { get => UserName.ToLower(); set { } }
        public string EmailHash { get; set; }

        //this could be using Identity roles, but it feels too small to use them just for this
        public bool IsTutor { get; set; } 

        public DateTimeOffset JoinDateTime { get; set; }

        public bool IsDeleted { get; set; }
        public string DeletionInfo { get; set; }

        public bool IsSuspended { get; set; }
        public string SuspentionInfo { get; set; }
        public DateTimeOffset SuspentionDateTime { get; set; }
        public DateTimeOffset SuspentionAutoEnd { get; set; }

        public bool IsShowcase { get; set; }
    }
}
