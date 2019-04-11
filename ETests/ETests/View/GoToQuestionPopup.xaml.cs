using ETests.Model;
using Rg.Plugins.Popup.Services;
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
	public partial class GoToQuestionPopup 
	{
        int count;
        ObservableCollection<string> list=new ObservableCollection<string>();
		public GoToQuestionPopup ( int count)
		{
			InitializeComponent ();
            this.count = count;
            for(int i = 0; i < count; i++)
            {
                list.Add(("Quesion No. "+(i + 1)).ToString());
            }
            GoToList.ItemsSource = list;

        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var layout = (StackLayout)sender;
            var label = (Label)layout.Children[0];
            string text = label.Text;
            int index = list.IndexOf(text);
            //DisplayAlert("MESSAGE", ""+index, "OK");
            MessagingCenter.Send(new PopupList() { Myvalue = index.ToString() }, "data");
            PopupNavigation.Instance.PopAsync(true);

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}