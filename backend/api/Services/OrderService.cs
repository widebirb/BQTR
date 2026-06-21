using System;
using System.Collections.Generic;
using System.Linq;

namespace api.Services
{
    public class OrderItem
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public class OrderService
    {
        private const decimal LoyaltyDiscountThreshold = 100m;
        private const decimal LoyaltyDiscountRate = 0.10m; // 10% off

        // Calculates the subtotal for a list of order items
        public decimal CalculateSubtotal(List<OrderItem> items)
        {
            return items.Sum(item => item.Price * item.Quantity);
        }

        // Applies a 10% discount if the subtotal is over the threshold
        public decimal ApplyDiscount(decimal subtotal)
        {
            if (subtotal > LoyaltyDiscountThreshold)
            {
                return subtotal - (subtotal * LoyaltyDiscountRate);
            }

            return subtotal;
        }

        // Calculates the final total: subtotal minus discount
        public decimal CalculateTotal(List<OrderItem> items)
        {
            decimal subtotal = CalculateSubtotal(items);
            return ApplyDiscount(subtotal);
        }
    }
}