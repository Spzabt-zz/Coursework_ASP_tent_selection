using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coursework.Models
{
    public class MountainHikingTent : Tent
    {
        public string VentilationSystem { get; set; }

        public MountainHikingTent(int id, string name, string producer, int price, int capacity, float weight, bool waterProof, float discount, string description, string ventilationSystem) :
            base(id, name, producer, price, capacity, weight, waterProof, discount, description)
        {
            VentilationSystem = ventilationSystem;
        }

        public MountainHikingTent()
        {

        }

        public override string ToString()
        {
            return $"{Name}, {Producer}, {Price}, {Capacity}, {Weight}, {WaterProof}, {VentilationSystem}";
        }

        public override string ShowInfo()
        {
            return $"Ventilation system: {VentilationSystem}";
        }

        public override float CalculateDiscountByName(string name, int price)
        {
            float finalPrice = 0;
            //string nameToLower = name.ToLower();
            if (name.ToLower().Contains("богдан"))
            {
                finalPrice = price / 100 * Discount;
            }
            else
            {
                finalPrice = price * 2;
            }

            return finalPrice;
        }

        public override float CalculateDiscountByCorrectEmail(string email, int price, ref float finalPrice)
        {
            //string nameToLower = name.ToLower();
            if (email.ToLower().Contains("@gmail.com"))
            {
                finalPrice = price / 100 * Discount;
            }
            else
            {
                finalPrice *= 1.3f;
            }

            return finalPrice;
        }

        public override string ShowTentDescription()
        {
            return "Seams: glued " +
                "Mosquito net: B3 No-see - um meshFrame " +
                "posts: Ø8.5 mm fiberglass reinforced - gray color(2 pcs.) " +
                "Pegs: metal(12 pcs.) " +
                "Locks: SBS " +
                "Clasps: plastic " +
                "Dimensions: sleeper 210 x 150 cm, height 115 cm";
        }
    }
}