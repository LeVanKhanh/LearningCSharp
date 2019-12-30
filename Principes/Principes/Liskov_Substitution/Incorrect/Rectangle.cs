using System;
using System.Collections.Generic;
using System.Text;

namespace Principes.Liskov_Substitution.Incorrect
{
    public class Rectangle
    {
        public virtual int Height { get; set; }
        public virtual int Width { get; set; }
    }
}
