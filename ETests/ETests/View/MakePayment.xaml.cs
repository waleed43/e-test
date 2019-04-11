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
	public partial class MakePayment : ContentPage
	{
        public MakePayment() { }
		public MakePayment (string payment)
		{
			InitializeComponent ();
            if (payment.Contains("EasyPassa"))
            {
                imgPayment.Source = "easypassa.PNG";
            }
            else if (payment.Contains("JazzCash"))
            {
                imgPayment.Source = "jazzcash.PNG";

            }
            else if (payment.Contains("BankAccount"))
            {
                imgPayment.Source = "bank.PNG";
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
           
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new PaymentFinish());
        }
    }
}