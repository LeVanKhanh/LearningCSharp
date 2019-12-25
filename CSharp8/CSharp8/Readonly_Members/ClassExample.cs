using System.Collections.Generic;

namespace CSharp8.Readonly_Members
{
    public class ClassExample
    {
        public Dictionary<string, int> _store;

        public ClassExample()
        {
            _store = new Dictionary<string, int>();
        }

        //public int Prop1
        //{
        //    readonly get
        //    {
        //        return _store["Prop1"];
        //    }
        //    readonly set
        //    {
        //        _store["Prop1"] = value;
        //    }
        //}

        //public readonly int Prop2
        //{
        //    get
        //    {
        //        return _store["Prop2"];
        //    }
        //    set
        //    {
        //        _store["Prop2"] = value;
        //    }
        //}

        //public int Prop3
        //{
        //    readonly get
        //    {
        //        return _store["Prop2"];
        //    }
        //    set
        //    {
        //        _store["Prop2"] = value;
        //    }
        //}
    }
}
