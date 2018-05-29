using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;

namespace NuGetPublishToolLib.ConfigurationData
{
    public class NuGetDataHandler : IConfigDataHandler
    {
        private readonly string sectionName = "NuGetData";

        public NuGetData GetData()
        {
            ConfigurationManager.RefreshSection(this.sectionName);
            Configuration config =
                    ConfigurationManager
                            .OpenExeConfiguration(ConfigurationUserLevel.None);
            NuGetData data = config.GetSection(this.sectionName) as NuGetData;
            if (data == null)
            {
                data = new NuGetData();
            }

            return data;
        }

        public string Save(ConfigurationSection data)
        {
            string isValid = this.IsValid(data);
            if (!string.IsNullOrEmpty(isValid))
            {
                return isValid;
            }

            this.FillMsNuGetConfig((NuGetData)data);
            ConfigurationManager.RefreshSection(this.sectionName);
            Configuration config =
                    ConfigurationManager
                            .OpenExeConfiguration(ConfigurationUserLevel.None);
            config.Sections.Add(this.sectionName, data);
            config.Save(ConfigurationSaveMode.Full);
            return string.Empty;
        }

        public string IsValid(ConfigurationSection data)
        {
            if (!data.GetType().Equals(typeof(NuGetData)))
            {
                return "数据类型不匹配";
            }

            NuGetData nuGetData = data as NuGetData;
            if (!File.Exists(nuGetData.ExePath))
            {
                return "文件路径不存在";
            }

            DirectoryInfo directory = new DirectoryInfo(nuGetData.ExePath);
            if (!directory.Name.ToLower().Equals("nuget.exe"))
            {
                return "该文件非nuget.exe";
            }

            return string.Empty;
        }

        private void FillMsNuGetConfig(NuGetData data)
        {
            string appdataPath =
                    Environment.GetFolderPath(Environment
                                                      .SpecialFolder
                                                      .ApplicationData);
            string msNuGetConfigPath =
                    Path.Combine(appdataPath, @"NuGet\NuGet.Config");
            if (!File.Exists(msNuGetConfigPath))
            {
                return;
            }

            Configuration msNuGetConfig =
                    ConfigurationManager
                            .OpenExeConfiguration(data.ExePath);
            data = data;
        }
    }
}
