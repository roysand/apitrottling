using System.Text.Json;

namespace ApiTrottling.Domain.Exceptions;

public class MobilePhoneInvalidException : Exception
{
    public MobilePhoneInvalidException(string mobilePhone, string errorMessage)
        : base(JsonSerializer.Serialize(new MobilePhoneInvalidExceptionVm($"Mobile phone '{mobilePhone}' is invalid", errorMessage)))
    {
    }
}