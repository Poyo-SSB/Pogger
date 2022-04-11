namespace Pogger;

internal struct InternalLogEventArgs
{
    public MessageType Severity;
    public string Message;

    public InternalLogEventArgs(MessageType severity, string message)
    {
        this.Severity = severity;
        this.Message = message;
    }
}
