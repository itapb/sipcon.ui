namespace Sipcon.WebApp
{
    public static class AppSettingsHelper 
    {
        private static IConfiguration? config;
        public static void AppSettingsConfigure(IConfiguration configuration)
        {
            config = configuration ?? throw new ArgumentNullException(nameof(configuration), "Configuration cannot be null.");
        }
        public static string GetConnectionString(string name)
        {
            return config?.GetConnectionString(name) ?? throw new InvalidOperationException($"Connection string '{name}' not found.");
        }
        public static string GetAppSetting(string key)
        {
            return config?[key] ?? throw new InvalidOperationException($"App setting '{key}' not found.");
        }
        public static T GetSection<T>(string sectionName) where T : class, new()
        {
            var section = config?.GetSection(sectionName);
            if (section == null)
            {
                throw new InvalidOperationException($"Configuration section '{sectionName}' not found.");
            }
            return section.Get<T>() ?? new T();
        }
    }
}
