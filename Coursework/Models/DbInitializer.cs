using System.Data.Entity;

namespace Coursework.Models
{
    public class DbInitializer : DropCreateDatabaseAlways<TentContext>
    {
        protected override void Seed(TentContext context)
        {
            /*context.Tents.Add(new Tent() {Name = "Mousson Link 2", Price = 1799, Producer = "Mousson"});
            context.Tents.Add(new Tent() {Name = "High Peak Kira 5", Price = 3999, Producer = "High Peak"});
            context.Tents.Add(new Tent() {Name = "Terra Incognita Alfa 2", Price = 2419, Producer = "Terra Incognita"});*/
            Tent[] tents = new Tent[]
            {
                new MountainHikingTent() {Name = "Mousson Link 2", Price = 1799, Producer = "Mousson", Capacity = 3, Weight = 5.5f, WaterProof = true, Discount = 15.0f, VentilationSystem = "Vario Vent Kontrol"},
                new ExpeditionaryTent() { Name = "High Peak Kira 5", Price = 3999, Producer = "High Peak", Capacity = 2, Weight = 4.5f, WaterProof = false, Discount = 20.0f, RoomCount = 3},
                new CampingTent() { Name = "Terra Incognita Alfa 2", Price = 2419, Producer = "Terra Incognita", Capacity = 4, Weight = 6.8f, WaterProof = true, Discount = 5.0f, MosquitoNet = "B3 No-see-um mesh"}
            };

            //context.Tents.Add(new MountainHikingTent() { Name = "Mousson Link 2", Price = 1799, Producer = "Mousson", Capacity = 3, Weight = 5.5f, WaterProof = true });
            foreach (var tent in tents)
            {
                context.Tents.Add(tent);
            }

            base.Seed(context);
        }
    }
}