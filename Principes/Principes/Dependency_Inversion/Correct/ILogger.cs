using System;

namespace Principes.Dependency_Inversion.Correct
{
    public interface ILogger
    {
        void Infor(string message);
        void Error(Exception exception);
        void Warning(string message);
    }
}
