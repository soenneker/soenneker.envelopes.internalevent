using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Soenneker.Envelopes.InternalEvent;

/// <summary>
/// A DTO for internal event packaging with minimal coupling
/// </summary>
public sealed class InternalEventEnvelope
{
    [JsonPropertyName("eventType")]
    [JsonProperty("eventType")]
    public string EventType { get; set; } = null!;

    [JsonPropertyName("payload")]
    [JsonProperty("payload")]
    public string Payload { get; set; } = null!;

    [JsonPropertyName("createdAt")]
    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("source")]
    [JsonProperty("source")]
    public string Source { get; set; } = null!;
}
