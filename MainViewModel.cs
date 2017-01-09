using System.Collections.ObjectModel;

namespace DXSample10
{
    public class MainViewModel
    {
        public ObservableCollection<RowObject> Rows { get; }

        public IPopupRepository PopupRepository { get; }

        public MainViewModel()
        {
            Rows = new ObservableCollection<RowObject>
            {
                new RowObject("Test 1"),
                new RowObject("Test 2"),
                new RowObject("Test 3"),
                new RowObject("Test 4"),
                new RowObject("Test 5")
            };
            PopupRepository = new PopupItemList
            {
                new PopupItem(1, "1"),
                new PopupItem(2, "Two"),
                new PopupItem(3, "III")
            };
        }
    }
}