using Principes.Single_Responsibility.Incorrect;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Principes.Single_Responsibility.Correct
{
    public class OrderService
    {
        private readonly IDBContext _dBContext;
        public OrderService(IDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public int CreateWithoutValidate(Order order)
        {
            _dBContext.Add(order);
            return _dBContext.SaveChange();
        }

        public int ValidateThenCreate(Order order)
        {
            string messages;
            if (!IsValid(order, out messages))
            {
                throw new Exception(messages);
            }
            return CreateWithoutValidate(order);
        }

        public static bool IsValid(Order order, out string messages)
        {
            if (order == null)
            {
                messages = "Order is null";
                return false;
            }

            var errorMessages = new List<string>();
            if (order.OrderDate > DateTime.Now)
            {
                errorMessages.Add("Invalid Order Date");
            }

            if(order.OrderDate< order.DeliveryDate)
            {
                errorMessages.Add("Delivery Date should be equal or after Order Date");
            }

            messages = string.Join(Environment.NewLine, errorMessages);
            return errorMessages.Any();
        }
    }
}
