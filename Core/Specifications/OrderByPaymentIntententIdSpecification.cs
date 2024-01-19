using System.Linq.Expressions;
using Core.Entities.OrderAggregate;

namespace Core.Specifications
{
    public class OrderByPaymentIntententIdSpecification : BaseSpecification<Order>
    {
        public OrderByPaymentIntententIdSpecification(string paymentIntentId)
        : base(o => o.PaymentIntentId == paymentIntentId)
        {
        }
    }
       
}