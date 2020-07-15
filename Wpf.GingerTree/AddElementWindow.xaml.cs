using Core.Domain;
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
using System.Windows.Shapes;

namespace Wpf.GingerTree
{
    /// <summary>
    /// Логика взаимодействия для AddElementWindow.xaml
    /// </summary>
    public partial class AddElementWindow : Window
    {
        public Element Element { get; set; }
        ObservableCollection<Param> @params = new ObservableCollection<Param>();

        public AddElementWindow()
        {
            InitializeComponent();

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            @params.Add(new Param(Key.Text, Value.Text));

            ParamsPanel.Children.Add(new ParamComponent(Key.Text, Value.Text));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Element = new Element(Title.Text);
            Element.Params = @params;



            this.DialogResult = true;
        }
    }
}
