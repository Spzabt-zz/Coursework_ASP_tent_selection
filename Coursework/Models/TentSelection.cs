using System;

namespace Coursework.Models
{
    public class TentSelection
    {
        public int TentSelectionId { get; set; }
        
        public DateTime DateTime { get; set; }

        public string Email { get; set; }

        public string Fio { get; set; }
        
        public string Address { get; set; }

        public string SelectedItem { get; set; }

        public float TentSelectionDiscount { get; set; }

        public int TentId { get; set; }
    }
}