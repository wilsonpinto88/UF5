using FREQ_2097309.Models;

namespace FREQ_2097309.Data
{
    public static class StoreDBInitializer
    {
        public static void InsertData(StoreContext context)
        {
            context.OrderDetails.Add(new OrderDetails
            {
                Id = 1,
                Amount = 50,
                OrderDate = DateTime.Now,
                Product =
                {
                    Name = "Coral",
                    Description = "Alcoholic beverage",
                    Price = 453.00,
                    Stock = 5000
                }
            });
            context.OrderDetails.Add(new OrderDetails
            {
                Id = 2,
                Amount = 30,
                OrderDate = DateTime.Now,
                Product =
                {
                    Name = "Banana",
                    Description = "Fruit",
                    Price = 143.65,
                    Stock = 500
                }
            });
            context.OrderDetails.Add(new OrderDetails
            {
                Id = 3,
                Amount = 10,
                OrderDate = DateTime.Now,
                Product =
                {
                    Name = "Pork",
                    Description = "Meat",
                    Price = 536.05,
                    Stock = 50
                }
            });
        }
    }
}
