namespace Pogger;

public static class LoggerManager
{
    public static MessageType Severity { get; set; } = MessageType.Info;

    public delegate void LogEventHandler(LogEventArgs e);
    public static event LogEventHandler OnLog;

    public static BaseLogger CreateLogger(string source)
    {
        var newLogger = new BaseLogger(source);

        newLogger.OnInternalLog += LoggerInternalLogged;

        return newLogger;
    }

    private static void LoggerInternalLogged(LogEventArgs e)
    {
        if (!Directory.Exists("logs"))
        {
            Directory.CreateDirectory("logs");
        }

        string fileName = $"./logs/{DateTime.Now:dd-MM-yyyy}.log";

        if (e.Severity <= Severity)
        {
            File.AppendAllText(fileName, e.Message + "\n");

            OnLog?.Invoke(new LogEventArgs(e.Severity, e.Message));
        }
    }
}
