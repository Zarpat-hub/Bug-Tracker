
using BugTracker.Data;
using BugTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext db)
        {
            _db = db;
            _logger = logger;
        }

        public List<DataPoint> GetTicketByProject()
        {
            var ticketsByProject = (from p in _db.Projects
                                    join t in _db.Tickets on p.Id equals t.ProjectId
                                    group p by p.Title into grp
                                    orderby grp.Count()
                                    select new { count = grp.Count(), title = grp.Key }).ToList();

            List<DataPoint> tickByProjDataPoints = new List<DataPoint>();
            foreach (var point in ticketsByProject)
            {
                tickByProjDataPoints.Add(new DataPoint(point.title, point.count));
            };

            return tickByProjDataPoints;
        }

        public List<DataPoint> GetTicketsByType()
        {
            var ticketsByType = (from t in _db.Tickets
                                 group t by t.Type into grp
                                 select new { count = grp.Count(), type = grp.Key }).ToList();

            List<DataPoint> tickByTypeDataPoints = new List<DataPoint>();
            foreach (var point in ticketsByType)
            {
                tickByTypeDataPoints.Add(new DataPoint(point.type.ToString(), point.count));
            }

            return tickByTypeDataPoints;
        }

        public List<DataPoint> GetTicketsByPriority()
        {
            var ticketsByPriority = (from t in _db.Tickets
                                    group t by t.Priority into grp
                                    select new {count = grp.Count(), priority = grp.Key}).ToList();

            List<DataPoint> tickByPriorDataPoints = new List<DataPoint>();
            foreach(var point in ticketsByPriority)
            {
                tickByPriorDataPoints.Add(new DataPoint(point.priority.ToString(), point.count));
            }

            return tickByPriorDataPoints;
        }

        public List<DataPoint> GetTicketsByStatus()
        {
            var ticketsByStatus = (from t in _db.Tickets
                                     group t by t.Status into grp
                                     select new { count = grp.Count(), status = grp.Key }).ToList();

            List<DataPoint> tickByStatusDataPoints = new List<DataPoint>();
            foreach (var point in ticketsByStatus)
            {
                tickByStatusDataPoints.Add(new DataPoint(point.status.ToString(), point.count));
            }

            return tickByStatusDataPoints;
        }

        [Authorize(Roles = "Admin,Demo Admin")]
        public IActionResult Dashboard()
        {
           
            ViewBag.TicketsByProjectDataPoints = JsonConvert.SerializeObject(GetTicketByProject());
            ViewBag.TicketsByTypeDataPoints = JsonConvert.SerializeObject(GetTicketsByType());
            ViewBag.TicketsByPriorityDataPoints = JsonConvert.SerializeObject(GetTicketsByPriority());
            ViewBag.TicketsByStatusDataPoints = JsonConvert.SerializeObject(GetTicketsByStatus());

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
