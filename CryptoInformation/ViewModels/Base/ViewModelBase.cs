using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CryptoInformation.ViewModels.Base
{
    internal abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        protected virtual void Set<T> (ref T member, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(member, value)) return;
            member = value;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
