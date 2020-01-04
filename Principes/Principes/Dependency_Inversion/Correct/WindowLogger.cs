using System;

namespace Principes.Dependency_Inversion.Correct
{
    public class WindowLogger: ILogger
    {
        public void Infor(string message)
        {
            Console.WriteLine($"WindowLogger - Infor: {message}");
        }

        public void Error(Exception exception)
        {
            Console.WriteLine($"WindowLogger - LogInfor: {exception.Message}");
        }

        public void Warning(string message)
        {
            Console.WriteLine($"WindowLogger - Warning: {message}");
        }
    }
}
