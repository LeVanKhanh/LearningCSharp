using System;

namespace Principes.Interface_Segregation.Correct
{
    public abstract class RepositorySoftDeleteBase<Entity>
        where Entity : ISoftDelete
    {
        public void Delete(Entity entity)
        {
            entity.IsDeleted = true;
            Console.WriteLine("Set IsDeleted = True");
        }
    }
}
