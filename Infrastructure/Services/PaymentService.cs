
using Core.Entities;
using Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Stripe;

namespace Infrastructure.Services;

public class PaymentService(IConfiguration config,
                            ICartService cartService,
                            IGenericRepository<DeliveryMethod> dmRepo,
                            IGenericRepository<Core.Entities.Product> productRepo) : IPaymentService
{
    public async Task<ShoppingCart> CreateOrUpdatePaymentIntentAsync(string cartId)
    {

        //Load Stripe API Key
        StripeConfiguration.ApiKey = config["StripeSettings:SecretKey"];

        //Get the user's shopping cart
        var cart = await cartService.GetCartAsync(cartId);

        if (cart == null) return null;


        //Calculate shipping price
        var shippingPrice = 0m;

        if (cart.DeliveryMethodId.HasValue)
        {
            var deliveryMethod = await dmRepo.GetByIdAsync((int)cart.DeliveryMethodId);

            if (deliveryMethod == null) return null;
            
            shippingPrice = deliveryMethod.Price;
        }


        //Validate product prices from the cart against the product prices in the database
        foreach (var item in cart.Items)
        {
            var productItem = await productRepo.GetByIdAsync(item.ProductId);

            if (productItem == null) return null;

            if (item.Price != productItem.Price)
            {
                item.Price = productItem.Price;
            }
        }

        //Create Stripe PaymentIntent service
        var service = new PaymentIntentService();

        PaymentIntent? intent = null;

        //Create a new PaymentIntent
        if (string.IsNullOrEmpty(cart.PaymentIntentId))
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = (long)cart.Items.Sum(i => i.Quantity * (i.Price * 100)) + (long)shippingPrice * 100,
                Currency = "usd",
                PaymentMethodTypes = ["card"]
            };
            intent = await service.CreateAsync(options);
            cart.PaymentIntentId = intent.Id;
            cart.ClientSecret = intent.ClientSecret;
        }
        //Update existing PaymentIntent
        else
        {
            var options = new PaymentIntentUpdateOptions
            {
                Amount = (long)cart.Items.Sum(i => i.Quantity * (i.Price * 100)) + (long)shippingPrice * 100,
            };
            intent = await service.UpdateAsync(cart.PaymentIntentId, options);
        }

        await cartService.SetCartAsync(cart);

        return cart;

    }
}
