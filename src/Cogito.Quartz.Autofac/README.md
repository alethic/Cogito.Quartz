# Cogito.Quartz.Autofac

Resolves Quartz jobs from an Autofac container.

## Why

Quartz constructs job instances itself, so a job cannot take constructor dependencies. Without a job
factory backed by the container, jobs end up reaching for a static locator — which is the thing the
container was meant to remove.

## Install

```shell
dotnet add package Cogito.Quartz.Autofac
```

## Use

```csharp
builder.RegisterAllAssemblyModules();
```

Jobs are then resolved from the container, each in its own lifetime scope, so a job can depend on
scoped services and they are disposed when it finishes:

```csharp
public class ImportJob : IJob
{
    public ImportJob(IOrderRepository orders) { ... }

    public Task Execute(IJobExecutionContext context) => ...;
}
```

## License

MIT.
