# Cogito.Quartz.Serilog.Autofac

Registers the Quartz destructuring policies with the container's Serilog configuration.

## Install

```shell
dotnet add package Cogito.Quartz.Serilog.Autofac
```

## Use

```csharp
builder.RegisterAllAssemblyModules();
```

The job and trigger destructuring policies are contributed to the logger built by
`Cogito.Serilog.Autofac`, so logging a `IJobDetail` or `ITrigger` produces structured output with no
further configuration.

## License

MIT.
