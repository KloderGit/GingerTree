using Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Domain.Interfaces
{
    public interface ITreeBuilder<in T>
    {
        IEnumerable<IComponent> Build();
    }
}
