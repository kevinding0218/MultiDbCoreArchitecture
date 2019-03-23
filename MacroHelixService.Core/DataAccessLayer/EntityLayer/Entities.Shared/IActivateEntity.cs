using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Shared
{
    public interface IActivateEntity : IEntity
    {
        Boolean Active { get; set; }
    }
}
