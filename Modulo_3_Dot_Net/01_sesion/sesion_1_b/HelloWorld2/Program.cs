using System;

class Program
{

    private static Dictionary<string, string> usuarios = new Dictionary<string, string>
    {
        {"admin", "querty"},
        {"usuario", "1234"},
        {"test", "testing"}
    };

    static void Main(string[] args)
    {
        // Mensaje de bienvenida
        Console.WriteLine("Este es el programa oficial hola mundo");
        Console.WriteLine("Tienes que iniciar sesion");

        Console.WriteLine("Escribe tu usuario");
        string? usuarioIngresado = Console.ReadLine();
        Console.WriteLine("Escribe tu contraseña");
        string? passIngresada = Console.ReadLine();

        if (usuarioIngresado != null)
        {
            if (usuarios.ContainsKey(usuarioIngresado) && usuarios[usuarioIngresado] == passIngresada) 
            {
                Console.WriteLine("has ingresado con éxito");
                for (int i = 1; i <= 50; i++)
                {
                    Console.WriteLine($"{i}. hola usuario, gracias");
                }
                Console.WriteLine("Presiona enter para salir del programa...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("usuario o clave incorrecto/a");
                Console.WriteLine("Presiona enter para salir del programa...");
                Console.ReadLine();
            }
        }
    }
}