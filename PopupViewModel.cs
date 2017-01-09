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

        private PopupItem _selectedItem;

        public PopupItem SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                NotifyPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}