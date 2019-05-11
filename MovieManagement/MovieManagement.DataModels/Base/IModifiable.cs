using System;

namespace MovieManagement.DataModels.Base
{
    public interface IModifiable
    {
        DateTime? CreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }
    }
}