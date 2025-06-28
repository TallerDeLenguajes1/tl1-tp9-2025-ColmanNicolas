namespace tagMP3
{
    public class Id3v1Tag
    {
        public string Titulo { get; set; }
        public string Artista { get; set; }
        public string Album { get; set; }
        public string Anio { get; set; }

        public void mostrar()
        {
            Console.WriteLine($"Título: {Titulo}");
            Console.WriteLine($"Artista: {Artista}");
            Console.WriteLine($"Álbum: {Album}");
            Console.WriteLine($"Año: {Anio}");

        }
    }
}