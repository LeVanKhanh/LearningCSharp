using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class ConcreteBuilder1 : Builder
    {
        private Product _product = new Product();

        public override void BuildPartA()
        {         
            _product.Add("PartA " + MyName());
        }

        public override void BuildPartB()
        {
            _product.Add("PartB " + MyName());
        }

        public override Product GetResult()
        {
            return _product;
        }

    }
}
