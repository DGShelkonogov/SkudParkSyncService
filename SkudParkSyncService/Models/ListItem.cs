﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkudParkSyncService.Models
{
    public class ListItem : INotifyPropertyChanged
    {
        string title;
        string id;
        List<PassagePoint> items;

        PassagePoint passagePoint { get; set; }

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public PassagePoint PassagePoint
        {
            get { return passagePoint; }
            set
            {
                passagePoint = value;
                OnPropertyChanged("PassagePoint");
            }
        }

        public List<PassagePoint> Items
        {
            get { return items; }
            set
            {
                items = value;
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
