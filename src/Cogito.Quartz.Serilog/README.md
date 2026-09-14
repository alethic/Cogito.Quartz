# Cogito.Quartz.Serilog

Logs Quartz jobs and triggers to Serilog as structured data.

## Why

Logging a `IJobDetail` or `ITrigger` directly gives you its `ToString()` — one opaque line. What you
want in Seq or any structured sink is the job key, the group, the trigger's schedule and its next
fire time as separate properties you can filter on.

## Install

```shell
dotnet add package Cogito.Quartz.Serilog
```

## Use

Register the destructuring policies on your logger configuration, then log the objects themselves:

```csharp
logger.Information("Firing {@Job} on {@Trigger}", context.JobDetail, context.Trigger);
```

`JobDetailDestructuringPolicy` and `TriggerDestructuringPolicy` expand them into their meaningful
properties.

## License

MIT.
