namespace DatosApi
{
    public class PersonajeApi
    {
        public string Name { get; set; }
        public string Ki { get; set; }
        public string Race { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
    }

    public class ApiResponse
    {
        public List<PersonajeApi> Items { get; set; }
    }
}