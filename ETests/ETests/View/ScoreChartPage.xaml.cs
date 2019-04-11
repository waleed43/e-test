using ETests.Model;
using ETests.ViewModel;
using Microcharts;
using OxyPlot;
using OxyPlot.Series;
using SkiaSharp;
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
	public partial class ScoreChartPage : ContentPage
	{
        string tableName = "Test No-1";
        PieChartViewModel vm;
        SQLiteAsyncConnection dbConn;
        List<TestScore> testScore;
        List<TestScore> listViewItems;
        List<Questions> list;
        List<TestDetail> testDetails;
        List<DashBoardListview> dashBoardListview;
        // List<Entry> entries;
        int index;
        int count = 0;
        //{
        //    new ListViewItem {Name="Test No-1",Result="0",NumberOfAttempt="0"},
        //    new ListViewItem {Name="Test No-2",Result="0",NumberOfAttempt="0"},
        //    new ListViewItem {Name="Test No-3",Result="0",NumberOfAttempt="0"}


        //};
        public ScoreChartPage ()
		{

            dbConn = DependencyService.Get<ISQLite>().GetConnection();
            
            InitializeComponent ();
           
            MessagingCenter.Subscribe<TestScore>(this, "PopUpData", (value) =>
            {
                if (value != null)
                {

                    tableName = value.Myvalue;
                }
                //else
                //{
                //    tableName = "Test No-1";
                //}
                //customButton.Text = receivedData;
            });
            //TESTLABEL.Text = name;

           

        }
        //private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new TestListView());
        //}
        protected override async void OnAppearing()
        {
            //WHERE Tests =\"" + tableName + "\"



            testScore = await dbConn.QueryAsync<TestScore>("Select Tests,TestName,Numbertapped,SectionA,SectionB,SectionC,SectionD,OutOF,OutofC,OutofB,OutofD,Email From [Test_score]");
           // listViewItems = await dbConn.QueryAsync<TestScore>("Select Tests,Score,Numbertapped From [Test_score]");
            testDetails = await dbConn.QueryAsync<TestDetail>("Select TestName,SectionAs,SectionBs,SectionCs,SectionDs,AverageScore," +
                "AverageTime,ScoreA,ScoreB,ScoreC,ScoreD,Atotal," +
                "Btotal,Ctotal,Dtotal,Attempts From [TestDetail]");
            //dbConn.GetConnection().Close();
            //await DisplayAlert("", ""+testDetails.Count, "OK");
            //if (testDetails.Count > 0)
            //{
            //   await DisplayAlert("alert", "Average Time: "+testDetails[testDetails.Count-1].AverageTime +" SCORE:"+ testDetails[testDetails.Count - 1]
            //       .Atotal+ testDetails[testDetails.Count - 1].Btotal+ testDetails[testDetails.Count - 1].Ctotal, "ok");
            //}
            
           // this.Content=new ScrollView { this.sl ,Or}
           string testCatagory= testScore[1].Email;
            dashBoardListview = await dbConn.QueryAsync<DashBoardListview>("Select TestName,AScore,BScore,CScore,AverageScore,Attempts,A,B,C,TimeTaken From [DashBoardListview] where TestCatagory=\""+testCatagory+"\"");
            TestNoOfTapped.Text = testScore[1].Email;
            //Mylistt.ItemsSource = testScore;
            //int min = list.Count;
            if (testDetails.Count==0)
            {
                vm = new PieChartViewModel("000", 00, 1, 0);
                testresult.Text = "Result of (" + dashBoardListview.Count + ") Tests Attempted "+testDetails.Count+" Times";
                //vm = new PieChartViewModel(testScore[0].TestName, testScore[0].Numbertapped, 1, 0);
                //  Mylistt.ItemsSource = null;
                // ScoreList.ItemsSource = dashBoardListview;

            }
            else
            {
                List<int> Av = new List<int>();
                List<int> To = new List<int>();
                List<int> Aaverage = new List<int>();
                List<int> Baverage = new List<int>();
                List<int> Caverage = new List<int>();
                List<int> Daverage = new List<int>();
                List<int> Atot = new List<int>();
                List<int> Btot = new List<int>();
                List<int> Ctot = new List<int>();
                List<int> Dtot = new List<int>();
                int a = 0;
                int b = 0;
                int c = 0;
                int d = 0;
                int AverageScore = 0;
                int Total = 0;
                int Aave = 0;
                int Bave = 0;
                int Cave = 0;
                int Dave = 0;
                for (int i = 0; i < testDetails.Count; i++)
                {
                    AverageScore = testDetails[i].Atotal + testDetails[i].Btotal + testDetails[i].Ctotal+testDetails[i].Dtotal;
                    Av.Add(AverageScore);
                    Total =testDetails[i].ScoreA + testDetails[i].ScoreB + testDetails[i].ScoreC+testDetails[i].ScoreD;
                    To.Add(Total);
                    Aave = testDetails[i].ScoreA;
                    Aaverage.Add(Aave);
                    Bave = testDetails[i].ScoreB;
                    Baverage.Add(Bave);
                    Cave = testDetails[i].ScoreC;
                    Caverage.Add(Cave);
                    Dave = testDetails[i].ScoreD;
                    Daverage.Add(Dave);
                    AverageScore += AverageScore;
                    Total += Total;
                    a = testDetails[i].Atotal;
                    Atot.Add(a);
                    b = testDetails[i].Btotal;
                    Btot.Add(b);
                    c = testDetails[i].Ctotal;
                    Ctot.Add(c);
                    d = testDetails[i].Dtotal;
                    Dtot.Add(d);
                }
                
                int add = To.Select(i=>i).Sum();
                int aa = Aaverage.Select(i => i).Sum();
                int bb = Baverage.Select(i => i).Sum();
                int cc = Caverage.Select(i => i).Sum();
                int dd = Daverage.Select(i => i).Sum();
                int add2 = Av.Select(i => i).Sum();

                int aoutof=Atot.Select(i => i).Sum();
                int boutof = Btot.Select(i => i).Sum();
                int coutof = Ctot.Select(i => i).Sum();
                int doutof = Dtot.Select(i => i).Sum();
                // await DisplayAlert("al", "" + add + "/" + add2, "ok");
                //int testAscore = testDetails[0].OutofC;
                //int testBscore = testScore[1].OutofC;
                //int testCscore = testScore[2].OutofC;
                //    int Atotal = testScore[0].OutofB;
                //    int Btotal = testScore[1].OutofB;
                //    int Ctotal = testScore[2].OutofB;


                //    int total = testAscore + testBscore + testCscore;


                //    int AverageScore = Atotal + Btotal + Ctotal;
                if (add2 == 0)
                {
                    //int rightper = (total * 100 / AverageScore);
                    //int wrongper = 100 - rightper;
                    // await DisplayAlert("task", "tablename" + tableName + " right: " + rightper + " wrong: " +OutOf, "ok");
                    vm = new PieChartViewModel(testScore[0].TestName, testScore[0].Numbertapped, 1, 0);
                    testresult.Text = "Result of (" + dashBoardListview.Count + ") Tests Attempted " + testDetails.Count + " Times";

                    // ScoreList.ItemsSource = dashBoardListview;

                }
                else
                {
                    testresult.Text = "Result of (" + dashBoardListview.Count + ") Tests Attempted " + testDetails.Count + " Times";
                    int rightper = (add * 100 / add2);
                    int wrongper = 100 - rightper;
                    // await DisplayAlert("task", "tablename" + tableName + " right: " + rightper + " wrong: " +OutOf, "ok");
                    vm = new PieChartViewModel(testScore[0].TestName, testScore[0].Numbertapped, wrongper, rightper);
                    SectionA.Text = aa+"/"+aoutof;
                    SectionB.Text = bb + "/" + boutof;
                    SectionC.Text = cc + "/" + coutof;
                    SectionD.Text = dd + "/" + doutof;
                    int  aper = (aa * 100 / aoutof);
                    int bper = (bb * 100 / boutof);
                    int cper = (cc * 100 / coutof);
                    int dper = (dd * 100 / doutof);
                    SectionAPer.Text = aper + "%";
                    SectionBPer.Text = bper + "%";
                    SectionDPer.Text = dper + "%";
                    SectionCPer.Text = cper + "%";
                    double avrg = To.Select(i => i).Sum();
                    double devid = Av.Select(i => i).Sum();
                    double avrageScore = avrg / devid;

                    Average.Text = string.Format("{0:F2}",avrageScore);
                    TotalPer.Text = rightper + "%";
                   //await DisplayAlert("ok", "avrg"+avrg+" devid:"+devid, "ok");
                    //SectionCPer.Text = cper + "%";

                    // ScoreList.ItemsSource = dashBoardListview;
                }
                //    //int OutOf = testScore[0].OutOF;


                //    //Mylistt.ItemsSource = null;
                //    ScoreList.ItemsSource = testScore;


                }
                this.BindingContext = vm;
            //Mylistt.ItemsSource = LIST;
            
            base.OnAppearing();
        }
        //protected override bool OnBackButtonPressed()
        //{
        //    Device.BeginInvokeOnMainThread(async () =>
        //    {
        //        System.Environment.Exit(0);
        //    });
        //    return false;
        //}
        //private async void TapGestureRecognizer_Tapped(object sender, MyListItemEventArgs e)
        //{
        //    TestScore item = e.MyItem;
        //    count++;

        //    ///listViewItems[index].NumberOfAttempt = count.ToString();
        //    string tableName = item.Tests;
        //    list = await dbConn.QueryAsync<Questions>("Select ID,Question,A,B,C,D,Answer,Filepath From [QuestionList] WHERE TEST=\"" + tableName + "\"");
        //    int min = list.Count;
        //    //DisplayAlert("task", "index :" + index, "Ok");
        //    Navigation.PushAsync(new QuizPage(index, tableName,min));
        //}
    }
    public class MyListItemEventArgs : EventArgs
    {
        public TestScore MyItem { get; set; }
        public MyListItemEventArgs(TestScore item)
        {
            this.MyItem = item;
        }
    }
}