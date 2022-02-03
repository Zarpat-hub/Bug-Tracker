using BugTracker.Areas.Identity.Data;
using BugTracker.Data;
using BugTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Controllers
{
    public class CommentController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public CommentController(ApplicationDbContext db, UserManager<ApplicationUser> userManager )
        {
            _db = db;
            _userManager = userManager;
        }


        public async Task<IActionResult> Create(int ticketId, string text)
        {
            var currentUserId = _userManager.GetUserId(HttpContext.User);

            CommentModel commentModel = new CommentModel();
            commentModel.TicketId = ticketId;
            commentModel.UserId = currentUserId;
            commentModel.Text = text;
            commentModel.Date = DateTime.Now;

            _db.Comments.Add(commentModel);
            await _db.SaveChangesAsync();

            return Ok();
        }
    }
}
