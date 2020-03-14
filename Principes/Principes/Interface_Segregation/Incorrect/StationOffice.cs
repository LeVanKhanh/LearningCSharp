namespace Principes.Interface_Segregation.Incorrect
{
    /// <summary>
    /// For example in this case StationOffice hasn't to implement soft delete. It can remove from DB.
    /// Station Office is belong to Station.
    /// If Station is deleted mean Station Office is deleted too.
    /// Does StationOffice need soft delete property.
    /// but it inherit interface IEntity so it have to implement property IsDeleted.
    /// Is it make sense?
    /// Let fix it!
    /// </summary>
    public class StationOffice : IEntity
    {
        public int Id { get; set; }
        public int StationId { get; set; }
        public string Name { get; set; }
        public Station Station { get; set; }
        public bool IsDeleted { get; set; }
    }
}
