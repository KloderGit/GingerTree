using Core.Domain;
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

namespace Wpf.TreeBuilder
{
    /// <summary>
    /// Логика взаимодействия для AddEvent.xaml
    /// </summary>
    public partial class AddEvent : UserControl
    {
        public ObservableCollection<Param> @params = new ObservableCollection<Param>();
        public string EvTitle { get; set; }
        

        public AddEvent()
        {
            InitializeComponent();
        }

        private void AddParamButton_Click(object sender, RoutedEventArgs e)
        {
            var key = Key.Text;
            var value = Value.Text;

            @params.Add(new Param(key, value));

            var paramControl = new ParamControl();
            paramControl.KeyTextBlock.Text = key;
            paramControl.ValueTextBlock.Text = value;
            ParamsWrapPanel.Children.Add(paramControl);
        }

        private void TitleTextBlock_TextChanged(object sender, TextChangedEventArgs e)
        {
            EvTitle = TitleTextBlock.Text;
        }
    }
}
