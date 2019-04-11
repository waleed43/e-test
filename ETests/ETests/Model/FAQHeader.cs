using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ETests.Model
{
    public class FAQHeader:ObservableCollection<FAQListItems>, INotifyPropertyChanged
    {
        public FAQHeader() { }
        public string  Header { get; set; }

        public int Id { get; set; }

        private bool _expanded;
        public bool Expanded
        {
            get { return _expanded; }
            set
            {
                if (_expanded != value)
                {
                    _expanded = value;
                    OnPropertyChanged();
                }
            }
        }
        public int GroupCount { get; set; }

        public string TitleWithItemCount
        {
            get { return string.Format("{0}", Header); }

        }

        public FAQHeader(int Id, string Header,bool expanded = true)
        {
            this.Id = Id;
            this.Header = Header;
            Expanded = expanded;
            
        }

        public static ObservableCollection<FAQHeader> All { set; get; }

        static FAQHeader()
        {
            ObservableCollection<FAQHeader> Groups = new ObservableCollection<FAQHeader>
   { new FAQHeader(1,"About MDCAT?",false){
           new FAQListItems { Question = "MDCAT is an exam mandatory for those who want to get admission in MBBS or BDS in any medical or dental college or university in Punjab Pakistan. It is an abbreviation for “Medical & Dental College Admission Test”. The test is conducted annually, mostly in September while its result announced after one 6-7 days of test."+
"According to previous examinations and experiences of the test takers, the test is based on FSc (Pre-medical) syllabus, having 220 questions total. Questions are divided into four sections; Biology = 88, Physics = 44, Chemistry = 58 and English = 30.Each question carries 5 marks.If the answer of candidate is correct, 5 marks are given, while 1 mark is deducted in case of in-correct answer(Negative marking).There is no mark if a question is un - attempted.Total time for MDCAT test is 150 minutes."
+     "Only those candidates who are domicile holder of Punjab and obtained 60 % marks in their intermediate or equivalent are eligible to appear in UHS MDCAT.Those who possess a domicile of Islamabad Capital Territory, Gilgit Baltistan, Overseas, Foreign and dual nationality holder who didn’t pass SAT - II are also eligible to appear in UHS test.For details about eligibility UHS Punjab may be contacted(http://www.uhs.edu.pk/)"
+     "The merit is formulated based on marks obtained in F.Sc., Secondary School(Matriculation etc.) and MDCAT marks.For further details relevant medical institutions may be contacted."
+    " Formula for calculating merit is given below:"
+"(10 % of Matriculation + 40 % of Intermediate + 50 % of MDCAT)/ (1100 x 100)"


                    }
                },
      new FAQHeader(2,"What is e-test?",false){
           new FAQListItems { Question = "e-test is a digital solution for test taking " +
           "and preparation. The e-test pro is built with various" +
           " tests having time binding. The app has a built-in count down timer to simulate the test environment."

                    }
                },

           new FAQHeader(3,"How the tests in e-test are prepared?",false){
           new FAQListItems { Question = "The tests built in e-test pro are prepared" +
           " by experienced academicians and based on questions that frequently appeared in previous papers."

                    }
                },
        new FAQHeader(4,"How to take a test in e-test?",false){
           new FAQListItems { Question = "To take a test; Go to Menu>Attempt test. A list of tests shall appear pertaining to " +
           "the test category already selected during " +
           "registration process. On clicking a test, there shall appear a pop-up to start test. Click “Yes” to start the test."

                    }
                },
        new FAQHeader(5,"What does the graph show on the dashboard?",false){
           new FAQListItems { Question = "The graph on dashboard shows your average score " +
           "(average correct and incorrect percentages), represented as pie chart. "

                    }
                },
        new FAQHeader(6,"How can I find my section wise average scores?",false){
           new FAQListItems { Question = "You can find your section wise average scores in the table on dashboard."

                    }
                },
        new FAQHeader(7,"How can I see my test attempt history?",false){
           new FAQListItems { Question = "To see your test attempt history; Go to Menu>Attempted Tests History"

                    }
                },
        new FAQHeader(8,"How many times I can attempt a test?",false){
           new FAQListItems { Question = "You can attempt a test maximum 20 times."

                    }
                }};
            All = Groups;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
