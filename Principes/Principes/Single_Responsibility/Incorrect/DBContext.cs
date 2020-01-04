namespace Principes.Single_Responsibility.Incorrect
{
    public interface IDBContext
    {
        void Add(object obj);
        int SaveChange();
    }
}
