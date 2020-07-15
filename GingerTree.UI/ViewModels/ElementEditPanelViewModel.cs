using Core.Domain;
using GingerTree.UI.Infrastructure;
using GingerTree.UI.Infrastructure.DomainViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GingerTree.UI.ViewModels
{
    public class ElementEditPanelViewModel
    {

        public ObservableCollection<ElementEditItemViewModel> EditedElements { get; set; }

        public ElementEditPanelViewModel()
        {
            EditedElements = new ObservableCollection<ElementEditItemViewModel>();
        }
    }
}
