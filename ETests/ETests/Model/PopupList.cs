using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ETests.Model
{
    public class PopupList : INotifyPropertyChanged
    {
        public string Name { get; set; }
       
        public static bool lastCheck;
        public string BGColor { get; set; }
        public string Myvalue { get; set; }

        private bool check;
        public bool Check
        {
            get { return check; }

            set
            {
                check = value;
                OnPropertyChanged("Check");
                lastCheck = value;
            }
        }






        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
