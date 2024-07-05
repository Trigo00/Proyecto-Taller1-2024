using DatosApi;
using Personajes;

namespace FabricaPersonajes
{
    public class Fabrica
    {

        public static List<Personaje> CreacionPersonajes(List<Personaje> listaPersonajes, List<PersonajeApi> personajesApi)
        {

            foreach (var personaje in personajesApi)
            {
                Personaje nuevoPersonaje = CreacionPersonaje(personaje);
                listaPersonajes.Add(nuevoPersonaje);
            }
            return listaPersonajes;
        }

        private static Personaje CreacionPersonaje(PersonajeApi personaje)
        {
            Personaje nuevoPersonaje = new Personaje();

            AsignoDatos(personaje, nuevoPersonaje);
            AsignoCaracteristicas(nuevoPersonaje);

            return nuevoPersonaje;
        }

        private static void AsignoDatos(PersonajeApi personaje, Personaje nuevoPersonaje)
        {
            nuevoPersonaje.Datos.Nombre = personaje.Name;
            nuevoPersonaje.Datos.Raza = personaje.Race;

            switch (personaje.Gender)
            {
                case "Male":
                    nuevoPersonaje.Datos.Genero = "Masculino";
                    break;
                case "Female":
                    nuevoPersonaje.Datos.Genero = "Femenino";
                    break;
            }

            if (personaje.Ki == "unknown")
            {
                nuevoPersonaje.Datos.Ki = "Desconocido";
            }
            else
            {
                nuevoPersonaje.Datos.Ki = personaje.Ki;
            }

            nuevoPersonaje.Datos.Descripcion = personaje.Description;
        }

        private static void AsignoCaracteristicas(Personaje nuevoPersonaje)
        {
            nuevoPersonaje.Caracteristicas.Fuerza = random.Next(20, 71);
            nuevoPersonaje.Caracteristicas.Salud = 100;
            nuevoPersonaje.Caracteristicas.Velocidad = random.Next(20, 71);
            nuevoPersonaje.Caracteristicas.Agilidad = random.Next(20, 71);
            nuevoPersonaje.Caracteristicas.Resistencia = random.Next(20, 71);
            nuevoPersonaje.Caracteristicas.Energia = random.Next(20, 71);
        }

        private static Random random = new Random();

    }
}