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
    /// Логика взаимодействия для SelectElement.xaml
    /// </summary>
    public partial class SelectElement : Window
    {
        public Element Element { get; set; }
        public SelectElement(IEnumerable<Element> elements)
        {
            InitializeComponent();

            Els.ItemsSource = elements;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Element = (Element)Els.SelectedItem;
            DialogResult = true;
        }
    }
}
