using System.Text.Json.Serialization;

namespace RentalHouseApi.Models
{

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum InvoiceType
    {
        Electricity = 1,
        Water = 2,
        NaturalGas = 3,

    }
}