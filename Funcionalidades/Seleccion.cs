using Personajes;

namespace Seleccion
{
    public class SeleccionUsuario
    {
        public static Personaje SeleccionPersonaje(List<Personaje> listaPersonajes)
        {
            if (listaPersonajes == null || listaPersonajes.Count == 0)
            {
                Console.WriteLine("No hay personajes disponibles.");
                return null;
            }

            int columnas = 3;
            int filas = (int)Math.Ceiling(listaPersonajes.Count / (double)columnas); //Math.Ceiling: Devuelve el valor integral más pequeño que es mayor o igual que el número decimal especificado.

            // Calculo el ancho de cada columna
            int maxNombreLength = listaPersonajes.Max(p => p.Datos.Nombre.Length);
            int columnWidth = maxNombreLength + 5; 

            int seleccionIndex = 0;

            Console.CursorVisible = false;
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Seleccione un personaje de la lista:");
                Console.WriteLine();

                // Muestro los personajes en columnas
                for (int fila = 0; fila < filas; fila++)
                {
                    for (int col = 0; col < columnas; col++)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        int index = fila * columnas + col;
                        if (index < listaPersonajes.Count)
                        {
                            string item = $"{listaPersonajes[index].Datos.Nombre}";
                            if (index == seleccionIndex)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                            }
                            Console.Write(item.PadRight(columnWidth));
                            Console.ResetColor();
                        }
                    }
                    Console.WriteLine();
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (seleccionIndex - columnas >= 0) seleccionIndex -= columnas;
                        break;
                    case ConsoleKey.DownArrow:
                        if (seleccionIndex + columnas < listaPersonajes.Count) seleccionIndex += columnas;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (seleccionIndex > 0) seleccionIndex--;
                        break;
                    case ConsoleKey.RightArrow:
                        if (seleccionIndex < listaPersonajes.Count - 1) seleccionIndex++;
                        break;
                    case ConsoleKey.Enter:
                        Personaje seleccionado = listaPersonajes[seleccionIndex];
                        Console.WriteLine($"\nHas seleccionado a {seleccionado.Datos.Nombre}.");
                        Console.CursorVisible = true;
                        Console.WriteLine("Presiona cualquier tecla para continuar...");
                        Console.ReadKey(true);
                        Console.CursorVisible = false;

