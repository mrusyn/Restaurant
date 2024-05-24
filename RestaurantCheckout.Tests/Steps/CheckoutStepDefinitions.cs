using NUnit.Framework;
using TechTalk.SpecFlow;

namespace RestaurantCheckout.Tests.Steps
{
    [Binding]
    public class CheckoutStepDefinitions
    {

        private readonly RestaurantCheckoutService _restaurantCheckout = new RestaurantCheckoutService();
        private decimal _bill;
        Dictionary<string, int> _orders;

        [When(@"There is a group of people orders meals at (.*):")]
        public void WhenThereIsAGroupOfPeopleOrdersMealsAt(int time, Table table)
        {
            _orders = new Dictionary<string, int>();

            foreach (var row in table.Rows)
            {
                var item = row["MenuItem"];
                var quantity = int.Parse(row["Quantity"]);
                _orders.Add(item, quantity);

            }
             _restaurantCheckout.CalculateTotalBill(_orders, time);
 
        }

        [When(@"A member of the group cancels order:")]
        public void WhenAMemberOfTheGroupCancelsOrder(Table table)
        {
            var _ordersCanceled = new Dictionary<string, int>();

            foreach (var row in table.Rows)
            {
                var item = row["MenuItem"];
                var quantity = int.Parse(row["Quantity"]);
                _ordersCanceled.Add(item, quantity);

            }

            var _ordersFinal = new Dictionary<string, int>();

            foreach (var canceledOrder in _ordersCanceled)
            {
                var canceledItem = canceledOrder.Key;
                var canceledQuantity = canceledOrder.Value;

                _orders[canceledItem] -= canceledQuantity;

                               
            }
            _restaurantCheckout.SetTotalBillToZero();

            _restaurantCheckout.CalculateTotalBill(_orders, 20);
            
        }

        [Given(@"A list of menu prices:")]
        public void GivenAListOfMenuPrices(Table table)
        {
            foreach (var row in table.Rows)
            {
                var item = row["MenuItem"];
                var price = decimal.Parse(row["Price"]);
                _restaurantCheckout.CreateMenu(item, price);
            }
        }

        [Then(@"The final bill should be (.*)")]
        public void ThenTheFinalBillShouldBe(decimal expectedBill)
        {
            _bill = _restaurantCheckout.GetTotalBill();

            Assert.AreEqual(expectedBill, _bill);
        }

 
     }
}
