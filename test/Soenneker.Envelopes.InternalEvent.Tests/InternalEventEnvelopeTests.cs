using Soenneker.Tests.Unit;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Soenneker.Envelopes.InternalEvent.Tests;

public sealed class InternalEventEnvelopeTests : UnitTest
{
    [Test]
    public async Task SystemTextJson_roundtrip_preserves_string_payload()
    {
        const string payload = "{\"id\":\"user-123\"}";
        var envelope = new InternalEventEnvelope
        {
            Id = "event-123",
            EventType = "user.created.v1",
            Payload = payload,
            CreatedAt = DateTimeOffset.Parse("2026-01-02T03:04:05+00:00")
        };

        string json = JsonSerializer.Serialize(envelope);
        using JsonDocument document = JsonDocument.Parse(json);
        InternalEventEnvelope? roundtrip = JsonSerializer.Deserialize<InternalEventEnvelope>(json);

        await Assert.That(document.RootElement.GetProperty("payload").ValueKind).IsEqualTo(JsonValueKind.String);
        await Assert.That(document.RootElement.GetProperty("payload").GetString()).IsEqualTo(payload);
        await Assert.That(roundtrip).IsNotNull();
        await Assert.That(roundtrip!.Payload).IsEqualTo(payload);
    }
}
