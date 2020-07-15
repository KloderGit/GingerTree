using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace GingerTree.UI.Infrastructure
{
    public class TunelProperty<T> : INotifyPropertyChanged 
    {
        private T property;

        public TunelProperty(T value = default)
        {
            property = value;
        }

        public T Value 
        {
            get => property;
            set { property = value; OnPropertyChanged("Value"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
