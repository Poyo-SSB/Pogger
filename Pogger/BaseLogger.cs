namespace Pogger;

public class BaseLogger
{
    private readonly string source;

    internal delegate void InternalLogEventHandler(LogEventArgs e);
    internal event InternalLogEventHandler? InternalLogged;

    internal BaseLogger(string source) => this.source = source;

    private readonly object logLock = new();

    public void Log(object message, MessageType severity)
    {
        lock (this.logLock)
        {
            string label = String.Empty;
            string time = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            switch (severity)
            {
                case MessageType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    label = "ERRR";
                    break;
                case MessageType.Warn:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    label = "WARN";
                    break;
                case MessageType.Info:
                    Console.ForegroundColor = ConsoleColor.Green;
                    label = "INFO";
                    break;
                case MessageType.Verbose:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    label = "VERB";
                    break;
                case MessageType.Debug:
                    Console.ForegroundColor = ConsoleColor.White;
                    label = "DEBG";
                    break;
            }

            var output = severity == MessageType.Error ? Console.Error : Console.Out;

            var header = $"[{label} {time} ({this.source})]";

            output.Write($"{header} ");
            Console.ResetColor();

            output.WriteLine(message);

            this.InternalLogged?.Invoke(new LogEventArgs(severity, $"{header} {message}"));
        }
    }

    public void Error(object message) => this.Log(message, MessageType.Error);
    public void Warn(object message) => this.Log(message, MessageType.Warn);
    public void Info(object message) => this.Log(message, MessageType.Info);
    public void Verbose(object message) => this.Log(message, MessageType.Verbose);
    public void Debug(object message) => this.Log(message, MessageType.Debug);
}
