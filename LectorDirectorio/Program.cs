using System;
using System.IO;

class Program
{
    public static void Main()
    {
        Console.WriteLine("La ruta del directorio de trabajo actual es: " + Directory.GetCurrentDirectory()); 
        string ruta ;
        do{

        Console.Write("Ingrese la direccion de un directorio dentro del Disco C:\\: "); 
        ruta = Console.ReadLine(); 

        if (!Directory.Exists(ruta)) 
        {
            Console.WriteLine("No se encontró el directorio: "+ ruta); 
        }

        }while(!Directory.Exists(ruta));
        string[] directorios = Directory.GetDirectories(ruta);
        Console.WriteLine("Carpetas dentro del directorio ingresado:");

        foreach (var direccion in directorios)
        {
            string[] partes = direccion.Split('\\');
            Console.WriteLine("Directorio: " + partes[^1]);
            var archivos = Directory.GetFiles(direccion);
            foreach (var archivo in archivos)
            {
                FileInfo fileInfo = new FileInfo(archivo);
                Console.WriteLine($"  Nombre: {fileInfo.Name}, Tamaño: {fileInfo.Length / 1024.0} Kilobytes, Último acceso: {fileInfo.LastAccessTime}");
            }
        Console.WriteLine("");
        }
    }
}