using System.Text.Json.Serialization;

namespace HRSystem.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Team
    {
        Team = 0,
        Frontend = 1,
        Backend = 2,
    }
}
