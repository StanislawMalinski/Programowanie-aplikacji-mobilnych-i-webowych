using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using Shared.Model;
using Shared.Services;

namespace WebApp.Controllers;

public class FilmsController : Controller
{
    private readonly ILogger<FilmsController> _logger;

    private readonly IFilmClientService _filmService;

    public FilmsController(ILogger<FilmsController> logger, IFilmClientService filmService)
    {
        _logger = logger;
        _filmService = filmService;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _filmService.GetTop10();
        return products != null ?
                        View(products.AsEnumerable()) :
                        Problem("Entity set 'ShopContext.Products'  is null.");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
