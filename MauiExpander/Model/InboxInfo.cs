using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiExpander
{
    public class InboxInfo : INotifyPropertyChanged
    {
        private string title;
        private string subject;
        private string desc;
        private string date;
        private bool isExpanded;
        private FontAttributes fontStyle = FontAttributes.Bold;


        public InboxInfo()
        {

        }

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        public string Subject
        {
            get
            {
                return subject;
            }

            set
            {
                subject = value;
                OnPropertyChanged("Subject");
            }
        }

        public string Description
        {
            get
            {
                return desc;
            }

            set
            {
                desc = value;
                OnPropertyChanged("Description");
            }
        }

        public string Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }

        public FontAttributes FontStyle
        {
            get
            {
                return fontStyle;
            }
            set
            {
                fontStyle = value;
                OnPropertyChanged("FontStyle");
            }
        }

        public bool IsExpanded
        {
            get
            {
                return isExpanded;
            }
            set
            {
                isExpanded = value;
                OnPropertyChanged("IsExpanded");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        
    }
}
