using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskThread2
{
    public class Order
    {
        public Order(uint custromerId, uint productId, uint totalSum, uint expenses, DateTime createDateTime, DateTime finishDateTime, Status orderStatus)
        {
            CustromerId = custromerId;
            ProductId = productId;
            TotalSum = totalSum;
            Expenses = expenses;
            CreateDateTime = createDateTime;
            FinishDateTime = finishDateTime;
            OrderStatus = orderStatus;

            if (CreateDateTime.Ticks > FinishDateTime.Ticks)
            {
                var temp = CreateDateTime;
                CreateDateTime = FinishDateTime;
                FinishDateTime = temp;
            }
        }

        public uint CustromerId { get; private set; }
        public uint ProductId { get; private set; }
        public uint TotalSum { get; private set; }
        public uint Expenses { get; private set; }
        public DateTime CreateDateTime { get; private set; }
        public DateTime FinishDateTime { get; private set; }
        public Status OrderStatus { get; private set; }

    }
    public enum Status
    {
        Confirmed = 0,
        Rejected

    }

}
