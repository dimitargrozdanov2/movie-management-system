using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.DataModels.Base
{
    public interface IDeletable
    {
        bool IsDeleted { get; set; }
    }
}
