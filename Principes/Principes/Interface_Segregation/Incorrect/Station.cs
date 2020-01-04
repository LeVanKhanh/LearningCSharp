namespace Principes.Interface_Segregation.Incorrect
{
    public class Station : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public int TenantId { get; set; }
    }
}
