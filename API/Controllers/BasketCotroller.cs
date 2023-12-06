
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
     public class BasketCotroller : BaseApiController
    {
        private readonly IBasketRepostory _basketRepostory;
        private readonly IMapper _mapper;

        public BasketCotroller(IBasketRepostory basketRepostory, IMapper mapper)
        {
            _mapper = mapper;
            _basketRepostory = basketRepostory;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
        {
            var basket = await _basketRepostory.GetBasketAsync(id);
            return Ok(basket?? new CustomerBasket(id));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasketDto basket)
        {
            var customerBasket = _mapper.Map<CustomerBasketDto, CustomerBasket>(basket);
            var updatedBasket = await _basketRepostory.UpdateBasketAsync(customerBasket);
            return Ok(updatedBasket);
        }

        [HttpDelete]
        public async Task DeleeBasketAsync (string id)
        {
            await _basketRepostory.DeleteBasketAsync(id);
        }

    }
}