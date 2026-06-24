namespace TimeTrackingApp.Services.Results;

public class ServiceResult
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;

    public ServiceResult() { }

    public ServiceResult(bool success, string message)
    {
        Success = success;
        Message = message;
    }
}
