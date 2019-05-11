namespace MovieManagement.DataModels.Base
{
    public interface IDeletable
    {
        bool IsDeleted { get; set; }
    }
}