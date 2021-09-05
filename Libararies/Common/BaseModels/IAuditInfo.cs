using System;
using System.Collections.Generic;
using System.Text;

namespace Common.BaseModels
{
    public interface IAuditInfo
    {
        DateTime CreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }
    }
}
