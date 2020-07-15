using GingerTree.UI.Infrastructure;
using GingerTree.UI.Infrastructure.DomainViewModels;
using GingerTree.UI.Module.Constructor.Model;
using GingerTree.UI.ViewModels;
using GongSolutions.Wpf.DragDrop;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace GingerTree.UI.Module.Constructor.ViewModel
{
    public class EditedNodeViewModel : IDropTarget
    {
        private NodeMockViewModel nodeViewModel;

        private NodeMockViewModel clonedNodeViewModel;

        public EditedNodeViewModel()
        {}

        public EditedNodeViewModel(NodeMockViewModel nodeViewModel)
        {
            this.nodeViewModel = nodeViewModel;

            this.clonedNodeViewModel = nodeViewModel.Clone();
        }

        public string Title { get => clonedNodeViewModel.Title.Value; set => clonedNodeViewModel.Title.Value = value; }

        public Status Status { get; set; }

        public string Description { get; set; } = "Описание мероприятия...";

        public AddParam AddParam { get; set; } = new AddParam() { Param = new ParamViewModel { Key = new TunelProperty<string>("name"), Value = new TunelProperty<string>("payload") } };


        public ObservableCollection<ParamViewModel> Params  { get => clonedNodeViewModel.Params; }

        public ObservableCollection<NodeMockViewModel> Children { get => clonedNodeViewModel.Children; }



        private ICommand addParamCommand;
        public ICommand AddParamCommand
        {
            get
            {
                return addParamCommand ?? (addParamCommand = new RelayCommand(ToAddParam));
            }
        }

        private void ToAddParam(object param)
        {
            Params.Add( new ParamViewModel { Key = new TunelProperty<string>(AddParam.Param.Key.Value), Value = new TunelProperty<string>(AddParam.Param.Value.Value) });
        }



        public void DragOver(IDropInfo dropInfo)
        {
            DragDrop.DefaultDropHandler.DragOver(dropInfo);
        }


        public void Drop(IDropInfo dropInfo)
        {
            var dataSource = dropInfo.Data as NodeMockViewModel;

            var sourceElement = dropInfo.DragInfo.VisualSource;
            var targetElement = dropInfo.VisualTarget;

            NodeMockViewModel item;

            if (sourceElement != targetElement)
            {
                item = dataSource.Clone();
            }
            else
            {
                item = dataSource;
            }
            

            var target = dropInfo.TargetItem as NodeMockViewModel;

            var pos = dropInfo.InsertPosition;

            if (pos.HasFlag(RelativeInsertPosition.TargetItemCenter)) 
                target.Children.Add(item);
            else Children.Add(item);
        }
    }

    public class AddParam
    {
        public ParamViewModel Param { get; set; }
    }
}
