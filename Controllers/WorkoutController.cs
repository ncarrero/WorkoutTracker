using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Data;
using WorkoutTracker.Models;
using WorkoutTracker.ViewModels;

namespace WorkoutTracker.Controllers
{
    [Authorize]
    public class WorkoutController : Controller
    {
        private readonly ApplicationDbContext context;

        public WorkoutController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
        
        public IActionResult Index()
        {
            List<Workout> workouts = context.Workouts.OrderBy(d => d.DateTaken).
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

        public IActionResult Edit(int workoutId)
        {
            Workout workout = context.Workouts.Single(w => w.ID == workoutId);

            List<Location> locations = context.Locations.ToList();
            List<ClassType> classTypes = context.ClassTypes.ToList();
            List<Instructor> instructors = context.Instructors.ToList();

            AddEditWorkoutViewModel addEditWorkoutViewModel = new AddEditWorkoutViewModel(instructors, locations, classTypes);
            addEditWorkoutViewModel.ID = workout.ID;
            addEditWorkoutViewModel.User = workout.User;
            addEditWorkoutViewModel.CaloriesBurned = workout.CaloriesBurned;
            addEditWorkoutViewModel.DateTaken = workout.DateTaken;
            addEditWorkoutViewModel.ClassType = workout.ClassType;
            addEditWorkoutViewModel.Instructor = workout.Instructor;
            addEditWorkoutViewModel.Location = workout.Location;
            addEditWorkoutViewModel.HasBeenLiked = workout.HasBeenLiked;

            return View(addEditWorkoutViewModel);
        }

        [HttpPost]
        public IActionResult Edit(AddEditWorkoutViewModel addEditWorkoutViewModel, int caloriesBurned, DateTime dateTaken, bool hasBeenLiked)
        {
            if (ModelState.IsValid)
            {
                Location newLocation = context.Locations.Single(c => c.ID == addEditWorkoutViewModel.Location.ID);
                Instructor newInstructor = context.Instructors.Single(c => c.ID == addEditWorkoutViewModel.Instructor.ID);
                ClassType newClassType = context.ClassTypes.Single(c => c.ID == addEditWorkoutViewModel.ClassType.ID);

                Workout workout = context.Workouts.Single(w => w.ID == addEditWorkoutViewModel.ID);
                workout.CaloriesBurned = caloriesBurned;
                workout.ClassType = newClassType;
                workout.DateTaken = dateTaken;
                workout.Instructor = newInstructor;
                workout.HasBeenLiked = hasBeenLiked;
                workout.Location = newLocation;

                context.SaveChanges();
                return Redirect("/Workout");
            }

            return View(addEditWorkoutViewModel);
        }
    }
}