using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace NuGetPublishToolLib.ConfigurationData
{
    public interface IConfigDataHandler
    {
        string Save(ConfigurationSection data);

        string IsValid(ConfigurationSection data);
    }
}
