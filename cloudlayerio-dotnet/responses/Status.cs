using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace cloudlayerio_dotnet.responses;

[JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
public enum StatusEnum
{
    [EnumMember(Value = "pending")]
    Pending,
    
    [EnumMember(Value = "success")]
    Success,
    
    [EnumMember(Value = "error")]
    Error    
    
}