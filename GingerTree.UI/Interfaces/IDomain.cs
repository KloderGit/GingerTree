using System;
using System.Collections.Generic;
using System.Text;

namespace GingerTree.UI.Interfaces
{
    public interface IDomain<T>
    {
        T GetDomain();
    }
}
