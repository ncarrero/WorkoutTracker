using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutTracker.Models
{
    public class Category : IChangeData
    {
        public int ID { get; set; }
        public string Name { get; set; }
        IList<Location> Locations { get; set; }
        IList<ClassType> ClassTypes { get; set; }
        IList<Instructor> Instructors { get; set; }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Edit()
        {
            throw new NotImplementedException();
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }
    }
}
