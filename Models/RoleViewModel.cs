﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class RoleViewModel
    {
        public string UserId { get; set; }
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public string Email{ get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
