using BugTracker.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class ProjectModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Title is required")]
        public string Title { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public List<ApplicationUser> AssignedPersonel { get; set; }
        [NotMapped]
        public List<TicketModel> Tickets { get; set; }
    }
}
