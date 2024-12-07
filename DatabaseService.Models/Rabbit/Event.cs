using System.Text.Json.Serialization;

namespace DatabaseService.Models.Rabbit;

public class Event
{
    [JsonPropertyName("notification_id")]
    public required string NotificationId { get; set; }
    
    [JsonPropertyName("channel_type")]
    public required string ChannelType { get; set; }
    
    [JsonPropertyName("recipient")]
    public required string Recipient { get; set; }
    
    [JsonPropertyName("message_content")]
    public required MessageContent MessageContent { get; set; }
    
    [JsonPropertyName("created_at")]
    public required string CreatedAt { get; set; }
    
    [JsonPropertyName("metadata")]
    public Metadata? Metadata { get; set; }
    
    [JsonPropertyName("priority")]
    public string? Priority { get; set; }
    
    [JsonPropertyName("event_type")]
    public required string EventType { get; set; }
}