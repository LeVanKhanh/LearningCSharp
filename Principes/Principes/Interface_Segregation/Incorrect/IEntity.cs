namespace Principes.Interface_Segregation.Incorrect
{
    public interface IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
