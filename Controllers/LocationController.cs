using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkoutTracker.Data;
using WorkoutTracker.Models;
using WorkoutTracker.ViewModels;

namespace WorkoutTracker.Controllers
{
    public class LocationController : Controller
    {
        private readonly ApplicationDbContext context;

        public LocationController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Location> locations = context.Locations.ToList();
            return View(locations);
        }

        public IActionResult Add()
        {
            AddCategoryViewModel addCategoryViewModel = new AddCategoryViewModel();
            return View(addCategoryViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCategoryViewModel addCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                Location newLocation = new Location
                {
                    Name = addCategoryViewModel.Name
                };

                context.Locations.Add(newLocation);
                context.SaveChanges();

                return Redirect("/Location");
            }

            return View(addCategoryViewModel);
        }

        public IActionResult Remove(int locationId)
        {
            Location location = context.Locations.Single(i => i.ID == locationId);
            return View(location);
        }

        [HttpPost]
        public IActionResult Remove(int locationId, Location collection)
        {
            Location location = context.Locations.Single(i => i.ID == locationId);
            context.Locations.Remove(location);
            context.SaveChanges();

            return Redirect("/Location");
        }

        public IActionResult Edit(int locationId)
        {
            Location location = new Location();
            Location editLocation = context.Locations.Single(l => l.ID == locationId);
            return View(editLocation);
        }

        [HttpPost]
        public IActionResult Edit(int locationId, string name)
        {
            Location location = context.Locations.Single(i => i.ID == locationId);
            location.Name = name;

            context.SaveChanges();

            return Redirect("/Location");
        }
    }
}