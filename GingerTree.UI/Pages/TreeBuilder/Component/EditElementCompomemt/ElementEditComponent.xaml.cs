using Core.Domain;
using GingerTree.UI.Infrastructure.DomainViewModels;
using GingerTree.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

namespace GingerTree.UI.Pages.Component
{
    /// <summary>
    /// Логика взаимодействия для ElementEditComponent.xaml
    /// </summary>
    public partial class ElementEditComponent : UserControl
    {
        ElementViewModel sourceElement;
        ElementEditComponentViewModel VM;

        public ElementEditComponent()
        {
            InitializeComponent();
            VM = new ElementEditComponentViewModel();

            DataContext = VM;
        }

        public ElementEditComponent(ElementViewModel elementViewModel)
            :this()
        {
            sourceElement = elementViewModel;

            VM.Title = sourceElement.Title.Value;
            VM.Params = sourceElement.Params.Select(x => new ParamListItem { Name = x.Key.Value, Value = x.Value.Value } );
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {



            sourceElement.Title.Value = VM.Title;

            //MessageBox.Show(sourceElement.Title.Value + "  |  " + element.Title.Value);
        }

        class ElementEditComponentViewModel
        {
            public string Title { get; set; }
            public IEnumerable<ParamListItem> Params { get; set; }
        }

        class ParamListItem
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
    }
}
