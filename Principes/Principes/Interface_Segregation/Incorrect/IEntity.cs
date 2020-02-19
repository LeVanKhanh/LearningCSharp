namespace Principes.Interface_Segregation.Incorrect
{
    public interface IEntity
    {
        int Id { get; set; }
        bool IsDeleted { get; set; }
    }
}
