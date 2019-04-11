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
	public partial class HelpPage : ContentPage
	{
        private ObservableCollection<FAQHeader> _allGroups;
        private ObservableCollection<FAQHeader> _expandedGroups;

        int selectedIndex;
        int previousindex;
        public HelpPage ()
		{
			InitializeComponent ();
            _allGroups = FAQHeader.All;
            UpdateListContent();
           

        }
        private void UpdateListContent()
        {
            _expandedGroups = new ObservableCollection<FAQHeader>();
            foreach (FAQHeader group in _allGroups)
            {
                //Create new FoodGroups so we do not alter original list
                FAQHeader newGroup = new FAQHeader(group.Id, group.Header,  group.Expanded);
                //Add the count of food items for Lits Header Titles to use
                newGroup.GroupCount = group.Count;
                if (group.Expanded)
                {
                    foreach (FAQListItems food in group)
                    {
                        newGroup.Add(food);
                    }
                }
                newGroup.Expanded = false;
                _expandedGroups.Add(newGroup);
            }
            _expandedGroups[0].Expanded = true;
            
            listview.ItemsSource = _expandedGroups;
            //listview.HeightRequest = (50 * _expandedGroups.Count)/(10* _expandedGroups.Count);

        }
        private void TapGestureRecognizer_Tapped(object sender, MyListEventArgsLIST e)
        {
           var item = e.MyItem1;
            string s = item.Header;



            selectedIndex = _expandedGroups.IndexOf(item);
            FAQHeader model = _allGroups[selectedIndex];

            //DisplayAlert("", "dag :" + selectedIndex, "ok");
            //if(prevoiusIndex == null)
            //{


            //_allGroups[selectedIndex].Expanded = !_allGroups[selectedIndex].Expanded;
            //    UpdateListContent();
            //}
            //else 
            if (previousindex == selectedIndex)
            {
                _allGroups[selectedIndex].Expanded = true;
               

                UpdateListContent();
            }
            else if (previousindex != selectedIndex && previousindex != null)
            {
                _allGroups[previousindex].Expanded = false;
                
                _allGroups[selectedIndex].Expanded = true;
               

                UpdateListContent();
            }



            previousindex = selectedIndex;

        }
    }
    public class MyListEventArgsLIST : EventArgs
    {
        public FAQHeader MyItem1 { get; set; }
        public MyListEventArgsLIST(FAQHeader item)
        {
            MyItem1 = item;
        }
    }
}