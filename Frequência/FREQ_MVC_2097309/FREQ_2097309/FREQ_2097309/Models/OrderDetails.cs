using System.ComponentModel.DataAnnotations.Schema;

namespace FREQ_2097309.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public List<Product>? Products { get; set; }
        public int Amount { get; set; }
        public DateTime OrderDate { get; set; }

        [NotMapped]
        public virtual Product Product { get; set; }
    }
}
