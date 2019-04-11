using ETests.View;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ETests.ViewModel
{
    public class SelectCatagoryViewModel : INotifyPropertyChanged
    {

        public Action DisplayInvalidLoginPrompt;
        public Action DisplayOk;
        public Action CheckInternetConnection;

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand FSubmitCommand
        {
            protected set; get;
        }
        string email, catagory_name;
        public SelectCatagoryViewModel() { }
        public SelectCatagoryViewModel(string email)
        {
            this.email = email;
            this.catagory_name = PopupView.name;
            FSubmitCommand = new Command(async() =>
            {
                IsBusy = true;


                var ress = await ApiResponse("catagory",email,catagory_name);

                if (!string.IsNullOrEmpty(ress))
                {
                    CatagoryGenerics req = JsonConvert.DeserializeObject<CatagoryGenerics>(ress.ToString());

                    if (req != null)
                    {
                        if (req.status == "FALSE")
                        {
                            DisplayInvalidLoginPrompt();
                            IsBusy = false;
                        }
                        else
                        {
                            DisplayOk();

                            IsBusy = false;
                            // MainPage = new Eptcon.Pages.Dashboaed();
                        }
                    }

                }
                else
                {
                    CatagoryGenerics req = JsonConvert.DeserializeObject<CatagoryGenerics>(ress.ToString());
                    if (req != null)
                    {

                        if (req.status == "FALSE")
                        {
                            DisplayInvalidLoginPrompt();
                            IsBusy = false;
                        }
                    }
                }



            } );
        }
        public async void OnSubmit()
        {

            var ress = await ApiResponse("catagory",email,catagory_name);
           

        }

        async Task<string> ApiResponse(string catagory_selection, string useremail, string catagory_name)
        {
            var isConnected = CrossConnectivity.Current.IsConnected;
            if (isConnected == false)
            {
                CheckInternetConnection();
            }
            else
            {
                try
                {


                    //if (!string.IsNullOrEmpty(User_Name) && !string.IsNullOrEmpty(User_Email) &&
                    //!string.IsNullOrEmpty(User_Contact) && !string.IsNullOrEmpty(User_CNIC) &&
                    //!string.IsNullOrEmpty(Institute_Name) && !string.IsNullOrEmpty(City))
                    //{

                    var postData = new List<KeyValuePair<string, string>>();
                    postData.Add(new KeyValuePair<string, string>("category_selection", catagory_selection));
                    postData.Add(new KeyValuePair<string, string>("useremail", useremail));
                    postData.Add(new KeyValuePair<string, string>("category_name", catagory_name));
                  

                    var content = new FormUrlEncodedContent(postData);

                    HttpClient client = new HttpClient();



                    var response = await client.PostAsync("http://theetest.com/API/category_selection.php", content);


                    if (response.IsSuccessStatusCode)
                    {

                        string result = await response.Content.ReadAsStringAsync();
                        return result;
                    }
                    else
                    {

                        return response.ReasonPhrase;
                    }

                    //}
                    //else
                    //{
                    //    DisplayInvalidLoginPrompt();
                    //}
                }
                catch (Exception ex)
                {

                }

            }
            return "";

        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class CatagoryGenerics
    {
        public string status { get; set; }
        public string message { get; set; }
    }
}
