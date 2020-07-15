using GingerTree.UI.Infrastructure;
using GingerTree.UI.Infrastructure.DomainViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GingerTree.UI.ViewModels
{
    public class ElementEditItemViewModel
    {
        public TunelProperty<string> Title { get; set; }

        public TunelProperty<string> Description { get; set; }

        public ObservableCollection<ParamViewModel> Params { get; set; }
    }
}
