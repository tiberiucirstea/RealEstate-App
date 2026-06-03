using RealEstate_App;
using RealEstate_App.Models;
using System;

namespace RealEstate_App.Models
{
    public class Request
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public PropertyType PropertyType { get; set; }
        public TransactionType TransactionType { get; set; }
        public decimal MaxBudget { get; set; }
        public string City { get; set; }
        public RequestStatus Status { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
