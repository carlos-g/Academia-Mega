using System;
using System.ComponentModel;
using System.Text;

class Program
{

    private static Dictionary<string, string> usuarios = new Dictionary<string, string>
    {
        {"admin", "qwerty"},
        {"usuario", "1234"},
        {"test", "testing"}
    };

    private const int MAX_ATTEMPTS = 3;
    static void Main(string[] args)
    {
        // Mensaje de bienvenida
        Console.WriteLine("Este es el programa oficial hola mundo v2");
        Console.WriteLine("Tienes que iniciar sesion");

        Console.WriteLine("Escribe tu usuario");
        string? usuarioIngresado = TryLogin();

        if (usuarioIngresado != null)
        {
            Console.WriteLine($"Hola {usuarioIngresado}");
        }
        else
        {
            Console.WriteLine("has excedido el número máximo de intentos");
        }

        Console.WriteLine("Presione Enter para salir");
        Console.ReadLine();

        /*
        Console.WriteLine("Escribe tu contraseña");
        string? passIngresada = ReadPassword();
        */

    }

    private static string? TryLogin()
    {
        int intentosRestantes = MAX_ATTEMPTS;
        while (intentosRestantes > 0)
        {
            Console.WriteLine($"\nIntentos restantes: {intentosRestantes}");
            Console.Write("Ingresa tu nombre de usuario: ");
            string? userLogged = Console.ReadLine();
            Console.WriteLine("Escribe tu contraseña");
            string? passIngresada = ReadPassword();

            if (string.IsNullOrWhiteSpace(userLogged) || string.IsNullOrWhiteSpace(passIngresada))
            {
                Console.WriteLine("\nError: El usuario y contraseña no pueden estar vacíos");
                intentosRestantes--;
                continue;
            }

            if (usuarios.ContainsKey(userLogged) && usuarios[userLogged] == passIngresada) 
            {
                Console.WriteLine("\nAcceso concedido!!");
                return userLogged;

                /*
                for (int i = 1; i <= 50; i++)
                {
                    Console.WriteLine($"{i}. hola usuario, gracias");
                }
                Console.WriteLine("Presiona enter para salir del programa...");
                Console.ReadLine();
                */
            }
            else
            {
                Console.WriteLine("usuario o clave incorrecto/a");
                Console.WriteLine("\n Intentalo de nuevo");
                intentosRestantes--;
            }
        }
        return null;
    }
    private static string? ReadPassword()
    {
        StringBuilder password = new StringBuilder();
        ConsoleKeyInfo keyinfo;

        do
        {
            keyinfo = Console.ReadKey(true);

            if (!char.IsControl(keyinfo.KeyChar))
            {
                password.Append(keyinfo.KeyChar);
                Console.Write("*");
            }
            else if (keyinfo.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password.Remove(password.Length - 1, 1);
                Console.Write("\b \b");
            }
        }
        while (keyinfo.Key != ConsoleKey.Enter);

        Console.WriteLine();
        return password.ToString();
    }
}