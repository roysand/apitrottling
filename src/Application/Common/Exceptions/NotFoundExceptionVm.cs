namespace ApiTrottling.Application.Common.Exceptions;

public class NotFoundExceptionVm
{
    public ExceptionEnums  ErrorId { get; set; }
    public string ErrorType { get; set; } = null!;
    public string ErrorMessage { get; set; } = null!;

    public NotFoundExceptionVm()
    {
        
    }

    public NotFoundExceptionVm(ExceptionEnums errorId, string errorType, string errorMessage)
    {
        ErrorId = errorId;
        ErrorType = errorType;
        ErrorMessage = errorMessage;
    }

    public NotFoundExceptionVm(ExceptionEnums errorId, string errorMessage)
    {
        ErrorId = errorId;
        ErrorType = errorId.ToString();
        ErrorMessage = errorMessage;
    }
}