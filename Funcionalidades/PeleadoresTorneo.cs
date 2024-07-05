using System.Text.Json;
using AparicionesPuar;
using Personajes;
using Seleccion;

namespace LuchadoresTorneo
{
    public class Torneo
    {
        public static List<Personaje> ObtenerListaPeleadores()
        {
            /////Traigo las lista de personajes cargada del json
            string jsonData = File.ReadAllText("Json/Personajes.json");
            List<Personaje> personajes = JsonSerializer.Deserialize<List<Personaje>>(jsonData);

            ApPuar.AparicionParaElegirPersonaje();

            Personaje personajeSeleccionado = SeleccionUsuario.SeleccionPersonaje(personajes);

            ApPuar.ExplicacionEleccionOponentes();

            List<Personaje> listaPersonajesSeleccionados = SeleccionUsuario.ElegirModoYMostrarMenuContrincantes(personajes, personajeSeleccionado);

            //Agrego a la lista de peleadores obtenidos(manual o automaticamente) el personaje a usar por el usuario.
            List<Personaje> listaPersonajesTorneo = [];
            listaPersonajesTorneo.Add(personajeSeleccionado);
            foreach (var personaje in listaPersonajesSeleccionados)
            {
                listaPersonajesTorneo.Add(personaje);
            }

            return listaPersonajesTorneo;
        }
    }
}