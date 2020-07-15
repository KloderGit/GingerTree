using Core.Domain;
using Core.Domain.Interfaces;
using GingerTree.UI.Interfaces;
using GingerTree.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace GingerTree.UI.Infrastructure.Dispatcher
{
    public class DomainToObserviableConverter<T,Vm> 
        where T: IEntity, new()
        where Vm: IDomain<T>, IDomainCreator<T,Vm>
    {
        public DomainToObserviableConverter()
        {

        }

        public ObservableCollection<Vm> Convert(IEnumerable<T> entities)
        {
            ObservableCollection<Vm> result = new ObservableCollection<Vm>();

            var newElementsFromSource = entities.Except<T>(
                        result.Select(x => x.GetDomain()), 
                        new IEntityComparer());

            var ddd = new Element("");

            //newElementsFromSource.ToList().ForEach(x => result.Add(Vm.CreateFromDomain(x)));

            return result;
        }

        private class IEntityComparer : IEqualityComparer<T>
        {
            public bool Equals([AllowNull] T x, [AllowNull] T y)
            {
                return (x.Id.Equals(y.Id));
            }

            public int GetHashCode([DisallowNull] T obj)
            {
                if (Object.ReferenceEquals(obj, null))
                    return 0;

                return obj.Id.GetHashCode();
            }
        }
    }


}
