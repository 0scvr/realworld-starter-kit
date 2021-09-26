using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealWorldMVC.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealWorldMVC.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserService _userService;

        public ProfileController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index(string username)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Movie movie = db.Movies.Find(id);
            //if (movie == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(movie);
            var user = await _userService.GetUserByUsernameAsync(username);

            return View(user);
        }
    }
}
