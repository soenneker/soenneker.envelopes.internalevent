using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Soenneker.Envelopes.InternalEvent;

/// <summary>
/// A lightweight data transfer object used for transporting internal events between services.
/// Designed to be decoupled from specific domain models to support generic event handling.
/// </summary>
public sealed class InternalEventEnvelope
{
    /// <summary>
    /// A unique identifier for the event instance (typically a GUID).
    /// </summary>
    [JsonPropertyName("id")]
    [JsonProperty("id")]
    public string Id { get; set; } = null!;

    /// <summary>
    /// The type of event being transmitted.
    /// Consumers use this to deserialize the <see cref="Payload"/> appropriately.
    /// </summary>
    [JsonPropertyName("eventType")]
    [JsonProperty("eventType")]
    public string EventType { get; set; } = null!;

    /// <summary>
    /// A serialized JSON payload representing the event data.
    /// Must be deserialized based on the <see cref="EventType"/>.
    /// </summary>
    [JsonPropertyName("payload")]
    [JsonProperty("payload")]
    public string Payload { get; set; } = null!;

    /// <summary>
    /// The UTC timestamp indicating when the event was originally created or emitted.
    /// </summary>
    [JsonPropertyName("createdAt")]
    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// An identifier indicating which service or component emitted the event.
    /// </summary>
    [JsonPropertyName("source")]
    [JsonProperty("source")]
    public string Source { get; set; } = null!;

    /// <summary>
    /// The Source's id associated with the event, if applicable. May be null.
    /// </summary>
    [JsonPropertyName("sourceId")]
    [JsonProperty("sourceId")]
    public string? SourceId { get; set; }

    /// <summary>
    /// The user ID associated with the event, if applicable. May be null.
    /// </summary>
    [JsonPropertyName("userId")]
    [JsonProperty("userId")]
    public string? UserId { get; set; }
}