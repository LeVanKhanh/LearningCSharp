using System;
using System.Collections.Generic;
using System.Text;

namespace Principes.Single_Responsibility.Incorrect
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
