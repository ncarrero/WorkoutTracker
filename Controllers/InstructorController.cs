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
    public class InstructorController : Controller
    {
        private readonly ApplicationDbContext context;

        public InstructorController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Instructor> instructors = context.Instructors.ToList();
            return View(instructors);
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
                Instructor newInstructor = new Instructor
                {
                    Name = addCategoryViewModel.Name
                };

            context.Instructors.Add(newInstructor);
            context.SaveChanges();

            return Redirect("/Instructor");
            }

            return View(addCategoryViewModel);
        }

        public IActionResult Remove(int instructorId)
        {
            Instructor instructor = context.Instructors.Single(i => i.ID == instructorId);
            return View(instructor);
        }

        [HttpPost]
        public IActionResult Remove(int instructorId, Instructor collection)
        {
            Instructor instructor = context.Instructors.Single(i => i.ID == instructorId);
            context.Instructors.Remove(instructor);
            context.SaveChanges();

            return Redirect("/Instructor");
        }

        public IActionResult Edit(int instructorId)
        {
            EditCategoryViewModel editCategoryViewModel = new EditCategoryViewModel();
            instructorId = editCategoryViewModel.ID;
            return View(editCategoryViewModel);
        }

        [HttpPost]
        public IActionResult Edit(int instructorId, string name)
        {
            var instructor = context.Instructors.Single(i => i.ID == instructorId);
            instructor.Name = name;

            context.SaveChanges();

            return Redirect("/Instructor");
        }
    }
}