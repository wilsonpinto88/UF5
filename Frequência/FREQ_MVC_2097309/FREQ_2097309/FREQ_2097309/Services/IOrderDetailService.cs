using FREQ_2097309.Models;

namespace FREQ_2097309.Services
{
    public interface IOrderDetailService
    {
        public abstract IEnumerable<OrderDetails> GetAll();
        public abstract OrderDetails Create(OrderDetails newOrder);
        public abstract void DeleteById(int id);
        public abstract OrderDetails? GetById(int id);
        public abstract void Update(int id, OrderDetails orderDetails);
        public abstract List<Product>? GetProducts();
        public abstract void UpdateAmount(int id, int productId);
    }
}
