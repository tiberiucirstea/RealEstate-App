using System;

namespace RealEstate_App.Models
{
    public class Offer
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public Guid PropertyId { get; set; }
        public Property Property { get; set; }
        public DateTime OfferDate { get; set; }
        public OfferStatus Status { get; set; }

        public string ClientFullName
        {
            get { return Client.LastName + " " + Client.FirstName; }
        }

        public string PropertyDetails
        {
            get { return Property.Address + ", " + Property.City; }
        }
    }
}
