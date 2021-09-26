using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealWorldMVC.Models;
using RealWorldMVC.Services;

namespace RealWorldMVC.Controllers
{
    public class EditorController : Controller
    {
        private readonly IArticleService _articleService;
        public EditorController(IArticleService articleService) => _articleService = articleService;

        public IActionResult Index()
        {
            return View(new Article());
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateArticle(Article newArticle)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var successful = await _articleService.CreateArticleAsync(newArticle);
            if (!successful)
            {
                return BadRequest("Could not add item.");
            }
            //return RedirectToAction("Index");
            return RedirectToAction("Index", "ArticleController");
        }
    }
}
