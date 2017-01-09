using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using DevExpress.Xpf.Editors;

namespace DXSample10
{
    public class CustomPopupEdit : PopupBaseEdit
    {
        static CustomPopupEdit()
        {
            CustomPopupEditSettings.RegisterEditSettings();
        }

        public CustomPopupEdit()
        {
            ViewModel = new PopupViewModel();
            Initialized += OnInitialized;
        }

        public static readonly DependencyProperty RepositoryProperty = DependencyProperty.Register(
            nameof(Repository),
            typeof(IPopupRepository),
            typeof(CustomPopupEdit),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None, RepositoryPropertyChangedCallback));

        private static void RepositoryPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var edit = dependencyObject as CustomPopupEdit;
            if (edit == null) return;
            edit.ViewModel.Repository = (IPopupRepository)e.NewValue;
        }

        public IPopupRepository Repository
        {
            get { return (IPopupRepository) GetValue(RepositoryProperty); }
            set { SetValue(RepositoryProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(
            nameof(SelectedItem),
            typeof(PopupItem),
            typeof(CustomPopupEdit));

        public PopupItem SelectedItem
        {
            get { return (PopupItem)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        private PopupViewModel ViewModel;

        private void OnInitialized(object sender, EventArgs eventArgs)
        {
            var template = new ControlTemplate();
            var listBoxFactory = new FrameworkElementFactory(typeof(ListBox));
            template.VisualTree = listBoxFactory;
            this.PopupContentTemplate = template;

            var repositoryBinding = new Binding
            {
                Source = ViewModel,
                Path = new PropertyPath(nameof(PopupViewModel.Repository))
            };

            listBoxFactory.SetBinding(ListBox.ItemsSourceProperty, repositoryBinding);

            var selectedItemBinding = new Binding
            {
                Source = ViewModel,
                Path = new PropertyPath(nameof(ViewModel.SelectedItem)),
                Mode = BindingMode.TwoWay
            };

            listBoxFactory.SetBinding(ListBox.SelectedItemProperty, selectedItemBinding);
        }
    }
}