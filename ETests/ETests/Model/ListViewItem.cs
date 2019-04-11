using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ETests.Model
{
    public class ListViewItem : INotifyPropertyChanged
    {
        public string Tests { get; set; }

        public string Score { get; set; }

        public string Numbertapped { get; set; }

        public ListViewItem SelectedItem { get; set; }

        string stackbackground;
        public string StackBackGround {
            get
            {
                return stackbackground;
            }
            set
            {
                stackbackground = value;
                OnPropertyChanged("StackBackGround");
            } }

        public bool isdisabled;
        public bool IsDisabled
        {
            get
            {
                return isdisabled;
            }
            set
            {
                isdisabled = value;
                OnPropertyChanged("IsDisabled");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
