using System;
using System.Collections.Generic;
using System.Text;

namespace Common.BaseModels
{
    public interface IDeletableEntity
    {
        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}
