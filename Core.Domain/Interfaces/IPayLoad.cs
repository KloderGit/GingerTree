using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Interfaces
{
    public interface IPayLoad
    {
        Element GetEvent();
        void SetEvent(Element element);

        void AddParam(Param param);
        IEnumerable<Param> GetParams();
    }
}
