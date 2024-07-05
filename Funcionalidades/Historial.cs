using System.Text.Json;
using Animaciones;
using MenuPrincipal;
using Personajes;

namespace Historial
{
    public class HistorialGanadores
    {
        public Personaje Ganador { get; set; }
        public DateTime Hora { get; set; }

        private static string nombreArchivo = "Json/Historial.json";

        public static void CargarHistorial(Personaje PersonajeGanador, List<HistorialGanadores> listaHistorial)
        {
            DateTime horaActual = DateTime.Now;
            HistorialGanadores datos = new HistorialGanadores(PersonajeGanador, horaActual);
            listaHistorial.Add(datos);
            GuardarHistorial(listaHistorial);
        }

        public static void MostrarListado(List<HistorialGanadores> listado)
        {
            Console.WriteLine("GANADORES DEL TORNEO");
            Console.WriteLine();
            if (listado.Count == 0)
            {
                Console.WriteLine("No existen ganadores del torneo");
            }
            else
            {
                foreach (var ganador in listado)
                {
                    Animaciones.misAnimaciones.AnimacionDeCargaHistorial();
                    Console.WriteLine("\r" + ganador.Hora + ": " + ganador.Ganador.Datos.Nombre);
                }
            }

            Console.WriteLine();
            misAnimaciones.LimpiarBuffer();
            string frase = "Pulse una tecla regresar al menu...";
            Console.WriteLine(frase);
            Console.CursorVisible = false;
            Console.ReadKey(true);
            misAnimaciones.LimpiarBuffer();
            Menu.MostrarMenuPrincipal(listado);
        }

        public static List<HistorialGanadores> CargarHistorialDesdeArchivo()
        {
            if (!File.Exists(nombreArchivo))
            {
                return new List<HistorialGanadores>();
            }

            string json = File.ReadAllText(nombreArchivo);
            return JsonSerializer.Deserialize<List<HistorialGanadores>>(json);
        }

        private static void GuardarHistorial(List<HistorialGanadores> listaHistorial)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(listaHistorial, options);
            File.WriteAllText(nombreArchivo, json);
        }

        // Constructor
        public HistorialGanadores(Personaje ganador, DateTime hora)
        {
            Ganador = ganador;
            Hora = hora;
        }

        // public HistorialGanadores()
        // {
        // }
    }
}
