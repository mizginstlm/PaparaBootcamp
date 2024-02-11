using System.Text.Json.Serialization;
namespace RentalHouseApi.Models;
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EPaymentType
{
    CreditCard = 1,
    DebitCard = 2

}