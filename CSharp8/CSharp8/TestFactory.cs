using System;

namespace CSharp8
{
    public class TestFactory
    {
        public ITest GetTest(string testName) => testName switch
        {
            TestName.DEFAULT_INTERFACE_METHODS => new Default_Interface_Methods.Default_Interface_Methods_Test(),
            TestName.READONLY_MEMBERS => new Readonly_Members.Readonly_Members_Test(),
            TestName.SWITCH_EXPRESSIONS => new Switch_Expressions.Switch_Expressions_Test(),
            _ => throw new ArgumentException(message: "invalid test name", paramName: nameof(testName)),
        };
    }
}
