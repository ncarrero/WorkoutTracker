using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutTracker.Models
{
    interface IChangeData
    {
        void Add();
        void Edit();
        void Remove();
    }
}
