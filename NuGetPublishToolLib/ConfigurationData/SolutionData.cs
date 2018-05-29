using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace NuGetPublishToolLib.ConfigurationData
{
    public class SolutionData : ConfigurationSection
    {
        [ConfigurationProperty("SlnPath")]
        public string SlnPath
        {
            get
            {
                return (string)this["SlnPath"];
            }
            set
            {
                this["SlnPath"] = value;
            }
        }
    }
}
