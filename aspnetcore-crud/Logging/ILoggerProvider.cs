namespace aspnetcore_crud.Logging
{
    public interface ILoggerProvider : IDisposable
    {
        ILogger CreateLogger(string categoryName);
    }
}
