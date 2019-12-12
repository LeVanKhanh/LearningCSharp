using System;
using System.Collections.Generic;
using System.Drawing;

namespace CSharp8.Readonly_Members
{
    public struct StructExample
    {
        public Dictionary<string, int> _store;
        
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

        public readonly int Prop2
        {
            get
            {
                return _store["Prop2"];
            }
            set
            {
                _store["Prop2"] = value;
            }
        }

        public int Prop3
        {
            readonly get
            {
                return _store["Prop3"];
            }
            set
            {
                _store["Prop3"] = value;
            }
        }

        // Allowed
        public readonly int Prop4 { get; }
        //public int Prop5 { readonly get; }
        public int Prop6 { readonly get; set; }

        // Not allowed
        //public readonly int Prop7 { get; set; }
        //public int Prop8 { get; readonly set; }

        // Allowed
        public readonly event Action<EventArgs> Event1
        {
            add { }
            remove { }
        }

        // Not allowed
        //public readonly event Action<EventArgs> Event2;
        //public event Action<EventArgs> Event3
        //{
        //    readonly add { }
        //    readonly remove { }
        //}

        //public static readonly event Event4
        //{
        //    add { }
        //    remove { }
        //}

        readonly public int Counter
        {
            get { return _store.Count; }
            set { } // not useful, but legal
        }

        private static readonly Point origin = new Point(0, 0);
        public static ref readonly Point Origin => ref origin;

    }
}
