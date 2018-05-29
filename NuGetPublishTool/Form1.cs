using System;
using System.Configuration;
using System.Windows.Forms;
using NuGetPublishToolLib.ConfigurationData;

namespace NuGetPublishTool
{
    public partial class Form1 : Form
    {
        private ConfigDataFactory factory;
        public Form1()
        {
            InitializeComponent();
            this.factory = new ConfigDataFactory();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NuGetDataHandler nuGetDataHandler =
                    this.factory.GetDataHandler(ConfigDataFactory
                                                        .DataType.NuGetData) as NuGetDataHandler;
            NuGetData data = nuGetDataHandler.GetData();
            data.ExePath = @"D:\Program Files\NuGet\nuget.exe";
            nuGetDataHandler.Save(data);
        }
    }
}
