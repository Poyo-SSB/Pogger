namespace Pogger;

public struct LogEventArgs
{
    public string Message;

    public LogEventArgs(string message)
    {
        this.Message = message;
    }
}
