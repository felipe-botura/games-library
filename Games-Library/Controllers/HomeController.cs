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
        List<Game> games = GetGames();
        List<Genero> generos = GetGeneros();
        ViewData["Gêneros"] = generos;
        return View(games);
    }

    public IActionResult Details(int id)
    {
        List<Game> games = GetGames();
        List<Genero> generos = GetGeneros();
        DetailsVM details = new() {
            Generos = generos,
            Atual = games.FirstOrDefault(p => p.ID == id),
            Anterior = games.OrderByDescending(p => p.ID).FirstOrDefault(p => p.ID < id),
            Proximo = games.OrderBy(p => p.ID).FirstOrDefault(p => p.ID > id),
        };
        return View(details);
    }

    private List<Game> GetGames()
    {
        using (StreamReader leitor = new("Data\\games.json"))
        {
            string dados = leitor.ReadToEnd();
            return JsonSerializer.Deserialize<List<Game>>(dados);
        }
    }

     private List<Genero> GetGeneros()
    {
        using (StreamReader leitor = new("Data\\genero.json"))
        {
            string dados = leitor.ReadToEnd();
            return JsonSerializer.Deserialize<List<Genero>>(dados);
        }
    }

    private List<Plataformas> GetPlataformas()
    {
        using (StreamReader leitor = new("Data\\plataformas.json"))
        {
            string dados = leitor.ReadToEnd();
            return JsonSerializer.Deserialize<List<Plataformas>>(dados);
        }
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
