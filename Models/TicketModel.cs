using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class TicketModel
    {

        [Key]
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string SubmitterId { get; set; }
        public string AssignedDevId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public PriorityType Priority { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Finished { get; set; } = null;
        public StatusType Status { get; set; }
        public BugType Type { get; set; }

        [NotMapped]
        public Dictionary<string,string> DevsForThisProject { get; set; }
        [NotMapped]
        public List<CommentModel> Comments { get; set; }
        [NotMapped]
        public string ProjectName { get; set; }

        public enum PriorityType
        {
            Low,
            Medium,
            High,
            TOP_PRIORITY,
        }

        public enum StatusType
        {
            Open,
            [Display(Name ="Waiting for accept")]
            Reported_As_done,
            Finished
        }

        public enum BugType
        {
            Bug,
            Feature,
            Change
        }
    }
}
