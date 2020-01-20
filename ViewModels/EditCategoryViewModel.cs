using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutTracker.Models;

namespace WorkoutTracker.ViewModels
{
    public class EditCategoryViewModel : AddCategoryViewModel
    {
        public int ID { get; set; }
    }
}
