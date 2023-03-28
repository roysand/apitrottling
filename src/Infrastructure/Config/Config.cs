using ApiTrottling.Application.Common.Exceptions;
using ApiTrottling.Application.Common.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ApiTrottling.Infrastructure.Config;

public class Config : IConfig
{
    private readonly IConfiguration _configuration;
    public IApplicationSettingsConfig ApplicationSettingsConfig { get; }
    public ISmsConfig SmsConfig { get; }

    public Config(IConfiguration configuration)
    {
        _configuration = configuration;
        ApplicationSettingsConfig = new ApplicationSettingsConfig(this);
        SmsConfig = new SmsConfig(this);
    }
    public T GetConfigValue<T>(string configKey, bool mustExist = true)
    {
        try
        {
            T configValue = _configuration.GetValue<T>(configKey) ?? Activator.CreateInstance<T>();;
            if (EqualityComparer<T>.Default.Equals(configValue, default(T)))
            {
                throw new ConfigException($"Config value '{configKey}' is missing");    
            }

            return configValue ?? Activator.CreateInstance<T>();
        }
        catch (Exception)
        {
            throw new ConfigException($"Config value '{configKey}' is missing");
        }    }
}