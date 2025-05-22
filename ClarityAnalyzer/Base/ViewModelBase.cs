using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClarityAnalyzer.Base
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        protected bool SetProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(property, value) == false)
            {
                property = value;
                OnPropertyChanged(propertyName);
                return true;
            }
            return false;
        }

        protected bool SetProperty<T>(ref T property, T value, List<string> otherPropertyNames, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(property, value) == false)
            {
                property = value;
                OnPropertyChanged(propertyName);
                if (otherPropertyNames != null)
                {
                    foreach (var otherPropertyName in otherPropertyNames)
                    {
                        OnPropertyChanged(otherPropertyName);
                    }
                }
                return true;
            }
            return false;
        }
    }
}
