using GingerTree.UI.Infrastructure;
using GingerTree.UI.ViewModels;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace GingerTree.UI.Pages.TreeBuilder.Component.SelectComponent
{
    public class SelectComponentViewModel
    {
        private CollectionMapper collectionMapper;

        public string Filter { get; set; } = "DSDASDASDASd";
        public ICollectionView Elements { get; private set; }

        public SelectComponentViewModel(ObservableCollection<ElementViewModel> sourceModels)
        {
            collectionMapper = new CollectionMapper(sourceModels);
            Elements = CollectionViewSource.GetDefaultView(collectionMapper.Collection);
            //Elements.Refresh();
        }


        private class CollectionMapper
        {
            public CollectionMapper(ObservableCollection<ElementViewModel> source)
            {
                source.CollectionChanged += Source_CollectionChanged;
                Source_CollectionChanged(this, new NotifyCollectionChangedEventArgs(action: NotifyCollectionChangedAction.Add, source));
            }

            public ObservableCollection<ElementItemViewModel> Collection { get; set; } = new ObservableCollection<ElementItemViewModel>();

            private void Source_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                if (e == null) return;

                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        foreach (var item in e.NewItems) Collection.Add(CreateItem(item));
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        foreach (var item in e.OldItems) Collection.Remove(FindItem(item));
                        break;
                }

                ElementItemViewModel CreateItem(object item)
                {
                    var source = item as ElementViewModel;

                    return new ElementItemViewModel(source)
                    {
                        FormatType = new TunelProperty<string>("added type"),
                        IsRed = true,
                        PropertiesCount = source.Params == null ? 0 : source.Params.Count,
                        Params = source.Params
                    };
                }

                ElementItemViewModel FindItem(object item)
                {
                    var source = item as ElementViewModel;

                    return Collection.FirstOrDefault(x => x.Title == source.Title);
                }
            }

        }
    }
}
