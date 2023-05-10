namespace aspnetcore_crud.Logging
{
    public interface ILoggerFactory : IDisposable
    {
        ILogger CreateLogger(string categoryName);
        void AddProvider(ILoggerProvider provider);
    }
}
