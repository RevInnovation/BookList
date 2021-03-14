using System;
using System.Collections.Generic;
using System.Text;

namespace Boilerplate.Helpers.Domain
{
    public interface IAggregateRoot<TId>
    {
        TId Id { get; }
        void SetId(TId id);
    }
}
