﻿using Merchello.Core;
using Merchello.Core.Cache;
using Merchello.Core.Checkout;
using Merchello.Core.Gateways.Payment;
using Merchello.Core.Models;
using Merchello.Core.Models.TypeFields;

namespace Merchello.Web.Workflow
{
    internal class BasketCheckout : CheckoutBase, IBasketCheckout 
    {
        internal BasketCheckout(IMerchelloContext merchelloContext, IItemCache itemCache, ICustomerBase customer) 
            : base(merchelloContext, itemCache, customer)
        { }

        internal static BasketCheckout GetBasketCheckout(IBasket basket)
        {
            return GetBasketCheckout(Core.MerchelloContext.Current, basket);
        }

        internal static BasketCheckout GetBasketCheckout(IMerchelloContext merchelloContext, IBasket basket)
        {
            throw new System.NotImplementedException();
        }

        //public override void CompleteCheckout(IPaymentGatewayProvider paymentGatewayProvider)
        //{
        //    throw new System.NotImplementedException();
        //}


        /// <summary>
        /// Generates a unique cache key for runtime caching of the <see cref="BasketCheckout"/>
        /// </summary>
        /// <param name="customer"><see cref="ICustomerBase"/></param>
        /// <returns>The unique CacheKey string</returns>
        /// <remarks>
        /// 
        /// CacheKey is assumed to be unique per customer and globally for CheckoutBase.  Therefore this will NOT be unique if 
        /// to different checkouts are happening for the same customer at the same time - we consider that an extreme edge case.
        /// 
        /// </remarks>
        private static string MakeCacheKey(ICustomerBase customer)
        {
            return CacheKeys.ItemCacheCacheKey(customer.EntityKey, EnumTypeFieldConverter.ItemItemCache.Checkout.TypeKey);
        }

    }
}