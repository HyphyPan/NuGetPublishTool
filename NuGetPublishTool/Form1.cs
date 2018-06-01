using System;
using System.Collections.Specialized;
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
            ConfigDataFactory factory = new ConfigDataFactory();
            NuGetData data = factory.GetData<NuGetData>() as NuGetData;
            if (data == null)
            {
                data = new NuGetData();
            }

            data.ExePath = @"D:\Program Files (x86)\NuGet\nuget.exe";
            factory.Save(data);
        }
    }
}
