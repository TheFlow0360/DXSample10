namespace DXSample10
{
    public class PopupItem
    {
        public object EditValue { get; }
        
        public string DisplayValue { get; }

        public PopupItem(object data, string text)
        {
            EditValue = data;
            DisplayValue = text;
        }
    }
}