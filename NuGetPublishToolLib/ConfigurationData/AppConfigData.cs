using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace NuGetPublishToolLib.ConfigurationData
{
    public abstract class AppConfigData : ConfigurationSection
    {
        public abstract string CheckValid();

        public abstract void CopyFrom(AppConfigData sourceData);
    }
}
