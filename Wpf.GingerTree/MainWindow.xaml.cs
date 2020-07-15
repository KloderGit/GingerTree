using Core.Domain;
using Database.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace Wpf.GingerTree
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Element> elements { get; set; } = new ObservableCollection<Element>();

        ObservableCollection<Core.Domain.Node> structures { get; set; } = new ObservableCollection<Core.Domain.Node>();

        public MainWindow()
        {
            InitializeComponent();

            lst.ItemsSource = elements;
            treeView1.ItemsSource = structures;
            Structrs.ItemsSource = structures;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var passwordWindow = new AddElementWindow();

            if (passwordWindow.ShowDialog() == true)
            {
                elements.Add(passwordWindow.Element);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var addElementWindow = new AddProgramWindow();

            if (addElementWindow.ShowDialog() == true)
            {
                structures.Add(addElementWindow.Structure);
                elements.Add(addElementWindow.Structure.Item);
            }
        }

        private void edt_Click(object sender, RoutedEventArgs e)
        {
            var strct = Structrs.SelectedItem as Node;

            MessageBox.Show(strct.GetEvent().Title);
        }

        //private void Button_Click_2(object sender, RoutedEventArgs e)
        //{
        //    var str = treeView1.SelectedItem as Node;

        //    var strct = Structrs.SelectedItem as Node;


        //    var dec = new Node(strct.GetEvent());
        //    dec.SetParent(str);
        //    dec.Params = strct.Params.Select(x => x.Copy()).ToList();
        //    dec.Children = strct.Children;

        //    dec.Params.Add( new Param("Added Decor", "DecorParamValue"));

        //    str.AddChildren(dec);

        //    treeView1.Items.Refresh();
        //    treeView1.UpdateLayout();
        //}

        //private void Button_Click_3(object sender, RoutedEventArgs e)
        //{
        //    var structr = treeView1.SelectedItem as Node;

        //    var addElementWindow = new AddProgramWindow();

        //    if (addElementWindow.ShowDialog() == true)
        //    {
        //        var created = addElementWindow.Structure;
        //        created.Parent = structr;

        //        structr.Children.Add(created);
        //        elements.Add(addElementWindow.Structure.Item);
        //    }

        //    treeView1.Items.Refresh();
        //    treeView1.UpdateLayout();
        //}
    }
}
