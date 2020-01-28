using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WorkoutTracker.Models;

namespace WorkoutTracker.ViewModels
{
    public class AddEditWorkoutViewModel : Workout
    {
        [Range(100,1000, ErrorMessage="Number should be between 100 and 1000.")]
        public override int CaloriesBurned { get; set; }
        [DataType(DataType.DateTime)]
        public override DateTime DateTaken { get; set; }
        public int ClassTypeID { get; set; }
        public int InstructorID { get; set; }
        public int LocationID { get; set; }

        public List<SelectListItem> Locations { get; set; }
        public List<SelectListItem> Instructors { get; set; }
        public List<SelectListItem> ClassTypes { get; set; }

        public AddEditWorkoutViewModel(IEnumerable<Instructor> instructors,
            IEnumerable<Location> locations, IEnumerable<ClassType> classTypes)
        {
            Instructors = new List<SelectListItem>();

            foreach (Instructor instructor in instructors)
            {
                Instructors.Add(new SelectListItem
                {
                    Value = instructor.ID.ToString(),
                    Text = instructor.Name
                });
            }

            Locations = new List<SelectListItem>();

            foreach (Location location in locations)
            {
                Locations.Add(new SelectListItem
                {
                    Value = location.ID.ToString(),
                    Text = location.Name
                });
            }

            ClassTypes = new List<SelectListItem>();

            foreach (ClassType classType in classTypes)
            {
                ClassTypes.Add(new SelectListItem
                {
                    Value = classType.ID.ToString(),
                    Text = classType.Name
                });
            }
        }

        public AddEditWorkoutViewModel()
        { }
    }
}
