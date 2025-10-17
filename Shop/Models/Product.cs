namespace Shop.Models
{
    public class Product(int id, string name, decimal cost, string description )
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public string Description { get; set; } = description;
        public decimal Cost { get; set; } = cost;

        public string ImagePath { get; set; } = "/img/logo.jpg";
        
        

        public override string ToString()
        {
            return $"ID: {Id},Name: {Name}, Description: {Description}, Price: {Cost}";
            
        }
    }
}
