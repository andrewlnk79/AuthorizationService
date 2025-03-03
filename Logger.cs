namespace AuthorizationService;

public class Logger : Ilogger
{
    private readonly ReaderWriterLockSlim lock_ = new();

    public Logger()
    {
        logDirectory = AppDomain.CurrentDomain.BaseDirectory + @"/_logs/" + DateTime.Now.ToString("dd-MM-yy HH-mm-ss") +
                       @"/";

        if (!Directory.Exists(logDirectory))
            Directory.CreateDirectory(logDirectory);
    }

    private string logDirectory { get; }

    public void WriteEvent(string eventMessage)
    {
        lock_.EnterWriteLock();
        try
        {
            using (var writer = new StreamWriter(logDirectory + "events.txt", true))
            {
                writer.WriteLine(eventMessage);
            }
        }
        finally
        {
            lock_.ExitWriteLock();
        }
    }

    public void WriteError(string errorMessage)
    {
        lock_.EnterWriteLock();
        try
        {
            using (var writer = new StreamWriter("errors.txt", true))
            {
                writer.WriteLine(errorMessage);
            }
        }
        finally
        {
            lock_.ExitWriteLock();
        }
    }
}