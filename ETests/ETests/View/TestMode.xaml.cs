using ETests.Model;
using ETests.ViewModel;
using Rg.Plugins.Popup.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ETests.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TestMode : ContentPage
	{
        //ObservableCollection<ListViewItem> listViewItems = new ObservableCollection<ListViewItem>()
        //{
        //    new ListViewItem {Name="Test No-1"},
        //    new ListViewItem {Name="Test No-2"},
        //    new ListViewItem {Name="Test No-3"}


        //};
        public static string mname;
        string receivedData;
        SQLiteAsyncConnection dbConn;
        List<TestScore> testScore, testScore2;
        public TestMode ()
		{
            dbConn = DependencyService.Get<ISQLite>().GetConnection();
            InitializeComponent ();
            MessagingCenter.Subscribe<PopupList>(this, "PopUpData", async(value) =>
            {
               receivedData = value.Myvalue;
                customButton.Text = receivedData;
                testScore2 = await dbConn.QueryAsync<TestScore>("select Email from Test_score WHERE Tests =\"Test No-3\"");
                //await DisplayAlert("task", "" + testScore2.Count, "ok");
                string email = testScore2[0].Email;
                var vm = new SelectCatagoryViewModel(email);
                this.BindingContext = vm;

                vm.CheckInternetConnection += () =>
                        DisplayAlert("Error!", "No Internet Connection, Please Connect to the Internet", "Ok");

                vm.DisplayInvalidLoginPrompt += () =>
                {

                    DisplayAlert("Error!", "please provide valid credential for requesting...", "Ok");
                    //await DisplayAlert("task", "successfull" , "ok");
                };

                vm.DisplayOk += async () =>
                {
                    string testname = customButton.Text;

                    if (receivedData.Contains("MDCAT"))
                    {
                        Application.Current.Properties["IsTestCatagory"] = true;
                        testScore = await dbConn.QueryAsync<TestScore>("UPDATE Test_score SET Email=\"" + testname + "\" WHERE Tests =\"Test No-2\"");
                        await Navigation.PushModalAsync(new LoginPage());
                        //await DisplayAlert("e-Test", "Category has been selected, Please cleared your payment, after that you will receive your login credentials. Thank you!", "ok");
                    }
                };
            });
            //if (receivedData != null)
            //{
               
               
                ////dbConn.GetConnection().Close();
                //
                
                
            
           

        }


        protected override async void OnAppearing()
        {
            
            base.OnAppearing();
        }
        //private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        //{
        //    if (receivedData != null)
        //    {
        //        //string testname = customButton.Text;

        //        //if (receivedData.Contains("MDCAT"))
        //        //{
        //        //    testScore = await dbConn.QueryAsync<TestScore>("UPDATE Test_score SET Email=\"" + testname + "\" WHERE Tests =\"Test No-2\"");
        //        //    await Navigation.PushModalAsync(new PaymentPage());
        //        //}

        //    }
        //    else
        //    {
        //        await DisplayAlert("e-Test", "Select your Test Catogary to Continue Your Registration Process!", "OK");
        //    }
        //    }
        private void CustomButton_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new PopupView());
            OnAppearing();

        }
    }
}