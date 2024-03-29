﻿namespace Pogger;

public static class LoggerManager
{
    public static MessageType Severity { get; set; } = MessageType.Info;

    public delegate void LogEventHandler(LogEventArgs e);
    public static event LogEventHandler? Logged;

    public static BaseLogger CreateLogger(string source, bool withLogs = true)
    {
        var newLogger = new BaseLogger(source);

        if (withLogs)
        {
            newLogger.InternalLogged += LoggerInternalLogged;
        }

        return newLogger;
    }

    private static void LoggerInternalLogged(LogEventArgs e)
    {
        if (!Directory.Exists("logs"))
        {
            Directory.CreateDirectory("logs");
        }

        string fileName = $"./logs/{DateTime.Now:yyyy-MM-dd}.log";

        if (e.Severity <= Severity)
        {
            File.AppendAllText(fileName, e.Message + "\n");

            Logged?.Invoke(new LogEventArgs(e.Severity, e.Message));
        }
    }
}
