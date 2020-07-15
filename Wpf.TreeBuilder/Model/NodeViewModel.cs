using Core.Domain;
using System.Collections.ObjectModel;
using System.Linq;
using Wpf.TreeBuilder.ViewModel;

namespace Wpf.TreeBuilder.Model
{
    public class NodeViewModel
    {
        public Node Node { get; set; }

        public NodeViewModel(Node node)
        {
            Node = node;

            Title = node.Title;
            node.GetParams().ToList().ForEach(x => Params.Add(new ParamViewModel(x)));
            node.GetChildren().ToList().ForEach(x=> Children.Add(new NodeViewModel(x)));
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public ObservableCollection<ParamViewModel> Params { get; set; } = new ObservableCollection<ParamViewModel>();
        public ObservableCollection<NodeViewModel> Children { get; set; } = new ObservableCollection<NodeViewModel>();

    }
}
