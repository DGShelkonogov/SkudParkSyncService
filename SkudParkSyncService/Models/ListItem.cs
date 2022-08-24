using System.Collections.Generic;
using System.ComponentModel;

namespace SkudParkSyncService.Models
{
    public class ListItem : INotifyPropertyChanged
    {
        private string _title;
        private string _id;
        private  List<PassagePoint> _items;

        private PassagePoint _passagePoint;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public PassagePoint PassagePoint
        {
            get { return _passagePoint; }
            set
            {
                _passagePoint = value;
                OnPropertyChanged("PassagePoint");
            }
        }

        public List<PassagePoint> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
