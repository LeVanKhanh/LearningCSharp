using System;

namespace Principes.Single_Responsibility.Incorrect
{
    /// <summary>
    /// Simple Order service
    /// Do validation and Creation in the same method
    /// </summary>
    public class OrderService
    {
        private readonly IDBContext _dBContext;
        public OrderService(IDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public int Create(Order order)
        {
            #region validate
            //Check order object is null
            if (order == null)
            {
                throw new ArgumentNullException("order");
            }

            //Validate order date
            if (order.OrderDate > DateTime.Now)
            {
                throw new Exception("Invalid Order Date");
            }

            //Compare order date and delivery date
            if (order.OrderDate < order.DeliveryDate)
            {
                throw new Exception("Delivery Date should be equal or after Order Date");
            }
            #endregion

            _dBContext.Add(order);
            return _dBContext.SaveChange();
        }
    }
}
