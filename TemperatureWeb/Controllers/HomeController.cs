using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Temperature;

namespace TemperatureWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(IFormCollection iFormCollection)
    {
        if (iFormCollection["value"] == ""){
            ViewData["result"] = 0;
            return View();
        }
        if (iFormCollection["from"] == iFormCollection["to"]){
            ViewData["result"] = iFormCollection["value"];
            return View();
        }

        Conversion conversion = new Conversion();
        Conversion.ConversionMode mode = conversion.ModeSelect(iFormCollection["from"], iFormCollection["to"]);
        ViewData["result"] = conversion.Convert(mode, double.Parse(iFormCollection["value"]));
        ViewData["input"] = double.Parse(iFormCollection["value"]);
        return View();
    }

    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
