using Animaciones;
using AparicionesPuar;
using ArmarJsonPjsConApi;
using Historial;
using Intro;
using MenuPrincipal;

namespace Presentacion
{
    public class Juego
    {

        public static async Task InicioJuego()
        {
            await CargadorDatos.CargarDatosApi();

            PresentacionJuego.Presentacion();

            List<HistorialGanadores> listado = HistorialGanadores.CargarHistorialDesdeArchivo();

            List<string> mensajes = new List<string>();

            mensajes.Add("Hola, mi nombre es Puar y yo sere tu guia durante esta experiencia");
            mensajes.Add("Este es un juego de rol basado en la serie Dragon Ball Z");
            mensajes.Add("La modalidad del mismo consiste en llevar a cabo el Gran Torneo de Artes Marciales");
            mensajes.Add("Donde habran un total de 16 participantes listos para luchar y poner a prueba sus habilidades");
            mensajes.Add("Estas listo para comenzar?");

            int mensajeNumero = 0;
            for (int i = 0; i < mensajes.Count; i++)
            {
                Console.Clear();

                Console.SetCursorPosition(0, 0);

                ApPuar.MostrarPuar();

                Console.SetCursorPosition(40, 0);

                int windowHeight = Console.WindowHeight;

                int textLineCount = mensajes[mensajeNumero].Split('\n').Length; // Split('\n') divide el mensaje en un array de cadenas, utilizando el carácter de nueva línea ('\n') como delimitador

                int paddingLines = (windowHeight - textLineCount) / 2;

                for (int j = 0; j < paddingLines - 5; j++)
                {
                    Console.WriteLine();
                }

                Console.WriteLine("         ^T$$     :\"---\";    $$P^'      " + mensajes[mensajeNumero]);

                // Cambio el mensaje después de un tiempo
                int cantidadTextos = mensajes.Count;
                if (i == cantidadTextos - 1)
                {
                    // Interacción con botones Sí y No
                    int seleccionIndex = 0;
                    string[] opciones = { "Si", "No" };

                    // Oculto el mouse
                    Console.CursorVisible = false;

                    // Posiciono el mouse antes de la línea de opciones
                    int leftMargin = 45;
                    int topMargin = Console.CursorTop + 2;

                    while (true)
                    {
                        Console.SetCursorPosition(0, topMargin - 1);
                        Console.WriteLine();
                        Console.SetCursorPosition(0, topMargin);

                        // Muestro las opciones
                        for (int k = 0; k < opciones.Length; k++)
                        {
                            Console.SetCursorPosition(leftMargin + (k * 10), topMargin);
                            if (k == seleccionIndex)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                            }
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write($"[{opciones[k]}]");
                            Console.ResetColor();
                        }

                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.LeftArrow:
                                if (seleccionIndex > 0) seleccionIndex--;
                                break;
                            case ConsoleKey.RightArrow:
                                if (seleccionIndex < opciones.Length - 1) seleccionIndex++;
                                break;
                            case ConsoleKey.Enter:
                                Console.Clear();
                                Console.CursorVisible = true;
                                if (opciones[seleccionIndex] == "Si")
                                {
                                    Menu.MostrarMenuPrincipal(listado);
                                }
                                else
                                {
                                    ApPuar.AparicionCuandoNoQuiereJugar();
                                    Console.Clear();
                                }
                                return;
                        }
                    }
                }
                else
                {
                    mensajeNumero = (mensajeNumero + 1) % mensajes.Count;
                    Thread.Sleep(4000);
                    misAnimaciones.LimpiarBuffer(); 
                }
            }
        }
    }
}