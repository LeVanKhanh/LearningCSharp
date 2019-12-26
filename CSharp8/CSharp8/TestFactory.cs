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
            TestName.PROPERTY_PATTERNS => new Property_Patterns.Property_Patterns_Test(),
            TestName.TUPLE_PATTERNS => new Tuple_Patterns.Tuple_Patterns_Test(),
            TestName.USING_DECLARATIONS => new Using_Declarations.Using_Declarations_Test(),
            TestName.POSITIONAL_PATTERNS => new Positional_Patterns.Positional_Patterns_Test(),
            TestName.STATIC_LOCAL_FUNCTION => new Static_Local_Functions.Static_Local_Functions_Test(),
            TestName.ASYNCHRONOUS_STREAMS => new Asynchronous_Streams.Asynchronous_Streams_Test(),
            TestName.INDICES_AND_RANGES => new Indices_And_Ranges.Indices_And_Ranges_Test(),
            TestName.NULL_COALESCING_ASSIGNMENT => new Null_Coalescing_Assignment.Null_Coalescing_Assignment_Test(),
            _ => throw new ArgumentException(message: "invalid test name", paramName: nameof(testName)),
        };
    }
}
