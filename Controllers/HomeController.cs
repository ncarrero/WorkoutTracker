using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WorkoutTracker.Data;
using WorkoutTracker.Models;

namespace WorkoutTracker.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext context;
        public HomeController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //parameter: string searchTerm
        public IActionResult Index()
        {
            //var workouts = context.Workouts.OrderBy(d => d.DateTaken).
            //    Where(w => w.User == User.GetUserId());

            //if (!string.IsNullOrEmpty(searchTerm))
            //{
            //    workouts = workouts.Where(s => s.ClassType.Name.Contains(searchTerm));
            //}

            //return View(workouts);
            List<Workout> Workouts = context.Workouts.Where(w => w.User == User.GetUserId())
                .Include(w => w.Location)
                .Include(w => w.Instructor)
                .Include(w => w.ClassType)
                .ToList();

            ViewBag.Workouts = Workouts;

            List<ClassType> ClassTypes = context.Workouts.Where(w => w.User == User.GetUserId())
                .Select(w => w.ClassType).ToList();

            var classTypesGrouped = ClassTypes.GroupBy(x => x.Name)
                       .Select(x => new { Name = x.Key, Values = x.Count() });

            StringBuilder sb = new StringBuilder();
            foreach (var x in classTypesGrouped)
            {
                sb.AppendLine(x.Name + ": " + x.Values);
            }

            ViewBag.ClassTypesGrouped = sb;

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
