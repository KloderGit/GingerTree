using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Linq;
using GingerTree.UI.Infrastructure.Dispatcher;
using GingerTree.UI.ViewModels;
using Core.Domain;
using GingerTree.UI.Infrastructure;
using GingerTree.UI.Infrastructure.DomainViewModels;
using GingerTree.UI.Pages.TreeBuilder.Component.SelectComponent;

namespace GingerTree.UI.Pages
{
    /// <summary>
    /// Логика взаимодействия для TreeBuilderPage.xaml
    /// </summary>
    public partial class TreeBuilderPage : Page
    {
        private ConstructorModuleDispatcher dispatcher = new ConstructorModuleDispatcher();

        public TreeBuilderPage()
        {
            InitializeComponent();

            SelectComponent.DataContext = new SelectComponentViewModel(dispatcher.Elements); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var el = SelectComponent.Elements_Listbox.SelectedItem as ElementItemViewModel;

            EditElement_Component.EditElement(el.GetElementViewModel());
        }
    }

}
