using Core.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Wpf.TreeBuilder.ViewModel;

namespace Wpf.TreeBuilder.Model
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel(IEnumerable<Node> nodes)
        {
            nodes.ToList().ForEach(x => TempalateTree.Add(new NodeViewModel(x)));
        }

        public ObservableCollection<NodeViewModel> TempalateTree { get; set; } = new ObservableCollection<NodeViewModel>();

        public ObservableCollection<ElementViewModel> Element { get; set; } = new ObservableCollection<ElementViewModel>();
    }
}
