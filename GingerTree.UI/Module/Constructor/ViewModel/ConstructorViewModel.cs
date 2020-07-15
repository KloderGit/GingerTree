using Core.Domain;
using GingerTree.UI.Infrastructure;
using GingerTree.UI.Infrastructure.DomainViewModels;
using GingerTree.UI.Module.Constructor.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace GingerTree.UI.Module.Constructor.ViewModel
{
    public class ConstructorViewModel
    {
        public ConstructorViewModel()
        {
            Nodes = new MockNodeRepository().GetNodeViewModels();
        }

        public ObservableCollection<NodeMockViewModel> Nodes { get; set; }
        public ObservableCollection<EditedNodeViewModel> EditedNodes { get; set; } = new ObservableCollection<EditedNodeViewModel>();


        public ObservableCollection<NodeMockViewModel> ListNodes {
            get;
            private set; }

        private ICommand editCommand;
        public ICommand AddCommand
        {
            get
            {
                return editCommand ??
                    (editCommand = new RelayCommand(CreateEditedModel));
            }
        }


        private void CreateEditedModel(object node)
        {
            EditedNodes.Add(new EditedNodeViewModel((NodeMockViewModel)node) { Status= Status.Edited });

        }
    }
}
