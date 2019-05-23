using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Games.Plugin.Sudoku.Events
{
    public class OnPropertyCange : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool ChangedProperty(object newValue, ref object value, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(newValue, value))
            {
                value = newValue;
                TriggerEvent(propertyName);
                return true;
            }
            return false;
        }

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
