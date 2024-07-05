namespace Animaciones
{
    public class misAnimaciones
    {

        public static void AnimacionCargaDeJuego()
        {
            MostrarMensajeConCarga("Cargando...");
        }

        public static void AnimacionCargaDePelea()
        {
            MostrarMensajeConCarga("Preparando el combate...");
        }

        public static void AnimacionRegresarAMenu()
        {
            Console.Clear();
            MostrarMensajeConCarga("Regresando al Menu Principal...");
        }
        
        public static void AnimacionDeCargaHistorial()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write("\rCargando " + new string('-', i % 4) + new string(' ', 3 - (i % 4)));
                Thread.Sleep(100);
            }
        }

        public static void ContadorPelea()
        {
            for (int i = 3; i > 0; i--)
            {
                Console.Clear();
                Console.WriteLine($"La pelea comienza en {i}");
                Thread.Sleep(1000);
            }

            Console.Clear();
            Console.WriteLine("¡La pelea ha comenzado!");
            LimpiarBuffer(); 

        }

        public static void LimpiarBuffer()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }

        private static void MostrarMensajeConCarga(string mensaje)
        {
            Console.WriteLine(mensaje);
            AnimacionDeCarga();
        }

        private static void AnimacionDeCarga()
        {
            int total = 50;
            Thread.Sleep(1000);
            for (int i = 0; i <= total; i++)
            {
                Console.Write("\r");
                Console.Write(new string('█', i));
                Console.Write(new string('░', total - i));
                Console.Write($" {i * 2}%");
                Thread.Sleep(50); // Pausa de 50ms entre cada incremento
            }
        }

    }
}