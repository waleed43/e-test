using ETests.MenuItem;
using ETests.Model;
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
	public partial class NavigationDrawarPage : MasterDetailPage
	{
        public List<NavigationDrawerItem> menuList { get; set; }
        SQLiteAsyncConnection dbConn;
        List<TestScore> testScore;
        public NavigationDrawarPage ()
		{
			InitializeComponent ();
            dbConn = DependencyService.Get<ISQLite>().GetConnection();
            MessagingCenter.Subscribe<PopupList>(this, "RegData", (value) =>
            {
                string receivedData = value.Myvalue;
                UserName.Text = receivedData;
            });
            menuList = new List<NavigationDrawerItem>();

            //Fot  icons
            var page1 = new NavigationDrawerItem() { Title = "Dashboard", Icon = "dashboard.PNG", TargetType = typeof(ScoreChartPage) };

            var page2 = new NavigationDrawerItem() { Title = "Attempted Tests History", Icon = "taketest.PNG", TargetType = typeof(TakeTest) };
            var page3 = new NavigationDrawerItem() { Title = "Atempt Test", Icon = "taketest.PNG", TargetType = typeof(TestListView) };
            var page4 = new NavigationDrawerItem() { Title = "FAQ", Icon = "help.PNG", TargetType = typeof(HelpPage) };
            var page5 = new NavigationDrawerItem() { Title = "Rate App", Icon = "star.png",TargetType=typeof(AboutPage) };
            var page6 = new NavigationDrawerItem() { Title = "FeedBack", Icon = "feedback.png", TargetType = typeof(AboutPage) };
            // Adding menu items to menuList
            menuList.Add(page1);
            menuList.Add(page3);
            menuList.Add(page2);
            menuList.Add(page4);
            menuList.Add(page5);
            menuList.Add(page6);


            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = menuList;

            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(ScoreChartPage)));
        }
        protected override async void OnAppearing()
        {
            testScore = await dbConn.QueryAsync<TestScore>("select Email from Test_score WHERE Tests =\"Test No-3\"");
            ////dbConn.GetConnection().Close();
            UserName.Text = testScore[0].Email;
            base.OnAppearing();
        }
        //private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{

        //    //item1.BackgroundColor = Color.AliceBlue;
        //    var item = (NavigationDrawerItem)e.SelectedItem;

        //    Type page = item.TargetType;
        //    string i = item.Title;

        //        Detail = new NavigationPage((Page)Activator.CreateInstance(page));
        //        IsPresented = false;


        //}

        private void TapGestureRecognizer_Tapped(object sender, MenuListItemEventArgs e)
        {
            NavigationDrawerItem item = e.MyItem;
            Type page = item.TargetType;
            string i = item.Title;
            if(i.Contains("Rate App"))
            {
                Device.OpenUri(new Uri("https://play.google.com/store/apps/details?id=com.webdowsecom.ecom"));
                IsPresented = false;
            }else if (i.Contains("FeedBack"))
            {
                Device.OpenUri(new Uri("https://forms.gle/7C7qhKSq3t1MGXr9A"));
                IsPresented = false;
            }
            else
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(page));
                IsPresented = false;
            }
           
        }
    }
    public class MenuListItemEventArgs : EventArgs
    {
        public NavigationDrawerItem MyItem { get; set; }
        public MenuListItemEventArgs(NavigationDrawerItem item)
        {
            this.MyItem = item;
        }
    }
}