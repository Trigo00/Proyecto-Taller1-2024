using System.Text.Json;
using Animaciones;
using Historial;
using MenuPrincipal;
using Personajes;

namespace Info
{
    public class InfoPlayers
    {
        public static void MostrarInformacionPersonajes(List<HistorialGanadores> listado)
        {
            string jsonData = File.ReadAllText("Json/Personajes.json");
            List<Personaje> personajes = JsonSerializer.Deserialize<List<Personaje>>(jsonData);

            Console.WriteLine("INFORMACION DE PERSONAJES");
            Console.WriteLine();

            foreach (var personaje in personajes)
            {
                MostrarInformacionPersonaje(personaje);
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            string frase = "Pulse una tecla regresar al menu...";
            Console.WriteLine(frase);
            Console.CursorVisible = false;
            Console.ReadKey(true);
            Console.Clear();
            misAnimaciones.LimpiarBuffer();
            Menu.MostrarMenuPrincipal(listado);
        }

        private static void MostrarInformacionPersonaje(Personaje pj)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Datos Personales");
            Console.ResetColor();
            Console.WriteLine($"Nombre: {pj.Datos.Nombre}");
            Console.WriteLine($"Raza: {pj.Datos.Raza}");
            Console.WriteLine($"Genero: {pj.Datos.Genero}");
            Console.WriteLine($"Ki: {pj.Datos.Ki}");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Estadisticas de Pelea");
            Console.ResetColor();
            Console.WriteLine($"Fuerza: {pj.Caracteristicas.Fuerza}");
            Console.WriteLine($"Velocidad: {pj.Caracteristicas.Velocidad}");
            Console.WriteLine($"Agilidad: {pj.Caracteristicas.Agilidad}");
            Console.WriteLine($"Resistencia: {pj.Caracteristicas.Resistencia}");
            Console.WriteLine($"Energia: {pj.Caracteristicas.Energia}");

        }
    }
}
