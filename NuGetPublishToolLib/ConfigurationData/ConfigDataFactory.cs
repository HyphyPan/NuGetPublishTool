using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.IO;
using System.Text;

namespace NuGetPublishToolLib.ConfigurationData
{
    public class ConfigDataFactory
    {
        public AppConfigData GetData<T>() where T : AppConfigData
        {
            ConfigurationManager.RefreshSection(typeof(T).Name);
            Configuration config =
                ConfigurationManager
                    .OpenExeConfiguration(ConfigurationUserLevel.None);
            AppConfigData data = config.GetSection(typeof(T).Name) as AppConfigData;
            return data;
        }

        public string Save(AppConfigData data)
        {
            string isValid = data.CheckValid();
            if (!string.IsNullOrEmpty(isValid))
            {
                return isValid;
            }

            ConfigurationManager.RefreshSection(data.GetType().Name);
            Configuration config =
                ConfigurationManager
                    .OpenExeConfiguration(ConfigurationUserLevel.None);
            AppConfigData section = config.Sections[data.GetType().Name] as AppConfigData;
            if (section == null)
            {
                config.Sections.Add(data.GetType().Name, data);
            }
            else
            {
                section.CopyFrom(data);
            }

            config.Save(ConfigurationSaveMode.Minimal);
            return string.Empty;
        }
    }
}
