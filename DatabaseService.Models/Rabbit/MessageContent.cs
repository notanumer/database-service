using System.Text.Json.Serialization;

namespace DatabaseService.Models.Rabbit;

public class MessageContent
{
    [JsonPropertyName("subject")]
    public string? Subject { get; set; }
        
    [JsonPropertyName("text")]
    public required string Text { get; set; }
}