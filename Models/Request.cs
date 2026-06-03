using RealEstateAgency;
using System;

namespace RealEstateAgency.Models
{
    public class Request
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public string ClientFullName => Client.LastName + " " + Client.FirstName;
        public PropertyType PropertyType { get; set; }
        public TransactionType TransactionType { get; set; }
        public decimal MaxBudget { get; set; }
        public string City { get; set; }
        public DateTime RequestDate { get; set; }
        public RequestStatus Status { get; set; }
    }
}
