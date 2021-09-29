using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealWorldMVC.Models;
using RealWorldMVC.Services;

namespace RealWorldMVC.Controllers
{
    [Authorize]
    public class EditorController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly UserManager<AppUser> _userManager;
        public EditorController(IArticleService articleService, UserManager<AppUser> userManager)
        {
            _articleService = articleService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(new NewOrEditArticleDto());
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateArticle(NewOrEditArticleDto newOrEditArticleDto)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            AppUser user = await _userManager.GetUserAsync(HttpContext.User);

            newOrEditArticleDto.AuthorId = user.Id;

            string maybeSlug = await _articleService.CreateArticleAsync(newOrEditArticleDto);
            if (maybeSlug == null)
            {
                return BadRequest("Could not add item.");
            }
            //return RedirectToAction("Index");
            return RedirectToAction("Index", "Article", new { slug = maybeSlug });
        }
    }
}
