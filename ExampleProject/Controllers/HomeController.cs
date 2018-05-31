﻿using AutoMapper;
using ExampleProject.Database;
using Microsoft.AspNetCore.Mvc;

namespace ExampleProject.Controllers
{
    public class HomeController : Controller
    {
	    public HomeController(IMapper mapper, MyContext context, ISuperCalculator calculator)
	    {
		    
	    }
        public IActionResult Index()
        {
	        var model = new ExampleModel()
	        {
		        Name = "Karin",
		        Value = "Hejsan!"
	        };
            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
    }
}
