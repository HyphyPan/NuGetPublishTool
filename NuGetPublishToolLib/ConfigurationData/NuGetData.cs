using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;

namespace NuGetPublishToolLib.ConfigurationData
{
    public class NuGetData : AppConfigData
    {
        [ConfigurationProperty("ExePath")]
        public string ExePath
        {
            get
            {
                return (string)base["ExePath"];
            }
            set
            {
                base["ExePath"] = value;
                string validInfo = this.CheckValid();
                if (string.IsNullOrEmpty(validInfo))
                {
                    this.FillOuterData();
                }
                else
                {
                    throw new Exception(validInfo);
                }
            }
        }

        [ConfigurationProperty("", IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(NuGetSourceInfo),
            CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap,
            RemoveItemName = "remove", AddItemName = "PackageSource")]
        public NuGetSourceConllection PackageSources
        {
            get
            {
                return (NuGetSourceConllection)this[""];
            }
            internal set
            {
                this[""] = value;
            }
        }

        public override string CheckValid()
        {
            if (!File.Exists(this.ExePath))
            {
                return "文件路径不存在";
            }

            DirectoryInfo directory = new DirectoryInfo(this.ExePath);
            if (!directory.Name.ToLower().Equals("nuget.exe"))
            {
                return "该文件非nuget.exe";
            }

            return string.Empty;
        }

        public override void CopyFrom(AppConfigData sourceData)
        {
            NuGetData data = sourceData as NuGetData;
            this.ExePath = data.ExePath;
            this.PackageSources = data.PackageSources;
        }

        private void FillOuterData()
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

            // TODO:Read config from NuGet.config.
            //this.PackageSources.Add(info);
        }
    }

    public class NuGetSourceConllection : ConfigurationElementCollection
    {
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((NuGetSourceInfo)element).Name;
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new NuGetSourceInfo();
        }

        public NuGetSourceInfo this[int i]
        {
            get
            {
                return (NuGetSourceInfo)base.BaseGet(i);
            }
        }

        public NuGetSourceInfo this[string key]
        {
            get
            {
                return (NuGetSourceInfo)base.BaseGet(key);
            }
        }

        internal void Add(NuGetSourceInfo info)
        {
            base.BaseAdd(info);
        }

        internal void Remove(string name)
        {
            base.BaseRemove(name);
        }

        internal void Clear()
        {
            base.BaseClear();
        }
    }

    public class NuGetSourceInfo : ConfigurationElement
    {
        [ConfigurationProperty("Name")]
        public string Name
        {
            get
            {
                return (string)this["Name"];
            }
            internal set
            {
                this["Name"] = value;
            }
        }

        [ConfigurationProperty("Path")]
        public string Path
        {
            get
            {
                return (string)this["Path"];
            }
            internal set
            {
                this["Path"] = value;
            }
        }

        [ConfigurationProperty("HasKey")]
        public bool HasKey
        {
            get
            {
                return (bool)this["HasKey"];
            }
            internal set
            {
                this["HasKey"] = value;
            }
        }
    }
}
