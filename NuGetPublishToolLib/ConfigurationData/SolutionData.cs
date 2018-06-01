using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Configuration.Internal;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

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
