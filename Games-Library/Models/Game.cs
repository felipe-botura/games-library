namespace Games_Library.Models
{
    public class Game
    {
        public int ID { get; set; }
        
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public List<string> Plataformas { get; set; } = [];

        public List<string> Genero { get; set; } = [];

        public int Preco { get; set; }

        public string Imagem { get; set; }

        public string Desenvolvedora { get; set; }
    }
}