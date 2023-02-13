# Pogger

![Nuget](https://img.shields.io/nuget/v/Pogger)

Lightweight logging for personal projects.

## Installation

You're a capable-looking feller, aren't you? I trust you to figure it out.

## Usage

```cs
global using static Guobbers.Logger;

using Pogger;

namespace Guobbers;

internal static class Logger
{
    private static readonly BaseLogger logger = LoggerManager.CreateLogger("Guobbers");

    public static void Error(object message) => logger.Error(message);
    public static void Warn(object message) => logger.Warn(message);
    public static void Info(object message) => logger.Info(message);
    public static void Verbose(object message) => logger.Verbose(message);
    public static void Debug(object message) => logger.Debug(message);
}
```

Or install a competent logging library.

## Contributing

Pull requests are unwelcome.