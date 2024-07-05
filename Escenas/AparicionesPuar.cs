using Animaciones;
using Personajes;


namespace AparicionesPuar
{
    public class ApPuar
    {
        public static void AparicionParaElegirPersonaje()
        {
            int mensajeNumero = 0;

            List<string> mensajes = new List<string>();

            mensajes.Add("Muy bien, comencemos por elegir el personaje que usarás para los combates");
            mensajes.Add("Recuerda que al elegir un personaje, no podrás elegir otro.");

            for (int i = 0; i < mensajes.Count; i++)
            {
                mensajeNumero = MostrarMensajesPuar(mensajeNumero, mensajes);
            }
            Console.Clear();
        }

        public static void ExplicacionEleccionOponentes()
        {
            int mensajeNumero = 0;

            List<string> mensajes = new List<string>();

            mensajes.Add("Ahora tendrás que elegir cómo te gustaría que sea la selección de tus oponentes");
            mensajes.Add("Si eliges de manera aleatoria, se cargarán todos tus oponentes aleatoriamente y automáticamente");
            mensajes.Add("En cambio");
            mensajes.Add("Si eliges de manera manual, tendrás que elegir 15 oponentes que quieras que participen del torneo");
            mensajes.Add("Tú eliges...");

            for (int i = 0; i < mensajes.Count; i++)
            {
                mensajeNumero = MostrarMensajesPuar(mensajeNumero, mensajes);
            }
            Console.Clear();
        }

        public static void AparicionParaMostrarParticipantes(List<Personaje> lista)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            int mensajeNumero = 0;

            List<string> mensajes = new List<string>();

            mensajes.Add("Excelente, ya tenemos a los 16 participantes del Torneo.");
            mensajes.Add("Esta es la lista de participantes");

            for (int i = 0; i < mensajes.Count; i++)
            {
                mensajeNumero = MostrarMensajesPuar(mensajeNumero, mensajes);
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Lista de participantes");
                Console.WriteLine();
                int cont = 1;
                foreach (var participante in lista)
                {
                    Console.WriteLine(cont + ": " + participante.Datos.Nombre);
                    cont++;
                }
            }
            Thread.Sleep(4000);
            misAnimaciones.LimpiarBuffer();

        }

        public static void AparicionParaSorteo()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            int mensajeNumero = 0;
            List<string> mensajes = new List<string>();

            mensajes.Add("Ahora se hará el sorteo de los enfrentamientos");
            mensajes.Add("Espero que tengas buena suerte");
            mensajes.Add("...");
            mensajes.Add("Muy bien, estos son los enfrentamientos");

