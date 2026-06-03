namespace RealEstate_App
{
    public enum PropertyType
    {
        Apartment,
        House,
        CommercialSpace
    }

    public enum TransactionType
    {
        Sale,
        Rental
    }

    public enum RequestStatus
    {
        Active,
        Resolved,
        Cancelled
    }

    public enum OfferStatus
    {
        Proposed,
        Accepted,
        Rejected
    }

    public enum PropertyStatus
    {
        Available,
        Sold,
        Rented
    }
}
