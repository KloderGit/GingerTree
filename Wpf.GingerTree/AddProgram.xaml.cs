using Core.Domain;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для AddProgram.xaml
    /// </summary>
    public partial class AddProgram : Window
    {
        public Structure Structure { get; set; }

        IEnumerable<Element> Elements { get; set; }

        public AddProgram(IEnumerable<Element> elements)
        {
            InitializeComponent();

            Elements = elements;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var wind = new SelectElement(Elements);

            var elm = wind.Element;

            var strc = new Structure(elm);

            Structure.Children.Add(strc);
        }
    }
}
