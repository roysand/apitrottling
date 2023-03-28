namespace ApiTrottling.Application.Common.Interfaces;

public interface IConfig
{
    IApplicationSettingsConfig ApplicationSettingsConfig { get;  }
    ISmsConfig SmsConfig { get; }
    T GetConfigValue<T>(string configKey, bool mustExist = true);
}