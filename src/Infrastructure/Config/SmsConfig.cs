using System.Reflection;
using ApiTrottling.Application.Common.Interfaces;

namespace ApiTrottling.Infrastructure.Config;

public class SmsConfig : ISmsConfig
{
    private readonly IConfig _config;
    private readonly string _configParentKey = "SMS";

    public SmsConfig(IConfig config)
    {
        _config = config;
    }
    
    public string SmsMobilePhoneCountryCode()
    {
        return _config.GetConfigValue<string>($"{_configParentKey}:{MethodBase.GetCurrentMethod()!.Name}");
    }
}