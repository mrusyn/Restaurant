using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantCheckout.Tests
{
    public class RestaurantCheckoutService
    {
        private Dictionary<string, decimal> _menu = new Dictionary<string, decimal>();
        

        private const decimal ServiceChargePercentage = 0.10M;
        private const decimal DrinksDiscountPercentage = 0.30M;


        private decimal _bill = 0;

        public void CreateMenu(string item, decimal price)
        {
            _menu.Add(item, price);
        }



        public void CalculateTotalBill(Dictionary<string, int> orders, int timeVisit)
        {
            decimal totalBill = 0;

            foreach (var order in orders)
            {
                decimal itemPrice = _menu[order.Key];
                if (order.Key == "Drinks" && timeVisit < 19)
                {
                    
                    itemPrice = itemPrice * (1 - DrinksDiscountPercentage);
                }
                totalBill = totalBill + (itemPrice * order.Value);
            }

            totalBill = totalBill + (totalBill * ServiceChargePercentage);

            _bill = _bill + totalBill;

        }

        public decimal GetTotalBill() {
            return _bill;
            }

        public void SetTotalBillToZero()
        {
            _bill=0;
        }
    }
}
