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
	public partial class SolvedQuestion : ContentPage
	{
        List<Questions> list;
        SQLiteAsyncConnection dbConn;
        string tableName;

        public SolvedQuestion (int index, string tableName)
		{
			InitializeComponent ();
            this.tableName = tableName;
            dbConn = DependencyService.Get<ISQLite>().GetConnection();
        }
        protected override async void OnAppearing()
        {
            await dbConn.CreateTableAsync<Questions>();
            string test1 = "Test No - 1";
            list = await dbConn.QueryAsync<Questions>("Select Question,A,B,C,D,Answer From [QuestionList] WHERE TEST=\"" + tableName + "\"");
            PreprationList.ItemsSource = list;
            base.OnAppearing();

        }
    }
}