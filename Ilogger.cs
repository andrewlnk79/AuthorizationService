namespace AuthorizationService;

public interface Ilogger
{
    void WriteEvent(string eventMessage);


    void WriteError(string errorMessage);
}