using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NuGetPublishTool.ConfigurationData
{
    public class NuGetData : ConfigurationSection
    {
        [ConfigurationProperty("ExePath")]
        public string ExePath
        {
            get => (string)this["ExePath"];
            set => this["ExePath"] = value;
        }

        [ConfigurationProperty("PackageSources", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(NuGetSourceInfo), CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap, RemoveItemName = "remove")]
        public NuGetSourceConllection PackageSources
        {
            get => (NuGetSourceConllection)base["PackageSources"];
            set => base["PackageSources"] = value;
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
            get => (NuGetSourceInfo)base.BaseGet(i);
        }
    }

    public class NuGetSourceInfo : ConfigurationElement
    {
        [ConfigurationProperty("Name")]
        public string Name
        {
            get => (string)this["Name"];
            set => this["Name"] = value;
        }

        [ConfigurationProperty("Path")]
        public string Path
        {
            get => (string)this["Path"];
            set => this["Path"] = value;
        }

        [ConfigurationProperty("HasKey")]
        public bool HasKey
        {
            get => (bool)this["HasKey"];
            set => this["HasKey"] = value;
        }
    }
}
