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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf.GingerTree
{
    /// <summary>
    /// Логика взаимодействия для ParamComponent.xaml
    /// </summary>
    public partial class ParamComponent : UserControl
    {

        public ParamComponent(string name, string value)
        {


            InitializeComponent();

            Key.Text = name;
            Value.Text = value;
        }
    }
}
