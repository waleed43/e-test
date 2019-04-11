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
	public partial class SectionsPage : ContentPage
	{
        int ind;
        string tableName;

        List<Questions> testScore;
        List<Questions> testScoreB;
        List<Questions> testScoreC;
        SQLiteAsyncConnection dbConn;
        public SectionsPage (int ind,string tableName)
		{
            dbConn = DependencyService.Get<ISQLite>().GetConnection();
            InitializeComponent ();
            this.ind = ind;
            this.tableName = tableName;
            this.Title = tableName;
		}
        protected override async void OnAppearing()
        {
            //WHERE Tests =\"" + tableName + "\"
           // testScore = await dbConn.QueryAsync<Questions>("Select Section From [QuestionList] WHERE TEST=\"" + tableName + "\"");
            testScore = await dbConn.QueryAsync<Questions>("Select Question From [QuestionList] WHERE Sections='A' AND Test=\""+tableName+"\"");
            testScoreB = await dbConn.QueryAsync<Questions>("Select Question From [QuestionList] WHERE Sections='B' AND Test=\"" + tableName+"\"");
            testScoreC = await dbConn.QueryAsync<Questions>("Select Question From [QuestionList] WHERE Sections='C' AND Test=\"" + tableName+"\"");
            //testScore = await dbConn.QueryAsync<Questions>("Select Section From [QuestionList] WHERE TEST=\"" + tableName + "\"");
           // SectionA.Text = testScore[0].ToString();
            SectionACount.Text = testScore.Count.ToString();

            //SectionB.Text = testScoreB[0].ToString();
            SectionBCount.Text = testScoreB.Count.ToString();

            //SectionC.Text = testScoreC[0].ToString();
            //SectionCCount.Text = testScoreC.Count.ToString();
            //SectionList.ItemsSource = testScore;

            base.OnAppearing();
        }

        private void SectionBTapped(object sender, EventArgs e)
        {
            Application.Current.Properties["IsTestPage"] = true;
            //Navigation.PushAsync(new QuizPage("B",tableName,testScoreB.Count));
        }
        private void SectionATapped(object sender, EventArgs e)
        {
            Application.Current.Properties["IsTestPage"] = true;
            //Navigation.PushAsync(new QuizPage("A", tableName, testScore.Count));
        }

    }
}