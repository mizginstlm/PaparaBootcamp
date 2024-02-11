using System.Text.Json.Serialization;

namespace RentalHouseApi.Models;
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EApartmentType
{
    oneplusone = 1,
    twoplustwo = 2,
    threeplusthree = 3,
    fourplusfour = 4,
    studio = 5,

}