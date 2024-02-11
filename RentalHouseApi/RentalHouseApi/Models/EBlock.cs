using System.Text.Json.Serialization;

namespace RentalHouseApi.Models;
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EBlock
{
    A = 1,
    B = 2,
    C = 3,
    D = 4,
    E = 5,
}
