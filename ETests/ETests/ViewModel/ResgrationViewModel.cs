using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ETests.ViewModel
{
    public class ResgrationViewModel : INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        public Action DisplayOk;
        public Action CheckInternetConnection;

        public User User { get; set; }
        public bool ErrorMessageVisiliby { get; set; }
        public string user_name;
       
        public string User_Name
        {
            get
            {
                return user_name;
            }
            set
            {
                user_name = value;
                //checkProperties();
                if (value.Length < 3)
                {
                    TextColorName = "#ff0000";
                }
                else
                    TextColorName = "#000000";
                OnPropertyChanged("User_Name");

            }
        }


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
                OnPropertyChanged("User_Email");

            }
        }


        public string user_contact;
        public string User_Contact
        {
            get
            {
                return user_contact;
            }
            set
            {
                user_contact = value;
                if (value.Length < 11)
                {
                    TextColorUser_Contact = "#ff0000";
                }else
                    TextColorUser_Contact = "#000000";
                //checkProperties();
                OnPropertyChanged("User_Contact");

            }
        }

        public string user_cnic;
        public string User_CNIC
        {
            get
            {
                return user_cnic;
            }
            set
            {
                user_cnic = value;
                //checkProperties();
                if (value.Length < 14)
                {
                    TextColorUser_CNIC = "#ff0000";
                }
                else
                {
                    TextColorUser_CNIC = "#000000";
                }
                OnPropertyChanged("User_CNIC");

            }
        }

        public string instute_name;
        public string Institute_Name
        {
            get
            {
                return instute_name;
            }
            set
            {
                instute_name = value;
                //checkProperties();
                if (value.Length < 4)
                {
                    TextColorInstitute_Name = "#ff0000";
                }
                else
                    TextColorInstitute_Name = "#000000";
                OnPropertyChanged("Institute_Name");

            }
        }

        public string city;
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
                if (value.Length < 4)
                {
                    TextColorCity = "#ff0000";
                }
                else
                    TextColorCity = "#000000";
                //checkProperties();
                OnPropertyChanged("City");

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand SubmitCommand
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
        private bool isButtonEnabled;
        public bool IsButtonEnabled
        {
            get { return isButtonEnabled; }
            set
            {
                isButtonEnabled = value;
                
                OnPropertyChanged("IsButtonEnabled");
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ResgrationViewModel()
        {
            User = new User();
            SubmitCommand = new Command(async () =>
            {
            if (string.IsNullOrEmpty(user_name) == false && user_name.Length < 3)
            {
                DisplayInvalidLoginPrompt();

                TextColorName = "#ff0000";
                IsBusy = false;
            }
            else if (string.IsNullOrEmpty(user_email) == false && user_email.Length < 7)
            {
                DisplayInvalidLoginPrompt();

                TextColorUser_Email = "#ff0000";
                IsBusy = false;
            }
            else if (string.IsNullOrEmpty(user_contact) == false && user_contact.Length < 11)
            {
                DisplayInvalidLoginPrompt();

                TextColorUser_Contact = "#ff0000";
                IsBusy = false;
            }
            else if (string.IsNullOrEmpty(instute_name) == false && instute_name.Length < 4)
               {
                    DisplayInvalidLoginPrompt();
                   
                    TextColorInstitute_Name = "#ff0000";
                    IsBusy = false;
                }
                else if (string.IsNullOrEmpty(city) == false && city.Length < 3)
                {
                    DisplayInvalidLoginPrompt();
                   
                    TextColorCity = "#ff0000";
                    IsBusy = false;
                }
                else
                {
                    IsBusy = true;
                    if (user_cnic == null)
                    {
                        user_cnic = " ";
                    }

                    var ress = await ApiResponse("Test", user_name, user_email, user_contact, user_cnic
                        , instute_name, city);

                    if (!string.IsNullOrEmpty(ress))
                    {
                        SignUpGeneric req = JsonConvert.DeserializeObject<SignUpGeneric>(ress.ToString());

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
                        SignUpGeneric req = JsonConvert.DeserializeObject<SignUpGeneric>(ress.ToString());
                        if (req != null)
                        {

                            if (req.status == "FALSE")
                            {
                                DisplayInvalidLoginPrompt();
                                IsBusy = false;
                            }
                        }
                    }

                }    });
        
        }

        void checkProperties()
        {
            if (string.IsNullOrEmpty(User_Name) == false && User_Name.Length > 2 && string.IsNullOrEmpty(User_Email) == false && User_Email.Length > 7
                && string.IsNullOrEmpty(User_Contact) == false && User_Contact.Length > 11 && string.IsNullOrEmpty(User_CNIC) == false
                &&User_CNIC.Length>14
                && string.IsNullOrEmpty(Institute_Name) == false && Institute_Name.Length > 5 && string.IsNullOrEmpty(City) == false && City.Length > 4)
                IsButtonEnabled = true;
            else
                IsButtonEnabled = false;

        }
        public string textColorUser_Email;
        public string TextColorUser_Email
        {
            get
            {
                return textColorUser_Email;
            } set
            {
                textColorUser_Email = value;
                OnPropertyChanged("TextColorUser_Email");
            }
        }

        public string textColorName;
        public string TextColorName { 
                get
            {
                    return textColorName;
                }
                set
            {
                textColorName = value;
                OnPropertyChanged("TextColorName");
            }
            }

        public string textColorUser_Contact;
        public string TextColorUser_Contact
        {
            get
            {
                return textColorUser_Contact;
            }
            set
            {
                textColorUser_Contact = value;
                OnPropertyChanged("TextColorUser_Contact");
            }
        }

        public string textColorUser_CNIC;
        public string TextColorUser_CNIC
        {
            get
            {
                return textColorUser_CNIC;
            }
            set
            {
                textColorUser_CNIC = value;
                
                OnPropertyChanged("TextColorUser_CNIC");
            }
        }

        public string textColorInstitute_Name;
        public string TextColorInstitute_Name
        {
            get
            {
                return textColorInstitute_Name;
            }
            set
            {
                textColorInstitute_Name = value;
                OnPropertyChanged("TextColorInstitute_Name");
            }
        }

        public string textColorCity;
        public string TextColorCity
        {
            get
            {
                return textColorCity;
            }
            set
            {
                textColorCity = value;
                OnPropertyChanged("TextColorCity");
            }
        }
        public async void OnSubmit()
        {


            //User = new User();
            //string name = User.Name.Name.ToString();
            //string email = User.Email.Name.ToString();
            //string contact = User.Contact.Name.ToString();
            //string cnic = User.CNIC.Name.ToString();
            //string institute = User.Institute.Name.ToString();
            //string city = User.City.Name.ToString();

            //if (string.IsNullOrEmpty(user_name) == false && user_name.Length < 2)
            //{
            //    DisplayInvalidLoginPrompt();
               
            //    TextColorName = "#ff0000";
            //    IsBusy = false;
            //}
            //else
            //{
                var ress = await ApiResponse("Test", user_name, user_email, user_contact, user_cnic
                    , instute_name, city);
            //}

            

            

        }

        async Task<string> ApiResponse(string Device_Registration, string User_Name, string User_Email,
            string User_Contact, string User_CNIC, string Institute_Name, string City)
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
                        postData.Add(new KeyValuePair<string, string>("device_registered", Device_Registration));
                        postData.Add(new KeyValuePair<string, string>("username", User_Name));
                        postData.Add(new KeyValuePair<string, string>("useremail", User_Email));
                        postData.Add(new KeyValuePair<string, string>("usercontact", User_Contact));
                        postData.Add(new KeyValuePair<string, string>("user_cnic", User_CNIC));
                        postData.Add(new KeyValuePair<string, string>("institution_name", Institute_Name));
                        postData.Add(new KeyValuePair<string, string>("city", City));

                        var content = new FormUrlEncodedContent(postData);

                        HttpClient client = new HttpClient();



                        var response = await client.PostAsync("http://theetest.com/API/new_req.php", content);


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

    }
    public class SignUpGeneric
    {
        public string status { get; set; }
        public string message { get; set; }
    }

    public class Field : INotifyPropertyChanged
    {
        string name;
        public string Name {
            get
            {
                return name;
            } set
            {
                name = value;
                OnPropertyChanged("Name");


            } }
        public bool IsNotValid { get; set; }
        public string NotValidMessageError { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
       
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class User: INotifyPropertyChanged
    {
        public Field user_Name;
        public Field User_Name { get; set; } = new Field();


        public string user_email;

        public Field Name { get; set; } = new Field();
        public Field Email { get; set; } = new Field();
        public Field Contact { get; set; } = new Field();
        public Field CNIC { get; set; } = new Field();
        public Field Institute { get; set; } = new Field();
        public Field City { get; set; } = new Field();
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
