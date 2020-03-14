namespace Principes.Interface_Segregation.Correct
{
    /// <summary>
    /// Interface for entities need to implement SoftDelete
    /// </summary>
    public interface ISoftDelete : IEntity
    {
        public bool IsDeleted { get; set; }
    }
}
