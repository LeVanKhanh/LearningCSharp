using System.Collections.Generic;

namespace CSharp8.Using_Declarations
{
    public class Using_Declarations_Test : ITest
    {
        public void Exec()
        {
            var lines = new List<string>
            {
                "One",
                "Two",
                "Three",
                "Second",
                "Four"
            };
            string fileName = "fileName";
            FileHelper.WriteLinesToFile(lines, fileName);
            FileHelper.ReadFile(fileName);
            FileHelper.DeleteFile(fileName);
        }
    }
}
