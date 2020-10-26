using System;

namespace Principes.Interface_Segregation.Correct
{
    public abstract class RepositoryBase<Entity>
        where Entity : IEntity
    {
        public void Delete(Entity entity)
        {
            Console.WriteLine("Delete From DB");
        }
    }
}
