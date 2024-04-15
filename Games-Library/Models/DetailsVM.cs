namespace Games_Library.Models;

public class DetailsVM
{
    public Game Anterior {get; set; }
    public Game Atual {get; set; }
    public Game Proximo {get; set; }
    public List<Genero> Generos {get; set; }
    public List<Plataformas> Plataformas {get; set; }
}