using ETests.Model;
using ETests.View;
using SQLite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ETests
{
    public partial class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }
        public static bool IsDashBoard { get; set; }
        public static bool IsTestPage { get; set; }
        public static DataAccess dbUtils;

        public App()
        {
            InitializeComponent();
            //if (Application.Current.Properties.ContainsKey("IsUserLoggedIn"))
            //{
            //    bool MyProp = Application.Current.Properties["IsUserLoggedIn"] is bool;
            //    if (MyProp == true)
            //    {
            //        if (Application.Current.Properties.ContainsKey("IsDashBoard"))
            //        {
            //            bool MyPropDash = Application.Current.Properties["IsDashBoard"] is bool;
            //            if (MyPropDash == true)
            //            {
            //                MainPage = new NavigationPage(new NavigationDrawarPage());
            //            }
            //            else
            //            {
            //                MainPage = new NavigationPage(new TestMode());
            //            }
            //        }
            //        else
            //        {
            //            MainPage = new NavigationPage(new TestMode());
            //        }


            //    }
            //    else
            //    {
            //        MainPage = new NavigationPage(new RegistrationPage());
            //    }
            //}
            //else
            //{
                //MainPage = new NavigationPage(new TestMode());
            //}
            // create the table(s)

            // if (IsUserLoggedIn)
            // {
            //     MainPage = new NavigationPage(new NavigationDrawarPage());
            // }
            // else
            // {
            //     MainPage = new NavigationPage(new RegistrationPage());
            //}
        }


        public static DataAccess DAUtil
        {
            get
            {
                if (dbUtils == null)
                {
                    dbUtils = new DataAccess();
                }
                return dbUtils;
            }
        }
        protected override void OnStart()
        {

            if (Application.Current.Properties.ContainsKey("IsUserLoggedIn"))
            {
                bool MyProp = Application.Current.Properties["IsUserLoggedIn"] is bool;
                if (MyProp == true)
                {
                    if (Application.Current.Properties.ContainsKey("IsTestCatagory"))
                    {
                        bool TestCatagory = Application.Current.Properties["IsTestCatagory"] is bool;
                        if (TestCatagory == true)
                        {


                            if (Application.Current.Properties.ContainsKey("IsUserSignIn"))
                            {
                                bool MyPropDash = Application.Current.Properties["IsUserSignIn"] is bool;
                                if (MyPropDash == true)
                                {
                                    MainPage = new NavigationPage(new NavigationDrawarPage());
                                }
                                else
                                {
                                    MainPage = new NavigationPage(new LoginPage());
                                }
                            }
                            else
                            {
                                MainPage = new NavigationPage(new LoginPage());
                            }
                        }
                        else
                        {
                            MainPage = new NavigationPage(new TestMode());
                        }

                    }
                    else
                    {
                        MainPage = new NavigationPage(new TestMode());
                    }
                }
                else
                {
                    MainPage = new NavigationPage(new RegistrationPage());
                }
            }
            else
            {

                MainPage = new NavigationPage(new RegistrationPage());
           }
        }
        protected override void OnSleep()
        {
            // Handle when your app sleeps
            
        }

        protected override void OnResume()
        {
            //if (Application.Current.Properties.ContainsKey("IsUserLoggedIn"))
            //{

            //    bool MyProp = Application.Current.Properties["IsUserLoggedIn"] is bool;
            //    if (MyProp == true)
            //    {
            //        if (Application.Current.Properties.ContainsKey("IsDashBoard"))
            //        {
            //            bool MyPropDash = Application.Current.Properties["IsDashBoard"] is bool;
            //            if (MyPropDash == true)
            //            {

            //                if (Application.Current.Properties.ContainsKey("IsTestPage"))
            //                {
            //                    bool testpage = Application.Current.Properties["IsTestPage"] is bool;
            //                    if (testpage == true)
            //                    {
            //                        // MainPage = new NavigationPage(new QuizPage());
            //                    }
            //                    else
            //                    {
            //                        MainPage = new NavigationPage(new NavigationDrawarPage());
            //                    }
            //                }
            //                else
            //                {
            //                    MainPage = new NavigationPage(new NavigationDrawarPage());
            //                }
            //                //MainPage = new NavigationPage(new NavigationDrawarPage());
            //            }
            //            else
            //            {
            //                MainPage = new NavigationPage(new TestMode());
            //            }
            //        }
            //        else
            //        {
            //            MainPage = new NavigationPage(new TestMode());
            //        }

            //    }
            //    else
            //    {
            //        MainPage = new NavigationPage(new RegistrationPage());
            //    }
            //}
            //else
            //{
            //    MainPage = new NavigationPage(new RegistrationPage());
            //}
            if (Application.Current.Properties.ContainsKey("IsUserLoggedIn"))
            {
                bool MyProp = Application.Current.Properties["IsUserLoggedIn"] is bool;
                if (MyProp == true)
                {
                    if (Application.Current.Properties.ContainsKey("IsTestCatagory"))
                    {
                        bool TestCatagory = Application.Current.Properties["IsTestCatagory"] is bool;
                        if (TestCatagory == true)
                        {


                            if (Application.Current.Properties.ContainsKey("IsUserSignIn"))
                            {
                                bool MyPropDash = Application.Current.Properties["IsUserSignIn"] is bool;
                                if (MyPropDash == true)
                                {
                                    MainPage = new NavigationPage(new NavigationDrawarPage());
                                }
                                else
                                {
                                    MainPage = new NavigationPage(new LoginPage());
                                }
                            }
                            else
                            {
                                MainPage = new NavigationPage(new LoginPage());
                            }
                        }
                        else
                        {
                            MainPage = new NavigationPage(new TestMode());
                        }

                    }
                    else
                    {
                        MainPage = new NavigationPage(new TestMode());
                    }
                }
                else
                {
                    MainPage = new NavigationPage(new RegistrationPage());
                }
            }
            else
            {

                MainPage = new NavigationPage(new RegistrationPage());
            }
        }
    }
    }

