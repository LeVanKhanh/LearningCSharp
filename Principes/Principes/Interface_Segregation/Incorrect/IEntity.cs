namespace Principes.Interface_Segregation.Incorrect
{
    public interface IEntity
    {
        //identify property
        public int Id { get; set; }
        //soft delete property
        public bool IsDeleted { get; set; }
    }
}
