namespace Principes.Interface_Segregation.Correct
{
    /// <summary>
    /// Interface for entities need to implement SoftDelete
    /// </summary>
    public interface ISoftDelete : IEntity
    {
        bool IsDeleted { get; set; }
    }
}
