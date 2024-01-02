using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
using Core.Specifications;

namespace Infrastructure.Services;

public class OrderService : IOrderService
{
    private readonly IBasketRepostory _basketRepostory;
    private readonly IUnitOfWork _unitOfWork;
    public OrderService(IBasketRepostory basketRepostory, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _basketRepostory = basketRepostory;
    }
    public async Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shippingAddress)
    {
        var basket = await _basketRepostory.GetBasketAsync(basketId);
        var items = new List<OrderItem>();
        foreach (var item in basket.Items)
        {
            var prodctItem = await _unitOfWork.Repository<Product>().GetByIdAsync(item.Id);
            var itemOrdered = new ProductItemOrdered(prodctItem.Id, prodctItem.Name, prodctItem.PictureUrl);
            var orderItem = new OrderItem(itemOrdered, prodctItem.Price, item.Quantity);
            items.Add(orderItem);
        }
        var deilveryMethod = await _unitOfWork.Repository<DeliveryMethod>().GetByIdAsync(deliveryMethodId);
        var subtotal = items.Sum(items => items.Price * items.Quantity);

        var order = new Order(items, buyerEmail, shippingAddress, deilveryMethod, subtotal);
        _unitOfWork.Repository<Order>().Add(order);

        var result = await _unitOfWork.Complete();

        if(result <= 0) return null;

        await _basketRepostory.DeleteBasketAsync(basketId);

        return order;
    }

    public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
    {
        return await _unitOfWork.Repository<DeliveryMethod>().ListAllAsync();
    }

    public async Task<IReadOnlyList<Order>> GetOdersForUserAsync(string buyerEmail)
    {
        var spec = new OrdersWithItemsAndOrderingSpecification(buyerEmail);
        return await _unitOfWork.Repository<Order>().ListAsync(spec);
    }

    public async Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
    {
        var spec = new OrdersWithItemsAndOrderingSpecification(id, buyerEmail);

        return await _unitOfWork.Repository<Order>().GetEntityWithSpec(spec);
    }
}
