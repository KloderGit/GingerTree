using Core.Domain;
using GingerTree.UI.Infrastructure;
using GingerTree.UI.Infrastructure.DomainViewModels;
using GingerTree.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GingerTree.UI.Pages.TreeBuilder.Component.UnitEdit
{
    public class UnitEditComponentViewModel
    {
        private UnitViewModel Unit { get; set; }

        public UnitEditComponentViewModel()
        {
            Unit = new Units().Getnodes();
            Nodes = new Units().getAll();
        }

        public string Title { get => Unit.Title.Value; set => Unit.Title.Value = value; }

        public ReadOnlyObservableCollection<UnitViewModel> Children { get => Unit.Children; }
        public ReadOnlyObservableCollection<ParamViewModel> Params { get => Unit.Params; }


        public ObservableCollection<UnitViewModel> Nodes { get; set; }

    }



    public class Units
    {      
        public UnitViewModel Getnodes()
        {
            var node1 = new UnitViewModel("One");
            var node2 = new UnitViewModel("Two");
            var node3 = new UnitViewModel("Three");
            var node4 = new UnitViewModel("Four");
            var node5 = new UnitViewModel("Five");
            var node6 = new UnitViewModel("Six");
            var node7 = new UnitViewModel("Seven");
            var node8 = new UnitViewModel("Eight");
            var node9 = new UnitViewModel("Nine");
            var node10 = new UnitViewModel("Ten");

            node1.AddChildren(node2);
            node1.AddChildren(node3);
            node1.AddChildren(node4);

            node2.AddChildren(node5);
            node2.AddChildren(node6);
            node2.AddChildren(node7);

            node3.AddChildren(node8);

            node4.AddChildren(node9);
            node4.AddChildren(node10);

            node8.AddChildren(node4);

            return node1;
        }

        public ObservableCollection<UnitViewModel> getAll()
        {
            var node11 = new UnitViewModel("Tensdasd");
            var node12 = new UnitViewModel("Ten2342342");
            var node13 = new UnitViewModel("fadfa adsfad");
            var node14 = new UnitViewModel("qer324234");
            var node15 = new UnitViewModel("fg sfdgsfdgsdfgsdfgsdf");
            var node16 = new UnitViewModel("45fsadfad ");

            return new ObservableCollection<UnitViewModel> { node11, node12, node13, node14, node15, node16 };
        }
    }


    
}
