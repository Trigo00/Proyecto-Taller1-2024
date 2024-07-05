using Animaciones;
using AparicionesPuar;
using Cruces;
using Historial;
using Info;
using LuchadoresTorneo;
using Personajes;

namespace MenuPrincipal
{
    public class Menu
    {
        public static void MostrarMenuPrincipal(List<HistorialGanadores> listado)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            string asciiArt = @"
    __  ___                     ____       _            _             __
   /  |/  /__  ____  __  __    / __ \_____(_)___  _____(_)___  ____ _/ /
  / /|_/ / _ \/ __ \/ / / /   / /_/ / ___/ / __ \/ ___/ / __ \/ __ / / 
 / /  / /  __/ / / / /_/ /   / ____/ /  / / / / / /__/ / /_/ / /_/ / /  
/_/  /_/\___/_/ /_/\__,_/   /_/   /_/  /_/_/ /_/\___/_/ .___/\__,_/_/   
                                                     /_/                 
";
            string[] opciones = {
                "Jugar",
                "Historial de Campeones",
                "Informacion de Jugadores",
                "Salir"
            };

            int seleccionIndex = 0;

            Console.CursorVisible = false;

            void DibujarMenu()
            {
                Console.Clear();

                int anchoConsola = Console.WindowWidth;

                // Divido el ASCII en líneas y las centro
                string[] asciiLineas = asciiArt.Split('\n');
                foreach (var linea in asciiLineas)
                {
                    int espaciosBlanco = (anchoConsola - linea.Length) / 2;
                    if (espaciosBlanco > 0)
                    {
                        Console.Write(new string(' ', espaciosBlanco));
                    }
                    // Imprimo cada caracter con color DarkYellow
                    ImprimoCaracteres(linea);
                    Console.WriteLine();
                }

                // Muestro las opciones
                for (int i = 0; i < opciones.Length; i++)
                {
                    int espaciosBlanco = (anchoConsola - opciones[i].Length) / 2;
                    if (espaciosBlanco > 0)
                    {
                        Console.Write(new string(' ', espaciosBlanco));
                    }

                    if (i == seleccionIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }

                    Console.WriteLine(opciones[i]);
                    Console.ResetColor(); // Restablezco los colores después de imprimir cada opción
                }
            }

            // Dibujo el menú inicial
            DibujarMenu();

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (seleccionIndex > 0) seleccionIndex--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (seleccionIndex < opciones.Length - 1) seleccionIndex++;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        // // Muestro el título antes de salir del método
                        // int anchoConsola = Console.WindowWidth;
                        // string[] asciiLineas = asciiArt.Split('\n');
                        // foreach (var linea in asciiLineas)
                        // {
                        //     int espaciosBlanco = (anchoConsola - linea.Length) / 2;
                        //     if (espaciosBlanco > 0)
                        //     {
                        //         Console.Write(new string(' ', espaciosBlanco));
                        //     }
                        //     ImprimoCaracteres(linea);
                        //     Console.WriteLine();
                        // }
                        // Console.WriteLine($"Seleccionaste: {opciones[seleccionIndex]}");
                        // Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        switch (seleccionIndex)
                        {
                            case 0:
                                // Lógica para "Comenzar a Jugar"
                                misAnimaciones.AnimacionCargaDeJuego();
                                Console.Clear();
                                List<Personaje> listaPersonajesTorneo = Torneo.ObtenerListaPeleadores();
                                ApPuar.AparicionParaMostrarParticipantes(listaPersonajesTorneo);
                                ApPuar.AparicionParaSorteo();
                                Peleas.MostrarCruces(listaPersonajesTorneo, listado);
                                break;
                            case 1:
                                // Lógica de "Historial de Campeones"
                                HistorialGanadores.MostrarListado(listado);
                                break;
                            case 2:
                                // Lógica para "Informacion de jugadores"
                                InfoPlayers.MostrarInformacionPersonajes(listado);
                                break;
                            case 3:
                                // Lógica para "Salir"
                                Console.WriteLine("Saliendo del programa...");
                                Thread.Sleep(3000); 
                                Console.Clear();
                                return;
                        }
                        return;
                }

                // Actualiza el menú
                DibujarMenu();
            }
        }

        private static void ImprimoCaracteres(string line)
        {
            foreach (char c in line)
            {
                if (c == ' ')
                {
                    Console.Write(' ');
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(c);
                }
            }
        }
    }
}
