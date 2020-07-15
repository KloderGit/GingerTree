using Core.Domain;
using GingerTree.UI.Interfaces;
using GingerTree.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace GingerTree.UI.Infrastructure.DomainViewModels
{
    public class NodeViewModel : IDomain<Node>
    {
        private Node node;
        private ObservableCollection<NodeViewModel> children = new ObservableCollection<NodeViewModel>();
        private ObservableCollection<ParamViewModel> nodeParams = new ObservableCollection<ParamViewModel>();

        public NodeViewModel(Node node)
        {
            this.node = node;
            this.node.GetParams().ToList().ForEach(x => nodeParams.Add(new ParamViewModel(x)));
            nodeParams.CollectionChanged += NodeParams_CollectionChanged;

            this.node.GetChildren().ToList().ForEach(x => children.Add(new NodeViewModel(x)));
            children.CollectionChanged += Children_CollectionChanged;
        }

        private void Children_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    var addedParam = (e.NewItems[0] as ParamViewModel).GetDomain();
                    node.AddParam(addedParam);
                    break;
            }
        }

        private void NodeParams_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    var addedNode = (e.NewItems[0] as NodeViewModel).GetDomain();
                    node.AddChild(addedNode);
                    break;
            }
        }

        public Node GetDomain()
        {
            return node;
        }

        public string Title
        {
            get => node.Title;
            set => node.Title = value;
        }


    }
}
