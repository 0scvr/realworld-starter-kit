using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RealWorld.Controllers;
public class EditorController : Controller
{
    // GET: /<controller>/
    public IActionResult Index()
    {
        return View();
    }
}
