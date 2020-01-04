using System;

namespace Principes.Interface_Segregation.Correct
{
    public class Repository<Entity>
        where Entity : IEntity
    {
        public void Delete(Entity entity)
        {
            if (entity is ISoftDelete)
            {
                Console.WriteLine("Set IsDeleted = True");
                return;
            }
            Console.WriteLine("Delete From DB");
        }
    }
}
