using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NuGetPublishToolLib.ConfigurationData
{
    public class NuGetData : ConfigurationSection
    {
        [ConfigurationProperty("ExePath")]
        public string ExePath
        {
            get
            {
                return (string)this["ExePath"];
            }
            set
            {
                this["ExePath"] = value;
            }
        }

        [ConfigurationProperty("PackageSources", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(NuGetSourceInfo),
            CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap,
            RemoveItemName = "remove")]
        public NuGetSourceConllection PackageSources
        {
            get
            {
                return (NuGetSourceConllection)base["PackageSources"];
            }
            internal set
            {
                base["PackageSources"] = value;
            }
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
