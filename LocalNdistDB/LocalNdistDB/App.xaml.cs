using LocalNdistDB.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LocalNdistDB
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<ILocalDatabaseService, LocalDatabaseService>();
            DependencyService.Register<IPostgreSQLService, PostgreSQLService>();

            MainPage = new NavigationPage(new MainPage());
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
