namespace ApiTrottling.Application.Common.Exceptions;

public class InitializationBusyException : Exception
{
    public InitializationBusyException(string message)
        : base(message)

    {
    }
}