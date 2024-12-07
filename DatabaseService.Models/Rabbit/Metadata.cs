using System.Text.Json.Serialization;

namespace DatabaseService.Models.Rabbit;

public class Metadata
{
    [JsonPropertyName("subject")]
    public string? Subject { get; set; }
        
    [JsonPropertyName("Body")]
    public required string Body { get; set; }
}