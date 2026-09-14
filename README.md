# Cogito.Quartz

[![Build](https://github.com/alethic/Cogito.Quartz/actions/workflows/Cogito.Quartz.yml/badge.svg)](https://github.com/alethic/Cogito.Quartz/actions/workflows/Cogito.Quartz.yml)

Quartz.NET jobs resolved from Autofac and logged to Serilog as structured data.

## Packages

**[Cogito.Quartz](https://www.nuget.org/packages/Cogito.Quartz)** — Shared [Quartz.NET](https://www.quartz-scheduler.net/) pieces for the Cogito family.

**[Cogito.Quartz.Autofac](https://www.nuget.org/packages/Cogito.Quartz.Autofac)** — Resolves Quartz jobs from an Autofac container.

**[Cogito.Quartz.Serilog](https://www.nuget.org/packages/Cogito.Quartz.Serilog)** — Logs Quartz jobs and triggers to Serilog as structured data.

**[Cogito.Quartz.Serilog.Autofac](https://www.nuget.org/packages/Cogito.Quartz.Serilog.Autofac)** — Registers the Quartz destructuring policies with the container's Serilog configuration.

Each package carries its own README with the detail; the links above go to nuget.org.

## Building

```shell
dotnet restore Cogito.Quartz.sln
dotnet msbuild -p:Configuration=Release Cogito.Quartz.dist.msbuildproj
```

Packages are staged into `dist/nuget` and test suites into `dist/tests`; run a suite with
`dotnet test -f <tfm> <path to its assembly>`.

## License

MIT — see [LICENSE](LICENSE).
