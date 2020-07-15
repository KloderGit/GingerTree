using GingerTree.UI.Infrastructure;
using GingerTree.UI.Infrastructure.DomainViewModels;
using GingerTree.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace GingerTree.UI.Pages.TreeBuilder.Component.EditElementCompomemt
{
    public class ElementEditComponentViewModel
    {
        ElementViewModel source;
        Status status;


        public ElementEditComponentViewModel()
        {
            status = Status.Added;
        }

        public ElementEditComponentViewModel(ElementViewModel element)
        {
            source = element;
            status = Status.Edited;
        }

        public TunelProperty<string> Title { get; set; }

        public ObservableCollection<KeyValuePair<string, string>> Params { get; set; }

        public void AddParam(KeyValuePair<string, string> param)
        {
            Params.Add(param);
        }

        enum Status
        {
            Added,
            Edited
        }
    }
}
