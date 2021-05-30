using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coursework.Models
{
    public class ExpeditionaryTent : Tent
    {
        public int RoomCount { get; set; }

        public ExpeditionaryTent(int id, string name, string producer, int price, int capacity, float weight, bool waterProof, float discount, string description, int roomCount) :
            base(id, name, producer, price, capacity, weight, waterProof, discount, description)
        {
            RoomCount = roomCount;
        }

        public ExpeditionaryTent()
        {

        }

        public override string ToString()
        {
            return $"{Name}, {Producer}, {Price}, {Capacity}, {Weight}, {WaterProof}, {RoomCount}";
        }

        public override string ShowInfo()
        {
            return $"Room count: {RoomCount}";
        }

        public override float CalculateDiscountByName(string name, int price)
        {
            float finalPrice = 0;
            if (name.ToLower().Contains("валера"))
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
            return "Ventilation system Vario Vent Kontrol " +
                "Anti - mosquito net at the entrance to the tent " +
                "All seams of the bottom and awning of the tent are glued with a special tape, " +
                "while guaranteeing protection against moisture penetration in rainy weather " +
                "Protective skirt from dirt " +
                "Bright red elements around the perimeter of the tent and in the tension cords improve orientation on the terrain, " +
                "in the dark To facilitate, quickly and correctly set up the tent, " +
                "the support arches are color-coded Pockets for small items " +
                "Flashlight mount";
        }
    }
}