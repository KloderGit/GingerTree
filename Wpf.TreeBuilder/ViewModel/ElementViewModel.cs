using Core.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Wpf.TreeBuilder.ViewModel
{
    public class ElementViewModel
    {
        Element element;
        ObservableCollection<ParamViewModel> @params = new ObservableCollection<ParamViewModel>();

        public ElementViewModel(Element element)
        {
            this.element = element;
            element?.Params.ToList().ForEach(x => @params.Add(new ParamViewModel(x)));
        }

        public string Title { get => element.Title; }
        public ObservableCollection<ParamViewModel> Params { get; }
    }
}
