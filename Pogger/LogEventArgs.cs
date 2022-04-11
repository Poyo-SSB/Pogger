namespace Pogger;

public struct LogEventArgs
{
    public MessageType Severity;
    public string Message;

    public LogEventArgs(MessageType severity, string message)
    {
        this.Severity = severity;
        this.Message = message;
    }
}
