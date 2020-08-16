
using Accounts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Markup;
using Xamarin.Forms.Xaml;
using VM = Accounts.ViewModels;
namespace Accounts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountsPage : ContentPage
    {
        public VM.AccountsViewModel ViewModel;
       
        public AccountsPage()
        {
            InitializeComponent();

            BindingContext = ViewModel = ServiceLocator.Resolve<VM.AccountsViewModel>();            

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();             

        }

    }
}