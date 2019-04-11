using ETests.Model;
using ETests.ViewModel;
using SQLite;
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
	public partial class RegistrationPage : ContentPage
	{
        SQLiteAsyncConnection dbConn;
        List<TestScore> testScore;
        public RegistrationPage ()
		{
			InitializeComponent ();
            dbConn = DependencyService.Get<ISQLite>().GetConnection();
            var vm = new ResgrationViewModel();
            this.BindingContext = vm;
            vm.CheckInternetConnection += () =>
                    DisplayAlert("Error!", "No Internet Connection, Please Connect to the Internet", "Ok");

            vm.DisplayInvalidLoginPrompt += () =>
                    DisplayAlert("Error!", "please provide valid credential for requesting...", "Ok");

            vm.DisplayOk += async() =>
            {
                //if (string.IsNullOrWhiteSpace(UName.Text))
                //{
                //    UName.BorderErrorColor = Color.Red;
                //    UName.IsBorderErrorVisible = true;
                //    UName.Placeholder = "Plz enter User Name";
                //    UName.PlaceholderColor = Color.Red;
                //}else if (string.IsNullOrWhiteSpace(UEmail.Text))
                //{
                //    UEmail.BorderErrorColor = Color.Red;
                //    UEmail.IsBorderErrorVisible = true;
                //    UEmail.Placeholder = "This field is required !";
                //    UEmail.PlaceholderColor = Color.Red;
                //}
                //else if (string.IsNullOrWhiteSpace(UContact.Text))
                //{
                //    UContact.BorderErrorColor = Color.Red;
                //    UContact.IsBorderErrorVisible = true;
                //    UContact.Placeholder = "This field is required !";
                //    UContact.PlaceholderColor = Color.Red;

                //}
                //else if (string.IsNullOrWhiteSpace(UCNIC.Text))
                //{
                //    UCNIC.BorderErrorColor = Color.Red;
                //    UCNIC.IsBorderErrorVisible = true;
                //    UCNIC.Placeholder = "this field is required";
                //    UCNIC.PlaceholderColor = Color.Red;
                //}
                //else if (string.IsNullOrWhiteSpace(UIntitue.Text))
                //{
                //    UIntitue.BorderErrorColor = Color.Red;
                //    UIntitue.IsBorderErrorVisible = true;
                //    UIntitue.Placeholder = "this field is required";
                //    UIntitue.PlaceholderColor = Color.Red;
                //}
                //else if (string.IsNullOrWhiteSpace(UCity.Text))
                //{
                //    UCity.BorderErrorColor = Color.Red;
                //    UCity.IsBorderErrorVisible = true;
                //    UCity.Placeholder = "City Field Is Required";
                //    UCity.PlaceholderColor = Color.Red;
                //}
                //else
                //{
                string userName = UEmail.Text;
                testScore = await dbConn.QueryAsync<TestScore>("UPDATE Test_score SET Email=\"" + userName + "\" WHERE Tests =\"Test No-3\"");
               // dbConn.GetConnection().Close();
                //MessagingCenter.Send(new PopupList() { Myvalue = userName }, "RegData");
                Application.Current.Properties["IsUserLoggedIn"] = true;
                Application.Current.MainPage = new TestMode();
                //DisplayAlert("Successfull", "Registration has been completed. Thank you!", "Ok");
                //}
                //} && ! && !
                //&& ! && ! && !
                //{
                //    App.IsUserLoggedIn = true;
                //    Application.Current.MainPage = new NavigationDrawarPage();
                //    DisplayAlert("Successfull", "Registration has been completed. Thank you!", "Ok");
                //}




            };
        }
        protected override void OnAppearing()
        {
            
            base.OnAppearing();
        }
    }
}