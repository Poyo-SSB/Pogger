namespace Pogger;

public static class LoggerManager
{
    public static MessageType Severity { get; set; } = MessageType.Info;

    public static BaseLogger CreateLogger(string source)
    {
        var newLogger = new BaseLogger(source);

        newLogger.OnLog += Write;

        return newLogger;
    }

    private static void Write(LogEventArgs e)
    {
        if (!Directory.Exists("logs"))
        {
            Directory.CreateDirectory("logs");
        }

        string fileName = $"./logs/{DateTime.Now:dd-MM-yyyy}.log";

        if (e.Severity <= Severity)
        {
            File.AppendAllText(fileName, e.Message + "\n");
        }
    }
}