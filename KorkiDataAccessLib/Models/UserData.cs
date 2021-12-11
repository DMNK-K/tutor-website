using System;
using System.Collections.Generic;
using System.Text;

namespace KorkiDataAccessLib.Models
{
    public class UserData
    {
        public int ID { get; set; }
        public bool IsTutor { get; set; }
        public string Email { get; set; }
        public string EmailHash { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }

        public DateTimeOffset JoinDateTime { get; set; }

        public bool IsDeleted { get; set; }
        public string DeletionInfo { get; set; }

        public bool IsSuspended { get; set; }
        public string SuspentionInfo { get; set; }
        public DateTimeOffset SuspentionDateTime { get; set; }
        public DateTimeOffset SuspentionAutoEnd { get; set; }

        public bool IsShowcase { get; set; }
        public int AccessFailedCount { get; set; }
    }
}
