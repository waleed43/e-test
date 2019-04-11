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
	public partial class PaymentPage : ContentPage
	{
		public PaymentPage ()
		{
			InitializeComponent ();
		}

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void EasyPaisaTapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MakePayment("EasyPassa"));

            //DisplayAlert("Message", "Make Payment with EasyPaisa Mobile Account", "OK");
        }
        private void JazzCashTaped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MakePayment("JazzCash"));
            //DisplayAlert("Message", "Make Payment with JazzCash Mobile Account", "OK");
        }
        private void BankTransactionTapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MakePayment("BankAccount"));
            // DisplayAlert("Message", "Make Payment with Bank Account", "OK");
        }
    }
}