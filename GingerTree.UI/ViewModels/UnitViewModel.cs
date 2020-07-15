using GingerTree.UI.Infrastructure;
using GingerTree.UI.Infrastructure.DomainViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GingerTree.UI.ViewModels
{
    public class UnitViewModel
    {
        private ObservableCollection<UnitViewModel> children = new ObservableCollection<UnitViewModel>();
        private ObservableCollection<ParamViewModel> nodeParams = new ObservableCollection<ParamViewModel>();

        public UnitViewModel(string title)
        {
            Title.Value = title;
            Children = new ReadOnlyObservableCollection<UnitViewModel>(children);
            Params = new ReadOnlyObservableCollection<ParamViewModel>(nodeParams);
        }

        public TunelProperty<string> Title { get; set; } = new TunelProperty<string>(String.Empty);
        public ReadOnlyObservableCollection<UnitViewModel> Children { get; private set; }
        public ReadOnlyObservableCollection<ParamViewModel> Params { get; private set; }

        public void AddChildren(UnitViewModel unitViewModel)
        {
            children.Add(unitViewModel);
        }
    }
}
