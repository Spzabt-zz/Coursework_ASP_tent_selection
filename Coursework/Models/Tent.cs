namespace Coursework.Models
{
    public abstract class Tent
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Producer { get; set; }

        public int Price { get; set; }

        public int Capacity { get; set; }

        public float Weight { get; set; }

        public bool WaterProof { get; set; }

        public float Discount { get; set; }

        public string Description { get; set; }

        public Tent(int id, string name, string producer, int price, int capacity, float weight, bool waterProof, float discount, string description)
        {
            Id = id;
            Name = name;
            Producer = producer;
            Price = price;
            Capacity = capacity;
            Weight = weight;
            WaterProof = waterProof;
            Discount = discount;
            Description = description;
        }

        public Tent()
        {

        }

        public abstract string ShowInfo();

        public abstract float CalculateDiscountByName(string name, int price);

        public abstract float CalculateDiscountByCorrectEmail(string email, int price, ref float finalPrice);

        public abstract string ShowTentDescription();
    }
}