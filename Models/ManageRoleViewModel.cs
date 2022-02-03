using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class ManageRoleViewModel
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public List<string> RoleNames { get; set; }
    }
}
