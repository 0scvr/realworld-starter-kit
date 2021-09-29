using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealWorldMVC.Models;
using RealWorldMVC.Services;

namespace RealWorldMVC.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService) => _articleService = articleService;

        [HttpGet("{slug}")] //add /article before {slug} ?
        public async Task<IActionResult> Index(string slug)
        {
            Article article = await _articleService.GetArticleBySlugAsync(slug);
            return View(article);
        }
    }
}
