using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealWorldMVC.Models;

namespace RealWorldMVC.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(); // inject current user or DTO in this view
        }

        [HttpPost]
        public IActionResult Index(AppUser profile)
        {
            return View();
        }
    }
}
