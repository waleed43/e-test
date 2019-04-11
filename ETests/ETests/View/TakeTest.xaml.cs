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
    public partial class TakeTest : ContentPage
    {

        SQLiteAsyncConnection dbConn;
        List<TestDetail> testScore;
        public TakeTest()
        {
            dbConn = DependencyService.Get<ISQLite>().GetConnection();
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //DisplayAlert("MESSAGE", "FRAME 1", "OK");
        }
        protected override async void OnAppearing()
        {
            List<TestScore> list = await dbConn.QueryAsync<TestScore>("Select Email From Test_score");
            testScore = await dbConn.QueryAsync<TestDetail>("Select TestName,AverageTime,TotalScore,Attempts,TotalTime,TotalQuestion,ScoreA,ScoreB,ScoreC From [TestDetail]");
            // dbConn.GetConnection().Close();
            testCatagory.Text = list[1].Email;
            for (int i = 0; i < testScore.Count; i++)
            {
                testScore[i].ID = (i + 1).ToString();
            }

            TakeTestList.ItemsSource = testScore;
            base.OnAppearing();
        }
        //private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        //{
        //    DisplayAlert("MESSAGE", "FRAME 2", "OK");
        //}

        //private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        //{
        //    DisplayAlert("MESSAGE", "FRAME 3", "OK");
        //}

        //private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        //{
        //    DisplayAlert("MESSAGE", "FRAME 4", "OK");
        //}

        //private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        //{
        //    DisplayAlert("MESSAGE", "FRAME 5", "OK");

        //}
    }
}