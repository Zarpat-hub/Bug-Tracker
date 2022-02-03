using BugTracker.Areas.Identity.Data;
using BugTracker.Data;
using BugTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using static BugTracker.Models.TicketModel;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System;

namespace BugTracker.Controllers
{
    public class TicketController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public TicketController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public Dictionary<string, string> GetDevs(int projectId)
        {
            var users = (from us in _db.Users
                         join pp in _db.ProjectPersonel on us.Id equals pp.UserId
                         where pp.ProjectId == projectId
                         select us);

            return users.ToDictionary(t => t.Id, t => t.FirstName + " " + t.LastName);
        }

        public List<CommentModel> GetComments(int ticketId)
        {
            var comments = (from c in _db.Comments
                            where c.TicketId == ticketId
                            select c).ToList();

            return comments;
        }
 
        [Authorize(Roles ="Admin,Demo Admin")]
        [HttpGet]
        public IActionResult Create(int projectId)
        {
            
            TicketModel ticketModel = new TicketModel();

            ticketModel.DevsForThisProject = GetDevs(projectId);    
            
            return View(ticketModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(int projectId,string devId, string title, string description, 
            PriorityType priority, BugType type)
        {
            TicketModel ticketModel = new TicketModel();
            ticketModel.ProjectId = projectId;
            var currentUserId = _userManager.GetUserId(HttpContext.User);
            ticketModel.SubmitterId = currentUserId;
            ticketModel.AssignedDevId = devId;
            ticketModel.Title = title;
            ticketModel.Description = description;
            ticketModel.Priority = priority;
            ticketModel.Created = DateTime.Now;
            ticketModel.Status = StatusType.Open;
            ticketModel.Type = type;

            await _db.Tickets.AddAsync(ticketModel);
            await _db.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int ticketId)
        {
            var ticket = await _db.Tickets.FindAsync(ticketId);

            ticket.DevsForThisProject = GetDevs(ticket.ProjectId);
            ticket.Comments = GetComments(ticketId);
            

            return View(ticket);
        }

        [Authorize(Roles = "Admin,Demo Admin")]
        [HttpGet]
        public async Task<IActionResult> Update(int ticketId)
        {
            var ticket = await _db.Tickets.FindAsync(ticketId);
            ticket.DevsForThisProject = GetDevs(ticket.ProjectId);

            return View(ticket);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Update(int ticketId, string devId, string title, string description,
            PriorityType priority, BugType type)
        {
            var ticketModel = _db.Tickets.Find(ticketId);
            
            
            ticketModel.AssignedDevId = devId;
            ticketModel.Title = title;
            ticketModel.Description = description;
            ticketModel.Priority = priority;
            ticketModel.Type = type;

            _db.Tickets.Update(ticketModel);
            await _db.SaveChangesAsync();

            return Ok();
        }

        public IActionResult AssignedIndex()
        {
            var currentUserId = _userManager.GetUserId(HttpContext.User);

            var tickets = _db.Tickets.Where(e => e.AssignedDevId == currentUserId).ToList();

            return View(tickets);
        }

        public async Task<IActionResult> DoneRequest(int ticketId)
        {
            var ticket = await _db.Tickets.FindAsync(ticketId);
            ticket.Status = StatusType.Reported_As_done;
            await _db.SaveChangesAsync();

            return Ok();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Accept(int ticketId)
        {
            var ticket = await _db.Tickets.FindAsync(ticketId);
            ticket.Status = StatusType.Finished;
            ticket.Finished = DateTime.Now;
            await _db.SaveChangesAsync();

            return Ok();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Reject(int ticketId)
        {
            var ticket = await _db.Tickets.FindAsync(ticketId);
            ticket.Status = StatusType.Open;
            await _db.SaveChangesAsync();

            return Ok();
        }

        [Authorize(Roles = "Admin,Demo Admin")]
        public IActionResult Index()
        {
            IEnumerable<TicketModel> tickets = _db.Tickets.ToList();
            foreach(var ticket in tickets)
            {
                ticket.ProjectName = _db.Projects.Find(ticket.ProjectId).Title;
            }

            return View(tickets);
        }
    }
}
