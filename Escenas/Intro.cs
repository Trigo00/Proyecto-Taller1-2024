using Animaciones;

namespace Intro
{
    public class PresentacionJuego
    {
        public static void Presentacion()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            MostrarLogo();
            MostrarMensajeParaAvanzar();

            // Espera que el usuario ingrese una tecla sin mostrarla en la consola
            misAnimaciones.LimpiarBuffer();
            Console.CursorVisible = false;
            Console.ReadKey(true);
            Console.Clear();
        }

        private static void MostrarMensajeParaAvanzar()
        {
            string frase = "Pulse una tecla para iniciar...";
    
            Console.WriteLine();
            Console.WriteLine(frase.PadLeft((Console.WindowWidth + frase.Length) / 2));
        }

        private static void MostrarLogo()
        {
            string[] logo =
                        {   "",
                "",
                " ___  ___    _   ___  ___  _  _ ___   _   _    _      ____",
                "|   \\| _ \\  /_\\ / __|/ _ \\| \\| | _ ) /_\\ | |  | |    |_  /",
                "| |) |   / / _ \\ (_ | (_) | .` | _ \\/ _ \\| |__| |__   / / ",
                "|___/|_|_\\/_/ \\_\\___|\\___/|_|\\_|___/_/ \\_\\____|____| /___|"
            };

            foreach (var linea in logo)
            {
                Console.WriteLine(linea.PadLeft((Console.WindowWidth + linea.Length) / 2));
            }
    
        }
    }
}
