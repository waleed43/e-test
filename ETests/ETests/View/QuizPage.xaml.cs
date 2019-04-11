using ETests.Model;
using IntelliAbb.Xamarin.Controls;
using Rg.Plugins.Popup.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ETests.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuizPage : ContentPage
    {
        SQLiteAsyncConnection dbConn, dbConn2, dbConn3;
        public static string sco;
        public static string EXTRA_SCORE = "extraScore";
        private static long COUNTDOWN_IN_MILLIS = 30000;

        int outA = 0;int outB = 0;int outC = 0; int outD=0;

        private bool defaultChecked;

        List<TestScore> testScore;
        int tstscore;

        private static string KEY_SCORE = "keyScore";
        private static string KEY_QUESTION_COUNT = "keyQuestionCount";
        private static string KEY_MILLIS_LEFT = "keyMillisLeft";
        private static string KEY_ANSWERED = "keyAnswered";
        private static string KEY_QUESTION_LIST = "keyQuestionList";
        List<Questions> list, sublist;
        public List<string> answer = new List<string>();
        public List<string> colorList = new List<string>();
        List<string> CorrectAnswer = new List<string>();
        private Color textColorDefaultRb;
        private Color textColorDefaultCd,confirmbtnColor;
        private bool ischecked;

        private int prevCounter, questionNumber;
        private int questionCountTotal;
        private int questionCounter;
        private Questions currentQuestion,previousQuestion;

        public int score=0;
        public int scoreB = 0;
        public int scoreC = 0;
        public int scoreD = 0;
        public string selectedAnswer;
        private bool answered;

        int i = 0;

        private long backPressedTime;

        bool btnfocus, btn2focus, btn3focus, btn4focus;
         
        private int counter = 0;
        private int mins;

       

        private int isTimerCancel = 0;

        string ans;

       

        string tableName;
        public static int ind,inde;

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            //Option A
            var fram = sender as Frame;
            btnfocus = fram.IsEnabled;

            centerFram1.BackgroundColor = Color.FromHex("#039be5");
            centerFram2.BackgroundColor = Color.White;
            centerFram3.BackgroundColor = Color.White;
            centerFram4.BackgroundColor = Color.White;
            if (list[prevCounter].Sections.Contains("A"))
            {
                outA++;
            }
            else if (list[prevCounter].Sections.Contains("B"))
            {
                outB++;
            }
            else if (list[prevCounter].Sections.Contains("C"))
            {
                outC++;
            }


            if (list[prevCounter].Answer.Contains("A"))
            {
                //if (list[prevCounter].Sections.Contains("A"))
                //{

                //    score++;
                //}
                //else if (list[prevCounter].Sections.Contains("B"))
                //{
                //    scoreB++;
                //}
                //else if (list[prevCounter].Sections.Contains("C"))
                //{
                //    scoreC++;
                //}

                list[prevCounter].textcolorA = "#00FF00";
                list[prevCounter].TextColorB = "#000000";
                list[prevCounter].TextColorC = "#000000";
                list[prevCounter].TextColorD = "#000000";
            }
            else if (list[prevCounter].Answer.Contains("B"))
            {
                list[prevCounter].textcolorA = "#0000ff";
                list[prevCounter].TextColorB = "#00FF00";
                list[prevCounter].TextColorC = "#000000";
                list[prevCounter].TextColorD = "#000000";
            }
            else if (list[prevCounter].Answer.Contains("C"))
            {
                list[prevCounter].textcolorA = "#0000ff";
                list[prevCounter].TextColorB = "#000000";
                list[prevCounter].TextColorC = "#00FF00";
                list[prevCounter].TextColorD = "#000000";
            }
            else if (list[prevCounter].Answer.Contains("D"))
            {
                list[prevCounter].textcolorA = "#0000ff";
                list[prevCounter].TextColorB = "#000000";
                list[prevCounter].TextColorC = "#000000";
                list[prevCounter].TextColorD = "#00FF00";
            }
           

            list[prevCounter].SeclectedButtonA = "#0000FF";
            list[prevCounter].SeclectedButtonB = "#000000";
            list[prevCounter].SeclectedButtonC = "#000000";
            list[prevCounter].SeclectedButtonD = "#000000";



        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            //Option C
            var fram = sender as Frame;
            btn3focus = fram.IsEnabled;

            centerFram3.BackgroundColor = Color.FromHex("#039be5");
            centerFram1.BackgroundColor = Color.White;
            centerFram2.BackgroundColor = Color.White;
            centerFram4.BackgroundColor = Color.White;

            if (list[prevCounter].Sections.Contains("A"))
            {
                outA++;
            }
            else if (list[prevCounter].Sections.Contains("B"))
            {
                outB++;
            }
            else if (list[prevCounter].Sections.Contains("C"))
            {
                outC++;
            }

            if (list[prevCounter].Answer.Contains("A"))
            {

                list[prevCounter].textcolorA = "#00FF00";
                list[prevCounter].TextColorB = "#000000";
                list[prevCounter].TextColorC = "#0000ff";
                list[prevCounter].TextColorD = "#000000";
            }
            else if (list[prevCounter].Answer.Contains("B"))
            {
                list[prevCounter].textcolorA = "#000000";
                list[prevCounter].TextColorB = "#00FF00";
                list[prevCounter].TextColorC = "#0000ff";
                list[prevCounter].TextColorD = "#000000";
            }
            else if (list[prevCounter].Answer.Contains("C"))
            {
            //    if (list[prevCounter].Sections.Contains("A"))
            //    {
            //        score++;
            //    }
            //    else if (list[prevCounter].Sections.Contains("B"))
            //    {
            //        scoreB++;
            //    }
            //    else if (list[prevCounter].Sections.Contains("C"))
            //    {
            //        scoreC++;
            //    }
                list[prevCounter].textcolorA = "#000000";
                list[prevCounter].TextColorB = "#000000";
                list[prevCounter].TextColorC = "#00FF00";
                list[prevCounter].TextColorD = "#000000";
            }
            else if (list[prevCounter].Answer.Contains("D"))
            {
                list[prevCounter].textcolorA = "#000000";
                list[prevCounter].TextColorB = "#000000";
                list[prevCounter].TextColorC = "#0000ff";
                list[prevCounter].TextColorD = "#00FF00";
            }
            list[prevCounter].SeclectedButtonC = "#0000FF";
            list[prevCounter].SeclectedButtonB = "#000000";
            list[prevCounter].SeclectedButtonA = "#000000";
            list[prevCounter].SeclectedButtonD = "#000000";
        }

        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            //Option D
            var fram = sender as Frame;
            btn4focus = fram.IsEnabled;

            centerFram4.BackgroundColor = Color.FromHex("#039be5");
            centerFram1.BackgroundColor = Color.White;
            centerFram3.BackgroundColor = Color.White;
            centerFram2.BackgroundColor = Color.White;

            if (list[prevCounter].Sections.Contains("A"))
            {
                outA++;
            }
            else if (list[prevCounter].Sections.Contains("B"))
            {
                outB++;
            }
            else if (list[prevCounter].Sections.Contains("C"))
            {
                outC++;
            }

            if (list[prevCounter].Answer.Contains("A"))
            {
                //score++;
                list[prevCounter].textcolorA = "#00FF00";
                list[prevCounter].TextColorB = "#000000";
                list[prevCounter].TextColorC = "#000000";
                list[prevCounter].TextColorD = "#0000ff";
            }
            else if (list[prevCounter].Answer.Contains("B"))
            {
                list[prevCounter].textcolorA = "#000000";
                list[prevCounter].TextColorB = "#00FF00";
                list[prevCounter].TextColorC = "#000000";
                list[prevCounter].TextColorD = "#0000ff";
            }
            else if (list[prevCounter].Answer.Contains("C"))
            {
                list[prevCounter].textcolorA = "#000000";
                list[prevCounter].TextColorB = "#000000";
                list[prevCounter].TextColorC = "#00FF00";
                list[prevCounter].TextColorD = "#0000ff";
            }
            else if (list[prevCounter].Answer.Contains("D"))
            {
                //if (list[prevCounter].Sections.Contains("A"))
                //{
                //    score++;
                //}
                //else if (list[prevCounter].Sections.Contains("B"))
                //{
                //    scoreB++;
                //}
                //else if (list[prevCounter].Sections.Contains("C"))
                //{
                //    scoreC++;
                //}
                list[prevCounter].textcolorA = "#000000";
                list[prevCounter].TextColorB = "#000000";
                list[prevCounter].TextColorC = "#000000";
                list[prevCounter].TextColorD = "#00FF00";
            }
            list[prevCounter].SeclectedButtonD = "#0000FF";
            list[prevCounter].SeclectedButtonB = "#000000";
            list[prevCounter].SeclectedButtonC = "#000000";
            list[prevCounter].SeclectedButtonA = "#000000";
        }

       

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            //Option B
            var fram = sender as Frame;
            btn2focus = fram.IsEnabled;

            centerFram2.BackgroundColor = Color.FromHex("#039be5");
            centerFram1.BackgroundColor = Color.White;
            centerFram3.BackgroundColor = Color.White;
            centerFram4.BackgroundColor = Color.White;

            if (list[prevCounter].Sections.Contains("A"))
            {
                outA++;
            }
            else if (list[prevCounter].Sections.Contains("B"))
            {
                outB++;
            }
            else if (list[prevCounter].Sections.Contains("C"))
            {
                outC++;
            }

            if (list[prevCounter].Answer.Contains("A"))
            {
                //score++;
                list[prevCounter].textcolorA = "#00ff00";
                list[prevCounter].TextColorB = "#0000ff";
                list[prevCounter].TextColorC = "#000000";
                list[prevCounter].TextColorD = "#000000";
            }
            else if (list[prevCounter].Answer.Contains("B"))
            {
                //if (list[prevCounter].Sections.Contains("A"))
                //{
                //    score++;
                //}
                //else if (list[prevCounter].Sections.Contains("B"))
                //{
                //    scoreB++;
                //}
                //else if (list[prevCounter].Sections.Contains("C"))
                //{
                //    scoreC++;
                //}
                list[prevCounter].textcolorA = "#000000";
                list[prevCounter].TextColorB = "#00FF00";
                list[prevCounter].TextColorC = "#000000";
                list[prevCounter].TextColorD = "#000000";
            }
            else if (list[prevCounter].Answer.Contains("C"))
            {
                list[prevCounter].textcolorA = "#000000";
                list[prevCounter].TextColorB = "#0000ff";
                list[prevCounter].TextColorC = "#00FF00";
                list[prevCounter].TextColorD = "#000000";
            }
            else if (list[prevCounter].Answer.Contains("D"))
            {
                list[prevCounter].textcolorA = "#000000";
                list[prevCounter].TextColorB = "#0000ff";
                list[prevCounter].TextColorC = "#000000";
                list[prevCounter].TextColorD = "#00FF00";
            }
            list[prevCounter].SeclectedButtonB = "#0000FF";
            list[prevCounter].SeclectedButtonA = "#000000";
            list[prevCounter].SeclectedButtonC = "#000000";
            list[prevCounter].SeclectedButtonD = "#000000";
        }
        int count;
        //SQLiteAsyncConnection database;
        //public QuizPage(string path, int count, string tableName, int min)
        //{
        //    database = new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "etests.db"));
        //    database.CreateTableAsync<Questions>().Wait();
        //    this.count = count;
        //    this.tableName = tableName;
        //    this.mins = min;
        //}
        string catagory;
        public QuizPage(int count, string tableName,string catagory,int min)
        {
            InitializeComponent();
            answer.Clear();
            this.tableName = tableName;
            this.count = count;
            this.catagory = catagory;
            dbConn = DependencyService.Get<ISQLite>().GetConnection();
            dbConn2 = DependencyService.Get<ISQLite>().GetConnection();
            dbConn3 = DependencyService.Get<ISQLite>().GetConnection();
            //dbConn.CreateTableAsync<Questions>().Wait();
            Task.Run(async() =>
            {
                await dbConn.CreateTableAsync<Questions>();
                await dbConn2.CreateTableAsync<TestDetail>();
                await dbConn3.CreateTableAsync<DashBoardListview>();

                string test1 = "Test No - 1";
                list = await dbConn.QueryAsync<Questions>("Select ID,Sections,Question,A,B,C,D,Answer,Filepath,SectionNO From [UpdatedQuestions] WHERE Test=\"" + tableName + "\"");
                testScore = await dbConn.QueryAsync<TestScore>("Select Tests,Score,Numbertapped,OutofC From [Test_score] WHERE Tests=\"" + tableName + "\"");
                sectionA = await dbConn.QueryAsync<Questions>("Select ID,Sections,Question,A,B,C,D,Answer,Filepath From [UpdatedQuestions] WHERE Sections=\"PHYSICS\" AND Test=\"" + tableName + "\"");
                sectionB = await dbConn.QueryAsync<Questions>("Select ID,Sections,Question,A,B,C,D,Answer,Filepath From [UpdatedQuestions] WHERE Sections=\"CHEMISTRY\" AND Test=\"" + tableName + "\"");
                sectionC = await dbConn.QueryAsync<Questions>("Select ID,Sections,Question,A,B,C,D,Answer,Filepath From [UpdatedQuestions] WHERE Sections=\"ENGLISH\" AND Test=\"" + tableName + "\"");
                Biology = await dbConn.QueryAsync<Questions>("Select ID,Sections,Question,A,B,C,D,Answer,Filepath From [UpdatedQuestions] WHERE Sections=\"BIOLOGY\" AND Test=\"" + tableName + "\"");
                dashBoardListviews = await dbConn3.QueryAsync<DashBoardListview>("select A,B,C,Atotal,Btotal,Ctotal from DashBoardListview where TestName=\"" + tableName + "\"");

                if (dashBoardListviews.Count > 0)
                {
                    //await DisplayAlert("count", ""+dashBoardListviews.Count, "ok");
                    A = Convert.ToInt32(dashBoardListviews[0].A);
                    B = Convert.ToInt32(dashBoardListviews[0].B);
                    C = Convert.ToInt32(dashBoardListviews[0].C);
                    at = Convert.ToInt32(dashBoardListviews[0].Atotal);
                    bt = Convert.ToInt32(dashBoardListviews[0].Btotol);
                    ct = Convert.ToInt32(dashBoardListviews[0].Ctotal);




                }


                sectionAcount = sectionA.Count;
                sectionBcount = sectionB.Count;
                sectionCcount = sectionC.Count;

                MessagingCenter.Send(new TestScore() { Myvalue = tableName }, "PopUpData");


                tstscore = testScore[0].Numbertapped;
                //if (tstscore.Score != 0)
                //{
                //    await DisplayAlert("task", ""+tstscore.Score, "Ok");
                //}

                questionCountTotal = list.Count;

                // Random rnd = new Random();
                // questionNumber = rnd.Next(0, list.Count);

                //Questions selectedItem = list[questionNumber];

                // showNextQuestion();
                currentQuestion = list[0];
                // await DisplayAlert("Message", ""+list.Count, "OK");
                // defaultChecked = btnAnswerOne.IsToggled;
                textColorDefaultCd = lblQuestion.TextColor;
                confirmbtnColor = btnConfirm.BackgroundColor;
                prevCounter = list.IndexOf(currentQuestion);
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].ID = (i + 1).ToString();
                }
                LIST.ItemsSource = list;
                //await DisplayAlert("MESSAGE", ""+currentQuestion.Filepath, "OK");
                if (currentQuestion.Filepath != null)
                {

                    //string icon_path = new Uri(currentQuestion.Filepath).LocalPath;
                    //img.Source = ImageSource.FromFile(currentQuestion.Filepath);
                    // img.IsVisible = false;
                }

                //Questions current2 = sectionA[0];
                //int indexer = sectionA.IndexOf(current2)+1;
                //if (currentQuestion.Sections.Contains("PHYSICS"))
                //{
                lblquestionNo.Text = "Question No" + currentQuestion.ID;
                lblsectionNo.Text = "Section:  " + currentQuestion.Sections + " (" + currentQuestion.SectionNO + "/" + sectionAcount + ")";
                a++;
                //}
                //else if (currentQuestion.Sections.Contains("B"))
                //{
                //    lblquestionNo.Text = "Question No" + currentQuestion.ID + ":                                          Section:" + currentQuestion.Sections + "(" + b + "/" + sectionBcount + ")";
                //    b++;
                //}
                //else if (currentQuestion.Sections.Contains("C"))
                //{
                //    lblquestionNo.Text = "Question No" + currentQuestion.ID + ":                                          Section:" + currentQuestion.Sections + "(" + c + "/" + sectionCcount + ")";
                //    c++;
                //}

                lblQuestion.Text = currentQuestion.Question;
                Option1.Text = currentQuestion.A;
                Option2.Text = currentQuestion.B;
                Option3.Text = currentQuestion.C;
                Option4.Text = currentQuestion.D;


                this.Title = tableName;
                //btnAnswerOne.Text = currentQuestion.A;
                //btnAnswerTwo.Text = currentQuestion.B;
                //btnAnswerThree.Text = currentQuestion.C;
                //btnAnswerFour.Text = currentQuestion.D;
                int cou = prevCounter + 1;
                list[0].FrameBackGroundColor = "#01579B";
                for (int i = 1; i < list.Count; i++)
                {
                    list[i].FrameBackGroundColor = "#039be5";
                }

                //LIST.WidthRequest = (20 * list.Count) + (10 * list.Count);
                //QuestionCount.Text = "Question: " + cou + "/" + questionCountTotal;
                answered = false;
                questionNumber = list.IndexOf(currentQuestion);
            });
            MessagingCenter.Subscribe<PopupList>(this, "data", (value) =>
            {
                if (value != null)
                {
                    prevCounter = 0;
                    int i2 = Convert.ToInt32(value.Myvalue);
                    prevCounter = i2;
                    //DisplayAlert("index", ""+prevCounter, "ok");
                    for (int i = 0; i < list.Count; i++)
                    {
                        list[i].FrameBackGroundColor = "#039be5";
                    }

                    list[prevCounter].FrameBackGroundColor = "#01579B";
                    LIST.ItemsSource = null;
                    LIST.ItemsSource = list;
                    
                    //var target = list[prevCounter - 1];
                    //LIST.ScrollTo(target, ScrollToPosition.Start, true);
                    // LIST.ScrollTo();
                    centerFram1.BackgroundColor = Color.White;
                    centerFram2.BackgroundColor = Color.White;
                    centerFram3.BackgroundColor = Color.White;
                    centerFram4.BackgroundColor = Color.White;
                    Questions PopQuestion = list[prevCounter];
                    if (list[prevCounter].Sections.Contains("PHYSICS"))
                    {

                        //Questions prevQuestion = sectionA[prevCounter];
                        ////a--;
                        //int sectionc = sectionA.IndexOf(prevQuestion) + 1;
                        //acount = sectionAcount - 1;
                        lblquestionNo.Text = "Question No" + PopQuestion.ID;
                        lblsectionNo.Text = "Section:  " + PopQuestion.Sections + "  (" + PopQuestion.SectionNO + "/" + sectionAcount + ")";
                        //if (sectionc == 1)
                        //{
                        //    a++;
                        //}
                        //DisplayAlert("MS", "" + prevCounter, "OK");
                        // }

                    }
                    else if (list[prevCounter].Sections.Contains("CHEMISTRY"))
                    {

                        //else if (list[prevCounter].Sections.Contains("B"))
                        //{

                        if (sectionB.Count <= 2)
                        {
                            // DisplayAlert("INDEX", "" + sectionB.Count, "OK");
                            int j1 = prevCounter - (sectionBcount + 1);
                            Questions PopQuestion1 = sectionB[j1];
                            int i = sectionB.IndexOf(PopQuestion1) + 1;
                            lblquestionNo.Text = "Question No" + currentQuestion.ID;
                            lblsectionNo.Text = "Section:  " + currentQuestion.Sections + "  (" + currentQuestion.SectionNO + "/" + sectionB.Count + ")";
                        }
                        else
                        {
                            //int j = prevCounter - sectionBcount;
                            ////DisplayAlert("sectionB", "" + sectionB.Count, "ok");
                            //Questions PopQuestion2 = sectionB[j];
                            ////j++;
                            //int i23 = sectionB.IndexOf(PopQuestion2) + 1;
                            lblquestionNo.Text = "Question No" + PopQuestion.ID;
                            lblsectionNo.Text = "Section:  " + PopQuestion.Sections + "  (" + PopQuestion.SectionNO + "/" + sectionB.Count + ")";
                        }

                        //}
                    }
                    else if (list[prevCounter].Sections.Contains("ENGLISH"))
                    {
                        lblquestionNo.Text = "Question No" + PopQuestion.ID;
                        lblsectionNo.Text = "Section:  " + PopQuestion.Sections + "  (" + PopQuestion.SectionNO + "/" + sectionCcount + ")";
                        c++;
                    }
                    else if (list[prevCounter].Sections.Contains("BIOLOGY"))
                    {
                        lblquestionNo.Text = "Question No" + PopQuestion.ID;
                        lblsectionNo.Text = "Section:  " + PopQuestion.Sections + "  (" + PopQuestion.SectionNO + "/" + Biology.Count + ")";
                    }
                    //DisplayAlert("M", ""+PopQuestion.Sections, "OK");
                    //if (list[prevCounter].Sections.Contains("A"))
                    //{

                    //    if (prevCounter+1 <= sectionAcount)
                    //    {

                    //        Questions PopQuestion2 = sectionA[prevCounter];
                    //        int i = (sectionA.IndexOf(PopQuestion2))+1;
                    //        //i++;
                    //        lblquestionNo.Text = "Question No" + PopQuestion.ID;
                    //       lblsectionNo.Text= "Section:" + PopQuestion.Sections + "(" + i.ToString() + "/" + sectionAcount + ")";
                    //        // DisplayAlert("MESSAGE", "A:" + i, "OK");
                    //    }
                    //    //else
                    //    //{ 

                    //    //}

                    //    //a++;

                    //}else if (prevCounter+1 > sectionAcount)
                    //{
                    //    //if (prevCounter >= sectionBcount)
                    //    //{
                    //    if (sectionB.Count <= 2)
                    //    {
                    //        int j1 = prevCounter - (sectionBcount+1);
                    //        Questions PopQuestion1 = sectionB[j1];
                    //        int i = sectionB.IndexOf(PopQuestion1) + 1;
                    //        lblquestionNo.Text = "Question No" + PopQuestion.ID;
                    //        lblsectionNo.Text= "Section:" + PopQuestion.Sections + "(" + i.ToString() + "/" + sectionBcount + ")";
                    //    }
                    //    else
                    //    {
                    //        int j = prevCounter - sectionBcount;
                    //       // DisplayAlert("sectionB", "" + sectionB.Count, "ok");
                    //        Questions PopQuestion2 = sectionB[j];
                    //        //j++;
                    //        int i23 = sectionB.IndexOf(PopQuestion2) + 1;
                    //        lblquestionNo.Text = "Question No" + PopQuestion.ID;
                    //        lblsectionNo.Text= "Section:" + PopQuestion.Sections + "(" + i23.ToString() + "/" + sectionBcount + ")";
                    //    }

                    //        //DisplayAlert("index", "B:" + i, "ok");
                    //    //}
                    //    //DisplayAlert("MESSAGE", "B", "OK");

                    //}
                    //else
                    //{

                    //}
                    //else if (PopQuestion.Sections.Contains("C"))
                    //{
                    //    lblquestionNo.Text = "Question No" + PopQuestion.ID + ":                                           Section:" + PopQuestion.Sections + "(" + c + "/" + sectionCcount + ")";
                    //    c++;
                    //}

                    
                        var target = list[prevCounter];
                    LIST.ScrollTo(target, ScrollToPosition.Start, true);
                    //lblQuestion.Text = currentQuestion.Question;
                    lblQuestion.Text = PopQuestion.Question;
                    Option1.Text = PopQuestion.A;
                    Option2.Text = PopQuestion.B;
                    Option3.Text = PopQuestion.C;
                    Option4.Text = PopQuestion.D;
                    
                    if (PopQuestion.Filepath != null)
                    {

                        //string icon_path = new Uri(currentQuestion.Filepath).LocalPath;
                        img.Source = ImageSource.FromFile(PopQuestion.Filepath);
                    }
                   

                    if (PopQuestion.SeclectedButtonA != null && PopQuestion.SeclectedButtonA.Contains("#0000FF"))
                    {
                        centerFram1.BackgroundColor = Color.FromHex("#039be5");
                        centerFram3.BackgroundColor = Color.White;
                        centerFram2.BackgroundColor = Color.White;
                        centerFram4.BackgroundColor = Color.White;


                    }
                    else if (PopQuestion.SeclectedButtonC != null && PopQuestion.SeclectedButtonB.Contains("#0000FF"))
                    {
                        centerFram2.BackgroundColor = Color.FromHex("#039be5");
                        centerFram3.BackgroundColor = Color.White;
                        centerFram4.BackgroundColor = Color.White;
                        centerFram1.BackgroundColor = Color.White;

                    }
                    else if (PopQuestion.SeclectedButtonC != null && PopQuestion.SeclectedButtonC.Contains("#0000FF"))
                    {
                        centerFram3.BackgroundColor = Color.FromHex("#039be5");
                        centerFram4.BackgroundColor = Color.White;
                        centerFram2.BackgroundColor = Color.White;
                        centerFram1.BackgroundColor = Color.White;

                    }
                    else if (PopQuestion.SeclectedButtonD != null && PopQuestion.SeclectedButtonD.Contains("#0000FF"))
                    {
                        centerFram4.BackgroundColor = Color.FromHex("#039be5");
                        centerFram3.BackgroundColor = Color.White;
                        centerFram2.BackgroundColor = Color.White;
                        centerFram1.BackgroundColor = Color.White;

                    }
                    else
                    {
                        centerFram4.BackgroundColor = Color.White;
                        centerFram3.BackgroundColor = Color.White;
                        centerFram2.BackgroundColor = Color.White;
                        centerFram1.BackgroundColor = Color.White;

                    }
                    //answered = false;
                    if (prevCounter+1 == questionCountTotal)
                    {
                        answered = true;
                    }
                }

            });
            //ind = index;
            //mins = list.Count;
            int hour = 3;
            min = 40;
            StartTimer(hour,min, counter);

        }

        bool isRunning;
        int totalmin = 0;
        int totolsec = 0;
        int totalhou = 0;
        public void StartTimer(int h,int m, int sec)
        {
           
            mins = m;
            counter = sec;
            totalhou = h;
            Device.StartTimer(new TimeSpan(0,0, 1), () =>
            {
                if (isTimerCancel == 1)
                {
                    //DisplayAlert("ALERT", "TIMER IS STOPPED!", "OK");
                    return false;
                }
                else
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        totolsec = totolsec + 1;
                        if (totolsec == 59)
                        {
                            totolsec = 0;
                            totalmin = totalmin + 1;

                        }
                        counter = counter - 1;
                        if (counter < 0)
                        {
                            counter = 59;
                            mins = mins - 1;

                            //if (mins < 1)
                            //{
                            //    CountDown.TextColor = Color.Red;


                            //}
                            //if (mins < 0)
                            //{
                            //    //CountDown.TextColor = Color.Red;
                            //    mins = 59;
                            //    totalhou = totalhou - 1;

                            //}

                        }
                        if (mins < 0)
                        {
                            //CountDown.TextColor = Color.Red;
                            mins = 59;
                            totalhou = totalhou - 1;

                        }
                        if (totalhou < 0)
                        {
                            totalhou = 0;
                            mins = 0;
                            counter = 0;
                        }
                        CountDown.Text = string.Format("{0:00}:{1:00}:{2:00}", totalhou,mins, counter);
                    });
                    if (mins == 0 && counter == 0)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i].TextColorA != null && list[i].TextColorB != null
                         && list[i].TextColorC != null && list[i].TextColorD != null &&
                        list[i].TextColorA.Contains("#00FF00") && list[i].TextColorB.Contains("#000000")
                         && list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#000000"))
                            {
                                if (list[i].Sections.Contains("PHYSICS"))
                                {
                                    score = score + 5;
                                }
                                else if (list[i].Sections.Contains("CHEMISTRY"))
                                {
                                    scoreB = scoreB + 5;
                                }
                                else if (list[i].Sections.Contains("ENGLISH"))
                                {
                                    scoreC = scoreC + 5;
                                }
                                else if (list[i].Sections.Contains("BIOLOGY"))
                                {
                                    scoreD = scoreD + 5;
                                }
                            }
                            else if (list[i].TextColorA != null && list[i].TextColorB != null
                                 && list[i].TextColorC != null && list[i].TextColorD != null &&
                                list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#00FF00")
                                 && list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#000000"))
                            {
                                if (list[i].Sections.Contains("PHYSICS"))
                                {
                                    score = score + 5;
                                }
                                else if (list[i].Sections.Contains("CHEMISTRY"))
                                {
                                    scoreB = scoreB + 5;
                                }
                                else if (list[i].Sections.Contains("ENGLISH"))
                                {
                                    scoreC = scoreC + 5;
                                }
                                else if (list[i].Sections.Contains("BIOLOGY"))
                                {
                                    scoreD = scoreD + 5;
                                }
                            }
                            else if (list[i].TextColorA != null && list[i].TextColorB != null
                                 && list[i].TextColorC != null && list[i].TextColorD != null &&
                                list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#000000")
                                 && list[i].TextColorC.Contains("#00FF00") && list[i].TextColorD.Contains("#000000"))
                            {
                                if (list[i].Sections.Contains("PHYSICS"))
                                {
                                    score = score + 5;
                                }
                                else if (list[i].Sections.Contains("CHEMISTRY"))
                                {
                                    scoreB = scoreB + 5;
                                }
                                else if (list[i].Sections.Contains("ENGLISH"))
                                {
                                    scoreC = scoreC + 5;
                                }
                                else if (list[i].Sections.Contains("BIOLOGY"))
                                {
                                    scoreD = scoreD + 5;
                                }
                            }
                            else if (list[i].TextColorA != null && list[i].TextColorB != null
                                 && list[i].TextColorC != null && list[i].TextColorD != null &&
                                list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#000000")
                                 && list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#00FF00"))
                            {
                                if (list[i].Sections.Contains("PHYSICS"))
                                {
                                    score = score + 5;
                                }
                                else if (list[i].Sections.Contains("CHEMISTRY"))
                                {
                                    scoreB = scoreB + 5;
                                }
                                else if (list[i].Sections.Contains("ENGLISH"))
                                {
                                    scoreC = scoreC + 5;
                                }
                                else if (list[i].Sections.Contains("BIOLOGY"))
                                {
                                    scoreD = scoreD + 5;
                                }
                            }
                            else
                            {
                                score = score + 0;
                                scoreB = scoreB + 0;
                                scoreC = scoreC + 0;
                                scoreD = scoreD + 0;
                            }




                        }
                        int a = 0;
                        int b = 0;
                        int c = 0;
                        int d = 0;
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i].TextColorA != null && list[i].TextColorB != null
                         && list[i].TextColorC != null && list[i].TextColorD != null &&
                            list[i].TextColorA.Contains("#00FF00") && list[i].TextColorB.Contains("#0000ff") &&
                                list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#000000")
                                )
                            {

                                //||
                                //list[i].TextColorA.Contains("#00FF00") && list[i].TextColorB.Contains("#000000") &&
                                //list[i].TextColorC.Contains("#0000ff") && list[i].TextColorD.Contains("#000000") ||
                                //list[i].TextColorA.Contains("#00FF00") && list[i].TextColorB.Contains("#000000") &&
                                //list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#0000ff")


                                if (list[i].Sections.Contains("PHYSICS"))
                                {
                                    //score = score - 6;
                                    a++;
                                }
                                else if (list[i].Sections.Contains("CHEMISTRY"))
                                {
                                    //scoreB = scoreB - 6;
                                    b++;
                                }
                                else if (list[i].Sections.Contains("ENGLISH"))
                                {
                                    //scoreC = scoreC - 6;
                                    c++;
                                }
                                else if (list[i].Sections.Contains("BIOLOGY"))
                                {
                                    //scoreD = scoreD - 6;
                                    d++;
                                }
                            }
                            else if (list[i].TextColorA != null && list[i].TextColorB != null
                         && list[i].TextColorC != null && list[i].TextColorD != null &&
                            list[i].TextColorA.Contains("#00FF00") && list[i].TextColorB.Contains("#000000") &&
                               list[i].TextColorC.Contains("#0000ff") && list[i].TextColorD.Contains("#000000")
                               )
                            {
                                // ||
                                //list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#00FF00") &&
                                //list[i].TextColorC.Contains("#0000ff") && list[i].TextColorD.Contains("#000000") ||
                                //list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#00FF00") &&
                                //list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#0000ff")

                                if (list[i].Sections.Contains("PHYSICS"))
                                {
                                    //score = score - 6;
                                    a++;
                                }
                                else if (list[i].Sections.Contains("CHEMISTRY"))
                                {
                                    //scoreB = scoreB - 6;
                                    b++;
                                }
                                else if (list[i].Sections.Contains("ENGLISH"))
                                {
                                    //scoreC = scoreC - 6;
                                    c++;
                                }
                                else if (list[i].Sections.Contains("BIOLOGY"))
                                {
                                    //scoreD = scoreD - 6;
                                    d++;
                                }
                            }
                            else if (list[i].TextColorA != null && list[i].TextColorB != null
                         && list[i].TextColorC != null && list[i].TextColorD != null &&
                            list[i].TextColorA.Contains("#00FF00") && list[i].TextColorB.Contains("#000000") &&
                              list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#0000ff")
                              )
                            {

                                //  ||
                                //list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#0000ff") &&
                                //list[i].TextColorC.Contains("#00FF00") && list[i].TextColorD.Contains("#000000") ||
                                //list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#000000") &&
                                //list[i].TextColorC.Contains("#00FF00") && list[i].TextColorD.Contains("#0000ff")

                                if (list[i].Sections.Contains("PHYSICS"))
                                {
                                    //score = score - 6;
                                    a++;
                                }
                                else if (list[i].Sections.Contains("CHEMISTRY"))
                                {
                                    //scoreB = scoreB - 6;
                                    b++;
                                }
                                else if (list[i].Sections.Contains("ENGLISH"))
                                {
                                    //scoreC = scoreC - 6;
                                    c++;
                                }
                                else if (list[i].Sections.Contains("BIOLOGY"))
                                {
                                    //scoreD = scoreD - 6;
                                    d++;
                                }
                            }
                            else if (list[i].TextColorA != null && list[i].TextColorB != null
                         && list[i].TextColorC != null && list[i].TextColorD != null &&
                            list[i].TextColorA.Contains("#0000ff") && list[i].TextColorB.Contains("#00FF00") &&
                             list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#000000")
                             )
                            {
                                //   ||
                                //list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#0000ff") &&
                                //list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#00FF00") ||
                                //list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#000000") &&
                                //list[i].TextColorC.Contains("#0000ff") && list[i].TextColorD.Contains("#00FF00")

                                if (list[i].Sections.Contains("PHYSICS"))
                                {
                                    //score = score - 6;
                                    a++;
                                }
                                else if (list[i].Sections.Contains("CHEMISTRY"))
                                {
                                    //scoreB = scoreB - 6;
                                    b++;
                                }
                                else if (list[i].Sections.Contains("ENGLISH"))
                                {
                                    //scoreC = scoreC - 6;
                                    c++;
                                }
                                else if (list[i].Sections.Contains("BIOLOGY"))
                                {
                                    //scoreD = scoreD - 6;
                                    d++;
                                }
                            }
                            else if (list[i].TextColorA != null && list[i].TextColorB != null
                        && list[i].TextColorC != null && list[i].TextColorD != null &&
                           list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#00FF00") &&
                            list[i].TextColorC.Contains("#0000ff") && list[i].TextColorD.Contains("#000000"))
                            {
                                if (list[i].Sections.Contains("PHYSICS"))
                                {
                                    //score = score - 6;
                                    a++;
                                }
                                else if (list[i].Sections.Contains("CHEMISTRY"))
                                {
                                    //scoreB = scoreB - 6;
                                    b++;
                                }
                                else if (list[i].Sections.Contains("ENGLISH"))
                                {
                                    //scoreC = scoreC - 6;
                                    c++;
                                }
                                else if (list[i].Sections.Contains("BIOLOGY"))
                                {
                                    //scoreD = scoreD - 6;
                                    d++;
                                }
                            }
                            else if (list[i].TextColorA != null && list[i].TextColorB != null
                        && list[i].TextColorC != null && list[i].TextColorD != null &&
                           list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#00FF00") &&
                            list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#0000ff"))
                            {
                                if (list[i].Sections.Contains("PHYSICS"))
                                {
                                    //score = score - 6;
                                    a++;
                                }
                                else if (list[i].Sections.Contains("CHEMISTRY"))
                                {
                                    //scoreB = scoreB - 6;
                                    b++;
                                }
                                else if (list[i].Sections.Contains("ENGLISH"))
                                {
                                    //scoreC = scoreC - 6;
                                    c++;
                                }
                                else if (list[i].Sections.Contains("BIOLOGY"))
                                {
                                    //scoreD = scoreD - 6;
                                    d++;
                                }
                            }
                            else if (list[i].TextColorA != null && list[i].TextColorB != null
                       && list[i].TextColorC != null && list[i].TextColorD != null &&
                          list[i].TextColorA.Contains("#0000ff") && list[i].TextColorB.Contains("#000000") &&
                           list[i].TextColorC.Contains("#00FF00") && list[i].TextColorD.Contains("#000000"))
                            {
                                if (list[i].Sections.Contains("PHYSICS"))
                                {
                                    //score = score - 6;
                                    a++;
                                }
                                else if (list[i].Sections.Contains("CHEMISTRY"))
                                {
                                    //scoreB = scoreB - 6;
                                    b++;
                                }
                                else if (list[i].Sections.Contains("ENGLISH"))
                                {
                                    //scoreC = scoreC - 6;
                                    c++;
                                }
                                else if (list[i].Sections.Contains("BIOLOGY"))
                                {
                                    //scoreD = scoreD - 6;
                                    d++;
                                }
                            }
                            else if (list[i].TextColorA != null && list[i].TextColorB != null
                     && list[i].TextColorC != null && list[i].TextColorD != null &&
                        list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#0000ff") &&
                         list[i].TextColorC.Contains("#00FF00") && list[i].TextColorD.Contains("#000000"))
                            {
                                if (list[i].Sections.Contains("PHYSICS"))
                                {
                                    //score = score - 6;
                                    a++;
                                }
                                else if (list[i].Sections.Contains("CHEMISTRY"))
                                {
                                    //scoreB = scoreB - 6;
                                    b++;
                                }
                                else if (list[i].Sections.Contains("ENGLISH"))
                                {
                                    //scoreC = scoreC - 6;
                                    c++;
                                }
                                else if (list[i].Sections.Contains("BIOLOGY"))
                                {
                                    //scoreD = scoreD - 6;
                                    d++;
                                }
                            }
                            else if (list[i].TextColorA != null && list[i].TextColorB != null
                     && list[i].TextColorC != null && list[i].TextColorD != null &&
                        list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#000000") &&
                         list[i].TextColorC.Contains("#00FF00") && list[i].TextColorD.Contains("#0000ff"))
                            {
                                if (list[i].Sections.Contains("PHYSICS"))
                                {
                                    //score = score - 6;
                                    a++;
                                }
                                else if (list[i].Sections.Contains("CHEMISTRY"))
                                {
                                    //scoreB = scoreB - 6;
                                    b++;
                                }
                                else if (list[i].Sections.Contains("ENGLISH"))
                                {
                                    //scoreC = scoreC - 6;
                                    c++;
                                }
                                else if (list[i].Sections.Contains("BIOLOGY"))
                                {
                                    //scoreD = scoreD - 6;
                                    d++;
                                }
                            }
                            else if (list[i].TextColorA != null && list[i].TextColorB != null
                     && list[i].TextColorC != null && list[i].TextColorD != null &&
                        list[i].TextColorA.Contains("#0000ff") && list[i].TextColorB.Contains("#000000") &&
                         list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#00FF00"))
                            {
                                if (list[i].Sections.Contains("PHYSICS"))
                                {
                                    //score = score - 6;
                                    a++;
                                }
                                else if (list[i].Sections.Contains("CHEMISTRY"))
                                {
                                    //scoreB = scoreB - 6;
                                    b++;
                                }
                                else if (list[i].Sections.Contains("ENGLISH"))
                                {
                                    //scoreC = scoreC - 6;
                                    c++;
                                }
                                else if (list[i].Sections.Contains("BIOLOGY"))
                                {
                                    //scoreD = scoreD - 6;
                                    d++;
                                }
                            }
                            else if (list[i].TextColorA != null && list[i].TextColorB != null
                    && list[i].TextColorC != null && list[i].TextColorD != null &&
                       list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#0000ff") &&
                        list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#00FF00"))
                            {
                                if (list[i].Sections.Contains("PHYSICS"))
                                {
                                    //score = score - 6;
                                    a++;
                                }
                                else if (list[i].Sections.Contains("CHEMISTRY"))
                                {
                                    //scoreB = scoreB - 6;
                                    b++;
                                }
                                else if (list[i].Sections.Contains("ENGLISH"))
                                {
                                    //scoreC = scoreC - 6;
                                    c++;
                                }
                                else if (list[i].Sections.Contains("BIOLOGY"))
                                {
                                    //scoreD = scoreD - 6;
                                    d++;
                                }
                            }
                            else if (list[i].TextColorA != null && list[i].TextColorB != null
                    && list[i].TextColorC != null && list[i].TextColorD != null &&
                       list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#000000") &&
                        list[i].TextColorC.Contains("#0000ff") && list[i].TextColorD.Contains("#00FF00"))
                            {
                                if (list[i].Sections.Contains("PHYSICS"))
                                {
                                    //score = score - 6;
                                    a++;
                                }
                                else if (list[i].Sections.Contains("CHEMISTRY"))
                                {
                                    //scoreB = scoreB - 6;
                                    b++;
                                }
                                else if (list[i].Sections.Contains("ENGLISH"))
                                {
                                    //scoreC = scoreC - 6;
                                    c++;
                                }
                                else if (list[i].Sections.Contains("BIOLOGY"))
                                {
                                    //scoreD = scoreD - 6;
                                    d++;
                                }
                            }
                            else
                            {
                                score = score - 0;
                                scoreB = scoreB - 0;
                                scoreC = scoreC - 0;
                                scoreD = scoreD - 0;
                            }
                        }
                        //await DisplayAlert("mesage", "a="+a+" b="+b+" c="+c+" d="+d, "ok");
                        int aS = a * 6;
                        int bS = b * 6;
                        int cS = c * 6;
                        int dS = d * 6;

                        score = score - aS;
                        scoreB = scoreB - bS;
                        scoreC = scoreC - cS;
                        scoreD = scoreD - dS;
                        string totalQuestions = (list.Count) + " Questions";
                        string totalTime = (list.Count) + " miniutes";
                        int tapped = tstscore + 1;
                        int outof = list.Count;
                        string Ascore = (score + "/" + sectionA.Count).ToString();
                        string Bscore = (scoreB + "/" + sectionB.Count).ToString();
                        string Cscore = (scoreC + "/" + sectionC.Count).ToString();
                        string Dscore = (scoreD + "/" + Biology.Count).ToString();
                        // DisplayAlert("MESSAGE", "" + Ascore, "OK");
                        //string AverageTime =CountDown.Text.ToString();
                        string AverageTime = string.Format("{0:00}:{1:00}", totalmin, totolsec);
                        string attempts = tapped.ToString();

                        int atotal = sectionA.Count;
                        int btotal = sectionB.Count;
                        int ctotal = sectionC.Count;
                        int dtotal = Biology.Count;

                        //DisplayAlert("ALERT", "Average Time" + AverageTime, "OK");
                        int totaloutof = list.Count;
                        double total = score + scoreB + scoreC + scoreD;
                        double averagescore = (total / 4);

                        //await DisplayAlert("averagescore", ""+averagescore.ToString("0.00"), "ok");
                        //averagescore = Math.Floor(averagescore * 100) / 100;
                        string AverageSc = string.Format("{0:F2}", averagescore);
                        string TO = total + "/" + outof;
                        // await DisplayAlert("alert", ""+AverageSc, "ok");
                        string test = "Test No-1";
                        TestDetail details = new TestDetail
                        {
                            TestName = tableName,
                            SectionAs = Ascore,
                            SectionBs = Bscore,
                            SectionCs = Cscore,
                            SectionDs = Dscore
                                   ,
                            AverageTime = AverageTime,
                            AverageScore = AverageSc,
                            Attempts = attempts,
                            TotalScore = TO,
                            ScoreA = score,
                            ScoreB = scoreB
                                   ,
                            ScoreC = scoreC,
                            ScoreD = scoreD,
                            TotalQuestion = totalQuestions,
                            TotalTime = totalTime,
                            Atotal = atotal,
                            Btotal = btotal,
                            Ctotal = ctotal,
                            Dtotal = dtotal
                        };
                        int Prevallscore = at + bt + ct;
                        int Currallscore = score + scoreB + scoreC;
                        //if (Prevallscore > Currallscore)
                        //{
                        //   await DisplayAlert("Etest", "Bad Performance then Before!", "OK");
                        //}
                        //else
                        //{
                        //    await DisplayAlert("Etest", "Better Performance then Bofore!", "OK");
                        //}

                        dbConn2.InsertAsync(details);
                        double averagea = score + A;
                        double AvergScoreA = averagea / tapped;
                        string AA = AvergScoreA + "/" + atotal;

                        double averageb = scoreB + B;
                        double AvergScoreB = averageb / tapped;
                        string BA = AvergScoreB + "/" + btotal;

                        double averagec = scoreC + C;
                        double AvergScoreC = averagec / tapped;
                        string CA = AvergScoreC + "/" + ctotal;


                        //await dbConn3.UpdateAsync();
                        //DisplayAlert("message", ""+total+"/"+outof, "ok");
                        //await dbConn3.QueryAsync<DashBoardListview>("INSERT INTO TestDetail(TestName,SectionAs,SectionBs,SectionCs,AverageTime,AverageScore," +
                        //    "Attempts,TotalScore,ScoreA,ScoreB,ScoreC,TotalQuestion,TotalTime,Atotal,Btotal,Ctotal) VALUES(\"" + tableName + "\",\""
                        //    + Ascore + "\",\"" + Bscore + "\",\"" + Cscore + "\"," +
                        //    "\"" + AverageTime + "\",\"" + AverageSc + "\",\"" + attempts + "\",\"" + TO + "\",\"" + score + "\",\"" +
                        //    scoreB + "\",\"" + scoreC + "\",\"" + totalQuestions + "\",\"" + totalTime + "\",\"" + atotal + "\",\"" + btotal + "\",\"" + ctotal + "\")");
                        // dbConn.QueryAsync<TestDetails>("insert into TestDetail(TestName) values(\"" + tableName + "\")");
                        dbConn.QueryAsync<TestScore>("UPDATE Test_score SET SectionA=\"" + Ascore + "\",SectionB=\"" + Bscore + "\",SectionC=\"" + Cscore + "\",OutOF=\"" + TO + "\",Numbertapped=\"" + tapped + "\",OutofC=\"" + total + "\",OutofB=\"" + outof + "\" WHERE Tests=\"" + tableName + "\"");
                        dbConn3.QueryAsync<DashBoardListview>("UPDATE DashBoardListview SET AScore=\"" + string.Format("{0:F2}", AA) + "\", BScore = \"" + string.Format("{0:F2}", BA) + "\", CScore = \"" + string.Format("{0:F2}", CA) + "\", Atotal =\"" + score + "\",Btotal = \"" + scoreB + "\", Ctotal =\"" + scoreC + "\", AverageScore = \"" + AverageSc + "\", Attempts =\"" + tapped + "\", A = \"" + averagea + "\", B = \"" + averageb + "\", C = \"" + averagec + "\",TimeTaken=\"" + AverageTime + "\" WHERE TestName = \"" + tableName + "\"");



                        // dbConn.GetConnection().Close();

                        //DisplayAlert("", "End Test Successfully at " + mins + ":" + counter, "ok");
                        isTimerCancel = 1;
                        int previousScore = testScore[0].OutofC;
                        if (previousScore < total)
                        {
                            Performance.Text = "Better Performance then Before";

                        }
                        else
                        {
                            Performance.Text = "Bad Performance then Before";
                        }
                        TotaLScore.Text = "Current Score :" + total + "/" + list.Count;
                        PreviousScore.Text = "Previous Score :" + previousScore + "/" + list.Count;
                        // DisplayAlert("", "" + mins + ":" + counter, "");
                        //MyListView.ItemsSource = list;
                        //TotaLScore.Text = "Total Score :" + total + "/" + list.Count;
                        slQuestion.IsVisible = false;
                        quizStack.IsVisible = false;
                        frameStack.IsVisible = true;
                        TotaLScore.Text = "Total Score :" + total + "/" + list.Count;
                        MyListView.ItemsSource = list;
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            });

        }
        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            return true;
        }
        private void BtnPrevious_Clicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async() =>
            {
                var result = await this.DisplayAlert("e-Test", "Are You Sure to Exit Test?", "Yes", "No");
                if (result)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].TextColorA != null && list[i].TextColorB != null
                     && list[i].TextColorC != null && list[i].TextColorD != null &&
                    list[i].TextColorA.Contains("#00FF00") && list[i].TextColorB.Contains("#000000")
                     && list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#000000"))
                        {
                            if (list[i].Sections.Contains("PHYSICS"))
                            {
                                score = score + 5;
                            }
                            else if (list[i].Sections.Contains("CHEMISTRY"))
                            {
                                scoreB = scoreB + 5;
                            }
                            else if (list[i].Sections.Contains("ENGLISH"))
                            {
                                scoreC = scoreC + 5;
                            }
                            else if (list[i].Sections.Contains("BIOLOGY"))
                            {
                                scoreD = scoreD + 5;
                            }
                        }
                        else if (list[i].TextColorA != null && list[i].TextColorB != null
                             && list[i].TextColorC != null && list[i].TextColorD != null &&
                            list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#00FF00")
                             && list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#000000"))
                        {
                            if (list[i].Sections.Contains("PHYSICS"))
                            {
                                score = score + 5;
                            }
                            else if (list[i].Sections.Contains("CHEMISTRY"))
                            {
                                scoreB = scoreB + 5;
                            }
                            else if (list[i].Sections.Contains("ENGLISH"))
                            {
                                scoreC = scoreC + 5;
                            }
                            else if (list[i].Sections.Contains("BIOLOGY"))
                            {
                                scoreD = scoreD + 5;
                            }
                        }
                        else if (list[i].TextColorA != null && list[i].TextColorB != null
                             && list[i].TextColorC != null && list[i].TextColorD != null &&
                            list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#000000")
                             && list[i].TextColorC.Contains("#00FF00") && list[i].TextColorD.Contains("#000000"))
                        {
                            if (list[i].Sections.Contains("PHYSICS"))
                            {
                                score = score + 5;
                            }
                            else if (list[i].Sections.Contains("CHEMISTRY"))
                            {
                                scoreB = scoreB + 5;
                            }
                            else if (list[i].Sections.Contains("ENGLISH"))
                            {
                                scoreC = scoreC + 5;
                            }
                            else if (list[i].Sections.Contains("BIOLOGY"))
                            {
                                scoreD = scoreD + 5;
                            }
                        }
                        else if (list[i].TextColorA != null && list[i].TextColorB != null
                             && list[i].TextColorC != null && list[i].TextColorD != null &&
                            list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#000000")
                             && list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#00FF00"))
                        {
                            if (list[i].Sections.Contains("PHYSICS"))
                            {
                                score = score + 5;
                            }
                            else if (list[i].Sections.Contains("CHEMISTRY"))
                            {
                                scoreB = scoreB + 5;
                            }
                            else if (list[i].Sections.Contains("ENGLISH"))
                            {
                                scoreC = scoreC + 5;
                            }
                            else if (list[i].Sections.Contains("BIOLOGY"))
                            {
                                scoreD = scoreD + 5;
                            }
                        }
                        else
                        {
                            score = score + 0;
                            scoreB = scoreB + 0;
                            scoreC = scoreC + 0;
                            scoreD = scoreD + 0;
                        }




                    }
                    int a = 0;
                    int b = 0;
                    int c = 0;
                    int d = 0;
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].TextColorA != null && list[i].TextColorB != null
                     && list[i].TextColorC != null && list[i].TextColorD != null &&
                        list[i].TextColorA.Contains("#00FF00") && list[i].TextColorB.Contains("#0000ff") &&
                            list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#000000")
                            )
                        {

                            //||
                            //list[i].TextColorA.Contains("#00FF00") && list[i].TextColorB.Contains("#000000") &&
                            //list[i].TextColorC.Contains("#0000ff") && list[i].TextColorD.Contains("#000000") ||
                            //list[i].TextColorA.Contains("#00FF00") && list[i].TextColorB.Contains("#000000") &&
                            //list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#0000ff")


                            if (list[i].Sections.Contains("PHYSICS"))
                            {
                                //score = score - 6;
                                a++;
                            }
                            else if (list[i].Sections.Contains("CHEMISTRY"))
                            {
                                //scoreB = scoreB - 6;
                                b++;
                            }
                            else if (list[i].Sections.Contains("ENGLISH"))
                            {
                                //scoreC = scoreC - 6;
                                c++;
                            }
                            else if (list[i].Sections.Contains("BIOLOGY"))
                            {
                                //scoreD = scoreD - 6;
                                d++;
                            }
                        }
                        else if (list[i].TextColorA != null && list[i].TextColorB != null
                     && list[i].TextColorC != null && list[i].TextColorD != null &&
                        list[i].TextColorA.Contains("#00FF00") && list[i].TextColorB.Contains("#000000") &&
                           list[i].TextColorC.Contains("#0000ff") && list[i].TextColorD.Contains("#000000")
                           )
                        {
                            // ||
                            //list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#00FF00") &&
                            //list[i].TextColorC.Contains("#0000ff") && list[i].TextColorD.Contains("#000000") ||
                            //list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#00FF00") &&
                            //list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#0000ff")

                            if (list[i].Sections.Contains("PHYSICS"))
                            {
                                //score = score - 6;
                                a++;
                            }
                            else if (list[i].Sections.Contains("CHEMISTRY"))
                            {
                                //scoreB = scoreB - 6;
                                b++;
                            }
                            else if (list[i].Sections.Contains("ENGLISH"))
                            {
                                //scoreC = scoreC - 6;
                                c++;
                            }
                            else if (list[i].Sections.Contains("BIOLOGY"))
                            {
                                //scoreD = scoreD - 6;
                                d++;
                            }
                        }
                        else if (list[i].TextColorA != null && list[i].TextColorB != null
                     && list[i].TextColorC != null && list[i].TextColorD != null &&
                        list[i].TextColorA.Contains("#00FF00") && list[i].TextColorB.Contains("#000000") &&
                          list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#0000ff")
                          )
                        {

                            //  ||
                            //list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#0000ff") &&
                            //list[i].TextColorC.Contains("#00FF00") && list[i].TextColorD.Contains("#000000") ||
                            //list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#000000") &&
                            //list[i].TextColorC.Contains("#00FF00") && list[i].TextColorD.Contains("#0000ff")

                            if (list[i].Sections.Contains("PHYSICS"))
                            {
                                //score = score - 6;
                                a++;
                            }
                            else if (list[i].Sections.Contains("CHEMISTRY"))
                            {
                                //scoreB = scoreB - 6;
                                b++;
                            }
                            else if (list[i].Sections.Contains("ENGLISH"))
                            {
                                //scoreC = scoreC - 6;
                                c++;
                            }
                            else if (list[i].Sections.Contains("BIOLOGY"))
                            {
                                //scoreD = scoreD - 6;
                                d++;
                            }
                        }
                        else if (list[i].TextColorA != null && list[i].TextColorB != null
                     && list[i].TextColorC != null && list[i].TextColorD != null &&
                        list[i].TextColorA.Contains("#0000ff") && list[i].TextColorB.Contains("#00FF00") &&
                         list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#000000")
                         )
                        {
                            //   ||
                            //list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#0000ff") &&
                            //list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#00FF00") ||
                            //list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#000000") &&
                            //list[i].TextColorC.Contains("#0000ff") && list[i].TextColorD.Contains("#00FF00")

                            if (list[i].Sections.Contains("PHYSICS"))
                            {
                                //score = score - 6;
                                a++;
                            }
                            else if (list[i].Sections.Contains("CHEMISTRY"))
                            {
                                //scoreB = scoreB - 6;
                                b++;
                            }
                            else if (list[i].Sections.Contains("ENGLISH"))
                            {
                                //scoreC = scoreC - 6;
                                c++;
                            }
                            else if (list[i].Sections.Contains("BIOLOGY"))
                            {
                                //scoreD = scoreD - 6;
                                d++;
                            }
                        }
                        else if (list[i].TextColorA != null && list[i].TextColorB != null
                    && list[i].TextColorC != null && list[i].TextColorD != null &&
                       list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#00FF00") &&
                        list[i].TextColorC.Contains("#0000ff") && list[i].TextColorD.Contains("#000000"))
                        {
                            if (list[i].Sections.Contains("PHYSICS"))
                            {
                                //score = score - 6;
                                a++;
                            }
                            else if (list[i].Sections.Contains("CHEMISTRY"))
                            {
                                //scoreB = scoreB - 6;
                                b++;
                            }
                            else if (list[i].Sections.Contains("ENGLISH"))
                            {
                                //scoreC = scoreC - 6;
                                c++;
                            }
                            else if (list[i].Sections.Contains("BIOLOGY"))
                            {
                                //scoreD = scoreD - 6;
                                d++;
                            }
                        }
                        else if (list[i].TextColorA != null && list[i].TextColorB != null
                    && list[i].TextColorC != null && list[i].TextColorD != null &&
                       list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#00FF00") &&
                        list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#0000ff"))
                        {
                            if (list[i].Sections.Contains("PHYSICS"))
                            {
                                //score = score - 6;
                                a++;
                            }
                            else if (list[i].Sections.Contains("CHEMISTRY"))
                            {
                                //scoreB = scoreB - 6;
                                b++;
                            }
                            else if (list[i].Sections.Contains("ENGLISH"))
                            {
                                //scoreC = scoreC - 6;
                                c++;
                            }
                            else if (list[i].Sections.Contains("BIOLOGY"))
                            {
                                //scoreD = scoreD - 6;
                                d++;
                            }
                        }
                        else if (list[i].TextColorA != null && list[i].TextColorB != null
                   && list[i].TextColorC != null && list[i].TextColorD != null &&
                      list[i].TextColorA.Contains("#0000ff") && list[i].TextColorB.Contains("#000000") &&
                       list[i].TextColorC.Contains("#00FF00") && list[i].TextColorD.Contains("#000000"))
                        {
                            if (list[i].Sections.Contains("PHYSICS"))
                            {
                                //score = score - 6;
                                a++;
                            }
                            else if (list[i].Sections.Contains("CHEMISTRY"))
                            {
                                //scoreB = scoreB - 6;
                                b++;
                            }
                            else if (list[i].Sections.Contains("ENGLISH"))
                            {
                                //scoreC = scoreC - 6;
                                c++;
                            }
                            else if (list[i].Sections.Contains("BIOLOGY"))
                            {
                                //scoreD = scoreD - 6;
                                d++;
                            }
                        }
                        else if (list[i].TextColorA != null && list[i].TextColorB != null
                 && list[i].TextColorC != null && list[i].TextColorD != null &&
                    list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#0000ff") &&
                     list[i].TextColorC.Contains("#00FF00") && list[i].TextColorD.Contains("#000000"))
                        {
                            if (list[i].Sections.Contains("PHYSICS"))
                            {
                                //score = score - 6;
                                a++;
                            }
                            else if (list[i].Sections.Contains("CHEMISTRY"))
                            {
                                //scoreB = scoreB - 6;
                                b++;
                            }
                            else if (list[i].Sections.Contains("ENGLISH"))
                            {
                                //scoreC = scoreC - 6;
                                c++;
                            }
                            else if (list[i].Sections.Contains("BIOLOGY"))
                            {
                                //scoreD = scoreD - 6;
                                d++;
                            }
                        }
                        else if (list[i].TextColorA != null && list[i].TextColorB != null
                 && list[i].TextColorC != null && list[i].TextColorD != null &&
                    list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#000000") &&
                     list[i].TextColorC.Contains("#00FF00") && list[i].TextColorD.Contains("#0000ff"))
                        {
                            if (list[i].Sections.Contains("PHYSICS"))
                            {
                                //score = score - 6;
                                a++;
                            }
                            else if (list[i].Sections.Contains("CHEMISTRY"))
                            {
                                //scoreB = scoreB - 6;
                                b++;
                            }
                            else if (list[i].Sections.Contains("ENGLISH"))
                            {
                                //scoreC = scoreC - 6;
                                c++;
                            }
                            else if (list[i].Sections.Contains("BIOLOGY"))
                            {
                                //scoreD = scoreD - 6;
                                d++;
                            }
                        }
                        else if (list[i].TextColorA != null && list[i].TextColorB != null
                 && list[i].TextColorC != null && list[i].TextColorD != null &&
                    list[i].TextColorA.Contains("#0000ff") && list[i].TextColorB.Contains("#000000") &&
                     list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#00FF00"))
                        {
                            if (list[i].Sections.Contains("PHYSICS"))
                            {
                                //score = score - 6;
                                a++;
                            }
                            else if (list[i].Sections.Contains("CHEMISTRY"))
                            {
                                //scoreB = scoreB - 6;
                                b++;
                            }
                            else if (list[i].Sections.Contains("ENGLISH"))
                            {
                                //scoreC = scoreC - 6;
                                c++;
                            }
                            else if (list[i].Sections.Contains("BIOLOGY"))
                            {
                                //scoreD = scoreD - 6;
                                d++;
                            }
                        }
                        else if (list[i].TextColorA != null && list[i].TextColorB != null
                && list[i].TextColorC != null && list[i].TextColorD != null &&
                   list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#0000ff") &&
                    list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#00FF00"))
                        {
                            if (list[i].Sections.Contains("PHYSICS"))
                            {
                                //score = score - 6;
                                a++;
                            }
                            else if (list[i].Sections.Contains("CHEMISTRY"))
                            {
                                //scoreB = scoreB - 6;
                                b++;
                            }
                            else if (list[i].Sections.Contains("ENGLISH"))
                            {
                                //scoreC = scoreC - 6;
                                c++;
                            }
                            else if (list[i].Sections.Contains("BIOLOGY"))
                            {
                                //scoreD = scoreD - 6;
                                d++;
                            }
                        }
                        else if (list[i].TextColorA != null && list[i].TextColorB != null
                && list[i].TextColorC != null && list[i].TextColorD != null &&
                   list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#000000") &&
                    list[i].TextColorC.Contains("#0000ff") && list[i].TextColorD.Contains("#00FF00"))
                        {
                            if (list[i].Sections.Contains("PHYSICS"))
                            {
                                //score = score - 6;
                                a++;
                            }
                            else if (list[i].Sections.Contains("CHEMISTRY"))
                            {
                                //scoreB = scoreB - 6;
                                b++;
                            }
                            else if (list[i].Sections.Contains("ENGLISH"))
                            {
                                //scoreC = scoreC - 6;
                                c++;
                            }
                            else if (list[i].Sections.Contains("BIOLOGY"))
                            {
                                //scoreD = scoreD - 6;
                                d++;
                            }
                        }
                        else
                        {
                            score = score - 0;
                            scoreB = scoreB - 0;
                            scoreC = scoreC - 0;
                            scoreD = scoreD - 0;
                        }
                    }
                    //await DisplayAlert("mesage", "a="+a+" b="+b+" c="+c+" d="+d, "ok");
                    int aS = a * 6;
                    int bS = b * 6;
                    int cS = c * 6;
                    int dS = d * 6;

                    score = score - aS;
                    scoreB = scoreB - bS;
                    scoreC = scoreC - cS;
                    scoreD = scoreD - dS;

                    string totalQuestions = (list.Count) + " Questions";
                    string totalTime = (list.Count) + " miniutes";
                    int tapped = tstscore + 1;
                    int outof = list.Count;
                    string Ascore = (score + "/" + (sectionA.Count) * 5).ToString();
                    string Bscore = (scoreB + "/" + (sectionB.Count) * 5).ToString();
                    string Cscore = (scoreC + "/" + (sectionC.Count) * 5).ToString();
                    string Dscore = (scoreD + "/" + (Biology.Count) * 5).ToString();
                    // DisplayAlert("MESSAGE", "" + Ascore, "OK");
                    //string AverageTime =CountDown.Text.ToString();
                    string AverageTime = string.Format("{0:00}:{1:00}", totalmin, totolsec);
                    string attempts = tapped.ToString();

                    int atotal = (sectionA.Count)*5;
                    int btotal = (sectionB.Count)*5;
                    int ctotal = (sectionC.Count)*5;
                    int dtotal = (Biology.Count)*5;

                    //DisplayAlert("ALERT", "Average Time" + AverageTime, "OK");
                    int totaloutof = list.Count;
                    double total = score + scoreB + scoreC+scoreD;
                    double averagescore = (total / 4);

                    //await DisplayAlert("averagescore", ""+averagescore.ToString("0.00"), "ok");
                    //averagescore = Math.Floor(averagescore * 100) / 100;
                    string AverageSc = string.Format("{0:F2}", averagescore);
                    string TO = total + "/" + outof;
                    // await DisplayAlert("alert", ""+AverageSc, "ok");
                    string test = "Test No-1";
                    TestDetail details = new TestDetail
                    {
                        TestName = tableName,
                        SectionAs = Ascore,
                        SectionBs = Bscore,
                        SectionCs = Cscore,
                        SectionDs=Dscore
                               ,
                        AverageTime = AverageTime,
                        AverageScore = AverageSc,
                        Attempts = attempts,
                        TotalScore = TO,
                        ScoreA = score,
                        ScoreB = scoreB
                               ,
                        ScoreC = scoreC,
                        ScoreD=scoreD,
                        TotalQuestion = totalQuestions,
                        TotalTime = totalTime,
                        Atotal = atotal,
                        Btotal = btotal,
                        Ctotal = ctotal,
                        Dtotal = dtotal
                    };
                    int Prevallscore = at + bt + ct;
                    int Currallscore = score + scoreB + scoreC;
                    //if (Prevallscore > Currallscore)
                    //{
                    //   await DisplayAlert("Etest", "Bad Performance then Before!", "OK");
                    //}
                    //else
                    //{
                    //    await DisplayAlert("Etest", "Better Performance then Bofore!", "OK");
                    //}

                    await dbConn2.InsertAsync(details);
                    double averagea = score + A;
                    double AvergScoreA = averagea / tapped;
                    string AA = AvergScoreA + "/" + atotal;

                    double averageb = scoreB + B;
                    double AvergScoreB = averageb / tapped;
                    string BA = AvergScoreB + "/" + btotal;

                    double averagec = scoreC + C;
                    double AvergScoreC = averagec / tapped;
                    string CA = AvergScoreC + "/" + ctotal;


                    //await dbConn3.UpdateAsync();
                    //DisplayAlert("message", ""+total+"/"+outof, "ok");
                    //await dbConn3.QueryAsync<DashBoardListview>("INSERT INTO TestDetail(TestName,SectionAs,SectionBs,SectionCs,AverageTime,AverageScore," +
                    //    "Attempts,TotalScore,ScoreA,ScoreB,ScoreC,TotalQuestion,TotalTime,Atotal,Btotal,Ctotal) VALUES(\"" + tableName + "\",\""
                    //    + Ascore + "\",\"" + Bscore + "\",\"" + Cscore + "\"," +
                    //    "\"" + AverageTime + "\",\"" + AverageSc + "\",\"" + attempts + "\",\"" + TO + "\",\"" + score + "\",\"" +
                    //    scoreB + "\",\"" + scoreC + "\",\"" + totalQuestions + "\",\"" + totalTime + "\",\"" + atotal + "\",\"" + btotal + "\",\"" + ctotal + "\")");
                    // dbConn.QueryAsync<TestDetails>("insert into TestDetail(TestName) values(\"" + tableName + "\")");
                    await dbConn.QueryAsync<TestScore>("UPDATE Test_score SET SectionA=\"" + Ascore + "\",SectionB=\"" + Bscore + "\",SectionC=\"" + Cscore + "\",OutOF=\"" + TO + "\",Numbertapped=\"" + tapped + "\",OutofC=\"" + total + "\",OutofB=\"" + outof + "\" WHERE Tests=\"" + tableName + "\"");
                    await dbConn3.QueryAsync<DashBoardListview>("UPDATE DashBoardListview SET AScore=\"" + string.Format("{0:F2}", AA) + "\", BScore = \"" + string.Format("{0:F2}", BA) + "\", CScore = \"" + string.Format("{0:F2}", CA) + "\", Atotal =\"" + score + "\",Btotal = \"" + scoreB + "\", Ctotal =\"" + scoreC + "\", AverageScore = \"" + AverageSc + "\", Attempts =\"" + tapped + "\", A = \"" + averagea + "\", B = \"" + averageb + "\", C = \"" + averagec + "\",TimeTaken=\"" + AverageTime + "\" WHERE TestName = \"" + tableName + "\"");



                    // dbConn.GetConnection().Close();

                    //DisplayAlert("", "End Test Successfully at " + mins + ":" + counter, "ok");
                    isTimerCancel = 1;
                    int previousScore = testScore[0].OutofC;
                    if (previousScore < total)
                    {
                        Performance.Text = "Better Performance then Before";

                    }
                    else
                    {
                        Performance.Text = "Bad Performance then Before";
                    }
                    TotaLScore.Text = "Current Score :" + total + "/" + (list.Count)*5;
                    PreviousScore.Text = "Previous Score :" + previousScore + "/" + (list.Count)*5;
                    // DisplayAlert("", "" + mins + ":" + counter, "");
                    //MyListView.ItemsSource = list;
                    //TotaLScore.Text = "Total Score :" + total + "/" + list.Count;
                    slQuestion.IsVisible = false;
                    quizStack.IsVisible = false;
                    frameStack.IsVisible = true;
                    TotaLScore.Text = "Total Score :" + total + "/" + (list.Count)*5;
                    MyListView.ItemsSource = list;
                    
                    //await DisplayAlert("", ""+mins+":"+counter, "");
                    //await this.Navigation.PopAsync();
                } 
            });
           
        //    int index = list.IndexOf(currentQuestion);

        //    if (prevCounter > 0 && prevCounter <= questionCountTotal)
        //    {
        //        btnConfirm.Text = "Next";

        //        questionCounter = prevCounter;
        //        prevCounter--;
        //        //DisplayAlert("INDEX", ""+prevCounter, "OK");
        //        previousQuestion = list[prevCounter];
        //        //DisplayAlert("task", "" + prevCounter, "ok");
        //        lblquestionNo.Text = "Question No" + previousQuestion.ID + ":";
        //        lblQuestion.Text = previousQuestion.Question;
        //        Option1.Text = previousQuestion.A;
        //        Option2.Text = previousQuestion.B;
        //        Option3.Text = previousQuestion.C;
        //        Option4.Text = previousQuestion.D;
        //        if (previousQuestion.Filepath != null)
        //        {

        //            //string icon_path = new Uri(currentQuestion.Filepath).LocalPath;
        //            img.Source = ImageSource.FromFile(previousQuestion.Filepath);
        //        }
        //        else
        //        {
        //            img.IsVisible = false;
        //        }
        //        //else if (previousQuestion.SeclectedButtonB != null && previousQuestion.SeclectedButtonB.Contains("#0000ff"))
        //        if (previousQuestion.SeclectedButtonA != null &&  previousQuestion.SeclectedButtonA.Contains("#0000FF"))
        //        {
        //            centerFram1.BackgroundColor = Color.Red;
        //            centerFram3.BackgroundColor = Color.White;
        //            centerFram2.BackgroundColor = Color.White;
        //            centerFram4.BackgroundColor = Color.White;
                    

        //        }
        //        else if (previousQuestion.SeclectedButtonB != null && previousQuestion.SeclectedButtonB.Contains("#0000FF"))
        //        {
        //            centerFram2.BackgroundColor = Color.Red;
        //            centerFram3.BackgroundColor = Color.White;
        //            centerFram4.BackgroundColor = Color.White;
        //            centerFram1.BackgroundColor = Color.White;
                    
        //        }
        //        else if (previousQuestion.SeclectedButtonC != null && previousQuestion.SeclectedButtonC.Contains("#0000FF"))
        //        {
        //            centerFram3.BackgroundColor = Color.Red;
        //            centerFram4.BackgroundColor = Color.White;
        //            centerFram2.BackgroundColor = Color.White;
        //            centerFram1.BackgroundColor = Color.White;
                    
        //        }
        //        else if (previousQuestion.SeclectedButtonD != null && previousQuestion.SeclectedButtonD.Contains("#0000FF"))
        //        {
        //            centerFram4.BackgroundColor = Color.Red;
        //            centerFram3.BackgroundColor = Color.White;
        //            centerFram2.BackgroundColor = Color.White;
        //            centerFram1.BackgroundColor = Color.White;
                    
        //        }
        //        else
        //        {
        //            centerFram4.BackgroundColor = Color.White;
        //            centerFram3.BackgroundColor = Color.White;
        //            centerFram2.BackgroundColor = Color.White;
        //            centerFram1.BackgroundColor = Color.White;
                   
        //        }

        //        int cou = prevCounter + 2 - 1;
        //        //QuestionCount.Text = "Question: " + cou + "/" + questionCountTotal;
        //        answered = false;

        //    }

        }

       
        private void BtnConfirm_Clicked(object sender, EventArgs e)
        {
            int count = list.Count;
            PopupNavigation.Instance.PushAsync(new GoToQuestionPopup(count));
            //centerFram1.BackgroundColor = Color.White;
            //centerFram2.BackgroundColor = Color.White;
            //centerFram3.BackgroundColor = Color.White;
            //centerFram4.BackgroundColor = Color.White;


            //    var button = sender as Button;
            //    if (!answered)
            //    {

            //        if (btnfocus || btn2focus || btn3focus || btn4focus)
            //        {


            //            centerFram1.BackgroundColor = Color.White;
            //            centerFram2.BackgroundColor = Color.White;
            //            centerFram3.BackgroundColor = Color.White;
            //            centerFram4.BackgroundColor = Color.White;



            //            list[prevCounter].FrameBackGroundColor = "#039be5";
            //            if (prevCounter < questionCountTotal)
            //            {

            //                int indexx = prevCounter;
            //                prevCounter++;

            //                if (prevCounter + 1 < questionCountTotal)
            //                {
            //                    var target = list[prevCounter];
            //                    LIST.ScrollTo(target, ScrollToPosition.Start, true);
            //                    currentQuestion = list[prevCounter];
            //                    list[prevCounter].FrameBackGroundColor = "#01579B";
            //                    lblquestionNo.Text = "Question No" + currentQuestion.ID + ":";
            //                    lblQuestion.Text = currentQuestion.Question;

            //                    Option1.Text= currentQuestion.A;
            //                    Option2.Text = currentQuestion.B;
            //                    Option3.Text = currentQuestion.C;
            //                    Option4.Text = currentQuestion.D;
            //                    if (currentQuestion.Filepath != null)
            //                    {

            //                        //string icon_path = new Uri(currentQuestion.Filepath).LocalPath;
            //                        img.Source = ImageSource.FromFile(currentQuestion.Filepath);
            //                    }
            //                    else
            //                    {
            //                        img.IsVisible = false;
            //                    }
            //                    if (currentQuestion.SeclectedButtonA != null && currentQuestion.SeclectedButtonA.Contains("#0000FF"))
            //                    {
            //                        centerFram1.BackgroundColor = Color.Red;
            //                        centerFram3.BackgroundColor = Color.White;
            //                        centerFram2.BackgroundColor = Color.White;
            //                        centerFram4.BackgroundColor = Color.White;


            //                    }
            //                    else if (currentQuestion.SeclectedButtonC != null && currentQuestion.SeclectedButtonB.Contains("#0000FF"))
            //                    {
            //                        centerFram2.BackgroundColor = Color.Red;
            //                        centerFram3.BackgroundColor = Color.White;
            //                        centerFram4.BackgroundColor = Color.White;
            //                        centerFram1.BackgroundColor = Color.White;

            //                    }
            //                    else if (currentQuestion.SeclectedButtonC != null && currentQuestion.SeclectedButtonC.Contains("#0000FF"))
            //                    {
            //                        centerFram3.BackgroundColor = Color.Red;
            //                        centerFram4.BackgroundColor = Color.White;
            //                        centerFram2.BackgroundColor = Color.White;
            //                        centerFram1.BackgroundColor = Color.White;

            //                    }
            //                    else if (currentQuestion.SeclectedButtonD != null && currentQuestion.SeclectedButtonD.Contains("#0000FF"))
            //                    {
            //                        centerFram4.BackgroundColor = Color.Red;
            //                        centerFram3.BackgroundColor = Color.White;
            //                        centerFram2.BackgroundColor = Color.White;
            //                        centerFram1.BackgroundColor = Color.White;

            //                    }
            //                    else
            //                    {
            //                        centerFram4.BackgroundColor = Color.White;
            //                        centerFram3.BackgroundColor = Color.White;
            //                        centerFram2.BackgroundColor = Color.White;
            //                        centerFram1.BackgroundColor = Color.White;

            //                    }


            //                    int cou = prevCounter + 1;

            //                    //QuestionCount.Text = "Question: " + cou + "/" + questionCountTotal;
            //                    answered = false;
            //                }
            //                else if (prevCounter + 1 == questionCountTotal)
            //                {
            //                    button.Text = "Finish";
            //                    //var target = list[prevCounter];
            //                    //LIST.ScrollTo(target, ScrollToPosition.Start, true);
            //                    currentQuestion = list[prevCounter];
            //                    list[prevCounter].FrameBackGroundColor = "#01579B";
            //                    lblquestionNo.Text = "Question No" + currentQuestion.ID + ":";
            //                    lblQuestion.Text = currentQuestion.Question;

            //                    Option1.Text = currentQuestion.A;
            //                    Option2.Text = currentQuestion.B;
            //                    Option3.Text = currentQuestion.C;
            //                    Option4.Text = currentQuestion.D;
            //                    int cou = prevCounter + 1;

            //                    //QuestionCount.Text = "Question: " + cou + "/" + questionCountTotal;

            //                }
            //                else
            //                {
            //                    slQuestion.IsVisible = false;
            //                    quizStack.IsVisible = false;
            //                    frameStack.IsVisible = true;
            //                    TotaLScore.Text = "TotaLScore :" + score + "/" + questionCountTotal;
            //                    int outof = list.Count;
            //                    int tapped = tstscore.Numbertapped + 1;
            //                    dbConn.QueryAsync<TestScore>("UPDATE Test_score SET Score =\"" + score + "\",OutOF=\"" + outof + "\",Numbertapped=\"" + tapped + "\" WHERE Tests =\"" + tableName + "\"");
            //                    MyListView.ItemsSource = list;
            //                }


            //                questionNumber = list.IndexOf(currentQuestion);


            //            }


            //        }
            //        else
            //        {


            //            centerFram1.BackgroundColor = Color.White;
            //            centerFram2.BackgroundColor = Color.White;
            //            centerFram3.BackgroundColor = Color.White;
            //            centerFram4.BackgroundColor = Color.White;



            //            if (prevCounter+1 < questionCountTotal)
            //            {

            //                if (prevCounter >= 0)
            //                {

            //                    int indexx = prevCounter;
            //                    prevCounter++;
            //                    if (prevCounter + 1 < questionCountTotal)
            //                    {
            //                        currentQuestion = list[prevCounter];

            //                        lblquestionNo.Text = "Question No"+currentQuestion.ID + ":";
            //                        lblQuestion.Text = currentQuestion.Question;

            //                        Option1.Text = currentQuestion.A;
            //                        Option2.Text = currentQuestion.B;
            //                        Option3.Text = currentQuestion.C;
            //                        Option4.Text = currentQuestion.D;
            //                        if (currentQuestion.Filepath != null)
            //                        {

            //                            //string icon_path = new Uri(currentQuestion.Filepath).LocalPath;
            //                            img.Source = ImageSource.FromFile(currentQuestion.Filepath);
            //                        }
            //                        else
            //                        {
            //                            img.IsVisible = false;
            //                        }
            //                        if (currentQuestion.SeclectedButtonA != null && currentQuestion.SeclectedButtonA.Contains("#0000FF"))
            //                        {
            //                            centerFram1.BackgroundColor = Color.Red;
            //                            centerFram3.BackgroundColor = Color.White;
            //                            centerFram2.BackgroundColor = Color.White;
            //                            centerFram4.BackgroundColor = Color.White;


            //                        }
            //                        else if (currentQuestion.SeclectedButtonC != null && currentQuestion.SeclectedButtonB.Contains("#0000FF"))
            //                        {
            //                            centerFram2.BackgroundColor = Color.Red;
            //                            centerFram3.BackgroundColor = Color.White;
            //                            centerFram4.BackgroundColor = Color.White;
            //                            centerFram1.BackgroundColor = Color.White;

            //                        }
            //                        else if (currentQuestion.SeclectedButtonC != null && currentQuestion.SeclectedButtonC.Contains("#0000FF"))
            //                        {
            //                            centerFram3.BackgroundColor = Color.Red;
            //                            centerFram4.BackgroundColor = Color.White;
            //                            centerFram2.BackgroundColor = Color.White;
            //                            centerFram1.BackgroundColor = Color.White;

            //                        }
            //                        else if (currentQuestion.SeclectedButtonD != null && currentQuestion.SeclectedButtonD.Contains("#0000FF"))
            //                        {
            //                            centerFram4.BackgroundColor = Color.Red;
            //                            centerFram3.BackgroundColor = Color.White;
            //                            centerFram2.BackgroundColor = Color.White;
            //                            centerFram1.BackgroundColor = Color.White;

            //                        }
            //                        else
            //                        {
            //                            centerFram4.BackgroundColor = Color.White;
            //                            centerFram3.BackgroundColor = Color.White;
            //                            centerFram2.BackgroundColor = Color.White;
            //                            centerFram1.BackgroundColor = Color.White;

            //                        }

            //                    }
            //                    else if (prevCounter + 1 == questionCountTotal)
            //                    {
            //                        button.Text = "Finish";
            //                        //var target = list[prevCounter];
            //                        //LIST.ScrollTo(target, ScrollToPosition.Start, true);
            //                        currentQuestion = list[prevCounter];
            //                        list[prevCounter].FrameBackGroundColor = "#01579B";
            //                        lblquestionNo.Text = "Question No" + currentQuestion.ID + ":";
            //                        lblQuestion.Text = currentQuestion.Question;


            //                        Option1.Text = currentQuestion.A;
            //                        Option2.Text = currentQuestion.B;
            //                        Option3.Text = currentQuestion.C;
            //                        Option4.Text = currentQuestion.D;


            //                    }
            //                    int cou = prevCounter + 1;

            //                    //QuestionCount.Text = "Question: " + cou + "/" + questionCountTotal;
            //                    answered = false;
            //                }

            //            }

            //        }

            //    }
            //    btnfocus = false;
            //    btn2focus = false;
            //    btn3focus = false;
            //    btn4focus = false;
        }

        List<Questions> sectionA, sectionB, sectionC,Biology;
        List<DashBoardListview> dashBoardListviews;
        int sectionAcount, sectionBcount, sectionCcount;
        int a = 1;int b = 1;int c=1;
        int A, B, C,at,bt,ct;
        protected override async void OnAppearing()
        {
            
           // await dbConn.CreateTableAsync<Questions>();
           // await dbConn2.CreateTableAsync<TestDetail>();
           // await dbConn3.CreateTableAsync<DashBoardListview>();

           // string test1 = "Test No - 1";
           //  list =await dbConn.QueryAsync<Questions>("Select ID,Sections,Question,A,B,C,D,Answer,Filepath,SectionNO From [UpdatedQuestions] WHERE Test=\"" + tableName+"\"");
           // testScore = await dbConn.QueryAsync<TestScore>("Select Tests,Score,Numbertapped,OutofC From [Test_score] WHERE Tests=\"" + tableName + "\"");
           // sectionA= await dbConn.QueryAsync<Questions>("Select ID,Sections,Question,A,B,C,D,Answer,Filepath From [UpdatedQuestions] WHERE Sections=\"PHYSICS\" AND Test=\"" + tableName + "\"");
           // sectionB = await dbConn.QueryAsync<Questions>("Select ID,Sections,Question,A,B,C,D,Answer,Filepath From [UpdatedQuestions] WHERE Sections=\"CHEMISTRY\" AND Test=\"" + tableName + "\"");
           // sectionC = await dbConn.QueryAsync<Questions>("Select ID,Sections,Question,A,B,C,D,Answer,Filepath From [UpdatedQuestions] WHERE Sections=\"ENGLISH\" AND Test=\"" + tableName + "\"");
           // Biology = await dbConn.QueryAsync<Questions>("Select ID,Sections,Question,A,B,C,D,Answer,Filepath From [UpdatedQuestions] WHERE Sections=\"BIOLOGY\" AND Test=\"" + tableName + "\"");
           // dashBoardListviews = await dbConn3.QueryAsync<DashBoardListview>("select A,B,C,Atotal,Btotal,Ctotal from DashBoardListview where TestName=\"" + tableName+"\"");
           
           // if (dashBoardListviews.Count > 0)
           // {
           //    //await DisplayAlert("count", ""+dashBoardListviews.Count, "ok");
           //     A =Convert.ToInt32(dashBoardListviews[0].A);
           //     B = Convert.ToInt32(dashBoardListviews[0].B);
           //     C = Convert.ToInt32(dashBoardListviews[0].C);
           //     at = Convert.ToInt32(dashBoardListviews[0].Atotal);
           //     bt = Convert.ToInt32(dashBoardListviews[0].Btotol);
           //     ct = Convert.ToInt32(dashBoardListviews[0].Ctotal);




           // }


           // sectionAcount = sectionA.Count;
           // sectionBcount = sectionB.Count;
           // sectionCcount = sectionC.Count;
           
           // MessagingCenter.Send(new TestScore() { Myvalue = tableName }, "PopUpData");

            
           // tstscore =testScore[0].Numbertapped;
           // //if (tstscore.Score != 0)
           // //{
           // //    await DisplayAlert("task", ""+tstscore.Score, "Ok");
           // //}
            
           // questionCountTotal = list.Count;

           // // Random rnd = new Random();
           // // questionNumber = rnd.Next(0, list.Count);

           // //Questions selectedItem = list[questionNumber];

           // // showNextQuestion();
           // currentQuestion = list[0];
           //// await DisplayAlert("Message", ""+list.Count, "OK");
           //// defaultChecked = btnAnswerOne.IsToggled;
           // textColorDefaultCd = lblQuestion.TextColor;
           // confirmbtnColor = btnConfirm.BackgroundColor;
           // prevCounter = list.IndexOf(currentQuestion);
           // for (int i = 0; i < list.Count; i++)
           // {
           //     list[i].ID = (i + 1).ToString();
           // }
           // LIST.ItemsSource = list;
           // //await DisplayAlert("MESSAGE", ""+currentQuestion.Filepath, "OK");
           // if (currentQuestion.Filepath != null)
           // {

           //     //string icon_path = new Uri(currentQuestion.Filepath).LocalPath;
           //     //img.Source = ImageSource.FromFile(currentQuestion.Filepath);
           //    // img.IsVisible = false;
           // }

           // //Questions current2 = sectionA[0];
           // //int indexer = sectionA.IndexOf(current2)+1;
           // //if (currentQuestion.Sections.Contains("PHYSICS"))
           // //{
           //     lblquestionNo.Text = "Question No" + currentQuestion.ID;
           //     lblsectionNo.Text= "Section:  " + currentQuestion.Sections + " (" + currentQuestion.SectionNO + "/" + sectionAcount + ")";
           //     a++;
           // //}
           // //else if (currentQuestion.Sections.Contains("B"))
           // //{
           // //    lblquestionNo.Text = "Question No" + currentQuestion.ID + ":                                          Section:" + currentQuestion.Sections + "(" + b + "/" + sectionBcount + ")";
           // //    b++;
           // //}
           // //else if (currentQuestion.Sections.Contains("C"))
           // //{
           // //    lblquestionNo.Text = "Question No" + currentQuestion.ID + ":                                          Section:" + currentQuestion.Sections + "(" + c + "/" + sectionCcount + ")";
           // //    c++;
           // //}

           // lblQuestion.Text = currentQuestion.Question;
           // Option1.Text = currentQuestion.A;
           // Option2.Text = currentQuestion.B;
           // Option3.Text = currentQuestion.C;
           // Option4.Text = currentQuestion.D;


           // this.Title = tableName;
           // //btnAnswerOne.Text = currentQuestion.A;
           // //btnAnswerTwo.Text = currentQuestion.B;
           // //btnAnswerThree.Text = currentQuestion.C;
           // //btnAnswerFour.Text = currentQuestion.D;
           // int cou = prevCounter + 1;
           // list[0].FrameBackGroundColor = "#01579B";
           // for(int i = 1; i < list.Count; i++)
           // {
           //     list[i].FrameBackGroundColor = "#039be5";
           // }
            
           // //LIST.WidthRequest = (20 * list.Count) + (10 * list.Count);
           // //QuestionCount.Text = "Question: " + cou + "/" + questionCountTotal;
           // answered = false;
           // questionNumber = list.IndexOf(currentQuestion);
            
            base.OnAppearing();
        }
        protected override async void OnDisappearing()
        {
            //StartTimer(mins, counter);
            base.OnDisappearing();
            //sco = score.ToString();
            //inde = ind;
            //await dbConn.CreateTableAsync<Questions>();
            //await dbConn2.CreateTableAsync<TestDetail>();
            //await dbConn3.CreateTableAsync<DashBoardListview>();

            //string test1 = "Test No - 1";
            //list = await dbConn.QueryAsync<Questions>("Select ID,Sections,Question,A,B,C,D,Answer,Filepath,SectionNO From [UpdatedQuestions] WHERE Test=\"" + tableName + "\"");
            //testScore = await dbConn.QueryAsync<TestScore>("Select Tests,Score,Numbertapped,OutofC From [Test_score] WHERE Tests=\"" + tableName + "\"");
            //sectionA = await dbConn.QueryAsync<Questions>("Select ID,Sections,Question,A,B,C,D,Answer,Filepath From [UpdatedQuestions] WHERE Sections=\"PHYSICS\" AND Test=\"" + tableName + "\"");
            //sectionB = await dbConn.QueryAsync<Questions>("Select ID,Sections,Question,A,B,C,D,Answer,Filepath From [UpdatedQuestions] WHERE Sections=\"CHEMISTRY\" AND Test=\"" + tableName + "\"");
            //sectionC = await dbConn.QueryAsync<Questions>("Select ID,Sections,Question,A,B,C,D,Answer,Filepath From [UpdatedQuestions] WHERE Sections=\"ENGLISH\" AND Test=\"" + tableName + "\"");
            //Biology = await dbConn.QueryAsync<Questions>("Select ID,Sections,Question,A,B,C,D,Answer,Filepath From [UpdatedQuestions] WHERE Sections=\"BIOLOGY\" AND Test=\"" + tableName + "\"");
            //dashBoardListviews = await dbConn3.QueryAsync<DashBoardListview>("select A,B,C,Atotal,Btotal,Ctotal from DashBoardListview where TestName=\"" + tableName + "\"");

            //if (dashBoardListviews.Count > 0)
            //{
            //    //await DisplayAlert("count", ""+dashBoardListviews.Count, "ok");
            //    A = Convert.ToInt32(dashBoardListviews[0].A);
            //    B = Convert.ToInt32(dashBoardListviews[0].B);
            //    C = Convert.ToInt32(dashBoardListviews[0].C);
            //    at = Convert.ToInt32(dashBoardListviews[0].Atotal);
            //    bt = Convert.ToInt32(dashBoardListviews[0].Btotol);
            //    ct = Convert.ToInt32(dashBoardListviews[0].Ctotal);




            //}


            //sectionAcount = sectionA.Count;
            //sectionBcount = sectionB.Count;
            //sectionCcount = sectionC.Count;

            //MessagingCenter.Send(new TestScore() { Myvalue = tableName }, "PopUpData");


            //tstscore = testScore[0].Numbertapped;
            ////if (tstscore.Score != 0)
            ////{
            ////    await DisplayAlert("task", ""+tstscore.Score, "Ok");
            ////}

            //questionCountTotal = list.Count;

            //// Random rnd = new Random();
            //// questionNumber = rnd.Next(0, list.Count);

            ////Questions selectedItem = list[questionNumber];

            //// showNextQuestion();
            //currentQuestion = list[0];
            //// await DisplayAlert("Message", ""+list.Count, "OK");
            //// defaultChecked = btnAnswerOne.IsToggled;
            //textColorDefaultCd = lblQuestion.TextColor;
            //confirmbtnColor = btnConfirm.BackgroundColor;
            //prevCounter = list.IndexOf(currentQuestion);
            //for (int i = 0; i < list.Count; i++)
            //{
            //    list[i].ID = (i + 1).ToString();
            //}
            //LIST.ItemsSource = list;
            ////await DisplayAlert("MESSAGE", ""+currentQuestion.Filepath, "OK");
            //if (currentQuestion.Filepath != null)
            //{

            //    //string icon_path = new Uri(currentQuestion.Filepath).LocalPath;
            //    //img.Source = ImageSource.FromFile(currentQuestion.Filepath);
            //    // img.IsVisible = false;
            //}

            ////Questions current2 = sectionA[0];
            ////int indexer = sectionA.IndexOf(current2)+1;
            ////if (currentQuestion.Sections.Contains("PHYSICS"))
            ////{
            //lblquestionNo.Text = "Question No" + currentQuestion.ID;
            //lblsectionNo.Text = "Section:  " + currentQuestion.Sections + " (" + currentQuestion.SectionNO + "/" + sectionAcount + ")";
            //a++;
            ////}
            ////else if (currentQuestion.Sections.Contains("B"))
            ////{
            ////    lblquestionNo.Text = "Question No" + currentQuestion.ID + ":                                          Section:" + currentQuestion.Sections + "(" + b + "/" + sectionBcount + ")";
            ////    b++;
            ////}
            ////else if (currentQuestion.Sections.Contains("C"))
            ////{
            ////    lblquestionNo.Text = "Question No" + currentQuestion.ID + ":                                          Section:" + currentQuestion.Sections + "(" + c + "/" + sectionCcount + ")";
            ////    c++;
            ////}

            //lblQuestion.Text = currentQuestion.Question;
            //Option1.Text = currentQuestion.A;
            //Option2.Text = currentQuestion.B;
            //Option3.Text = currentQuestion.C;
            //Option4.Text = currentQuestion.D;


            //this.Title = tableName;
            ////btnAnswerOne.Text = currentQuestion.A;
            ////btnAnswerTwo.Text = currentQuestion.B;
            ////btnAnswerThree.Text = currentQuestion.C;
            ////btnAnswerFour.Text = currentQuestion.D;
            //int cou = prevCounter + 1;
            //list[0].FrameBackGroundColor = "#01579B";
            //for (int i = 1; i < list.Count; i++)
            //{
            //    list[i].FrameBackGroundColor = "#039be5";
            //}

            ////LIST.WidthRequest = (20 * list.Count) + (10 * list.Count);
            ////QuestionCount.Text = "Question: " + cou + "/" + questionCountTotal;
            //answered = false;
            //questionNumber = list.IndexOf(currentQuestion);

        }
        
        
        private void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {
            var frame = sender as Frame;
            //frame.BackgroundColor = Color.FromHex("#01579B"); 
           
            var label = (Label)frame.Children[0];

            centerFram1.BackgroundColor = Color.White;
            centerFram2.BackgroundColor = Color.White;
            centerFram3.BackgroundColor = Color.White;
            centerFram4.BackgroundColor = Color.White;
            int count = Convert.ToInt32(label.Text);
            prevCounter = count - 1;
            //list[i].FrameBackGroundColor = "#01579B";
            for(int i = 0; i < list.Count; i++)
            {
                list[i].FrameBackGroundColor = "#039be5";
            }
            
            list[prevCounter].FrameBackGroundColor = "#01579B";
            LIST.ItemsSource = null;
            LIST.ItemsSource = list;
            if (prevCounter == 0)
            {
                var target1 = list[prevCounter];
                LIST.ScrollTo(target1, ScrollToPosition.Start, true);
            }
            else
            {
                var target = list[prevCounter - 1];
                LIST.ScrollTo(target, ScrollToPosition.Start, true);
            }
           
            // LIST.ScrollTo();
            
            Questions indexedQuestion = list[prevCounter];
            //DisplayAlert("task", "" + prevCounter, "ok");
            //DisplayAlert("", "" + indexedQuestion.A, "OK");
            if (indexedQuestion.Sections.Contains("PHYSICS"))
            {
                lblquestionNo.Text = "Question No" + indexedQuestion.ID;
                lblsectionNo.Text= "Section:  " + indexedQuestion.Sections + "  (" + indexedQuestion.SectionNO + "/" + sectionAcount + ")";
                a++;
            }
            else if (indexedQuestion.Sections.Contains("CHEMISTRY"))
            {
                lblquestionNo.Text = "Question No" + indexedQuestion.ID;
                lblsectionNo.Text = " Section:  " + indexedQuestion.Sections + " (" + indexedQuestion.SectionNO + "/" + sectionBcount + ")";
                if (b != sectionBcount)
                {
                    b++;
                }

            }
            else if (indexedQuestion.Sections.Contains("ENGLISH"))
            {
                lblquestionNo.Text = "Question No" + indexedQuestion.ID;
                lblsectionNo.Text = "Section:  " + indexedQuestion.Sections + "  (" + indexedQuestion.SectionNO + "/" + sectionCcount + ")";
                c++;
            }else if (indexedQuestion.Sections.Contains("BIOLOGY"))
            {
                lblquestionNo.Text = "Question No" + indexedQuestion.ID;
                lblsectionNo.Text = "Section:  " + indexedQuestion.Sections + "  (" + indexedQuestion.SectionNO + "/" + Biology.Count + ")";
            }
            lblQuestion.Text = indexedQuestion.Question;
            Option1.Text = indexedQuestion.A;
            Option2.Text = indexedQuestion.B;
            Option3.Text = indexedQuestion.C;
            Option4.Text = indexedQuestion.D;
            //DisplayAlert("MESSAGE", "INDEX:"+prevCounter, "OK");
            if (indexedQuestion.Filepath != null)
            {

                //string icon_path = new Uri(currentQuestion.Filepath).LocalPath;
                img.Source = ImageSource.FromFile(indexedQuestion.Filepath);
            }
           
            if (list[prevCounter].SeclectedButtonA != null && list[prevCounter].SeclectedButtonA.Contains("#0000FF"))
            {
                centerFram1.BackgroundColor = Color.FromHex("#039be5");
                centerFram3.BackgroundColor = Color.White;
                centerFram2.BackgroundColor = Color.White;
                centerFram4.BackgroundColor = Color.White;


            }
            else if (list[prevCounter].SeclectedButtonB != null && list[prevCounter].SeclectedButtonB.Contains("#0000FF"))
            {
                centerFram2.BackgroundColor = Color.FromHex("#039be5");
                centerFram3.BackgroundColor = Color.White;
                centerFram4.BackgroundColor = Color.White;
                centerFram1.BackgroundColor = Color.White;

            }
            else if (list[prevCounter].SeclectedButtonC != null && list[prevCounter].SeclectedButtonC.Contains("#0000FF"))
            {
                centerFram3.BackgroundColor = Color.FromHex("#039be5");
                centerFram4.BackgroundColor = Color.White;
                centerFram2.BackgroundColor = Color.White;
                centerFram1.BackgroundColor = Color.White;

            }
            else if (list[prevCounter].SeclectedButtonD != null && list[prevCounter].SeclectedButtonD.Contains("#0000FF"))
            {
                centerFram4.BackgroundColor = Color.FromHex("#039be5");
                centerFram3.BackgroundColor = Color.White;
                centerFram2.BackgroundColor = Color.White;
                centerFram1.BackgroundColor = Color.White;

            }
            else
            {
                centerFram4.BackgroundColor = Color.White;
                centerFram3.BackgroundColor = Color.White;
                centerFram2.BackgroundColor = Color.White;
                centerFram1.BackgroundColor = Color.White;

            }

            if (prevCounter + 1 == questionCountTotal)
            {
                answered = true;
            }
        }
        int acount, bcount;
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

            int index = list.IndexOf(currentQuestion);
            for (int i = 0; i < list.Count; i++)
            {
                list[i].FrameBackGroundColor = "#039be5";
            }

            
            if (prevCounter > 0 && prevCounter <= questionCountTotal)
            {
               // btnConfirm.Text = "Next";

                questionCounter = prevCounter;
                prevCounter--;
                list[prevCounter].FrameBackGroundColor = "#01579B";
                LIST.ItemsSource = null;
                LIST.ItemsSource = list;
                var target = list[prevCounter];
                LIST.ScrollTo(target, ScrollToPosition.Start, true);
                //DisplayAlert("INDEX", ""+prevCounter, "OK");
                previousQuestion = list[prevCounter];
                //DisplayAlert("task", "" + prevCounter, "ok");
                //if (prevCounter < sectionA.Count)
                //{
                    if (list[prevCounter].Sections.Contains("PHYSICS"))
                    {

                        //Questions prevQuestion = sectionA[prevCounter];
                        ////a--;
                        //int sectionc = sectionA.IndexOf(prevQuestion) + 1;
                        //acount = sectionAcount - 1;
                    lblquestionNo.Text = "Question No" + previousQuestion.ID;
                        lblsectionNo.Text= "Section:  " + previousQuestion.Sections + "  (" + previousQuestion.SectionNO + "/" + sectionAcount + ")";
                    //if (sectionc == 1)
                    //{
                    //    a++;
                    //}
                    // DisplayAlert("MS", ""+prevCounter, "OK");
                    // }

                }
                else if (list[prevCounter].Sections.Contains("CHEMISTRY"))
                {

                    //else if (list[prevCounter].Sections.Contains("B"))
                    //{

                    if (sectionB.Count <= 2)
                    {
                       // DisplayAlert("INDEX", ""+sectionB.Count, "OK");
                        int j1 = prevCounter - (sectionBcount + 1);
                        Questions PopQuestion1 = sectionB[j1];
                        int i = sectionB.IndexOf(PopQuestion1) + 1;
                        lblquestionNo.Text = "Question No" + previousQuestion.ID;
                        lblsectionNo.Text= " Section:  " + previousQuestion.Sections + "  (" + i.ToString() + "/" + sectionB.Count + ")";
                    }
                    else
                    {
                        //int j = prevCounter - sectionBcount;
                        ////DisplayAlert("sectionB", "" + sectionB.Count, "ok");
                        //Questions PopQuestion2 = sectionB[j];
                        ////j++;
                        //int i23 = sectionB.IndexOf(PopQuestion2) + 1;
                        lblquestionNo.Text = "Question No" + previousQuestion.ID;
                        lblsectionNo.Text= "Section:  " + previousQuestion.Sections + "  (" + previousQuestion.SectionNO + "/" + sectionB.Count + ")";
                    }

                    //}
                }
                else if (previousQuestion.Sections.Contains("ENGLISH"))
                {
                    lblquestionNo.Text = "Question No" + previousQuestion.ID;
                    lblsectionNo.Text = "Section:  " + previousQuestion.Sections + "  (" + previousQuestion.SectionNO + "/" + sectionCcount + ")";
                    c++;
                }
                else if (previousQuestion.Sections.Contains("BIOLOGY"))
                {
                    lblquestionNo.Text = "Question No" + previousQuestion.ID;
                    lblsectionNo.Text = "Section:  " + previousQuestion.Sections + "  (" + previousQuestion.SectionNO + "/" + Biology.Count + ")";
                }

                //else if (previousQuestion.Sections.Contains("C"))
                //{
                //    c--;
                //    lblquestionNo.Text = "Question No" + previousQuestion.ID + ":                                             Section:" + previousQuestion.Sections + "(" + c + "/" + sectionCcount + ")";

                //}
                lblQuestion.Text = previousQuestion.Question;
                Option1.Text = previousQuestion.A;
                Option2.Text = previousQuestion.B;
                Option3.Text = previousQuestion.C;
                Option4.Text = previousQuestion.D;
                if (previousQuestion.Filepath != null)
                {

                    //string icon_path = new Uri(currentQuestion.Filepath).LocalPath;
                    img.Source = ImageSource.FromFile(previousQuestion.Filepath);
                }
               
                //else if (previousQuestion.SeclectedButtonB != null && previousQuestion.SeclectedButtonB.Contains("#0000ff"))
                if (list[prevCounter].SeclectedButtonA != null && list[prevCounter].SeclectedButtonA.Contains("#0000FF"))
                {
                    centerFram1.BackgroundColor = Color.FromHex("#039be5");
                    centerFram3.BackgroundColor = Color.White;
                    centerFram2.BackgroundColor = Color.White;
                    centerFram4.BackgroundColor = Color.White;


                }
                else if (list[prevCounter].SeclectedButtonB != null && list[prevCounter].SeclectedButtonB.Contains("#0000FF"))
                {
                    centerFram2.BackgroundColor = Color.FromHex("#039be5");
                    centerFram3.BackgroundColor = Color.White;
                    centerFram4.BackgroundColor = Color.White;
                    centerFram1.BackgroundColor = Color.White;

                }
                else if (list[prevCounter].SeclectedButtonC != null && list[prevCounter].SeclectedButtonC.Contains("#0000FF"))
                {
                    centerFram3.BackgroundColor = Color.FromHex("#039be5");
                    centerFram4.BackgroundColor = Color.White;
                    centerFram2.BackgroundColor = Color.White;
                    centerFram1.BackgroundColor = Color.White;

                }
                else if (list[prevCounter].SeclectedButtonD != null && list[prevCounter].SeclectedButtonD.Contains("#0000FF"))
                {
                    centerFram4.BackgroundColor = Color.FromHex("#039be5");
                    centerFram3.BackgroundColor = Color.White;
                    centerFram2.BackgroundColor = Color.White;
                    centerFram1.BackgroundColor = Color.White;

                }
                else
                {
                    centerFram4.BackgroundColor = Color.White;
                    centerFram3.BackgroundColor = Color.White;
                    centerFram2.BackgroundColor = Color.White;
                    centerFram1.BackgroundColor = Color.White;

                }

                int cou = prevCounter + 2 - 1;
                //QuestionCount.Text = "Question: " + cou + "/" + questionCountTotal;
                answered = false;

            }

        }
        //var target = list[0];
        //LIST.ScrollTo(target, ScrollToPosition.Start, true);

           

        private void TapGestureRecognizer_TappedLef(object sender, EventArgs e)
        
            //var target = list[list.Count-1];
            //LIST.ScrollTo(target, ScrollToPosition.Start, true);

            {

               // var button = sender as Button;
                if (!answered)
                {

                    if (btnfocus || btn2focus || btn3focus || btn4focus)
                    {


                        centerFram1.BackgroundColor = Color.White;
                        centerFram2.BackgroundColor = Color.White;
                        centerFram3.BackgroundColor = Color.White;
                        centerFram4.BackgroundColor = Color.White;



                    for (int i = 0; i < list.Count; i++)
                    {
                        list[i].FrameBackGroundColor = "#039be5";
                    }
                    if (prevCounter < questionCountTotal)
                        {

                            int indexx = prevCounter;
                            prevCounter++;

                            if (prevCounter + 1 < questionCountTotal)
                            {
                                var target = list[prevCounter];
                                LIST.ScrollTo(target, ScrollToPosition.Start, true);
                                currentQuestion = list[prevCounter];
                                list[prevCounter].FrameBackGroundColor = "#01579B";
                            LIST.ItemsSource = null;
                            LIST.ItemsSource = list;
                            //if (currentQuestion.Sections.Contains("A"))
                            //{
                            //    lblquestionNo.Text = "Question No" + currentQuestion.ID + ":                                         Section:" + currentQuestion.Sections + "(" + a + "/" + sectionAcount + ")";
                            //    //if (a != sectionAcount)
                            //    //{
                            //        a++;
                            //    //}

                            //}
                            //else if (currentQuestion.Sections.Contains("B"))
                            //{
                            //    lblquestionNo.Text = "Question No" + currentQuestion.ID + ":                                           Section:" + currentQuestion.Sections + "(" + b + "/" + sectionBcount + ")";
                            //    if (b != sectionBcount)
                            //    {
                            //        b++;
                            //    }
                            //}
                            //else if (currentQuestion.Sections.Contains("C"))
                            //{
                            //    lblquestionNo.Text = "Question No" + currentQuestion.ID + ":                                            Section:" + currentQuestion.Sections + "(" + c + "/" + sectionCcount + ")";
                            //    c++;
                            //}
                            //if (prevCounter < sectionA.Count)
                            //{
                            //    if (list[prevCounter].Sections.Contains("A"))
                            //    {

                            //        Questions prevQuestion = sectionA[prevCounter];
                            //        //a--;
                            //        int sectionc = sectionA.IndexOf(prevQuestion) + 1;
                            //        acount = sectionAcount - 1;
                            //        lblquestionNo.Text = "Question No" + currentQuestion.ID + ":                                        Section:" + currentQuestion.Sections + "(" + sectionc + "/" + sectionAcount + ")";
                            //        //if (sectionc == 1)
                            //        //{
                            //        //    a++;
                            //        //}
                            //    }
                            //}
                            //else
                            //{

                            //    //else if (list[prevCounter].Sections.Contains("B"))
                            //    //{

                            //    int b = prevCounter - sectionB.Count + 1;
                            //    //Questions prevQuestion = sectionB[prevCounter];
                            //    //a--;
                            //    //int sectionb = sectionB.IndexOf(prevQuestion) + 1-sectionB.Count;
                            //    acount = sectionAcount - 1;
                            //    lblquestionNo.Text = "Question No" + currentQuestion.ID + ":                                        Section:" + currentQuestion.Sections + "(" + b + "/" + sectionAcount + ")";

                            //    //}
                            //}
                            if (list[prevCounter].Sections.Contains("PHYSICS"))
                            {

                                //Questions prevQuestion = sectionA[prevCounter];
                                ////a--;
                                //int sectionc = sectionA.IndexOf(prevQuestion) + 1;
                                //acount = sectionAcount - 1;
                                lblquestionNo.Text = "Question No" + currentQuestion.ID;
                                lblsectionNo.Text= "Section:  " + currentQuestion.Sections + "  (" + currentQuestion.SectionNO + "/" + sectionAcount + ")";
                                //if (sectionc == 1)
                                //{
                                //    a++;
                                //}
                                //DisplayAlert("MS", "" + prevCounter, "OK");
                                // }

                            }
                            else if (list[prevCounter].Sections.Contains("CHEMISTRY"))
                            {

                                //else if (list[prevCounter].Sections.Contains("B"))
                                //{

                                if (sectionB.Count <= 2)
                                {
                                   // DisplayAlert("INDEX", "" + sectionB.Count, "OK");
                                    int j1 = prevCounter - (sectionBcount + 1);
                                    Questions PopQuestion1 = sectionB[j1];
                                    int i = sectionB.IndexOf(PopQuestion1) + 1;
                                    lblquestionNo.Text = "Question No" + currentQuestion.ID;
                                    lblsectionNo.Text= "Section:  " + currentQuestion.Sections + "  (" + currentQuestion.SectionNO + "/" + sectionB.Count + ")";
                                }
                                else
                                {
                                    //int j = prevCounter - sectionBcount;
                                    ////DisplayAlert("sectionB", "" + sectionB.Count, "ok");
                                    //Questions PopQuestion2 = sectionB[j];
                                    ////j++;
                                    //int i23 = sectionB.IndexOf(PopQuestion2) + 1;
                                    lblquestionNo.Text = "Question No" + currentQuestion.ID;
                                    lblsectionNo.Text= "Section:  " + currentQuestion.Sections + "  (" + currentQuestion.SectionNO + "/" + sectionB.Count + ")";
                                }

                                //}
                            }
                            else if (currentQuestion.Sections.Contains("ENGLISH"))
                            {
                                lblquestionNo.Text = "Question No" + currentQuestion.ID;
                                lblsectionNo.Text = "Section:  " + currentQuestion.Sections + "  (" + currentQuestion.SectionNO + "/" + sectionCcount + ")";
                                c++;
                            }
                            else if (currentQuestion.Sections.Contains("BIOLOGY"))
                            {
                                lblquestionNo.Text = "Question No" + currentQuestion.ID;
                                lblsectionNo.Text = "Section: " + currentQuestion.Sections + "  (" + currentQuestion.SectionNO + "/" + Biology.Count + ")";
                            }

                            lblQuestion.Text = currentQuestion.Question;

                                Option1.Text = currentQuestion.A;
                                Option2.Text = currentQuestion.B;
                                Option3.Text = currentQuestion.C;
                                Option4.Text = currentQuestion.D;
                                if (currentQuestion.Filepath != null)
                                {

                                    //string icon_path = new Uri(currentQuestion.Filepath).LocalPath;
                                    img.Source = ImageSource.FromFile(currentQuestion.Filepath);
                                }
                                
                                if (list[prevCounter].SeclectedButtonA != null && list[prevCounter].SeclectedButtonA.Contains("#0000FF"))
                                {
                                    centerFram1.BackgroundColor = Color.FromHex("#039be5");
                                centerFram3.BackgroundColor = Color.White;
                                    centerFram2.BackgroundColor = Color.White;
                                    centerFram4.BackgroundColor = Color.White;


                                }
                                else if (list[prevCounter].SeclectedButtonC != null && list[prevCounter].SeclectedButtonB.Contains("#0000FF"))
                                {
                                    centerFram2.BackgroundColor = Color.FromHex("#039be5");
                                centerFram3.BackgroundColor = Color.White;
                                    centerFram4.BackgroundColor = Color.White;
                                    centerFram1.BackgroundColor = Color.White;

                                }
                                else if (list[prevCounter].SeclectedButtonC != null && list[prevCounter].SeclectedButtonC.Contains("#0000FF"))
                                {
                                    centerFram3.BackgroundColor = Color.FromHex("#039be5");
                                centerFram4.BackgroundColor = Color.White;
                                    centerFram2.BackgroundColor = Color.White;
                                    centerFram1.BackgroundColor = Color.White;

                                }
                                else if (list[prevCounter].SeclectedButtonD != null && list[prevCounter].SeclectedButtonD.Contains("#0000FF"))
                                {
                                    centerFram4.BackgroundColor = Color.FromHex("#039be5");
                                centerFram3.BackgroundColor = Color.White;
                                    centerFram2.BackgroundColor = Color.White;
                                    centerFram1.BackgroundColor = Color.White;

                                }
                                else
                                {
                                    centerFram4.BackgroundColor = Color.White;
                                    centerFram3.BackgroundColor = Color.White;
                                    centerFram2.BackgroundColor = Color.White;
                                    centerFram1.BackgroundColor = Color.White;

                                }


                                int cou = prevCounter + 1;

                                //QuestionCount.Text = "Question: " + cou + "/" + questionCountTotal;
                                answered = false;
                            }
                            else if (prevCounter + 1 == questionCountTotal)
                            {
                                //button.Text = "Finish";
                                //var target = list[prevCounter];
                                //LIST.ScrollTo(target, ScrollToPosition.Start, true);
                                currentQuestion = list[prevCounter];
                                list[prevCounter].FrameBackGroundColor = "#01579B";
                            //if (currentQuestion.Sections.Contains("A"))
                            //{
                            //    lblquestionNo.Text = "Question No" + currentQuestion.ID + ":                                        Section:" + currentQuestion.Sections + "(" + a + "/" + sectionAcount + ")";
                            //    a++;
                            //}
                            //else if (currentQuestion.Sections.Contains("B"))
                            //{
                            //    lblquestionNo.Text = "Question No" + currentQuestion.ID + ":                                         Section:" + currentQuestion.Sections + "(" + b + "/" + sectionBcount + ")";
                            //    if (b != sectionBcount)
                            //    {
                            //        b++;
                            //    }

                            //}
                            //else if (currentQuestion.Sections.Contains("C"))
                            //{
                            //    lblquestionNo.Text = "Question No" + currentQuestion.ID + ":                                           Section:" + currentQuestion.Sections + "(" + c + "/" + sectionCcount + ")";
                            //    c++;
                            //}

                            //if (prevCounter < sectionA.Count)
                            //{
                            //    if (list[prevCounter].Sections.Contains("A"))
                            //    {

                            //        Questions prevQuestion = sectionA[prevCounter];
                            //        //a--;
                            //        int sectionc = sectionA.IndexOf(prevQuestion) + 1;
                            //        acount = sectionAcount - 1;
                            //        lblquestionNo.Text = "Question No" + currentQuestion.ID + ":                                        Section:" + currentQuestion.Sections + "(" + sectionc + "/" + sectionAcount + ")";
                            //        //if (sectionc == 1)
                            //        //{
                            //        //    a++;
                            //        //}
                            //    }
                            //}
                            //else
                            //{

                            //    //else if (list[prevCounter].Sections.Contains("B"))
                            //    //{

                            //    int b = prevCounter - sectionB.Count + 1;
                            //    //Questions prevQuestion = sectionB[prevCounter];
                            //    //a--;
                            //    //int sectionb = sectionB.IndexOf(prevQuestion) + 1-sectionB.Count;
                            //    acount = sectionAcount - 1;
                            //    lblquestionNo.Text = "Question No" + currentQuestion.ID + ":                                        Section:" + currentQuestion.Sections + "(" + b + "/" + sectionAcount + ")";

                            //    //}
                            //}
                            if (list[prevCounter].Sections.Contains("PHYSICS"))
                            {

                                //Questions prevQuestion = sectionA[prevCounter];
                                ////a--;
                                //int sectionc = sectionA.IndexOf(prevQuestion) + 1;
                                //acount = sectionAcount - 1;
                                lblquestionNo.Text = "Question No" + currentQuestion.ID;
                                lblsectionNo.Text = "Section:  " + currentQuestion.Sections + "  (" + currentQuestion.SectionNO + "/" + sectionAcount + ")";
                                //if (sectionc == 1)
                                //{
                                //    a++;
                                //}
                                //DisplayAlert("MS", "" + prevCounter, "OK");
                                // }

                            }
                            else if (list[prevCounter].Sections.Contains("CHEMISTRY"))
                            {

                                //else if (list[prevCounter].Sections.Contains("B"))
                                //{

                                if (sectionB.Count <= 2)
                                {
                                    // DisplayAlert("INDEX", "" + sectionB.Count, "OK");
                                    int j1 = prevCounter - (sectionBcount + 1);
                                    Questions PopQuestion1 = sectionB[j1];
                                    int i = sectionB.IndexOf(PopQuestion1) + 1;
                                    lblquestionNo.Text = "Question No" + currentQuestion.ID;
                                    lblsectionNo.Text = "Section:  " + currentQuestion.Sections + "  (" + currentQuestion.SectionNO + "/" + sectionB.Count + ")";
                                }
                                else
                                {
                                    //int j = prevCounter - sectionBcount;
                                    ////DisplayAlert("sectionB", "" + sectionB.Count, "ok");
                                    //Questions PopQuestion2 = sectionB[j];
                                    ////j++;
                                    //int i23 = sectionB.IndexOf(PopQuestion2) + 1;
                                    lblquestionNo.Text = "Question No" + currentQuestion.ID;
                                    lblsectionNo.Text = "Section:  " + currentQuestion.Sections + " (" + currentQuestion.SectionNO + "/" + sectionB.Count + ")";
                                }

                                //}
                            }
                            else if (currentQuestion.Sections.Contains("ENGLISH"))
                            {
                                lblquestionNo.Text = "Question No" + currentQuestion.ID;
                                lblsectionNo.Text = "Section:  " + currentQuestion.Sections + "  (" + currentQuestion.SectionNO + "/" + sectionCcount + ")";
                                c++;
                            }
                            else if (currentQuestion.Sections.Contains("BIOLOGY"))
                            {
                                lblquestionNo.Text = "Question No" + currentQuestion.ID;
                                lblsectionNo.Text = "Section:  " + currentQuestion.Sections + "  (" + currentQuestion.SectionNO + "/" + Biology.Count + ")";
                            }
                            lblQuestion.Text = currentQuestion.Question;

                                Option1.Text = currentQuestion.A;
                                Option2.Text = currentQuestion.B;
                                Option3.Text = currentQuestion.C;
                                Option4.Text = currentQuestion.D;
                            if (currentQuestion.Filepath != null)
                            {

                                //string icon_path = new Uri(currentQuestion.Filepath).LocalPath;
                                img.Source = ImageSource.FromFile(currentQuestion.Filepath);
                            }
                           
                            if (list[prevCounter].SeclectedButtonA != null && list[prevCounter].SeclectedButtonA.Contains("#0000FF"))
                            {
                                centerFram1.BackgroundColor = Color.FromHex("#039be5");
                                centerFram3.BackgroundColor = Color.White;
                                centerFram2.BackgroundColor = Color.White;
                                centerFram4.BackgroundColor = Color.White;


                            }
                            else if (list[prevCounter].SeclectedButtonC != null && list[prevCounter].SeclectedButtonB.Contains("#0000FF"))
                            {
                                centerFram2.BackgroundColor = Color.FromHex("#039be5");
                                centerFram3.BackgroundColor = Color.White;
                                centerFram4.BackgroundColor = Color.White;
                                centerFram1.BackgroundColor = Color.White;

                            }
                            else if (list[prevCounter].SeclectedButtonC != null && list[prevCounter].SeclectedButtonC.Contains("#0000FF"))
                            {
                                centerFram3.BackgroundColor = Color.FromHex("#039be5");
                                centerFram4.BackgroundColor = Color.White;
                                centerFram2.BackgroundColor = Color.White;
                                centerFram1.BackgroundColor = Color.White;

                            }
                            else if (list[prevCounter].SeclectedButtonD != null && list[prevCounter].SeclectedButtonD.Contains("#0000FF"))
                            {
                                centerFram4.BackgroundColor = Color.FromHex("#039be5");
                                centerFram3.BackgroundColor = Color.White;
                                centerFram2.BackgroundColor = Color.White;
                                centerFram1.BackgroundColor = Color.White;

                            }
                            else
                            {
                                centerFram4.BackgroundColor = Color.White;
                                centerFram3.BackgroundColor = Color.White;
                                centerFram2.BackgroundColor = Color.White;
                                centerFram1.BackgroundColor = Color.White;

                            }
                            answered = true;
                            //int cou = prevCounter + 1;

                            //QuestionCount.Text = "Question: " + cou + "/" + questionCountTotal;

                        }
                        else
                        {


                            for (int i = 0; i < list.Count; i++)
                            {
                                if (list[i].TextColorA != null && list[i].TextColorB != null
                             && list[i].TextColorC != null && list[i].TextColorD != null &&
                            list[i].TextColorA.Contains("#00FF00") && list[i].TextColorB.Contains("#000000")
                             && list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#000000"))
                                {
                                    if (list[i].Sections.Contains("PHYSICS"))
                                    {
                                        score++;
                                    }
                                    else if (list[i].Sections.Contains("CHEMISTRY"))
                                    {
                                        scoreB++;
                                    }
                                    else if (list[i].Sections.Contains("ENGLISH"))
                                    {
                                        scoreC++;
                                    }
                                    else if (list[i].Sections.Contains("BIOLOGY"))
                                    {
                                        scoreD++;
                                    }
                                }
                                else if (list[i].TextColorA != null && list[i].TextColorB != null
                                     && list[i].TextColorC != null && list[i].TextColorD != null &&
                                    list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#00FF00")
                                     && list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#000000"))
                                {
                                    if (list[i].Sections.Contains("PHYSICS"))
                                    {
                                        score++;
                                    }
                                    else if (list[i].Sections.Contains("CHEMISTRY"))
                                    {
                                        scoreB++;
                                    }
                                    else if (list[i].Sections.Contains("ENGLISH"))
                                    {
                                        scoreC++;
                                    }
                                    else if (list[i].Sections.Contains("BIOLOGY"))
                                    {
                                        scoreD++;
                                    }
                                }
                                else if (list[i].TextColorA != null && list[i].TextColorB != null
                                     && list[i].TextColorC != null && list[i].TextColorD != null &&
                                    list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#000000")
                                     && list[i].TextColorC.Contains("#00FF00") && list[i].TextColorD.Contains("#000000"))
                                {
                                    if (list[i].Sections.Contains("PHYSICS"))
                                    {
                                        score++;
                                    }
                                    else if (list[i].Sections.Contains("CHEMISTRY"))
                                    {
                                        scoreB++;
                                    }
                                    else if (list[i].Sections.Contains("ENGLISH"))
                                    {
                                        scoreC++;
                                    }
                                    else if (list[i].Sections.Contains("BIOLOGY"))
                                    {
                                        scoreD++;
                                    }
                                }
                                else if (list[i].TextColorA != null && list[i].TextColorB != null
                                     && list[i].TextColorC != null && list[i].TextColorD != null &&
                                    list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#000000")
                                     && list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#00FF00"))
                                {
                                    if (list[i].Sections.Contains("PHYSICS"))
                                    {
                                        score++;
                                    }
                                    else if (list[i].Sections.Contains("CHEMISTRY"))
                                    {
                                        scoreB++;
                                    }
                                    else if (list[i].Sections.Contains("ENGLISH"))
                                    {
                                        scoreC++;
                                    }
                                    else if (list[i].Sections.Contains("BIOLOGY"))
                                    {
                                        scoreD++;
                                    }
                                }
                                else
                                {
                                    score = score + 0;
                                    scoreB = scoreB + 0;
                                    scoreC = scoreC + 0;
                                    scoreD = scoreD + 0;
                                }
                                
                                

                            }

                            string totalQuestions = (list.Count) + " Questions";
                            string totalTime = (list.Count) + " miniutes";
                            int tapped = tstscore + 1;
                            int outof = list.Count;
                            string Ascore = (score + "/" + sectionA.Count).ToString();
                            string Bscore = (scoreB + "/" + sectionB.Count).ToString();
                            string Cscore = (scoreC + "/" + sectionC.Count).ToString();
                            string Dscore = (scoreD + "/" + Biology.Count).ToString();
                            // DisplayAlert("MESSAGE", "" + Ascore, "OK");
                            //string AverageTime =CountDown.Text.ToString();
                            string AverageTime = string.Format("{0:00}:{1:00}", totalmin, totolsec);
                            string attempts = tapped.ToString();

                            int atotal = sectionA.Count;
                            int btotal = sectionB.Count;
                            int ctotal = sectionC.Count;
                            int dtotal = Biology.Count;

                            //DisplayAlert("ALERT", "Average Time" + AverageTime, "OK");
                            int totaloutof = list.Count;
                            double total = score + scoreB + scoreC + scoreD;
                            double averagescore = (total / 4);

                            //await DisplayAlert("averagescore", ""+averagescore.ToString("0.00"), "ok");
                            //averagescore = Math.Floor(averagescore * 100) / 100;
                            string AverageSc = string.Format("{0:F2}", averagescore);
                            string TO = total + "/" + outof;
                            // await DisplayAlert("alert", ""+AverageSc, "ok");
                            string test = "Test No-1";
                            TestDetail details = new TestDetail
                            {
                                TestName = tableName,
                                SectionAs = Ascore,
                                SectionBs = Bscore,
                                SectionCs = Cscore,
                                SectionDs = Dscore
                                       ,
                                AverageTime = AverageTime,
                                AverageScore = AverageSc,
                                Attempts = attempts,
                                TotalScore = TO,
                                ScoreA = score,
                                ScoreB = scoreB
                                       ,
                                ScoreC = scoreC,
                                ScoreD = scoreD,
                                TotalQuestion = totalQuestions,
                                TotalTime = totalTime,
                                Atotal = atotal,
                                Btotal = btotal,
                                Ctotal = ctotal,
                                Dtotal = dtotal
                            };
                            int Prevallscore = at + bt + ct;
                            int Currallscore = score + scoreB + scoreC;
                            //if (Prevallscore > Currallscore)
                            //{
                            //   await DisplayAlert("Etest", "Bad Performance then Before!", "OK");
                            //}
                            //else
                            //{
                            //    await DisplayAlert("Etest", "Better Performance then Bofore!", "OK");
                            //}

                            dbConn2.InsertAsync(details);
                            double averagea = score + A;
                            double AvergScoreA = averagea / tapped;
                            string AA = AvergScoreA + "/" + atotal;

                            double averageb = scoreB + B;
                            double AvergScoreB = averageb / tapped;
                            string BA = AvergScoreB + "/" + btotal;

                            double averagec = scoreC + C;
                            double AvergScoreC = averagec / tapped;
                            string CA = AvergScoreC + "/" + ctotal;


                            //await dbConn3.UpdateAsync();
                            //DisplayAlert("message", ""+total+"/"+outof, "ok");
                            //await dbConn3.QueryAsync<DashBoardListview>("INSERT INTO TestDetail(TestName,SectionAs,SectionBs,SectionCs,AverageTime,AverageScore," +
                            //    "Attempts,TotalScore,ScoreA,ScoreB,ScoreC,TotalQuestion,TotalTime,Atotal,Btotal,Ctotal) VALUES(\"" + tableName + "\",\""
                            //    + Ascore + "\",\"" + Bscore + "\",\"" + Cscore + "\"," +
                            //    "\"" + AverageTime + "\",\"" + AverageSc + "\",\"" + attempts + "\",\"" + TO + "\",\"" + score + "\",\"" +
                            //    scoreB + "\",\"" + scoreC + "\",\"" + totalQuestions + "\",\"" + totalTime + "\",\"" + atotal + "\",\"" + btotal + "\",\"" + ctotal + "\")");
                            // dbConn.QueryAsync<TestDetails>("insert into TestDetail(TestName) values(\"" + tableName + "\")");
                            dbConn.QueryAsync<TestScore>("UPDATE Test_score SET SectionA=\"" + Ascore + "\",SectionB=\"" + Bscore + "\",SectionC=\"" + Cscore + "\",OutOF=\"" + TO + "\",Numbertapped=\"" + tapped + "\",OutofC=\"" + total + "\",OutofB=\"" + outof + "\" WHERE Tests=\"" + tableName + "\"");
                            dbConn3.QueryAsync<DashBoardListview>("UPDATE DashBoardListview SET AScore=\"" + string.Format("{0:F2}", AA) + "\", BScore = \"" + string.Format("{0:F2}", BA) + "\", CScore = \"" + string.Format("{0:F2}", CA) + "\", Atotal =\"" + score + "\",Btotal = \"" + scoreB + "\", Ctotal =\"" + scoreC + "\", AverageScore = \"" + AverageSc + "\", Attempts =\"" + tapped + "\", A = \"" + averagea + "\", B = \"" + averageb + "\", C = \"" + averagec + "\",TimeTaken=\"" + AverageTime + "\" WHERE TestName = \"" + tableName + "\"");



                            // dbConn.GetConnection().Close();

                            //DisplayAlert("", "End Test Successfully at " + mins + ":" + counter, "ok");
                            isTimerCancel = 1;
                            int previousScore = testScore[0].OutofC;
                            if (previousScore < total)
                            {
                                Performance.Text = "Better Performance then Before";

                            }
                            else
                            {
                                Performance.Text = "Bad Performance then Before";
                            }
                            TotaLScore.Text = "Current Score :" + total + "/" + list.Count;
                            PreviousScore.Text = "Previous Score :" + previousScore + "/" + list.Count;
                            // DisplayAlert("", "" + mins + ":" + counter, "");
                            //MyListView.ItemsSource = list;
                            //TotaLScore.Text = "Total Score :" + total + "/" + list.Count;
                            slQuestion.IsVisible = false;
                            quizStack.IsVisible = false;
                            frameStack.IsVisible = true;
                            TotaLScore.Text = "Total Score :" + total + "/" + list.Count;
                            MyListView.ItemsSource = list;
                        }


                            questionNumber = list.IndexOf(currentQuestion);


                        }


                    }
                    else
                    {

                        
                        centerFram1.BackgroundColor = Color.White;
                        centerFram2.BackgroundColor = Color.White;
                        centerFram3.BackgroundColor = Color.White;
                        centerFram4.BackgroundColor = Color.White;

                    for (int i = 0; i < list.Count; i++)
                    {
                        list[i].FrameBackGroundColor = "#039be5";
                    }

                    if (prevCounter + 1 < questionCountTotal)
                        {

                            if (prevCounter >= 0)
                            {

                                int indexx = prevCounter;
                                prevCounter++;
                            list[prevCounter].FrameBackGroundColor = "#01579B";
                            LIST.ItemsSource = null;
                            LIST.ItemsSource = list;
                            if (prevCounter + 1 < questionCountTotal)
                                {
                                    currentQuestion = list[prevCounter];

                                //if (currentQuestion.Sections.Contains("A"))
                                //{
                                //    lblquestionNo.Text = "Question No" + currentQuestion.ID + ":                                       Section:" + currentQuestion.Sections + "(" + a + "/" + sectionAcount + ")";
                                //    //if (a != sectionAcount)
                                //    //{
                                //        a++;
                                //    //}
                                //}
                                //else if (currentQuestion.Sections.Contains("B"))
                                //{
                                //    lblquestionNo.Text = "Question No" + currentQuestion.ID + ":                                         Section:" + currentQuestion.Sections + "(" + b + "/" + sectionBcount + ")";
                                //    if (b != sectionBcount)
                                //    {
                                //        b++;
                                //    }
                                //}
                                //else if (currentQuestion.Sections.Contains("C"))
                                //{
                                //    lblquestionNo.Text = "Question No" + currentQuestion.ID + ":                                           Section:" + currentQuestion.Sections + "(" + c + "/" + sectionCcount + ")";
                                //    c++;
                                //}
                                //if (prevCounter < sectionA.Count)
                                //{
                                //    if (list[prevCounter].Sections.Contains("A"))
                                //    {

                                //        Questions prevQuestion = sectionA[prevCounter];
                                //        //a--;
                                //        int sectionc = sectionA.IndexOf(prevQuestion) + 1;
                                //        acount = sectionAcount - 1;
                                //        lblquestionNo.Text = "Question No" + currentQuestion.ID + ":                                        Section:" + currentQuestion.Sections + "(" + sectionc + "/" + sectionAcount + ")";
                                //        //if (sectionc == 1)
                                //        //{
                                //        //    a++;
                                //        //}
                                //    }
                                //}
                                //else
                                //{

                                //    //else if (list[prevCounter].Sections.Contains("B"))
                                //    //{

                                //    int b = prevCounter - sectionB.Count + 1;
                                //    //Questions prevQuestion = sectionB[prevCounter];
                                //    //a--;
                                //    //int sectionb = sectionB.IndexOf(prevQuestion) + 1-sectionB.Count;
                                //    acount = sectionAcount - 1;
                                //    lblquestionNo.Text = "Question No" + currentQuestion.ID + ":                                        Section:" + currentQuestion.Sections + "(" + b + "/" + sectionAcount + ")";

                                //    //}
                                //}
                                if (list[prevCounter].Sections.Contains("PHYSICS"))
                                {

                                    //Questions prevQuestion = sectionA[prevCounter];
                                    ////a--;
                                    //int sectionc = sectionA.IndexOf(prevQuestion) + 1;
                                    //acount = sectionAcount - 1;
                                    lblquestionNo.Text = "Question No" + currentQuestion.ID;
                                    lblsectionNo.Text = "Section:  " + currentQuestion.Sections + "  (" + currentQuestion.SectionNO + "/" + sectionAcount + ")";
                                    //if (sectionc == 1)
                                    //{
                                    //    a++;
                                    //}
                                    //DisplayAlert("MS", "" + prevCounter, "OK");
                                    // }

                                }
                                else if (list[prevCounter].Sections.Contains("CHEMISTRY"))
                                {

                                    //else if (list[prevCounter].Sections.Contains("B"))
                                    //{

                                    if (sectionB.Count <= 2)
                                    {
                                        // DisplayAlert("INDEX", "" + sectionB.Count, "OK");
                                        int j1 = prevCounter - (sectionBcount + 1);
                                        Questions PopQuestion1 = sectionB[j1];
                                        int i = sectionB.IndexOf(PopQuestion1) + 1;
                                        lblquestionNo.Text = "Question No" + currentQuestion.ID;
                                        lblsectionNo.Text = "Section:  " + currentQuestion.Sections + "  (" + currentQuestion.SectionNO + "/" + sectionB.Count + ")";
                                    }
                                    else
                                    {
                                        //int j = prevCounter - sectionBcount;
                                        ////DisplayAlert("sectionB", "" + sectionB.Count, "ok");
                                        //Questions PopQuestion2 = sectionB[j];
                                        ////j++;
                                        //int i23 = sectionB.IndexOf(PopQuestion2) + 1;
                                        lblquestionNo.Text = "Question No" + currentQuestion.ID;
                                        lblsectionNo.Text = "Section:  " + currentQuestion.Sections + "  (" + currentQuestion.SectionNO + "/" + sectionB.Count + ")";
                                    }

                                    //}
                                }
                                else if (currentQuestion.Sections.Contains("ENGLISH"))
                                {
                                    lblquestionNo.Text = "Question No" + currentQuestion.ID;
                                    lblsectionNo.Text = "Section:  " + currentQuestion.Sections + "  (" + currentQuestion.SectionNO + "/" + sectionCcount + ")";
                                    c++;
                                }
                                else if (currentQuestion.Sections.Contains("BIOLOGY"))
                                {
                                    lblquestionNo.Text = "Question No" + currentQuestion.ID;
                                    lblsectionNo.Text = "Section:  " + currentQuestion.Sections + "  (" + currentQuestion.SectionNO + "/" + Biology.Count + ")";
                                }
                                var target = list[prevCounter];
                                LIST.ScrollTo(target, ScrollToPosition.Start, true);
                                lblQuestion.Text = currentQuestion.Question;

                                    Option1.Text = currentQuestion.A;
                                    Option2.Text = currentQuestion.B;
                                    Option3.Text = currentQuestion.C;
                                    Option4.Text = currentQuestion.D;
                                    if (currentQuestion.Filepath != null)
                                    {

                                        //string icon_path = new Uri(currentQuestion.Filepath).LocalPath;
                                        img.Source = ImageSource.FromFile(currentQuestion.Filepath);
                                    }
                                   
                                    if (list[prevCounter].SeclectedButtonA != null && list[prevCounter].SeclectedButtonA.Contains("#0000FF"))
                                    {
                                        centerFram1.BackgroundColor = Color.FromHex("#039be5");
                                    centerFram3.BackgroundColor = Color.White;
                                        centerFram2.BackgroundColor = Color.White;
                                        centerFram4.BackgroundColor = Color.White;


                                    }
                                    else if (list[prevCounter].SeclectedButtonC != null && list[prevCounter].SeclectedButtonB.Contains("#0000FF"))
                                    {
                                        centerFram2.BackgroundColor = Color.FromHex("#039be5");
                                        centerFram3.BackgroundColor = Color.White;
                                        centerFram4.BackgroundColor = Color.White;
                                        centerFram1.BackgroundColor = Color.White;

                                    }
                                    else if (list[prevCounter].SeclectedButtonC != null && list[prevCounter].SeclectedButtonC.Contains("#0000FF"))
                                    {
                                        centerFram3.BackgroundColor = Color.FromHex("#039be5");
                                    centerFram4.BackgroundColor = Color.White;
                                        centerFram2.BackgroundColor = Color.White;
                                        centerFram1.BackgroundColor = Color.White;

                                    }
                                    else if (list[prevCounter].SeclectedButtonD != null && list[prevCounter].SeclectedButtonD.Contains("#0000FF"))
                                    {
                                        centerFram4.BackgroundColor = Color.FromHex("#039be5");
                                    centerFram3.BackgroundColor = Color.White;
                                        centerFram2.BackgroundColor = Color.White;
                                        centerFram1.BackgroundColor = Color.White;

                                    }
                                    else
                                    {
                                        centerFram4.BackgroundColor = Color.White;
                                        centerFram3.BackgroundColor = Color.White;
                                        centerFram2.BackgroundColor = Color.White;
                                        centerFram1.BackgroundColor = Color.White;

                                    }

                                }
                                else if (prevCounter + 1 == questionCountTotal)
                                {
                                    //button.Text = "Finish";
                                    //var target = list[prevCounter];
                                    //LIST.ScrollTo(target, ScrollToPosition.Start, true);
                                    currentQuestion = list[prevCounter];
                                    list[prevCounter].FrameBackGroundColor = "#01579B";
                                //if (currentQuestion.Sections.Contains("A"))
                                //{
                                //    lblquestionNo.Text = "Question No" + currentQuestion.ID + ":                                          Section:" + currentQuestion.Sections + "(" + a + "/" + sectionAcount + ")";
                                //    //if (a != sectionAcount)
                                //    //{
                                //        a++;
                                //    //}
                                //}
                                //else if (currentQuestion.Sections.Contains("B"))
                                //{
                                //    lblquestionNo.Text = "Question No" + currentQuestion.ID + ":                                           Section:" + currentQuestion.Sections + "(" + b + "/" + sectionBcount + ")";
                                //    if (b != sectionBcount)
                                //    {
                                //        b++;
                                //    }
                                //}
                                //else if (currentQuestion.Sections.Contains("C"))
                                //{
                                //    lblquestionNo.Text = "Question No" + currentQuestion.ID + ":                                            Section:" + currentQuestion.Sections + "(" + c + "/" + sectionCcount + ")";
                                //    c++;
                                //}

                                //if (prevCounter < sectionA.Count)
                                //{
                                //    if (list[prevCounter].Sections.Contains("A"))
                                //    {

                                //        Questions prevQuestion = sectionA[prevCounter];
                                //        //a--;
                                //        int sectionc = sectionA.IndexOf(prevQuestion) + 1;
                                //        acount = sectionAcount - 1;
                                //        lblquestionNo.Text = "Question No" + currentQuestion.ID + ":                                        Section:" + currentQuestion.Sections + "(" + sectionc + "/" + sectionAcount + ")";
                                //        //if (sectionc == 1)
                                //        //{
                                //        //    a++;
                                //        //}
                                //    }
                                //}
                                //else
                                //{

                                //    //else if (list[prevCounter].Sections.Contains("B"))
                                //    //{

                                //    int b = prevCounter - sectionB.Count + 1;
                                //    //Questions prevQuestion = sectionB[prevCounter];
                                //    //a--;
                                //    //int sectionb = sectionB.IndexOf(prevQuestion) + 1-sectionB.Count;
                                //    acount = sectionAcount - 1;
                                //    lblquestionNo.Text = "Question No" + currentQuestion.ID + ":                                        Section:" + currentQuestion.Sections + "(" + b + "/" + sectionAcount + ")";

                                //    //}
                                //}
                                if (list[prevCounter].Sections.Contains("PHYSICS"))
                                {

                                    //Questions prevQuestion = sectionA[prevCounter];
                                    ////a--;
                                    //int sectionc = sectionA.IndexOf(prevQuestion) + 1;
                                    //acount = sectionAcount - 1;
                                    lblquestionNo.Text = "Question No" + currentQuestion.ID;
                                    lblsectionNo.Text = "Section:  " + currentQuestion.Sections + "  (" + currentQuestion.SectionNO + "/" + sectionAcount + ")";
                                    //if (sectionc == 1)
                                    //{
                                    //    a++;
                                    //}
                                    //DisplayAlert("MS", "" + prevCounter, "OK");
                                    // }

                                }
                                else if (list[prevCounter].Sections.Contains("CHEMISTRY"))
                                {

                                    //else if (list[prevCounter].Sections.Contains("B"))
                                    //{

                                    if (sectionB.Count <= 2)
                                    {
                                        // DisplayAlert("INDEX", "" + sectionB.Count, "OK");
                                        int j1 = prevCounter - (sectionBcount + 1);
                                        Questions PopQuestion1 = sectionB[j1];
                                        int i = sectionB.IndexOf(PopQuestion1) + 1;
                                        lblquestionNo.Text = "Question No" + currentQuestion.ID;
                                        lblsectionNo.Text = "Section:  " + currentQuestion.Sections + " (" + currentQuestion.SectionNO + "/" + sectionB.Count + ")";
                                    }
                                    else
                                    {
                                        //int j = prevCounter - sectionBcount;
                                        ////DisplayAlert("sectionB", "" + sectionB.Count, "ok");
                                        //Questions PopQuestion2 = sectionB[j];
                                        ////j++;
                                        //int i23 = sectionB.IndexOf(PopQuestion2) + 1;
                                        lblquestionNo.Text = "Question No" + currentQuestion.ID;
                                        lblsectionNo.Text = "Section:  " + currentQuestion.Sections + "  (" + currentQuestion.SectionNO + "/" + sectionB.Count + ")";
                                    }

                                    //}
                                }
                                else if (currentQuestion.Sections.Contains("ENGLISH"))
                                {
                                    lblquestionNo.Text = "Question No" + currentQuestion.ID;
                                    lblsectionNo.Text = "Section:  " + currentQuestion.Sections + "  (" + currentQuestion.SectionNO + "/" + sectionCcount + ")";
                                    c++;
                                }
                                else if (currentQuestion.Sections.Contains("BIOLOGY"))
                                {
                                    lblquestionNo.Text = "Question No" + currentQuestion.ID;
                                    lblsectionNo.Text = "Section:  " + currentQuestion.Sections + " (" + currentQuestion.SectionNO + "/" + Biology.Count + ")";
                                }
                                lblQuestion.Text = currentQuestion.Question;


                                    Option1.Text = currentQuestion.A;
                                    Option2.Text = currentQuestion.B;
                                    Option3.Text = currentQuestion.C;
                                    Option4.Text = currentQuestion.D;

                                    if (currentQuestion.Filepath != null)
                                    {

                                    //string icon_path = new Uri(currentQuestion.Filepath).LocalPath;
                                         img.Source = ImageSource.FromFile(currentQuestion.Filepath);
                                    }
                                   

                                if (list[prevCounter].SeclectedButtonA != null && list[prevCounter].SeclectedButtonA.Contains("#0000FF"))
                                {
                                    centerFram1.BackgroundColor = Color.FromHex("#039be5");
                                    centerFram3.BackgroundColor = Color.White;
                                    centerFram2.BackgroundColor = Color.White;
                                    centerFram4.BackgroundColor = Color.White;


                                }
                                else if (list[prevCounter].SeclectedButtonC != null && list[prevCounter].SeclectedButtonB.Contains("#0000FF"))
                                {
                                    centerFram2.BackgroundColor = Color.FromHex("#039be5");
                                    centerFram3.BackgroundColor = Color.White;
                                    centerFram4.BackgroundColor = Color.White;
                                    centerFram1.BackgroundColor = Color.White;

                                }
                                else if (list[prevCounter].SeclectedButtonC != null && list[prevCounter].SeclectedButtonC.Contains("#0000FF"))
                                {
                                    centerFram3.BackgroundColor = Color.FromHex("#039be5");
                                    centerFram4.BackgroundColor = Color.White;
                                    centerFram2.BackgroundColor = Color.White;
                                    centerFram1.BackgroundColor = Color.White;

                                }
                                else if (list[prevCounter].SeclectedButtonD != null && list[prevCounter].SeclectedButtonD.Contains("#0000FF"))
                                {
                                    centerFram4.BackgroundColor = Color.FromHex("#039be5");
                                    centerFram3.BackgroundColor = Color.White;
                                    centerFram2.BackgroundColor = Color.White;
                                    centerFram1.BackgroundColor = Color.White;

                                }
                                else
                                {
                                    centerFram4.BackgroundColor = Color.White;
                                    centerFram3.BackgroundColor = Color.White;
                                    centerFram2.BackgroundColor = Color.White;
                                    centerFram1.BackgroundColor = Color.White;

                                }
                                int cou = prevCounter + 1;
                                answered = true;
                                //prevCounter++;
                                //QuestionCount.Text = "Question: " + cou + "/" + questionCountTotal;
                                
                            }
                            
                            //     else
                            //     {
                            //    slQuestion.IsVisible = false;
                            //    quizStack.IsVisible = false;
                            //    frameStack.IsVisible = true;
                            //    TotaLScore.Text = "TotaLScore :" + score + "/" + questionCountTotal;
                            //    int outof = list.Count;
                            //    int tapped = tstscore.Numbertapped + 1;

                            //    dbConn.QueryAsync<TestScore>("UPDATE Test_score SET Score =\"" + score + "\",OutOF=\"" + outof + "\",Numbertapped=\"" + tapped + "\",TestName=\"" + tableName + "\" WHERE Tests =\"" + section + "\"");
                            //    MyListView.ItemsSource = list;
                            //}
                           
                            }

                        }
                    

                }

                }
            else
            {
                
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        var result = await this.DisplayAlert("e-Test", "Are You Sure to Exit Test?", "Yes", "No");
                        if (result)
                        {
                            for (int i = 0; i < list.Count; i++)
                            {
                                if (list[i].TextColorA != null && list[i].TextColorB != null
                             && list[i].TextColorC != null && list[i].TextColorD != null &&
                            list[i].TextColorA.Contains("#00FF00") && list[i].TextColorB.Contains("#000000")
                             && list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#000000"))
                                {
                                    if (list[i].Sections.Contains("PHYSICS"))
                                    {
                                        score = score + 5;
                                    }
                                    else if (list[i].Sections.Contains("CHEMISTRY"))
                                    {
                                        scoreB = scoreB + 5;
                                    }
                                    else if (list[i].Sections.Contains("ENGLISH"))
                                    {
                                        scoreC = scoreC + 5;
                                    }
                                    else if (list[i].Sections.Contains("BIOLOGY"))
                                    {
                                        scoreD = scoreD + 5;
                                    }
                                }
                                else if (list[i].TextColorA != null && list[i].TextColorB != null
                                     && list[i].TextColorC != null && list[i].TextColorD != null &&
                                    list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#00FF00")
                                     && list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#000000"))
                                {
                                    if (list[i].Sections.Contains("PHYSICS"))
                                    {
                                        score = score + 5;
                                    }
                                    else if (list[i].Sections.Contains("CHEMISTRY"))
                                    {
                                        scoreB = scoreB + 5;
                                    }
                                    else if (list[i].Sections.Contains("ENGLISH"))
                                    {
                                        scoreC = scoreC + 5;
                                    }
                                    else if (list[i].Sections.Contains("BIOLOGY"))
                                    {
                                        scoreD = scoreD + 5;
                                    }
                                }
                                else if (list[i].TextColorA != null && list[i].TextColorB != null
                                     && list[i].TextColorC != null && list[i].TextColorD != null &&
                                    list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#000000")
                                     && list[i].TextColorC.Contains("#00FF00") && list[i].TextColorD.Contains("#000000"))
                                {
                                    if (list[i].Sections.Contains("PHYSICS"))
                                    {
                                        score = score + 5;
                                    }
                                    else if (list[i].Sections.Contains("CHEMISTRY"))
                                    {
                                        scoreB = scoreB + 5;
                                    }
                                    else if (list[i].Sections.Contains("ENGLISH"))
                                    {
                                        scoreC = scoreC + 5;
                                    }
                                    else if (list[i].Sections.Contains("BIOLOGY"))
                                    {
                                        scoreD = scoreD + 5;
                                    }
                                }
                                else if (list[i].TextColorA != null && list[i].TextColorB != null
                                     && list[i].TextColorC != null && list[i].TextColorD != null &&
                                    list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#000000")
                                     && list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#00FF00"))
                                {
                                    if (list[i].Sections.Contains("PHYSICS"))
                                    {
                                        score=score+5;
                                    }
                                    else if (list[i].Sections.Contains("CHEMISTRY"))
                                    {
                                        scoreB=scoreB+5;
                                    }
                                    else if (list[i].Sections.Contains("ENGLISH"))
                                    {
                                        scoreC=scoreC+5;
                                    }
                                    else if (list[i].Sections.Contains("BIOLOGY"))
                                    {
                                        scoreD=scoreD+5;
                                    }
                                }
                                else
                                {
                                    score = score + 0;
                                    scoreB = scoreB + 0;
                                    scoreC = scoreC + 0;
                                    scoreD = scoreD + 0;
                                }

                                

                              
                            }
                            int a = 0;
                            int b = 0;
                            int c = 0;
                            int d = 0;
                            for (int i = 0; i < list.Count; i++)
                            {
                                if (list[i].TextColorA != null && list[i].TextColorB != null
                             && list[i].TextColorC != null && list[i].TextColorD != null &&
                                list[i].TextColorA.Contains("#00FF00") && list[i].TextColorB.Contains("#0000ff") &&
                                    list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#000000")
                                    )
                                {

                                    //||
                                    //list[i].TextColorA.Contains("#00FF00") && list[i].TextColorB.Contains("#000000") &&
                                    //list[i].TextColorC.Contains("#0000ff") && list[i].TextColorD.Contains("#000000") ||
                                    //list[i].TextColorA.Contains("#00FF00") && list[i].TextColorB.Contains("#000000") &&
                                    //list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#0000ff")


                                    if (list[i].Sections.Contains("PHYSICS"))
                                    {
                                        //score = score - 6;
                                        a++;
                                    }
                                    else if (list[i].Sections.Contains("CHEMISTRY"))
                                    {
                                        //scoreB = scoreB - 6;
                                        b++;
                                    }
                                    else if (list[i].Sections.Contains("ENGLISH"))
                                    {
                                        //scoreC = scoreC - 6;
                                        c++;
                                    }
                                    else if (list[i].Sections.Contains("BIOLOGY"))
                                    {
                                        //scoreD = scoreD - 6;
                                        d++;
                                    }
                                }
                                else if (list[i].TextColorA != null && list[i].TextColorB != null
                             && list[i].TextColorC != null && list[i].TextColorD != null &&
                                list[i].TextColorA.Contains("#00FF00") && list[i].TextColorB.Contains("#000000") &&
                                   list[i].TextColorC.Contains("#0000ff") && list[i].TextColorD.Contains("#000000")
                                   )
                                {
                                    // ||
                                    //list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#00FF00") &&
                                    //list[i].TextColorC.Contains("#0000ff") && list[i].TextColorD.Contains("#000000") ||
                                    //list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#00FF00") &&
                                    //list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#0000ff")

                                    if (list[i].Sections.Contains("PHYSICS"))
                                    {
                                        //score = score - 6;
                                        a++;
                                    }
                                    else if (list[i].Sections.Contains("CHEMISTRY"))
                                    {
                                        //scoreB = scoreB - 6;
                                        b++;
                                    }
                                    else if (list[i].Sections.Contains("ENGLISH"))
                                    {
                                        //scoreC = scoreC - 6;
                                        c++;
                                    }
                                    else if (list[i].Sections.Contains("BIOLOGY"))
                                    {
                                        //scoreD = scoreD - 6;
                                        d++;
                                    }
                                }
                                else if (list[i].TextColorA != null && list[i].TextColorB != null
                             && list[i].TextColorC != null && list[i].TextColorD != null &&
                                list[i].TextColorA.Contains("#00FF00") && list[i].TextColorB.Contains("#000000") &&
                                  list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#0000ff")
                                  )
                                {

                                    //  ||
                                    //list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#0000ff") &&
                                    //list[i].TextColorC.Contains("#00FF00") && list[i].TextColorD.Contains("#000000") ||
                                    //list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#000000") &&
                                    //list[i].TextColorC.Contains("#00FF00") && list[i].TextColorD.Contains("#0000ff")

                                    if (list[i].Sections.Contains("PHYSICS"))
                                    {
                                        //score = score - 6;
                                        a++;
                                    }
                                    else if (list[i].Sections.Contains("CHEMISTRY"))
                                    {
                                        //scoreB = scoreB - 6;
                                        b++;
                                    }
                                    else if (list[i].Sections.Contains("ENGLISH"))
                                    {
                                        //scoreC = scoreC - 6;
                                        c++;
                                    }
                                    else if (list[i].Sections.Contains("BIOLOGY"))
                                    {
                                        //scoreD = scoreD - 6;
                                        d++;
                                    }
                                }
                                else if (list[i].TextColorA != null && list[i].TextColorB != null
                             && list[i].TextColorC != null && list[i].TextColorD != null &&
                                list[i].TextColorA.Contains("#0000ff") && list[i].TextColorB.Contains("#00FF00") &&
                                 list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#000000")
                                 )
                                {
                                    //   ||
                                    //list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#0000ff") &&
                                    //list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#00FF00") ||
                                    //list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#000000") &&
                                    //list[i].TextColorC.Contains("#0000ff") && list[i].TextColorD.Contains("#00FF00")

                                    if (list[i].Sections.Contains("PHYSICS"))
                                    {
                                        //score = score - 6;
                                        a++;
                                    }
                                    else if (list[i].Sections.Contains("CHEMISTRY"))
                                    {
                                        //scoreB = scoreB - 6;
                                        b++;
                                    }
                                    else if (list[i].Sections.Contains("ENGLISH"))
                                    {
                                        //scoreC = scoreC - 6;
                                        c++;
                                    }
                                    else if (list[i].Sections.Contains("BIOLOGY"))
                                    {
                                        //scoreD = scoreD - 6;
                                        d++;
                                    }
                                }
                                else if (list[i].TextColorA != null && list[i].TextColorB != null
                            && list[i].TextColorC != null && list[i].TextColorD != null &&
                               list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#00FF00") &&
                                list[i].TextColorC.Contains("#0000ff") && list[i].TextColorD.Contains("#000000"))
                                {
                                    if (list[i].Sections.Contains("PHYSICS"))
                                    {
                                        //score = score - 6;
                                        a++;
                                    }
                                    else if (list[i].Sections.Contains("CHEMISTRY"))
                                    {
                                        //scoreB = scoreB - 6;
                                        b++;
                                    }
                                    else if (list[i].Sections.Contains("ENGLISH"))
                                    {
                                        //scoreC = scoreC - 6;
                                        c++;
                                    }
                                    else if (list[i].Sections.Contains("BIOLOGY"))
                                    {
                                        //scoreD = scoreD - 6;
                                        d++;
                                    }
                                }
                                else if (list[i].TextColorA != null && list[i].TextColorB != null
                            && list[i].TextColorC != null && list[i].TextColorD != null &&
                               list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#00FF00") &&
                                list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#0000ff"))
                                {
                                    if (list[i].Sections.Contains("PHYSICS"))
                                    {
                                        //score = score - 6;
                                        a++;
                                    }
                                    else if (list[i].Sections.Contains("CHEMISTRY"))
                                    {
                                        //scoreB = scoreB - 6;
                                        b++;
                                    }
                                    else if (list[i].Sections.Contains("ENGLISH"))
                                    {
                                        //scoreC = scoreC - 6;
                                        c++;
                                    }
                                    else if (list[i].Sections.Contains("BIOLOGY"))
                                    {
                                        //scoreD = scoreD - 6;
                                        d++;
                                    }
                                }
                                else if (list[i].TextColorA != null && list[i].TextColorB != null
                           && list[i].TextColorC != null && list[i].TextColorD != null &&
                              list[i].TextColorA.Contains("#0000ff") && list[i].TextColorB.Contains("#000000") &&
                               list[i].TextColorC.Contains("#00FF00") && list[i].TextColorD.Contains("#000000"))
                                {
                                    if (list[i].Sections.Contains("PHYSICS"))
                                    {
                                        //score = score - 6;
                                        a++;
                                    }
                                    else if (list[i].Sections.Contains("CHEMISTRY"))
                                    {
                                        //scoreB = scoreB - 6;
                                        b++;
                                    }
                                    else if (list[i].Sections.Contains("ENGLISH"))
                                    {
                                        //scoreC = scoreC - 6;
                                        c++;
                                    }
                                    else if (list[i].Sections.Contains("BIOLOGY"))
                                    {
                                        //scoreD = scoreD - 6;
                                        d++;
                                    }
                                }
                                else if (list[i].TextColorA != null && list[i].TextColorB != null
                         && list[i].TextColorC != null && list[i].TextColorD != null &&
                            list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#0000ff") &&
                             list[i].TextColorC.Contains("#00FF00") && list[i].TextColorD.Contains("#000000"))
                                {
                                    if (list[i].Sections.Contains("PHYSICS"))
                                    {
                                        //score = score - 6;
                                        a++;
                                    }
                                    else if (list[i].Sections.Contains("CHEMISTRY"))
                                    {
                                        //scoreB = scoreB - 6;
                                        b++;
                                    }
                                    else if (list[i].Sections.Contains("ENGLISH"))
                                    {
                                        //scoreC = scoreC - 6;
                                        c++;
                                    }
                                    else if (list[i].Sections.Contains("BIOLOGY"))
                                    {
                                        //scoreD = scoreD - 6;
                                        d++;
                                    }
                                }
                                else if (list[i].TextColorA != null && list[i].TextColorB != null
                         && list[i].TextColorC != null && list[i].TextColorD != null &&
                            list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#000000") &&
                             list[i].TextColorC.Contains("#00FF00") && list[i].TextColorD.Contains("#0000ff"))
                                {
                                    if (list[i].Sections.Contains("PHYSICS"))
                                    {
                                        //score = score - 6;
                                        a++;
                                    }
                                    else if (list[i].Sections.Contains("CHEMISTRY"))
                                    {
                                        //scoreB = scoreB - 6;
                                        b++;
                                    }
                                    else if (list[i].Sections.Contains("ENGLISH"))
                                    {
                                        //scoreC = scoreC - 6;
                                        c++;
                                    }
                                    else if (list[i].Sections.Contains("BIOLOGY"))
                                    {
                                        //scoreD = scoreD - 6;
                                        d++;
                                    }
                                }
                                else if (list[i].TextColorA != null && list[i].TextColorB != null
                         && list[i].TextColorC != null && list[i].TextColorD != null &&
                            list[i].TextColorA.Contains("#0000ff") && list[i].TextColorB.Contains("#000000") &&
                             list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#00FF00"))
                                {
                                    if (list[i].Sections.Contains("PHYSICS"))
                                    {
                                        //score = score - 6;
                                        a++;
                                    }
                                    else if (list[i].Sections.Contains("CHEMISTRY"))
                                    {
                                        //scoreB = scoreB - 6;
                                        b++;
                                    }
                                    else if (list[i].Sections.Contains("ENGLISH"))
                                    {
                                        //scoreC = scoreC - 6;
                                        c++;
                                    }
                                    else if (list[i].Sections.Contains("BIOLOGY"))
                                    {
                                        //scoreD = scoreD - 6;
                                        d++;
                                    }
                                }
                                else if (list[i].TextColorA != null && list[i].TextColorB != null
                        && list[i].TextColorC != null && list[i].TextColorD != null &&
                           list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#0000ff") &&
                            list[i].TextColorC.Contains("#000000") && list[i].TextColorD.Contains("#00FF00"))
                                {
                                    if (list[i].Sections.Contains("PHYSICS"))
                                    {
                                        //score = score - 6;
                                        a++;
                                    }
                                    else if (list[i].Sections.Contains("CHEMISTRY"))
                                    {
                                        //scoreB = scoreB - 6;
                                        b++;
                                    }
                                    else if (list[i].Sections.Contains("ENGLISH"))
                                    {
                                        //scoreC = scoreC - 6;
                                        c++;
                                    }
                                    else if (list[i].Sections.Contains("BIOLOGY"))
                                    {
                                        //scoreD = scoreD - 6;
                                        d++;
                                    }
                                }
                                else if (list[i].TextColorA != null && list[i].TextColorB != null
                        && list[i].TextColorC != null && list[i].TextColorD != null &&
                           list[i].TextColorA.Contains("#000000") && list[i].TextColorB.Contains("#000000") &&
                            list[i].TextColorC.Contains("#0000ff") && list[i].TextColorD.Contains("#00FF00"))
                                {
                                    if (list[i].Sections.Contains("PHYSICS"))
                                    {
                                        //score = score - 6;
                                        a++;
                                    }
                                    else if (list[i].Sections.Contains("CHEMISTRY"))
                                    {
                                        //scoreB = scoreB - 6;
                                        b++;
                                    }
                                    else if (list[i].Sections.Contains("ENGLISH"))
                                    {
                                        //scoreC = scoreC - 6;
                                        c++;
                                    }
                                    else if (list[i].Sections.Contains("BIOLOGY"))
                                    {
                                        //scoreD = scoreD - 6;
                                        d++;
                                    }
                                }
                                else
                                {
                                    score = score - 0;
                                    scoreB = scoreB - 0;
                                    scoreC = scoreC - 0;
                                    scoreD = scoreD - 0;
                                }
                            }
                            //await DisplayAlert("mesage", "a="+a+" b="+b+" c="+c+" d="+d, "ok");
                            int aS = a * 6;
                            int bS = b * 6;
                            int cS = c * 6;
                            int dS = d * 6;

                            score = score - aS;
                            scoreB = scoreB - bS;
                            scoreC = scoreC - cS;
                            scoreD = scoreD - dS;


                            string totalQuestions = (list.Count) + " Questions";
                            string totalTime = (list.Count) + " miniutes";
                            int tapped = tstscore + 1;
                            int outof = list.Count;
                            string Ascore = (score + "/" + (sectionA.Count)*5).ToString();
                            string Bscore = (scoreB + "/" + (sectionB.Count)*5).ToString();
                            string Cscore = (scoreC + "/" + (sectionC.Count)*5).ToString();
                            string Dscore = (scoreD + "/" + (Biology.Count)*5).ToString();
                            // DisplayAlert("MESSAGE", "" + Ascore, "OK");
                            //string AverageTime =CountDown.Text.ToString();
                            string AverageTime = string.Format("{0:00}:{1:00}", totalmin, totolsec);
                            string attempts = tapped.ToString();

                            int atotal = (sectionA.Count)*5;
                            int btotal = (sectionB.Count)*5;
                            int ctotal = (sectionC.Count)*5;
                            int dtotal = (Biology.Count)*5;

                            //DisplayAlert("ALERT", "Average Time" + AverageTime, "OK");
                            int totaloutof = list.Count;
                            double total = score + scoreB + scoreC + scoreD;
                            double averagescore = (total / 4);

                            //await DisplayAlert("averagescore", ""+averagescore.ToString("0.00"), "ok");
                            //averagescore = Math.Floor(averagescore * 100) / 100;
                            string AverageSc = string.Format("{0:F2}", averagescore);
                            string TO = total + "/" + outof;
                            // await DisplayAlert("alert", ""+AverageSc, "ok");
                            string test = "Test No-1";
                            TestDetail details = new TestDetail
                            {
                                TestName = tableName,
                                SectionAs = Ascore,
                                SectionBs = Bscore,
                                SectionCs = Cscore,
                                SectionDs = Dscore
                                       ,
                                AverageTime = AverageTime,
                                AverageScore = AverageSc,
                                Attempts = attempts,
                                TotalScore = TO,
                                ScoreA = score,
                                ScoreB = scoreB
                                       ,
                                ScoreC = scoreC,
                                ScoreD = scoreD,
                                TotalQuestion = totalQuestions,
                                TotalTime = totalTime,
                                Atotal = atotal,
                                Btotal = btotal,
                                Ctotal = ctotal,
                                Dtotal = dtotal
                            };
                            int Prevallscore = at + bt + ct;
                            int Currallscore = score + scoreB + scoreC;
                            //if (Prevallscore > Currallscore)
                            //{
                            //   await DisplayAlert("Etest", "Bad Performance then Before!", "OK");
                            //}
                            //else
                            //{
                            //    await DisplayAlert("Etest", "Better Performance then Bofore!", "OK");
                            //}

                            await dbConn2.InsertAsync(details);
                            double averagea = score + A;
                            double AvergScoreA = averagea / tapped;
                            string AA = AvergScoreA + "/" + atotal;

                            double averageb = scoreB + B;
                            double AvergScoreB = averageb / tapped;
                            string BA = AvergScoreB + "/" + btotal;

                            double averagec = scoreC + C;
                            double AvergScoreC = averagec / tapped;
                            string CA = AvergScoreC + "/" + ctotal;


                            //await dbConn3.UpdateAsync();
                            //DisplayAlert("message", ""+total+"/"+outof, "ok");
                            //await dbConn3.QueryAsync<DashBoardListview>("INSERT INTO TestDetail(TestName,SectionAs,SectionBs,SectionCs,AverageTime,AverageScore," +
                            //    "Attempts,TotalScore,ScoreA,ScoreB,ScoreC,TotalQuestion,TotalTime,Atotal,Btotal,Ctotal) VALUES(\"" + tableName + "\",\""
                            //    + Ascore + "\",\"" + Bscore + "\",\"" + Cscore + "\"," +
                            //    "\"" + AverageTime + "\",\"" + AverageSc + "\",\"" + attempts + "\",\"" + TO + "\",\"" + score + "\",\"" +
                            //    scoreB + "\",\"" + scoreC + "\",\"" + totalQuestions + "\",\"" + totalTime + "\",\"" + atotal + "\",\"" + btotal + "\",\"" + ctotal + "\")");
                            // dbConn.QueryAsync<TestDetails>("insert into TestDetail(TestName) values(\"" + tableName + "\")");
                            await dbConn.QueryAsync<TestScore>("UPDATE Test_score SET SectionA=\"" + Ascore + "\",SectionB=\"" + Bscore + "\",SectionC=\"" + Cscore + "\",OutOF=\"" + TO + "\",Numbertapped=\"" + tapped + "\",OutofC=\"" + total + "\",OutofB=\"" + outof + "\" WHERE Tests=\"" + tableName + "\"");
                            await dbConn3.QueryAsync<DashBoardListview>("UPDATE DashBoardListview SET AScore=\"" + string.Format("{0:F2}", AA) + "\", BScore = \"" + string.Format("{0:F2}", BA) + "\", CScore = \"" + string.Format("{0:F2}", CA) + "\", Atotal =\"" + score + "\",Btotal = \"" + scoreB + "\", Ctotal =\"" + scoreC + "\", AverageScore = \"" + AverageSc + "\", Attempts =\"" + tapped + "\", A = \"" + averagea + "\", B = \"" + averageb + "\", C = \"" + averagec + "\",TimeTaken=\"" + AverageTime + "\" WHERE TestName = \"" + tableName + "\"");



                            // dbConn.GetConnection().Close();

                            //DisplayAlert("", "End Test Successfully at " + mins + ":" + counter, "ok");
                            isTimerCancel = 1;
                            int previousScore = testScore[0].OutofC;
                            if (previousScore < total)
                            {
                                Performance.Text = "Better Performance then Before";

                            }
                            else
                            {
                                Performance.Text = "Bad Performance then Before";
                            }
                            TotaLScore.Text = "Current Score :" + total + "/" + (list.Count)*5;
                            PreviousScore.Text = "Previous Score :" + previousScore + "/" + (list.Count)*5;
                            // DisplayAlert("", "" + mins + ":" + counter, "");
                            //MyListView.ItemsSource = list;
                            //TotaLScore.Text = "Total Score :" + total + "/" + list.Count;
                            slQuestion.IsVisible = false;
                            quizStack.IsVisible = false;
                            frameStack.IsVisible = true;
                            TotaLScore.Text = "Total Score :" + total + "/" + (list.Count)*5;
                            MyListView.ItemsSource = list;
                        }
                        else
                        {
                            answered = false;
                        }
                    });
                

                
            }
            btnfocus = false;
                btn2focus = false;
                btn3focus = false;
                btn4focus = false;
            }
        }
    

    class CheckedToSourceConverter : IValueConverter
    {



       

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is string && (string)value != "")
                return Color.FromHex(value.ToString());
            else
                return Color.White;
        }

        

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
           
                return Color.FromHex(value.ToString());
            
               
        }
    }
    class TextColorToSourceConverter : IValueConverter
    {





        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is string && (string)value != "")
                return Color.FromHex(value.ToString());
            else
                return Color.Black;
        }



        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {

            return Color.FromHex(value.ToString());


        }
    }

}