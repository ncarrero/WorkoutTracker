using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutTracker.Models
{
    public class ClassType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
    }
}
