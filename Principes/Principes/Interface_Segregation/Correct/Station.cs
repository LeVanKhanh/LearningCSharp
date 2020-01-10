namespace Principes.Interface_Segregation.Correct
{
    public class Station : IEntity, ISoftDelete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public int TenantId { get; set; }
    }
}
