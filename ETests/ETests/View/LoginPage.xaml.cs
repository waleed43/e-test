using ETests.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ETests.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();

            var vm = new LoginViewModel();
            this.BindingContext = vm;
            vm.CheckInternetConnection += () =>
                    DisplayAlert("e-Test", "No Internet Connection, Please Connect to the Internet", "OK");

            vm.DisplayInvalidLoginPrompt += () =>
            {
                payment.IsVisible = true;
                payment.Text = "You did not pay your fee.After your payment you will receive your credential.Thank You";
                //DisplayAlert("e-Test", "", "OK");
            };
            vm.DisplayOk += async () =>
            {
                
                Application.Current.Properties["IsUserSignIn"] = true;
                Application.Current.MainPage = new NavigationDrawarPage();
               
            };

        }

        //private void Button_Clicked(object sender, EventArgs e)
        //{
        //    Navigation.PushModalAsync(new NavigationDrawarPage());
        //}
    }
}