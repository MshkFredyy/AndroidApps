using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mapsui;
using Mapsui.Layers;
using Mapsui.UI.Forms;
using Mapsui.Utilities;

using Mapsui.Providers;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Geo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
