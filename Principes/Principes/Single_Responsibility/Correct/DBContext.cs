namespace Principes.Single_Responsibility.Correct
{
    public interface DBContext
    {
        void Add(object obj);
        int SaveChange();
    }
}
