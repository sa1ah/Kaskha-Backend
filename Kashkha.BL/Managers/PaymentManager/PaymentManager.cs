using Kashkha.DAL;
using Kashkha.DAL.Models;
using Stripe;
using Stripe.Checkout;
using System.Security.Claims;

public class PaymentManager
{
    private readonly IOrderRepository _orderRepository;
    public PaymentManager(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
        
    }


    public async Task<Session> CreateCheckoutSessionAsync(int orderId, string userId)
    {
        var order = _orderRepository.GetOrderById(userId,  orderId);
        var lineItems = new List<SessionLineItemOptions>();

        
            lineItems.Add(new SessionLineItemOptions
        {
            PriceData = new SessionLineItemPriceDataOptions
            {
                UnitAmount = (long)(order.TotalPrice * 100), 
                Currency = "usd",
                //ProductData = new SessionLineItemPriceDataProductDataOptions
                //{
                //    Name =order.Id,
                //},
            },
            //Quantity = order.,
        });
    

    var options = new SessionCreateOptions
    {
        PaymentMethodTypes = new List<string> { "card" },
        LineItems = lineItems,
        Mode = "payment",
        SuccessUrl = "https://localhost:5001/api/payment/success?orderId=" + order.Id,
        CancelUrl = "https://localhost:5001/api/payment/cancel?orderId=" + order.Id,
    };

    var service = new SessionService();
    return await service.CreateAsync(options);
}
}