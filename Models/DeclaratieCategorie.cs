using System.Text.Json.Serialization;

namespace HRSystem.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DeclaratieCategorie
    {
        Uitgave_Declaratie = 1 ,
        Kilometer_Declaratie = 2 ,
        Vaste_Vergoeding = 3,

    }
}
