namespace Principes.Interface_Segregation.Incorrect
{
    public class StationOffice : IEntity
    {
        public int Id { get; set; }
        public int StationId { get; set; }
        public string Name { get; set; }
        public Station Station { get; set; }
        public bool IsDeleted { get; set; }
    }
}
