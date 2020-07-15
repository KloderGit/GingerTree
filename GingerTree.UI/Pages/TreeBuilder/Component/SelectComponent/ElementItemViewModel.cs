using GingerTree.UI.Infrastructure;
using GingerTree.UI.Infrastructure.DomainViewModels;
using GingerTree.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GingerTree.UI.Pages.TreeBuilder.Component.SelectComponent
{
    public class ElementItemViewModel
    {
        private readonly ElementViewModel sourceElement;

        public ElementItemViewModel(ElementViewModel elementViewModel)
        {
            sourceElement = elementViewModel;
        }

        public TunelProperty<string> Title
        {
            get => sourceElement.Title;
            set => sourceElement.Title = value;
        }

        public TunelProperty<string> FormatType { get; set; }
        public int PropertiesCount { get; set; }

        public ObservableCollection<ParamViewModel> Params { get; set; }

        public bool IsRed { get; set; }

        public ElementViewModel GetElementViewModel()
        {
            return sourceElement;
        }
    }
}
