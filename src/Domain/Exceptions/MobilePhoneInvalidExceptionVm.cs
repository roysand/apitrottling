namespace ApiTrottling.Domain.Exceptions;

public class MobilePhoneInvalidExceptionVm
{
    public string ErrorMessage { get; set; }
    public string Rule { get; set; }

    public MobilePhoneInvalidExceptionVm(string errorMessage, string rule)
    {
        ErrorMessage = errorMessage;
        Rule = rule;
    }
}