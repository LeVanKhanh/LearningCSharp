using System;

namespace Principes.Single_Responsibility.Incorrect
{
    /// <summary>
    /// Simple order model
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
