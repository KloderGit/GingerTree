using Core.Domain;
using GingerTree.UI.Infrastructure;
using GingerTree.UI.Infrastructure.DomainViewModels;
using GingerTree.UI.Interfaces;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace GingerTree.UI.ViewModels
{
    public class ElementViewModel : IDomain<Element>, IDomainCreator<Element, ElementViewModel>
    {
        Element element;

        public ElementViewModel(Element element)
        {
            this.element = element;
            Title = new TunelProperty<string>(this.element.Title);
            this.element.Params.ToList().ForEach(x => Params.Add(new ParamViewModel(x)));
            Params.CollectionChanged += ElementParams_CollectionChanged;
        }

        public TunelProperty<string> Title { get; set; }

        public ObservableCollection<ParamViewModel> Params { get; set; } = new ObservableCollection<ParamViewModel>();

        public Element GetDomain()
        {
            return element;
        }

        private void ElementParams_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    var addedParam = (e.NewItems[0] as ParamViewModel).GetDomain();
                    element.Params.Add(addedParam);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    var deletedParam = (e.OldItems[0] as ParamViewModel).GetDomain();
                    element.Params.Remove(deletedParam);
                    break;
                case NotifyCollectionChangedAction.Replace: // если замена
                    var replacedParam = (e.OldItems[0] as ParamViewModel).GetDomain();
                    var newParam = (e.NewItems[0] as ParamViewModel).GetDomain();
                    replacedParam = newParam;
                    break;
            }
        }


        public static ElementViewModel CreateFromDomain(Element element)
        {
            return new ElementViewModel(element);
        }

        ElementViewModel IDomainCreator<Element, ElementViewModel>.CreateFromDomain(Element element)
        {
            return ElementViewModel.CreateFromDomain(element);
        }

    }
}
