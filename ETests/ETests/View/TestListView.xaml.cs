using ETests.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ETests.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestListView : ContentPage
    {
        SQLiteAsyncConnection dbConn;
        List<Questions> testScore;
        List<ListViewItem> Attempts;

        ObservableCollection<ListViewItem> listViewItems = new ObservableCollection<ListViewItem>()
        {
            new ListViewItem {Tests="Test No-1",Numbertapped="0"},
            new ListViewItem {Tests="Test No-2",Numbertapped="0"},
            new ListViewItem {Tests="Test No-3",Numbertapped="0"}


        };
        int index;
        public TestListView()
        {
            InitializeComponent();
            dbConn = DependencyService.Get<ISQLite>().GetConnection();

            //Mylistt.ItemsSource = listViewItems;



        }

        //private void Mylistt_ItemTapped(object sender, MyListItemEventArgs e)
        //{
        //    ListViewItem item = e.MyItem;

        //    index = listViewItems.IndexOf(item);
        //    DisplayAlert("task", "index :" + index, "Ok");
        //    Navigation.PushAsync(new QuizPage(index));
        //}
        string testcatogary;
        protected override async void OnAppearing()
        {
            List<TestScore> list = await dbConn.QueryAsync<TestScore>("Select Email From Test_score");
            testcatogary = list[1].Email;
            Attempts = await dbConn.QueryAsync<ListViewItem>("select Numbertapped,Tests from Test_score where TestCatagory=\"MDCAT\"");
            for (int i = 0; i < Attempts.Count; i++)
            {
                Attempts[i].IsDisabled = true;
                Attempts[i].StackBackGround = "#397290";
                if (Attempts[i].Numbertapped.Contains("10"))
                {
                    Attempts[i].IsDisabled = false;
                    Attempts[i].StackBackGround = "#e0e0e0";
                }
            }

            Mylistt.ItemsSource = Attempts;
            MainFrame.HeightRequest = 45 * (Attempts.Count+1);
            Mylistt.HeightRequest = 45 * (Attempts.Count+1);
            base.OnAppearing();
            //string scor = QuizPage.sco;
            //if (scor != null)
            //{
            //    //listViewItems[QuizPage.inde].Result = scor;
            //    listViewItems[QuizPage.inde].Numbertapped = count.ToString();
            //    Mylistt.ItemsSource = null;
            //    Mylistt.ItemsSource = listViewItems;
            //}
            //else
            //{
            //    Mylistt.ItemsSource = listViewItems;
            //}
        }

        //static QuizPage database;
        //static QuizPage DataBase
        //{
        //    get
        //    {
        //        if (database == null)
        //        {
        //            database=new QuizPage(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"etests.db")));
        //        }
        //        return database;
        //    }
        //}
        int count = 0;
        private async void TapGestureRecognizer_Tapped(object sender, TestListViewItem e)
        {
            ListViewItem item = e.MyItem;
            count++;
            var layout = sender as StackLayout;
            //if (item.Numbertapped.Contains("10"))
            //{
            //    item.IsDisabled = false;
            //    item.StackBackGround = "#eeeeee";
            //}
            //else
            //{

                listViewItems[index].Numbertapped = count.ToString();
                string tableName = item.Tests;
                testScore = await dbConn.QueryAsync<Questions>("select Question from UpdatedQuestions where Test=\"" + tableName + "\"");
                //dbConn.GetConnection().Close();
                int cou = testScore.Count;
                //DisplayAlert("task", "Table :" + tableName, "Ok");
                Application.Current.Properties["IsTestPage"] = true;
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("e-Test", "Are You Sure to Start "+tableName, "Yes", "No");
                if (result)
                {
                    await Navigation.PushAsync(new QuizPage(count, tableName,testcatogary, cou));
                }
            });
            
            //}
            

        }

        //private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        //{
        //    centerFram.BackgroundColor = Color.Red;
        //    centerFram2.BackgroundColor = Color.White;

        //}

        //private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        //{
        //    centerFram.BackgroundColor = Color.White;
        //    centerFram2.BackgroundColor = Color.Red;
        //}
    }
    public class TestListViewItem : EventArgs
    {
        public ListViewItem MyItem { get; set; }
        public TestListViewItem(ListViewItem item)
        {
            this.MyItem = item;
        }
    }
}