using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace CrudXamarin2.Models
{
    public class BaseModel : INotifyPropertyChanged
    {
        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }   

}
