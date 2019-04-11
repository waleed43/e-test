using ETests.Model;
using IntelliAbb.Xamarin.Controls;
using Rg.Plugins.Popup.Services;
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
	public partial class PopupView 
	{
        List<PopupList> list = new List<PopupList> { new PopupList {

            Name="MDCAT",Check=false
        },new PopupList {

            Name="Gre General",Check=false
        },new PopupList {

            Name="Gre Maths",Check=false
        } };
        public static string name;
        PopupList Item;
        public static int selectedIndex;
        int previousIndex;
        public static bool lastcheck;
        public PopupView ()
		{
			InitializeComponent ();
            if (name != null)
            {
                PopupList custom = list[selectedIndex];
                PopupList custom2 = list[previousIndex];
                custom2.Check = false;
                custom.Check = true;
                PopupListView.ItemsSource = null;
                PopupListView.ItemsSource = list;
            }
            else
            {
                PopupListView.ItemsSource = list;
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, ListItemEventArgs e)
        {
            Item = e.MyItem;
            selectedIndex = list.IndexOf(Item);
            var layout = (StackLayout)sender;
            var checkbox = (Checkbox)layout.Children[1];

            TestMode.mname = Item.Name;
            if (name == null)
            {
                PopupList popupList = list[selectedIndex];
                popupList.Check = true;
                PopupListView.ItemsSource = null;
                PopupListView.ItemsSource = list;
                MessagingCenter.Send(new PopupList() { Myvalue = Item.Name }, "PopUpData");
            }
            else if (Item.Name.Contains(name) && name != null)
            {
                PopupList popupList = list[selectedIndex];
                popupList.Check = true;
                PopupListView.ItemsSource = null;
                PopupListView.ItemsSource = list;

            }
            else if (name != Item.Name)
            {
                checkbox.IsChecked = false;
                PopupList popupList = list[selectedIndex];
                //CustomPopupList popupList2 = list[previousIndex];
                //popupList2.Check = false;
                MessagingCenter.Send(new PopupList() { Myvalue = Item.Name }, "PopUpData");
                popupList.Check = true;
                PopupListView.BackgroundColor = Color.Green;
                PopupListView.ItemsSource = null;
                PopupListView.ItemsSource = list;
            }
            else
            {
                PopupList popupList = list[selectedIndex];
                popupList.Check = true;
                PopupListView.ItemsSource = null;
                PopupListView.ItemsSource = list;

            }

            previousIndex = selectedIndex;
            name = Item.Name;
            PopupNavigation.Instance.PopAsync(true);


        }

        //private void CheckMe_Unfocused(object sender, FocusRequestArgs e)
        //{
        //   // var check = sender as Checkbox;
        //    e.Focus = false;
        //}



        //private void CheckMe_IsCheckedChanged(object sender, TappedEventArgs e)
        //{
        //    var check = sender as Checkbox;
        //    //var item = e;

        //   // var stack = (StackLayout)check.Parent;
        //    //var label =stack.Children[0].BindingContext as PopupList;
        //    //var item = check.BindingContext as PopupList;
        //  //  selectedIndex = list.IndexOf(check);
        //   // var layout = (StackLayout)sender;
        //    //var checkbox = (Checkbox)layout.Children[1];

        //    TestMode.mname = Item.Name;
        //    if (name == null)
        //    {
        //        //PopupList popupList = list[selectedIndex];
        //        check.IsChecked = true;
        //        PopupListView.ItemsSource = null;
        //        PopupListView.ItemsSource = list;
        //        MessagingCenter.Send(new PopupList() { Myvalue = Item.Name }, "PopUpData");
        //    }
        //    else if (Item.Name.Contains(name) && name != null)
        //    {
        //       // PopupList popupList = list[selectedIndex];
        //        //popupList.Check = true;
        //        PopupListView.ItemsSource = null;
        //        PopupListView.ItemsSource = list;

        //    }
        //    else if (name != Item.Name)
        //    {
        //        check.Check = false;
        //        PopupList popupList = list[selectedIndex];
        //        //CustomPopupList popupList2 = list[previousIndex];
        //        //popupList2.Check = false;
        //        MessagingCenter.Send(new PopupList() { Myvalue = Item.Name }, "PopUpData");
        //        popupList.Check = true;
        //        PopupListView.BackgroundColor = Color.Green;
        //        PopupListView.ItemsSource = null;
        //        PopupListView.ItemsSource = list;
        //    }
        //    else
        //    {
        //        PopupList popupList = list[selectedIndex];
        //        popupList.Check = true;
        //        PopupListView.ItemsSource = null;
        //        PopupListView.ItemsSource = list;

        //    }

        //    previousIndex = selectedIndex;
        //    name = Item.Name;
        //    PopupNavigation.Instance.PopAsync(true);
        //}
    }
    public class ListItemEventArgs : EventArgs
    {
        public PopupList MyItem { get; set; }
        public ListItemEventArgs(PopupList item)
        {
            this.MyItem = item;
        }
    }
}