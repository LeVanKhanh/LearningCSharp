namespace Principes.Interface_Segregation.Correct
{
    /// <summary>
    /// IEntity only need identity property
    /// </summary>
    public interface IEntity
    {
        int Id { get; set; }
    }
}
