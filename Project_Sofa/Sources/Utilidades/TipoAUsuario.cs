using System.Text.Json.Serialization;

namespace Project_Sofa.Sources.Utilidades
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TipoAUsuario {USUARIO, INSPETOR}
}
