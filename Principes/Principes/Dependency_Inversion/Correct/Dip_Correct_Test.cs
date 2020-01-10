namespace Principes.Dependency_Inversion.Correct
{
    public class Dip_Correct_Test: ITest
    {
        public void Test()
        {
            MyService myService;
            myService = new MyService(new FileLogger());
            myService.DoSomething();
            myService = new MyService(new DbLogger());
            myService.DoSomething();
            myService = new MyService(new WindowLogger());
            myService.DoSomething();
        }
    }
}
