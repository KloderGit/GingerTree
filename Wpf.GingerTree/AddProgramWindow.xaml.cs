using Core.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection.Metadata.Ecma335;
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
    /// Логика взаимодействия для AddProgramWindow.xaml
    /// </summary>
    public partial class AddProgramWindow : Window
    {
        ObservableCollection<Param> Params = new ObservableCollection<Param>();

        public Wrapper Structure { get; set; }

        public AddProgramWindow()
        {
            InitializeComponent();            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Params.Add(new Param(ParamName.Text, ParamValue.Text));
            ParamsPanel.Children.Add(new ParamComponent(ParamName.Text, ParamValue.Text));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var element = new Element(Title.Text);

            var layout = new Layout();
            Structure = new Wrapper(element, layout);
            Structure.Params = Params;

            DialogResult = true;
        }
    }
}
