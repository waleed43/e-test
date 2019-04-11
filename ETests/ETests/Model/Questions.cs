using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ETests.Model
{
   public class Questions : INotifyPropertyChanged
    {
        public string ID { get; set; }

        public string Question { get; set; }

        public string Sections { get; set; }

        public string SectionNO { get; set; }
        string a;
        public string A { get; set; }

        string b;
        public string B { get; set; }

        string c;
        public string C { get; set; }

        string d;
        public string D { get; set; }

        public string Filepath { get; set; }

        public string Answer { get; set; }

        private bool ischecka;
        public bool IsCheckedA {
            get
            {
                return ischecka;
            }
            set
            {
                ischecka = value;
                OnPropertyChanged("IsCheckedA");
            }
        }

        private bool ischeckb;
        public bool IsCheckedB
        {
            get
            {
                return ischeckb;
            }
            set
            {
                ischeckb = value;
                OnPropertyChanged("IsCheckedB");
            }
        }

        private bool ischeckc;
        public bool IsCheckedC
        {
            get
            {
                return ischeckc;
            }
            set
            {
                ischeckc = value;
                OnPropertyChanged("IsCheckedC");
            }
        }

        private bool ischeckd;
        public bool IsCheckedD
        {
            get
            {
                return ischeckd;
            }
            set
            {
                ischeckd = value;
                OnPropertyChanged("IsCheckedD");
            }
        }

        public string frameBackGroundColor;
        public string FrameBackGroundColor
        {
            get
            { return frameBackGroundColor; }
            set
            {
                if (value != null)
                {
                    frameBackGroundColor = value;
                    OnPropertyChanged("FrameBackGroundColor");

                }

            }
        }

        public string slecta;
        public string SeclectedButtonA
        {
            get
            { return slecta; }
            set
            {
                if (value != null)
                {
                    slecta = value;
                    OnPropertyChanged("SeclectedButtonA");

                }
            }
        }
        public string slectb;
        public string SeclectedButtonB
        {
            get
            { return slectb; }
            set
            {
                if (value != null)
                {
                    slectb = value;
                    OnPropertyChanged("SeclectedButtonB");

                }

            }
        }

        public string slectc;
        public string SeclectedButtonC
        {
            get
            { return slectc; }
            set
            {
                if (value != null)
                {
                    slectc = value;
                    OnPropertyChanged("SeclectedButtonC");

                }
            }
        }

        public string slectd;
        public string SeclectedButtonD
        {
            get
            { return slectd; }
            set
            {
                slectd = value;
                OnPropertyChanged("SeclectedButtonD");
            }
        }
        public string textcolorA;
        
        public string TextColorA
        {
            get
            { return textcolorA; }
            set
            {
                textcolorA = value;
                OnPropertyChanged("TextColorA");
            }
        }
        public string textcolorB;
        public string TextColorB
        {
            get
            { return textcolorB; }
            set
            {
                textcolorB = value;
                OnPropertyChanged("TextColorB");
            }
        }
        public string textcolorC;
        public string TextColorC
        {
            get
            { return textcolorC; }
            set
            {
                textcolorC = value;
                OnPropertyChanged("TextColorC");
            }
        }
        public string textcolorD;
        public string TextColorD
        {
            get
            { return textcolorD; }
            set
            {
                textcolorD = value;
                OnPropertyChanged("TextColorD");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        //public string textcolor;
        //public string Textcolor
        //{
        //    get
        //    {
        //        return textcolor;
        //    }
        //    set
        //    {
        //        textcolor = value;
        //    }
        //} 

    }
}
