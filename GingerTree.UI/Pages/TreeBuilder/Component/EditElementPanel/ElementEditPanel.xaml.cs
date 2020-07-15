using GingerTree.UI.Pages.Component;
using GingerTree.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GingerTree.UI.Pages.TreeBuilder.Component.EditElementPanel
{
    /// <summary>
    /// Логика взаимодействия для ElementEditPanel.xaml
    /// </summary>
    public partial class ElementEditPanel : UserControl
    {
        public ObservableCollection<TabItem> Tabs { get; set; }

        public ElementEditPanel()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var editComponent = new ElementEditComponent();

            var newTab = new TabItem { Header = "Добавить Элемент", Content = editComponent };

            ElementEditPanel_TabControl.Items.Add(newTab);
        }


        public void EditElement(ElementViewModel elementViewModel)
        {
            var editComponent = new ElementEditComponent(elementViewModel);

            var newTab = new TabItem { Header = elementViewModel.Title.Value, Content = editComponent };

            ElementEditPanel_TabControl.Items.Add(newTab);

            ElementEditPanel_TabControl.SelectedItem = ElementEditPanel_TabControl.Items.Count;
        }
    }
}
