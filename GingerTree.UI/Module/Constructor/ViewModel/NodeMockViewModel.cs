using GingerTree.UI.Infrastructure;
using GingerTree.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace GingerTree.UI.Module.Constructor.ViewModel
{
    public class NodeMockViewModel
    {
        public NodeMockViewModel Parent { get; set; }

        public TunelProperty<string> Title { get; set; }

        public ObservableCollection<ParamViewModel> Params { get; set; } = new ObservableCollection<ParamViewModel>();
        public ObservableCollection<NodeMockViewModel> Children { get; set; } = new ObservableCollection<NodeMockViewModel>();

        public NodeMockViewModel Clone()
        {
            var cloneNode = new NodeMockViewModel();

            cloneNode.Title = new TunelProperty<string>(this.Title.Value);

            var prmsCloneArray = this.Params.Select(x => new ParamViewModel { Key = new TunelProperty<string>(x.Key.Value), Value = new TunelProperty<string>(x.Value.Value) });
            cloneNode.Params = new ObservableCollection<ParamViewModel>(prmsCloneArray);

            if (this.Children.Count() > 0)
            {
                var chldsArray = this.Children.Select(x => x.Clone());
                cloneNode.Children = new ObservableCollection<NodeMockViewModel>(chldsArray);
            }

            return cloneNode;
        }


        public override string ToString()
        {
            return Title.Value;
        }
    }
}
