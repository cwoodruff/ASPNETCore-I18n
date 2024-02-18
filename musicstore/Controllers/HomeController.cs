using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using musicstore.Models;

namespace musicstore.Controllers;

public class HomeController(ILogger<HomeController> logger, IHtmlLocalizer<HomeController> localizer)
    : Controller
{
    private readonly ILogger<HomeController> _logger = logger;
    private readonly IHtmlLocalizer<HomeController> _localizer = localizer;

    public IActionResult Index()
    {
        ViewData["Title"] = _localizer["Title"];
        ViewData["Home"] = _localizer["Home"];
        ViewData["About"] = _localizer["About"];
        ViewData["Featured"] = _localizer["Featured"];
        ViewData["Album1Name"] = _localizer["Album1Name"];
        ViewData["Album1Descr"] = _localizer["Album1Descr"];
        ViewData["Album2Name"] = _localizer["Album2Name"];
        ViewData["Album2Descr"] = _localizer["Album2Descr"];
        ViewData["Album3Name"] = _localizer["Album3Name"];
        ViewData["Album3Descr"] = _localizer["Album3Descr"];
        ViewData["Album4Name"] = _localizer["Album4Name"];
        ViewData["Album4Descr"] = _localizer["Album4Descr"];
        ViewData["Album5Name"] = _localizer["Album5Name"];
        ViewData["Album5Descr"] = _localizer["Album5Descr"];
        ViewData["Album6Name"] = _localizer["Album6Name"];
        ViewData["Album6Descr"] = _localizer["Album6Descr"];
        return View();
    }

    public IActionResult About()
    {
        ViewData["Title"] = _localizer["Title"];
        ViewData["Home"] = _localizer["Home"];
        ViewData["About"] = _localizer["About"];
        ViewData["AboutUs"] = _localizer["AboutUs"];
        return View();
    }
    
    public IActionResult LocalizedView()
    {
        return View();
    }

    public IActionResult DataAnnotationView([FromQuery] string? culture)
    {
        ViewData["culture"] = culture;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DataAnnotationView(AlbumViewModel personViewModel, [FromQuery] string? culture)
    {
        ViewData["culture"] = culture;

        if (!ModelState.IsValid)
        {
            return View();
        }

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}