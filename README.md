[![](https://img.shields.io/nuget/v/soenneker.envelopes.internalevent.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.envelopes.internalevent/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.envelopes.internalevent/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.envelopes.internalevent/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.envelopes.internalevent.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.envelopes.internalevent/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.envelopes.internalevent/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.envelopes.internalevent/actions/workflows/codeql.yml)

# Soenneker.Envelopes.InternalEvent

A lightweight data transfer object used for transporting internal events between services. Designed to be decoupled from specific domain models to support generic event handling.

## Install

```bash
dotnet add package Soenneker.Envelopes.InternalEvent
```

## What you get

- `InternalEventEnvelope` — A lightweight data transfer object used for transporting internal events between services. Designed to be decoupled from specific domain models to support generic event handling.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `InternalEventEnvelope.Id` | A unique identifier for the event instance (typically a GUID). | A unique identifier for the event instance (typically a GUID). |
| `InternalEventEnvelope.EventType` | The type of event being transmitted. Consumers use this to deserialize the `Payload` appropriately. | The type of event being transmitted. Consumers use this to deserialize the `Payload` appropriately. |
| `InternalEventEnvelope.Payload` | A serialized JSON payload representing the event data. Must be deserialized based on the `EventType`. | A serialized JSON payload representing the event data. Must be deserialized based on the `EventType`. |
| `InternalEventEnvelope.CreatedAt` | The instance in time indicating when the event was originally created or emitted. | The instance in time indicating when the event was originally created or emitted. |
| `InternalEventEnvelope.Source` | The service or component that emitted the event, it's name and id (both/either may be null). | The service or component that emitted the event, it's name and id (both/either may be null). |
| `InternalEventEnvelope.UserId` | The user ID associated with the event, if applicable. May be null. | The user ID associated with the event, if applicable. May be null. |
