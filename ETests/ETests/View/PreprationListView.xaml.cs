using ETests.Model;
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
	public partial class PreprationListView : ContentPage
	{
        //ObservableCollection<ListViewItem> listViewItems = new ObservableCollection<ListViewItem>()
        //{
        //    new ListViewItem {Name="Test No-1",Result="0",NumberOfAttempt="0"},
        //    new ListViewItem {Name="Test No-2",Result="0",NumberOfAttempt="0"},
        //    new ListViewItem {Name="Test No-3",Result="0",NumberOfAttempt="0"}


        //};

        int index;

        public PreprationListView ()
		{
			InitializeComponent ();
            //Mylistt.ItemsSource = listViewItems;
        }
        private void TapGestureRecognizer_Tapped(object sender, MyListEventArgs e)
        {
            //ListViewItem item = e.MyItem;
            ////count++;

            //index = listViewItems.IndexOf(item);
            ////listViewItems[index].NumberOfAttempt = count.ToString();
            //string tableName = item.Name;
            ////DisplayAlert("task", "index :" + index, "Ok");
            //Navigation.PushAsync(new SolvedQuestion(index, tableName));
            //Mylistt.ItemsSource = null;
            //Mylistt.ItemsSource = listViewItems;
        }
    }
    public class MyListEventArgs : EventArgs
    {
        public ListViewItem MyItem { get; set; }
        public MyListEventArgs(ListViewItem item)
        {
            this.MyItem = item;
        }
    }
}