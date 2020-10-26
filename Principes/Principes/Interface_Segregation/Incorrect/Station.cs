namespace Principes.Interface_Segregation.Incorrect
{
    /// <summary>
    /// Station has soft delete property IsDeleted
    /// </summary>
    public class Station : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