            for (int i = 0; i < mensajes.Count; i++)
            {
                mensajeNumero = MostrarMensajesPuar(mensajeNumero, mensajes);
            }
            Console.Clear();
        }

        public static void ExplicacionSobreCombates()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            int mensajeNumero = 0;
            List<string> mensajes = new List<string>();

            mensajes.Add("Los combates se realizarán de manera simultánea");
            mensajes.Add("Por lo tanto, no podrás observar a los demás pelear");
            mensajes.Add("...");
            mensajes.Add("Haré algo que no debería, pero Yamcha siempre me dice que debo ayudar a mis amigos");
            mensajes.Add("Así que te daré ataques y defensas especiales, pero no se lo digas a nadie");
            mensajes.Add("Lo que debes hacer es simple: responde bien las preguntas y obtendrás beneficios");
            mensajes.Add("Si atacas y respondes bien, tu ataque será potenciado; de lo contrario, no recibirás nada");
            mensajes.Add("Si te defiendes y respondes bien, obtendrás mayor resistencia. En caso de error, no recibirás nada");

            for (int i = 0; i < mensajes.Count; i++)
            {
                mensajeNumero = MostrarMensajesPuar(mensajeNumero, mensajes);
            }
            Console.Clear();
        }

        public static void AparicionCuandoPerdesCombate()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            int mensajeNumero = 0;
            List<string> mensajes = new List<string>();

            mensajes.Add("Vaya, perdiste...");
            mensajes.Add("No importa, lo importante es participar y divertirse");
            mensajes.Add("¡Te espero en el siguiente torneo!");

            for (int i = 0; i < mensajes.Count; i++)
            {
                mensajeNumero = MostrarMensajesPuar(mensajeNumero, mensajes);
            }
            Console.Clear();
        }

        public static void AparicionCuandoGanasCombate()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            int mensajeNumero = 0;
            List<string> mensajes = new List<string>();

            mensajes.Add("¡Felicidades, estuviste increíble!");
            mensajes.Add("Como premio por tu esfuerzo, recibiste un incremento en tus estadísticas");
            mensajes.Add("Aprovéchalas");

            for (int i = 0; i < mensajes.Count; i++)
            {
                mensajeNumero = MostrarMensajesPuar(mensajeNumero, mensajes);
            }
            Console.Clear();
        }


        public static void AparicionAlGanarTorneo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            int mensajeNumero = 0;
            List<string> mensajes = new List<string>();

            mensajes.Add("¡Felicidades, ganaste el Torneo!");
            mensajes.Add("Siempre confié en ti");
            mensajes.Add("Ahora formarás parte del salón de campeones");

            for (int i = 0; i < mensajes.Count; i++)
            {
                mensajeNumero = MostrarMensajesPuar(mensajeNumero, mensajes);
            }
            Console.Clear();
        }
        public static void AparicionCuandoNoQuiereJugar()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            int mensajeNumero = 0;
            List<string> mensajes = new List<string>();

            mensajes.Add("Aún no estás listo, por lo visto");
            mensajes.Add("Vuelve cuando estés preparado, estaré esperándote");

            for (int i = 0; i < mensajes.Count; i++)
            {
                mensajeNumero = MostrarMensajesPuar(mensajeNumero, mensajes);
            }
            Console.Clear();
        }

        public static void MostrarPuar()
        {

            Console.WriteLine("              ,$$.       ,$$.      ");
            Console.WriteLine("             ,$'$.       ,$'$.     ");
            Console.WriteLine("             $'  $      $'   $     ");
            Console.WriteLine("            :$    $;   :$    $;    ");
            Console.WriteLine("            $$    $$   $$    $$    ");
            Console.WriteLine("            $$  _.$bqgpd$._  $$    ");
            Console.WriteLine("            ;$gd$$^$$$$$^$$bg$:    ");
            Console.WriteLine("          .d$P^*'   \"*\"   *^T$b.  ");
            Console.WriteLine("         d$$$    ,*\"   \"*.    $$$b ");
            Console.WriteLine("        d$$$b._    o   o    _.d$$$b");
            Console.WriteLine("       *T$$$$$P             T$$$$$P*");
            Console.WriteLine("         ^T$$    :\"---\";    $$P^' ");
            Console.WriteLine("            $._     ---'   _.$'    ");
            Console.WriteLine("           .d$$P\"**-----**\"T$$b.   ");
            Console.WriteLine("          d$$P'             T$$b  ");
            Console.WriteLine("         d$$P                 T$$b ");
            Console.WriteLine("        d$P'.'               .T$b");
            Console.WriteLine("        --:                   ;--'");
            Console.WriteLine("           |                   |   ");
            Console.WriteLine("           :                   ;   ");
            Console.WriteLine("            \\                 /    ");
            Console.WriteLine("            .-.           .-'.    ");
            Console.WriteLine("           /   .\"*--+g+--*\".   \\   ");
            Console.WriteLine("          :   /     $$$     \\   ;  ");
            Console.WriteLine("           --'      $$$      '--  ");
            Console.WriteLine("                    :$$;           ");
            Console.WriteLine("                     :$$           ");
            Console.WriteLine("                     'T$bg+.____   ");
            Console.WriteLine("                       'T$$$$$  :  ");
            Console.WriteLine("                           \"**--'  ");

        }

        private static int MostrarMensajesPuar(int mensajeNumero, List<string> mensajes)
        {
            Console.Clear();
            Console.CursorVisible = false;

            // Muevo el cursor al principio de la consola
            Console.SetCursorPosition(0, 0);

            // Imprimo el ASCII de Puar
            MostrarPuar();

            // Imprimo el mensaje al costado
            Console.SetCursorPosition(40, 0);

            // Obtengo el tamaño de la ventana de la consola
            int windowHeight = Console.WindowHeight;

            // Si el mensajeNumero es mayor o igual que la cantidad de mensajes, termino la función
            if (mensajeNumero >= mensajes.Count)
            {
                return mensajeNumero;
            }

            // Cuento el número de líneas en el texto
            int textLineCount = mensajes[mensajeNumero].Split('\n').Length;

            // Calculo el número de líneas de relleno necesarias para centrar el texto
            int paddingLines = (windowHeight - textLineCount) / 2;

            // Imprimo líneas en blanco antes del texto para centrarlo verticalmente
            for (int j = 0; j < paddingLines - 5; j++)
            {
                Console.WriteLine();
            }

            Console.WriteLine("         ^T$$     :\"---\";    $$P^'      " + mensajes[mensajeNumero]);

            Console.SetCursorPosition(Console.WindowWidth - 40, Console.WindowHeight - 2);
            Console.WriteLine("Ingrese S si desea saltar la cinemática");

            // Limpiar el buffer antes de iniciar la espera de la tecla
            misAnimaciones.LimpiarBuffer();

            // Esto espera que se ingrese la tecla
            DateTime fin = DateTime.Now.AddSeconds(4);
            while (DateTime.Now < fin)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.S) // Si presiono 'S', avanzo rápidamente
                    {
                        mensajeNumero = mensajes.Count; // Salto al final de la lista de mensajes
                        break;
                    }
                    else
                    {
                        misAnimaciones.LimpiarBuffer(); // Limpiar el buffer si se presiona cualquier otra tecla
                    }
                }
                Thread.Sleep(100); // Hago una pequeña espera por el tema que no quiero sobreexigir al CPU
            }

            Console.Clear();

            // Llamo recursivamente para el siguiente mensaje
            return mensajeNumero + 1;
        }

    }
}
