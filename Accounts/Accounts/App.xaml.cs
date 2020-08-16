using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Accounts.Services;
using Accounts.Views;
using Accounts.ViewModels;
using TinyIoC;
using Accounts.Core;
using Accounts.Core.Interfaces;

namespace Accounts
{
    public partial class App : Application
    {

        public App()
        {
           
            InitializeComponent();
            ServiceLocator.RegisterSingleton<ILogging, LoggingService>();
            ServiceLocator.RegisterSingleton<IServiceClient, ServiceClient>();
            ServiceLocator.Register<AccountsViewModel, AccountsViewModel>();

            MainPage = new AppShell();
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
