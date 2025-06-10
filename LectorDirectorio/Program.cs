using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("La ruta del directorio de trabajo actual es: " + Directory.GetCurrentDirectory()); 
        string ruta ;
        do{

        Console.Write("Ingrese la direccion de un directorio dentro del Disco C:\\: "); 
        ruta = Console.ReadLine(); 

        if (!Directory.Exists(ruta)) 
        {
            Console.WriteLine("No se encontró el directorio: ", ruta); 
        }

        }while(!Directory.Exists(ruta));
        string[] carpetas = Directory.GetDirectories(ruta);
        Console.WriteLine("Carpetas dentro del directorio ingresado:");
        foreach(var direccion in carpetas)
        {
            string[] partes = direccion.Split('\\');
            Console.WriteLine("Directorio: ", partes[partes.Length - 1]);
            var[] archivos = Directory.GetFiles(direccion);
            foreach (var archivo in direccion)
            {
                FileInfo fileInfo = new FileInfo(archivo);
                Console.WriteLine($"  Nombre: {fileInfo.Name}, Tamaño: {fileInfo.Length / 1024} Kilobytes, Último acceso: {fileInfo.LastAccessTime}");
            }
        }
    }
}