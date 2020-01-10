using System;

namespace Principes.Single_Responsibility.Incorrect
{
    public class OrderService
    {
        private readonly IDBContext _dBContext;
        public OrderService(IDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public int Create(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException("order");
            }

            if (order.OrderDate > DateTime.Now)
            {
                throw new Exception("Invalid Order Date");
            }

            if (order.OrderDate < order.DeliveryDate)
            {
                throw new Exception("Delivery Date should be equal or after Order Date");
            }

            _dBContext.Add(order);
            return _dBContext.SaveChange();
        }
    }
}
