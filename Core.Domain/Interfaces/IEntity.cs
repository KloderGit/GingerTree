using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Interfaces
{
    public interface IEntity
    {
        int Id { get; set; }
        bool IsDelete { get; set; }

        DateTimeOffset Created { get; set; }
        DateTimeOffset Modified { get; set; }
    }
}
