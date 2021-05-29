using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coursework.Models
{
    public class CampingTent : Tent
    {
        public string MosquitoNet { get; set; }

        public CampingTent(int id, string name, string producer, int price, int capacity, float weight, bool waterProof, float discount, string description, string mosquitoNet) :
            base(id, name, producer, price, capacity, weight, waterProof, discount, description)
        {
            MosquitoNet = mosquitoNet;
        }

        public CampingTent()
        {

        }

        public override string ToString()
        {
            return $"{Name}, {Producer}, {Price}, {Capacity}, {Weight}, {WaterProof}, {MosquitoNet}";
        }

        public override string ShowInfo()
        {
            return $"Mosquito net: {MosquitoNet}";
        }

        public override float CalculateDiscountByName(string name, int price)
        {
            float finalPrice = 0;
            if (name.ToLower().Contains("вася"))
            {
                finalPrice = price / 100 * Discount;
            }
            else
            {
                finalPrice = price * 10;
            }

            return finalPrice;
        }

        public override float CalculateDiscountByCorrectEmail(string email, int price)
        {
            float finalPrice = 0;
            //string nameToLower = name.ToLower();
            if (email.ToLower().Contains("@gmail.com"))
            {
                finalPrice = price / 100 * Discount;
            }
            else
            {
                finalPrice = price * 1.3f;
            }

            return finalPrice;
        }

        public override string ShowTentDescription()
        {
            return "Easy and fast installation";
        }
    }
}