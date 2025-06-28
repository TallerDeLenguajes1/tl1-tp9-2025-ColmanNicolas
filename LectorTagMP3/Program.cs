using System;
using System.Text;
using tagMP3;

class Program
{
    static void Main()
    {
        string ruta;
        Console.Write("Escriba la ruta completa donde esta el archivo .mp3: ");
        ruta = Console.ReadLine();
        Console.WriteLine($"recupero: ({ruta})");
        string[] partes = ruta.Split(".");
        if (partes[^1] != "mp3")
        {
            ruta = string.Concat(ruta, ".mp3");
        }
        
        if (!File.Exists(ruta))
        {
            Console.WriteLine("El archivo no existe en la ruta especificada");
            return;
        }
        using (FileStream fs = new FileStream(ruta, FileMode.Open, FileAccess.Read))
        {
            if (fs.Length < 128)
            {
                Console.WriteLine("El archivo no tiene el tamaño suficiente para leer el tag de mp3");
                return;
            }
            fs.Seek(-128, SeekOrigin.End);
            byte[] buffer = new byte[128];
            fs.Read(buffer, 0, 128);

            string cabecera = Encoding.ASCII.GetString(buffer, 0, 3);

            if (string.Compare(cabecera, "TAG") != 0)
            {
                Console.WriteLine("El archivo no contiene una etiqueta ID3v1 válida.");
                return;
            }

            Id3v1Tag mp3_info = new Id3v1Tag
            {
                Titulo = Encoding.GetEncoding("latin1").GetString(buffer, 3, 30).TrimEnd('\0', ' '),
                Artista = Encoding.GetEncoding("latin1").GetString(buffer, 33, 30).TrimEnd('\0', ' '),
                Album = Encoding.GetEncoding("latin1").GetString(buffer, 63, 30).TrimEnd('\0', ' '),
                Anio = Encoding.GetEncoding("latin1").GetString(buffer, 93, 4).TrimEnd('\0', ' ')
            };

            Console.WriteLine("Informacion del archivo MP3");
            mp3_info.mostrar();
        }
    }
}



