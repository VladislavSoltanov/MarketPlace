using Shop2.Models.Image;

namespace Shop2.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Descriptons { get; set; }
        public int Quantitys { get; set; }
        //public string ProductCategory { get; set; }
        public byte[] ImageProduct { get; set; }

    }
}
