using RealEstate_App;
using System;

namespace RealEstate_App.Models
{
    public class Property
    {
        public Guid Id { get; set; }
        public PropertyType Type { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public double Area { get; set; }
        public decimal Price { get; set; }
        public TransactionType TransactionType { get; set; }
        public PropertyStatus Status { get; set; }
    }
}
