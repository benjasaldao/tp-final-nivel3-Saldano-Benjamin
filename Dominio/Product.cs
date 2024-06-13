using System.ComponentModel;

namespace Domain
{
    public class Product
    {

        public int id {  get; set; }
        [DisplayName("Nombre")]
        public string name { get; set; }
        [DisplayName("Codigo")]
        public string code { get; set; }
        [DisplayName("Descripción")]
        public string description { get; set; }
        [DisplayName("Marca")]
        public Brand brand { get; set; }
        [DisplayName("Categoria")]
        public Category category { get; set; }
        public string imageUrl { get; set; }
        [DisplayName("Precio")]
        public decimal price { get; set; }

    }
}
