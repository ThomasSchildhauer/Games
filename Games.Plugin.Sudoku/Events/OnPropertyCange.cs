using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Games.Plugin.Sudoku.Events
{
    public class OnPropertyCange : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool ChangedProperty<T>(T newValue, ref T value, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(newValue, value))
            {
                value = newValue;
                TriggerEvent(propertyName);
                return true;
            }
            return false;
        }

        private void TriggerEvent(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
