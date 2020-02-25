using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace WorkoutTracker.Models
{
    public static class HelperClass
    {
        public static string GetUserId(this IPrincipal principal)
        {
            var claimsIdentity = (ClaimsIdentity)principal.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            return claim.Value;
        }

        //public static void GetWorkouts()
        //{
        //    List<Workout> workouts = context.Workouts.
        //        OrderByDescending(d => d.DateTaken).
        //        Where(w => w.User == User.GetUserId()).
        //        Include(w => w.Location).
        //        Include(w => w.ClassType).
        //        Include(w => w.Instructor).
        //        ToList();
        //}


    }
}
