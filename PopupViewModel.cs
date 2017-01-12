using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DXSample10.Annotations;

namespace DXSample10
{
    public class PopupViewModel: INotifyPropertyChanged
    {
        private IPopupRepository _repository;
        public IPopupRepository Repository
        {
            get {  return _repository; }
            set
            {
                _repository = value;
                NotifyPropertyChanged();
            }
        }

        private object _selectedItem;

        public object SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem == value)
                    return;
                _selectedItem = value;
                NotifySelectionChanged(value);
                NotifyPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event EventHandler<object> SelectionChanged;

        protected virtual void NotifySelectionChanged(object newValue)
        {
            SelectionChanged?.Invoke(this, newValue);
        }
    }
}