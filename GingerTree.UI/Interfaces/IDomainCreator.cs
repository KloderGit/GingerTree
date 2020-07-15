using System;
using System.Collections.Generic;
using System.Text;

namespace GingerTree.UI.Interfaces
{
    public interface IDomainCreator<T,Vm>
    {
        Vm CreateFromDomain(T item);
    }
}
