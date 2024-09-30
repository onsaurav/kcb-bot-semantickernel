using KcbBotSemanticKernel.Bot.Models;
using Microsoft.Bot.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace KcbBotSemanticKernel.Bot.Helper
{
    public class ConfigHelper
    {
        private Config _config;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ConfigHelper> _logger;

        public ConfigHelper(IConfiguration configuration, ILogger<ConfigHelper> logger)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            try
            {
                LoadConfig();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initializing BotService.");
                throw;
            }
        }

        private void LoadConfig()
        {
            try
            {
                _config = new Config
                {
                    MicrosoftAppType = _configuration["MicrosoftAppType"],
                    MicrosoftAppId = _configuration["MicrosoftAppId"],
                    MicrosoftAppPassword = _configuration["MicrosoftAppPassword"],
                    MicrosoftAppTenantId = _configuration["MicrosoftAppTenantId"],
                    BaseUrl = _configuration["BaseUrl"],
                    ApiSettings = new ApiSettings
                    {
                        BaseUrl = _configuration["ApiSettings:BaseUrl"],
                        MessageEndpoing = _configuration["ApiSettings:MessageEndpoing"],
                        Key = _configuration["ApiSettings:Key"],
                        Token = _configuration["ApiSettings:Token"],
                        AuthType = _configuration["ApiSettings:AuthType"]
                    },
                    BotImage = new BotImage
                    {
                        WelcomeImageUrl = _configuration["BotImage:WelcomeImageUrl"]
                    }
                };

                ValidateConfig();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while loading configuration.");
                throw;
            }
        }

        private void ValidateConfig()
        {
            if (string.IsNullOrEmpty(_config.ApiSettings.BaseUrl))
            {
                throw new InvalidOperationException("API base url is invalid.");
            }
        }

        public Config GetConfig()
        {
            return _config;
        }

        public ApiSettings GetApiSettings()
        {
            return _config?.ApiSettings ?? new ApiSettings();
        }
    }
}
