namespace Pogger;

public record struct LogEventArgs(MessageType Severity, string Message);
