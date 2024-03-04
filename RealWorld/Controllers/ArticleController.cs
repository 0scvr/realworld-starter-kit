using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealWorld.Models;
using RealWorld.Services;

namespace RealWorld.Controllers;
public class ArticleController : Controller
{
    private readonly IArticleService _articleService;

    public ArticleController(IArticleService articleService)
    {
        _articleService = articleService;
    }

    public async Task<IActionResult> Index(string slug)
    {
        var article = await _articleService.GetArticleBySlugAsync(slug);
        return View(article);
    }
}
