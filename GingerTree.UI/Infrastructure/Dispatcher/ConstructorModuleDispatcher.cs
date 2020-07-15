using Core.Domain;
using GingerTree.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace GingerTree.UI.Infrastructure.Dispatcher
{
    public class ConstructorModuleDispatcher
    {
        public ConstructorModuleDispatcher()
        {
            ConvertDomainToObserviable(GetElements());
        }

        public ObservableCollection<ElementViewModel> Elements { get; private set; } = new ObservableCollection<ElementViewModel>();


        public IEnumerable<Element> GetElements()
        {
            return new List<Element> { new Element("First Element") { Params = new List<Param> { new Param("place", "banana"), new Param("type", "full-time"), } } };
        }

        private void ConvertDomainToObserviable(IEnumerable<Element> elements)
        {
            var newElementsFromSource = elements.Except(Elements.Select(x => x.GetDomain()), new ElementComparer());
            newElementsFromSource.ToList().ForEach(x => Elements.Add(ElementViewModel.CreateFromDomain(x)));
        }
    }

    public class ElementComparer : IEqualityComparer<Element>
    {
        public bool Equals([AllowNull] Element x, [AllowNull] Element y)
        {
            return (x.Key.Equals(y.Key) && x.Title.Equals(y.Title));
        }

        public int GetHashCode([DisallowNull] Element obj)
        { 
            if (Object.ReferenceEquals(obj, null))
                return 0;

            return obj.Key.GetHashCode() + obj.Title.GetHashCode();
        }
    }
}
