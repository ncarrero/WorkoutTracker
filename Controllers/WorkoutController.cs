using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Data;
using WorkoutTracker.Models;
using WorkoutTracker.ViewModels;

namespace WorkoutTracker.Controllers
{
    public class WorkoutController : Controller
    {
        private readonly ApplicationDbContext context;

        public WorkoutController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
        
        public IActionResult Index()
        {
            IList<Workout> workouts = context.Workouts.
                Where( w => w.User == User.GetUserId()).
                Include(w => w.Location).
                Include(w => w.ClassType).
                Include(w => w.Instructor).
                ToList();
            
            return View(workouts);
        }

        public IActionResult Add()
        {
            List<Location> locations = context.Locations.ToList();
            List<ClassType> classTypes = context.ClassTypes.ToList();
            List<Instructor> instructors = context.Instructors.ToList();

            AddEditWorkoutViewModel addEditWorkoutViewModel = new AddEditWorkoutViewModel(instructors, locations, classTypes);
            return View(addEditWorkoutViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddEditWorkoutViewModel addEditWorkoutViewModel)
        {
            if (ModelState.IsValid)
            {
                Location newLocation = context.Locations.Single(c => c.ID == addEditWorkoutViewModel.LocationID);
                Instructor newInstructor = context.Instructors.Single(c => c.ID == addEditWorkoutViewModel.InstructorID);
                ClassType newClassType = context.ClassTypes.Single(c => c.ID == addEditWorkoutViewModel.ClassTypeID);

                Workout newWorkout = new Workout
                {
                    User = User.GetUserId(),
                    CaloriesBurned = addEditWorkoutViewModel.CaloriesBurned,
                    ClassType = newClassType,
                    DateTaken = addEditWorkoutViewModel.DateTaken,
                    Instructor = newInstructor,
                    HasBeenLiked = addEditWorkoutViewModel.HasBeenLiked,
                    Location = newLocation
                };

                context.Workouts.Add(newWorkout);
                context.SaveChanges();

                return Redirect("/Workout");
            }

            return View(addEditWorkoutViewModel);
        }

        public IActionResult Remove(int workoutId)
        {
            Workout workout = context.Workouts.Single(w => w.ID == workoutId);
            return View(workout);
        }

        [HttpPost]
        public IActionResult Remove(int workoutId, Workout collection)
        {
            Workout workout = context.Workouts.Single(w => w.ID == workoutId);
            context.Workouts.Remove(workout);
            context.SaveChanges();

            return Redirect("/Workout");
        }

        //TODO: Fix editing functionality for dropdown menus
        public IActionResult Edit(int workoutId)
        {
            List<Location> locations = context.Locations.ToList();
            List<ClassType> classTypes = context.ClassTypes.ToList();
            List<Instructor> instructors = context.Instructors.ToList();

            AddEditWorkoutViewModel addEditWorkoutViewModel = new AddEditWorkoutViewModel(instructors, locations, classTypes);
            workoutId = addEditWorkoutViewModel.ID;

            return View(addEditWorkoutViewModel);
        }

        [HttpPost]
        public IActionResult Edit(AddEditWorkoutViewModel addEditWorkoutViewModel, int workoutId, int caloriesBurned, ClassType classType, 
            DateTime dateTaken, Instructor instructor, bool hasBeenLiked, Location location)
        {
            if (ModelState.IsValid)
            {
                Location newLocation = context.Locations.Single(c => c.ID == addEditWorkoutViewModel.LocationID);
                Instructor newInstructor = context.Instructors.Single(c => c.ID == addEditWorkoutViewModel.InstructorID);
                ClassType newClassType = context.ClassTypes.Single(c => c.ID == addEditWorkoutViewModel.ClassTypeID);

                Workout workout = context.Workouts.Single(w => w.ID == workoutId);
                workout.CaloriesBurned = caloriesBurned;
                workout.ClassType = classType;
                workout.DateTaken = dateTaken;
                workout.Instructor = instructor;
                workout.HasBeenLiked = hasBeenLiked;
                workout.Location = location;

                context.SaveChanges();
                return Redirect("/Workout");
            }

            return View(addEditWorkoutViewModel);
        }
    }
}