                        return seleccionado;
                }
            }
        }

        public static List<Personaje> ElegirModoYMostrarMenuContrincantes(List<Personaje> listaPersonajes, Personaje personajePrincipal)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Selecciona cómo quieres elegir los contrincantes:");

            int seleccionIndex = 0;
            string[] opciones = {
                "Seleccionar contrincantes aleatoriamente",
                "Seleccionar contrincantes manualmente"
            };

            // Oculto el mouse
            Console.CursorVisible = false;

            while (true)
            {
                Console.Clear();

                // Muestro las opciones
                for (int i = 0; i < opciones.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    if (i == seleccionIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    Console.WriteLine(opciones[i]);
                    Console.ResetColor();
                }

                Console.WriteLine();

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
                        // Muestro el mouse nuevamente antes de salir del método
                        Console.CursorVisible = true;
                        switch (seleccionIndex)
                        {
                            case 0:
                                List<Personaje> contrincantesAleatorios = SeleccionarContrincantesAleatoriamente(listaPersonajes, personajePrincipal);
                                Console.Clear();
                                return contrincantesAleatorios;
                            case 1:
                                List<Personaje> contrincantesSeleccionados = SeleccionarContrincantesManualmente(listaPersonajes, personajePrincipal);
                                Console.Clear();
                                return contrincantesSeleccionados;
                        }
                        return null;
                }
            }
        }


        private static List<Personaje> SeleccionarContrincantesAleatoriamente(List<Personaje> listaPersonajes, Personaje personajePrincipal)
        {
            Random random = new Random();
            List<Personaje> contrincantes = listaPersonajes.Where(p => p != personajePrincipal).OrderBy(p => random.Next()).Take(15).ToList();
            //.Where(p => p != personajePrincipal): crea una colección de personajes que contiene todos los elementos de listaPersonajes excepto aquel que es igual a personajePrincipal
            //.OrderBy(p => random.Next()): ordena la colección resultante del filtro anterior en un orden aleatorio
            //.Take(15): selecciona los primeros 15 elementos de la colección ordenada aleatoriamente.
            //.ToList(): convierte la colección de los 15 personajes seleccionados en una lista de tipo List<Personaje>.

            return contrincantes;
        }

        private static List<Personaje> SeleccionarContrincantesManualmente(List<Personaje> listaPersonajes, Personaje personajePrincipal)
        {
            List<Personaje> seleccionados = new List<Personaje>();
            List<Personaje> disponibles = listaPersonajes.Where(p => p != personajePrincipal).ToList();
            int seleccionadosCount = 0;
            int seleccionIndex = 0;
            int columnas = 3; 
            int maxNombreLength = disponibles.Max(p => p.Datos.Nombre.Length); //Busco el nombre que mas espacio usa
            int columnWidth = maxNombreLength + 5; // Ajusto el espacio entre columnas
            int filas = (int)Math.Ceiling(disponibles.Count / (double)columnas); //calculo cuántas filas son necesarias para organizar los elementos de disponibles en una cuadrícula con un número específico de columnas, redondeando hacia arriba para asegurarse de que todos los elementos entren en la cuadrícula.
            ConsoleKeyInfo keyInfo; //ConsoleKeyInfo es una estructura que representa la tecla presionada por el usuario y contiene información sobre la tecla y el modificador de tecla (como Shift, Ctrl o Alt) que se utilizaron al presionar la tecla.

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Seleccione 15 contrincantes (presione Enter para seleccionar):");

            // Muestro los personajes disponibles inicialmente
            MostrarPersonajesDisponibles(disponibles, seleccionIndex);

            while (seleccionadosCount < 15)
            {
                Console.CursorVisible = false;
                keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Enter:
                        if (disponibles.Count > seleccionIndex)
                        {
                            Personaje seleccionado = disponibles[seleccionIndex];
                            seleccionados.Add(seleccionado);
                            disponibles.RemoveAt(seleccionIndex);
                            seleccionadosCount++;
                            if (seleccionIndex >= disponibles.Count && disponibles.Count > 0)
                            {
                                seleccionIndex = disponibles.Count - 1;
                            }

                            // Muestro los personajes disponibles actualizados después de la selección
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Seleccione 15 contrincantes (presione Enter para seleccionar):");
                            MostrarPersonajesDisponibles(disponibles, seleccionIndex);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (seleccionIndex - columnas >= 0)
                        {
                            seleccionIndex -= columnas;
                            MostrarPersonajesDisponibles(disponibles, seleccionIndex);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (seleccionIndex + columnas < disponibles.Count)
                        {
                            seleccionIndex += columnas;
                            MostrarPersonajesDisponibles(disponibles, seleccionIndex);
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (seleccionIndex > 0)
                        {
                            seleccionIndex--;
                            MostrarPersonajesDisponibles(disponibles, seleccionIndex);
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (seleccionIndex < disponibles.Count - 1)
                        {
                            seleccionIndex++;
                            MostrarPersonajesDisponibles(disponibles, seleccionIndex);
                        }
                        break;
                }
            }

            return seleccionados;
        }

        private static void MostrarPersonajesDisponibles(List<Personaje> disponibles, int seleccionIndex)
        {
            Console.SetCursorPosition(0, 3); // Posiciono el mouse debajo del título

            int columnas = 3; 
            int filas = (int)Math.Ceiling(disponibles.Count / (double)columnas);

            // Calculo el ancho de cada columna
            int maxNombreLength = disponibles.Max(p => p.Datos.Nombre.Length);
            int columnWidth = maxNombreLength + 5; // Ajusto el espacio entre columnas

            // Muestro los personajes en columnas
            for (int fila = 0; fila < filas; fila++)
            {
                for (int col = 0; col < columnas; col++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    int index = fila * columnas + col;
                    if (index < disponibles.Count)
                    {
                        string item = $"{disponibles[index].Datos.Nombre}";
                        if (index == seleccionIndex)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                        }
                        Console.Write(item.PadRight(columnWidth));
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }
        }
    }
}