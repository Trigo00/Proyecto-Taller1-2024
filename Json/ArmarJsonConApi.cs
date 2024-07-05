using System.Text.Json;
using DatosApi;
using FabricaPersonajes;
using Personajes;

namespace ArmarJsonPjsConApi
{
    public class CargadorDatos
    {
        public static async Task CargarDatosApi()
        {
            await CargarDatosPersonajesAsync();
        }

        private static async Task CargarDatosPersonajesAsync()
        {
            List<PersonajeApi> listaPersonajesApi = new List<PersonajeApi>();
            List<Personaje> listaPersonajes = new List<Personaje>();

            listaPersonajesApi = await TraerInformacionApi(listaPersonajesApi);
            listaPersonajes = Fabrica.CreacionPersonajes(listaPersonajes, listaPersonajesApi);

            // Guarda los personajes en un archivo JSON en el directorio "Json"
            GenerarJsonPersonajes(listaPersonajes, "Json/Personajes.json");
        }

        private static async Task<List<PersonajeApi>> TraerInformacionApi(List<PersonajeApi> listaPersonajes)
        {
            try
            {
                HttpClient client = new HttpClient();
                var url = "https://dragonball-api.com/api/characters?limit=58";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                // Deserializo la respuesta JSON en ApiResponse
                var apiResponse = JsonSerializer.Deserialize<ApiResponse>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (apiResponse != null && apiResponse.Items != null)
                {
                    foreach (var personaje in apiResponse.Items)
                    {
                        listaPersonajes.Add(personaje);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
                return null;
            }

            return listaPersonajes;
        }

        private static void GenerarJsonPersonajes(List<Personaje> misPersonajes, string nombreArchivo)
        {
            if (!File.Exists(nombreArchivo))
            {
                var opciones = new JsonSerializerOptions
                {
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping, //Para evitar los acentos
                    WriteIndented = true
                };

                // Convierto la lista de personajes a JSON
                string jsonString = JsonSerializer.Serialize(misPersonajes, opciones);

                // Guardo el JSON en el archivo
                File.WriteAllText(nombreArchivo, jsonString);
            }

        }
    }
}