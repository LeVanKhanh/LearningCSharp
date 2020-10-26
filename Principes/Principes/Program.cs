namespace Principes
{
    class Program
    {
        static void Main()
        {
            ITest test = new Liskov_Substitution.Correct.Lsp_Correct_Test();
            test.Test();
        }
    }
}
