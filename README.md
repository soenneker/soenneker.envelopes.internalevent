[![](https://img.shields.io/nuget/v/soenneker.envelopes.internalevent.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.envelopes.internalevent/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.envelopes.internalevent/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.envelopes.internalevent/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.envelopes.internalevent.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.envelopes.internalevent/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.envelopes.internalevent/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.envelopes.internalevent/actions/workflows/codeql.yml)

# Soenneker.Envelopes.InternalEvent

A serializer-neutral envelope for carrying an internal event identifier, type, JSON payload, creation time, and optional source/user metadata.

## Install

```bash
dotnet add package Soenneker.Envelopes.InternalEvent
```

## Create an envelope

`Payload` is a JSON string, not an embedded JSON object. Serialize the event body before assigning it:

```csharp
using System.Text.Json;
using Soenneker.Envelopes.InternalEvent;

var body = new UserCreated("user-123", "user@example.com");

var envelope = new InternalEventEnvelope
{
    Id = Guid.NewGuid().ToString("D"),
    EventType = "user.created.v1",
    Payload = JsonSerializer.Serialize(body),
    CreatedAt = DateTimeOffset.UtcNow,
    UserId = body.Id
};

string message = JsonSerializer.Serialize(envelope);

public sealed record UserCreated(string Id, string Email);
```

The envelope uses the same camel-case property names with both `System.Text.Json` and Newtonsoft.Json: `id`, `eventType`, `payload`, `createdAt`, `source`, and `userId`. Because `payload` is a string, serializing the envelope escapes the inner JSON. Consumers deserialize the envelope first and then deserialize `Payload` into the type selected by `EventType`.

## Consume safely

Treat `EventType` as an untrusted discriminator and map it through an explicit allowlist:

```csharp
InternalEventEnvelope envelope =
    JsonSerializer.Deserialize<InternalEventEnvelope>(message)!;

switch (envelope.EventType)
{
    case "user.created.v1":
        UserCreated created = JsonSerializer.Deserialize<UserCreated>(envelope.Payload)!;
        await Handle(created);
        break;

    default:
        throw new NotSupportedException($"Unsupported event type: {envelope.EventType}");
}
```

Do not resolve arbitrary CLR types from `EventType` or enable unsafe polymorphic deserialization for received data. Apply payload size limits before deserialization and validate the resulting event model.

`Id`, `EventType`, `Payload`, and `CreatedAt` are required when constructing the envelope. The class does not generate IDs, enforce uniqueness, validate JSON, authenticate a source, sign content, deduplicate deliveries, or provide ordering/retry behavior. Use `Id` as an idempotency key only when the producer guarantees its uniqueness, and interpret `CreatedAt` as producer-supplied metadata rather than a trusted receipt time.
