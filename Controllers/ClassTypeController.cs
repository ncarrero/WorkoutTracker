﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WorkoutTracker.Controllers
{
    public class ClassTypeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}