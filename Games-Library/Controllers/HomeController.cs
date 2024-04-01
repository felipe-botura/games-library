using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Games_Library.Models;
using System.Text.Json;

namespace Games_Library.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Game> games = [];
        using (StreamReader leitor = new("Data\\games.json"))
        {
            string dados = leitor.ReadToEnd();
            games = JsonSerializer.Deserialize<List<Game>>(dados);
        }
        return View(games);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
