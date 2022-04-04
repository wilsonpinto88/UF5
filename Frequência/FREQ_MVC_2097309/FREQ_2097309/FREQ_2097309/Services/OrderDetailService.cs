using FREQ_2097309.Models;
using Microsoft.EntityFrameworkCore;

namespace FREQ_2097309.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly StoreContext context;

        public OrderDetailService(StoreContext context)
        {
            this.context = context;
        }

        public IEnumerable<OrderDetails> GetAll()
        {
            var orders = context.OrderDetails
                .Include(p => p.Products);
            return orders;
        }

        public OrderDetails Create(OrderDetails newOrder)
        {
            Product prod = context.Products.Find(newOrder.Product!.Id)!;

            if (prod is null)
            {
                throw new NullReferenceException("Product does not exist");
            }
            else
            {
                newOrder.Product = prod;
                context.OrderDetails.Add(newOrder);
                context.SaveChanges();
                return newOrder;
            }
        }

        public void DeleteById(int id)
        {
            var orderToDelete = context.Products.Find(id);
            if (orderToDelete is not null)
            {
                context.Products.Remove(orderToDelete);
                context.SaveChanges();
            }

        }

        public OrderDetails? GetById(int id)
        {
            var order = context.OrderDetails
                .Include(b => b.Product)
                .SingleOrDefault(b => b.Id == id);
            return order;
        }

        public void Update(int id, OrderDetails order)
        {
            var orderToUpdate = context.OrderDetails.Find(id);
            if (orderToUpdate is null)
            {
            }
            else
            {
                Product prod = context.Products.Find(order.Product!.Id)!;
                orderToUpdate.Amount = order.Amount;
                if (prod != null) orderToUpdate.Product = prod;
                orderToUpdate.OrderDate = order.OrderDate;

                context.SaveChanges();
            }
        }

        public List<Product>? GetProducts()
        {
            var prods = context.OrderDetails
                .Include(p => p.Products);
            return prods as List<Product>;
        }

        public void UpdateAmount(int id, int productId)
        {
            var orderToUpdate = context.OrderDetails.Find(id);
            var productToUpdate = context.Products.Find(productId);

            if (orderToUpdate is null || productToUpdate is null)
            {
                throw new NullReferenceException("Order or Product does not exist");
            }

            orderToUpdate.Product = productToUpdate;

            context.SaveChanges();
        }
    }
}
