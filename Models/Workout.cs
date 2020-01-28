using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutTracker.Models
{
    public class Workout
    {
        public int ID { get; set; }
        public string User { get; set; }
        public virtual int CaloriesBurned { get; set; }
        public ClassType ClassType { get; set; }
        public virtual DateTime DateTaken { get; set; }
        public Instructor Instructor { get; set; }
        public bool HasBeenLiked { get; set; }
        public Location Location { get; set; }
    }
}
