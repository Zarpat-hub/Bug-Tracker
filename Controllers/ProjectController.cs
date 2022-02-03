using BugTracker.Areas.Identity.Data;
using BugTracker.Data;
using BugTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Controllers
{
    public class ProjectController : Controller
    {

        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProjectController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [Authorize(Roles ="Admin,Demo Admin")]
        public IActionResult Index()
        {

            IEnumerable<ProjectModel> projects = _db.Projects.ToList();
            return View(projects);
        }

        public IActionResult AssignedIndex()
        {
            var currentUserId = _userManager.GetUserId(HttpContext.User);

            var projects = (from pr in _db.Projects
                            join pp in _db.ProjectPersonel on pr.Id equals pp.ProjectId
                            where pp.UserId == currentUserId
                            select pr).ToList();

            //var projects = _db.Projects
            //                .Join(_db.ProjectPersonel,
            //                       pr => pr.Id,
            //                       pp => pp.ProjectId,
            //                       (pr, pp) => new { pr, pp })
            //                .Where(filt => filt.pp.UserId == currentUserId)
            //                .Select(res => res.pp).ToList();


            return View(projects);
        }

        [HttpGet]
        [Authorize(Roles ="Admin,Demo Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles ="Admin,DemoAdmin")]
        public async Task<IActionResult> Create(string prTitle,string prDescription, string[] UsersId)
        {
            ProjectModel projectModel = new ProjectModel();
            projectModel.Title = prTitle;
            projectModel.Description = prDescription;
            await _db.Projects.AddAsync(projectModel);
            await _db.SaveChangesAsync();
            foreach(var userId in UsersId)
            {
                var thisProjectPersonelModel = new AssignedToProjectModel();
                thisProjectPersonelModel.ProjectId = projectModel.Id;
                thisProjectPersonelModel.UserId = userId;
                await _db.ProjectPersonel.AddAsync(thisProjectPersonelModel);
                await _db.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Project");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
           ProjectModel project = await _db.Projects.FindAsync(id);
            var projectsPersonel = _db.ProjectPersonel.ToList();

            var users = (from us in _db.Users
                         join pp in _db.ProjectPersonel on us.Id equals pp.UserId
                         where pp.ProjectId == project.Id
                         select us).ToList();

            var tickets = (from t in _db.Tickets
                          join p in _db.Projects on t.ProjectId equals p.Id
                          where t.ProjectId == id
                          select t).ToList();

            project.AssignedPersonel = users;
            project.Tickets = tickets;

            return View(project);
        }

        [HttpGet]
        [Authorize(Roles ="Admin,Demo Admin")]
        public async Task<IActionResult> Update(int id)
        {
            ProjectModel project = await _db.Projects.FindAsync(id);
            var assignedPersonel = _db.ProjectPersonel.ToList();

            List<ApplicationUser> users = new List<ApplicationUser>();

            foreach (AssignedToProjectModel model in assignedPersonel)
            {
                if (model.ProjectId == project.Id)
                {
                    var user = await _db.Users.FindAsync(model.UserId);
                    users.Add(user);
                }
            }

            project.AssignedPersonel = users;
            return View(project);
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Update(int id,string prTitle, string prDescription, string[] UsersId)
        {

            var projectModel = await _db.Projects.FindAsync(id);
            projectModel.Title = prTitle;
            projectModel.Description = prDescription;
            _db.Projects.Update(projectModel);
            await _db.SaveChangesAsync();

            var personelList = _db.ProjectPersonel.ToList();
          

            foreach (var userId in UsersId)
            {
                var thisProjectPersonelModel = new AssignedToProjectModel();
                thisProjectPersonelModel.ProjectId = projectModel.Id;
                thisProjectPersonelModel.UserId = userId;
                if (_db.ProjectPersonel.Any(e => e.ProjectId == thisProjectPersonelModel.ProjectId && e.UserId == thisProjectPersonelModel.UserId))
                {

                }
                else
                    await _db.ProjectPersonel.AddAsync(thisProjectPersonelModel);

                await _db.SaveChangesAsync();
            }



            return Ok();
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var projectModel = await _db.Projects.FindAsync(id);
            _db.Projects.Remove(projectModel);
            await _db.SaveChangesAsync();

            return Ok();
        }

        [HttpPost, ActionName("RemovePersonel")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> RemovePersonel(string idsString)
        {

            string[] subs = idsString.Split(',');
            string personId = subs[0];
            int projectId = Convert.ToInt32(subs[1]);

            var assignedRow = _db.ProjectPersonel.FirstOrDefault(e => e.UserId==personId && e.ProjectId==projectId);
            _db.ProjectPersonel.Remove(assignedRow);
            await _db.SaveChangesAsync();

            return Ok();
        }
    }
}
