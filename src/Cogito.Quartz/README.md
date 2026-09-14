# Cogito.Quartz

Shared [Quartz.NET](https://www.quartz-scheduler.net/) pieces for the Cogito family.

## Why

The scheduler integrations in this family need a common place to depend on Quartz without each of them
picking a container or a logging implementation. Take this for the shared types; take one of the
packages below for a working setup.

## Install

```shell
dotnet add package Cogito.Quartz
```

## See also

- `Cogito.Quartz.Autofac` — jobs resolved from an Autofac container.
- `Cogito.Quartz.Serilog` — jobs and triggers logged as structured data.
- `Cogito.Quartz.Serilog.Autofac` — both together.

## License

MIT.
