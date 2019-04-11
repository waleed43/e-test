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
    public class LoginViewModel : INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        public Action DisplayOk;
        public Action CheckInternetConnection;

        public string user_email;
        public string User_Email
        {
            get
            {
                return user_email;
            }
            set
            {
                user_email = value;
                //checkProperties();
                OnPropertyChanged("User_Contact");

            }
        }

        public string loginKey;
        public string LoginKey
        {
            get
            {
                return loginKey;
            }
            set
            {
                loginKey = value;
                //checkProperties();
                OnPropertyChanged("LoginKey");

            }
        }

        public ICommand LSubmitCommand
        {
            protected set; get;
        }

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

        public LoginViewModel()
        {
            LSubmitCommand = new Command(async () =>
            {
                IsBusy = true;
               

                var ress = await ApiResponse("Test", user_email,loginKey);

                if (!string.IsNullOrEmpty(ress))
                {
                    LoginGeneric req = JsonConvert.DeserializeObject<LoginGeneric>(ress.ToString());

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
                    LoginGeneric req = JsonConvert.DeserializeObject<LoginGeneric>(ress.ToString());
                    if (req != null)
                    {

                        if (req.status == "FALSE")
                        {
                            DisplayInvalidLoginPrompt();
                            IsBusy = false;
                        }
                    }
                }

                });
        
        }

        async Task<string> ApiResponse(string signin, string useremail, string loginkey)
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
                    postData.Add(new KeyValuePair<string, string>("signin", signin));
                    postData.Add(new KeyValuePair<string, string>("useremail", useremail));
                    postData.Add(new KeyValuePair<string, string>("login_key", loginkey));
                   

                    var content = new FormUrlEncodedContent(postData);

                    HttpClient client = new HttpClient();



                    var response = await client.PostAsync("http://theetest.com/API/signin.php", content);


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

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
    public class LoginGeneric
    {
        public string status { get; set; }
        public string message { get; set; }
    }
}
