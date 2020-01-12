using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutTracker.Models
{
    public class Workout : IChangeData
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int CaloriesBurned { get; set; }
        public ClassType ClassType { get; set; }
        public DateTime DateTaken { get; set; }
        public Instructor Instructor { get; set; }
        public bool HasBeenLiked { get; set; }
        public Location Location { get; set; }

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
