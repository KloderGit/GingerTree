using Core.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.TreeBuilder.Model;

namespace Wpf.TreeBuilder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel context;
        public MainWindow()
        {
            InitializeComponent();
            context = new MainWindowViewModel(Nodes());
            Elements().ToList().ForEach(x => context.Element.Add(new ViewModel.ElementViewModel(x)));
            DataContext = context;
        }

        private void AddProgram_Click(object sender, RoutedEventArgs e)
        {
            var eventW = new AddProgramWindow();

            if (eventW.ShowDialog() == true)
            {
                var sel = ProgramTree.SelectedItem as NodeViewModel;

                var itm = new Element(eventW.EventTitle);
                itm.Params = eventW.@params;

                var nod = new Node(itm);

                if (sel != null)
                {
                    sel.Children.Add(new NodeViewModel(nod));
                    sel.Node.AddChild(nod);
                }
                else
                {
                    context.TempalateTree.Add(new NodeViewModel(nod));
                }
                
            }
        }

        private IEnumerable<Node> Nodes()
        {
            var node11 = new Node(new Element("dddd"));

            var node1 = new Node(new Element("dd"));
            var node2 = new Node(new Element("ff"));
            var node3 = new Node(new Element("cc"));
            var node4 = new Node(new Element("32"));
            node2.AddChild(node3);
            node2.AddChild(node4);
            node1.AddChild(node2);

            return new List<Node> { node11, node1 };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var sel = ProgramTree.SelectedItem as NodeViewModel;

            MessageBox.Show(String.Join(" | ", sel.Node.GetElements().Select(x => x.Title)));
        }

        private IEnumerable<Element> Elements()
        {
            return new List<Element> { 
                new Element("First"){ Params = new List<Param>{ new Param("Key1", "Value - 1" ), new Param("Key2", "Value - 2") } },
                new Element("Second"){ Params = new List<Param>{ new Param("Key21", "Value - 21" ), new Param("Key22", "Value - 22") } }
            };
        }
    }
}


