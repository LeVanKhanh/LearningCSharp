namespace Principes.Dependency_Inversion.Incorrect
{
    public class MyService
    {
        private readonly FileLogger _fileLogger;
        // This class is tightly coupled with FileLogger
        public MyService(FileLogger fileLogger)
        {
            _fileLogger = fileLogger;
        }

        public void DoSomething()
        {
            _fileLogger.Infor("MyService do something");
        }
    }
}
