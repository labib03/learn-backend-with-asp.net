using System.Text.Json.Serialization;

namespace latihan.api;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Gender
{
    Male = 0,
    Female = 1
}
