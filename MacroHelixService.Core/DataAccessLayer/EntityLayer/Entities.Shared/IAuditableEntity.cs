using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Shared
{
    public interface IAuditableEntity : IEntity
    {
        DateTime DateAdded { get; set; }
        int AddedBy { get; set; }
        DateTime? DateUpdated { get; set; }
        int? UpdatedBy { get; set; }
    }
}
