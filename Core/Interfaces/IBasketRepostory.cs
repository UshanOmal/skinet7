using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IBasketRepostory
    {
        Task<CustomerBasket> GetBasketAsync(string basketId);
        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);
        Task<bool> DeleteBasketAsync(string basketId);
    }
}