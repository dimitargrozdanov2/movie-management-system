using System;

namespace MovieManagement.DataModels.Base
{
    public class Entity : IDeletable, IModifiable
    {
        public string Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
