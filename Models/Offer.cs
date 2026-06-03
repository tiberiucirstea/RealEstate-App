using System;

namespace RealEstateAgency.Models
{
    public class Offer
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public string ClientFullName => Client.LastName + " " + Client.FirstName;
        public Guid PropertyId { get; set; }
        public Property Property { get; set; }
        public string PropertyDetails => Property.Address + ", " + Property.City;
        public DateTime OfferDate { get; set; }
        public OfferStatus Status { get; set; }
    }
}
