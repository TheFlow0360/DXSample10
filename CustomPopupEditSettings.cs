using System.Windows;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Editors.Helpers;
using DevExpress.Xpf.Editors.Settings;

namespace DXSample10
{
    public class CustomPopupEditSettings : PopupBaseEditSettings
    {
        static CustomPopupEditSettings()
        {
            RegisterEditSettings();
        }

        public static void RegisterEditSettings()
        {
            EditorSettingsProvider.Default.RegisterUserEditor2(
                typeof(CustomPopupEdit),
                typeof(CustomPopupEditSettings),
                optimized => optimized ? new InplaceBaseEdit() : (IBaseEdit)new CustomPopupEdit(),
                () => new CustomPopupEditSettings());
        }

        protected override void AssignToEditCore(IBaseEdit edit)
        {
            base.AssignToEditCore(edit);
            var editor = edit as CustomPopupEdit;
            if (editor == null)
                return;
            SetValueFromSettings(RepositoryProperty, () => editor.Repository = Repository);
        }

        public static readonly DependencyProperty RepositoryProperty = DependencyProperty.Register(
            nameof(Repository),
            typeof(IPopupRepository),
            typeof(CustomPopupEditSettings));

        public IPopupRepository Repository
        {
            get { return (IPopupRepository)GetValue(RepositoryProperty); }
            set { SetValue(RepositoryProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(
            nameof(SelectedItem),
            typeof(PopupItem),
            typeof(CustomPopupEditSettings));

        public PopupItem SelectedItem
        {
            get { return (PopupItem)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }
    }
}