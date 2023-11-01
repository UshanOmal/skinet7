
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
     public class BasketCotroller : BaseApiController
    {
        private readonly IBasketRepostory _basketRepostory;

        public BasketCotroller(IBasketRepostory basketRepostory)
        {
            _basketRepostory = basketRepostory;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
        {
            var basket = await _basketRepostory.GetBasketAsync(id);
            return Ok(basket?? new CustomerBasket(id));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket)
        {
            var updatedBasket = await _basketRepostory.UpdateBasketAsync(basket);
            return Ok(updatedBasket);
        }

        [HttpDelete]
        public async Task DeleeBasketAsync (string id)
        {
            await _basketRepostory.DeleteBasketAsync(id);
        }

    }
}