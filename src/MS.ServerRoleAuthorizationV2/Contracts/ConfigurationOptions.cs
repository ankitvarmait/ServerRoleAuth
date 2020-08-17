namespace MS.ServerRoleAuthorization.Contracts
{
    public class ConfigurationOptions
    {
        public ConfigurationOptions(string configData)
        {
            this.ConfigData = configData;
        }

        public ConfigurationOptions WithIgnoreCaseMode(bool enableIgnoreCaseMode)
        {
            var option = Clone(this);
            option.EnableIgnoreCaseMode = enableIgnoreCaseMode;

            return option;
        }

        public string ConfigData { get; set; }
        public bool EnableIgnoreCaseMode { get; set; } = true;

        private ConfigurationOptions Clone(ConfigurationOptions source)
        {
            return new ConfigurationOptions(source.ConfigData)
            {
                EnableIgnoreCaseMode = source.EnableIgnoreCaseMode
            };
        }
    }
}