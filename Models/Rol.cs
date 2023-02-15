using System.Text.Json.Serialization;

namespace HRSystem.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Rol
    {
        Rol = 0,
        Medewerker = 1,
        Manager = 2,
    }
}
