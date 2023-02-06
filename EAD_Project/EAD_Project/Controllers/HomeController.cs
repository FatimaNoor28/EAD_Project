﻿using EAD_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EAD_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType"))
                if (HttpContext.Request.Cookies["UserType"].Equals("Patient"))
                {
                    ViewData["PatientUserName"] = HttpContext.Request.Cookies["UserName"];
                }
                else if(HttpContext.Request.Cookies["UserType"].Equals("Admin"))
                {
                    ViewData["AdminUserName"] = HttpContext.Request.Cookies["AdminUserName"];
                }
           
                
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}