using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Soenneker.Dtos.IdNamePairs.Partial;

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
    /// The instance in time indicating when the event was originally created or emitted.
    /// </summary>
    [JsonPropertyName("createdAt")]
    [JsonProperty("createdAt")]
    public DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    /// The service or component that emitted the event, it's name and id (both/either may be null)
    /// </summary>
    [JsonPropertyName("source")]
    [JsonProperty("source")]
    public PartialIdNamePair? Source { get; set; }

    /// <summary>
    /// The user ID associated with the event, if applicable. May be null.
    /// </summary>
    [JsonPropertyName("userId")]
    [JsonProperty("userId")]
    public string? UserId { get; set; }
}