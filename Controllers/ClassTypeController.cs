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
    public class ClassTypeController : Controller
    {
        private readonly ApplicationDbContext context;

        public ClassTypeController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<ClassType> classTypes = context.ClassTypes.ToList();
            return View(classTypes);
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
                ClassType newClassType = new ClassType
                {
                    Name = addCategoryViewModel.Name
                };

                context.ClassTypes.Add(newClassType);
                context.SaveChanges();

                return Redirect("/ClassType");
            }

            return View(addCategoryViewModel);
        }

        public IActionResult Remove(int classTypeId)
        {
            ClassType classType = context.ClassTypes.Single(i => i.ID == classTypeId);
            return View(classType);
        }

        [HttpPost]
        public IActionResult Remove(int classTypeId, ClassType collection)
        {
            ClassType classType = context.ClassTypes.Single(i => i.ID == classTypeId);
            context.ClassTypes.Remove(classType);
            context.SaveChanges();

            return Redirect("/ClassType");
        }

        public IActionResult Edit(int classTypeId)
        {
            EditCategoryViewModel editCategoryViewModel = new EditCategoryViewModel();
            classTypeId = editCategoryViewModel.ID;
            return View(editCategoryViewModel);
        }

        [HttpPost]
        public IActionResult Edit(int classTypeId, string name)
        {
            ClassType classType = context.ClassTypes.Single(i => i.ID == classTypeId);
            classType.Name = name;

            context.SaveChanges();

            return Redirect("/ClassType");
        }
    }
}