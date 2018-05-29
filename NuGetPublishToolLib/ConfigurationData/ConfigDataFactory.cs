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
        public enum DataType
        {
            NuGetData,
            SolutionData,
            ProjectData
        }

        public IConfigDataHandler GetDataHandler(DataType dataType)
        {
            switch (dataType)
            {
                case DataType.NuGetData:
                    return new NuGetDataHandler();
                case DataType.ProjectData:
                //return new ProjectData();
                case DataType.SolutionData:
                    //return new SolutionData();
                    break;
            }

            return null;
        }
    }
}
