using RealEstate_App.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RealEstate_App.Repositories
{
    public class OfferRepository
    {
        private string _connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=RealEstateAppDB;Integrated Security=True";

        public List<Offer> GetAll()
        {
            var results = new List<Offer>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(
                    "SELECT o.Id, o.ClientId, o.PropertyId, o.OfferDate, o.Status, " +
                    "c.LastName, c.FirstName, c.Phone, c.Email, " +
                    "p.Type, p.Address, p.City, p.Area, p.Price, p.TransactionType, p.Status AS PropertyStatus " +
                    "FROM Offers o " +
                    "INNER JOIN Clients c ON o.ClientId = c.Id " +
                    "INNER JOIN Properties p ON o.PropertyId = p.Id", connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var offer = new Offer
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("Id")),
                            ClientId = reader.GetGuid(reader.GetOrdinal("ClientId")),
                            PropertyId = reader.GetGuid(reader.GetOrdinal("PropertyId")),
                            OfferDate = reader.GetDateTime(reader.GetOrdinal("OfferDate")),
                            Status = (OfferStatus)Enum.Parse(typeof(OfferStatus), reader.GetString(reader.GetOrdinal("Status")))
                        };
                        offer.Client = new Client
                        {
                            Id = offer.ClientId,
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            Phone = reader.GetString(reader.GetOrdinal("Phone")),
                            Email = reader.GetString(reader.GetOrdinal("Email"))
                        };
                        offer.Property = new Property
                        {
                            Id = offer.PropertyId,
                            Type = (PropertyType)Enum.Parse(typeof(PropertyType), reader.GetString(reader.GetOrdinal("Type"))),
                            Address = reader.GetString(reader.GetOrdinal("Address")),
                            City = reader.GetString(reader.GetOrdinal("City")),
                            Area = reader.GetDouble(reader.GetOrdinal("Area")),
                            Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                            TransactionType = (TransactionType)Enum.Parse(typeof(TransactionType), reader.GetString(reader.GetOrdinal("TransactionType"))),
                            Status = (PropertyStatus)Enum.Parse(typeof(PropertyStatus), reader.GetString(reader.GetOrdinal("PropertyStatus")))
                        };
                        results.Add(offer);
                    }
                }
            }
            return results;
        }

        public void Add(Offer offer)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(
                    "INSERT INTO Offers (Id, ClientId, PropertyId, OfferDate, Status) " +
                    "VALUES (@id, @clientId, @propertyId, @date, @status)", connection))
                {
                    command.Parameters.AddWithValue("@id", offer.Id);
                    command.Parameters.AddWithValue("@clientId", offer.ClientId);
                    command.Parameters.AddWithValue("@propertyId", offer.PropertyId);
                    command.Parameters.AddWithValue("@date", offer.OfferDate);
                    command.Parameters.AddWithValue("@status", offer.Status.ToString());
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Offer offer)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(
                    "UPDATE Offers SET ClientId = @clientId, PropertyId = @propertyId, " +
                    "OfferDate = @date, Status = @status WHERE Id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", offer.Id);
                    command.Parameters.AddWithValue("@clientId", offer.ClientId);
                    command.Parameters.AddWithValue("@propertyId", offer.PropertyId);
                    command.Parameters.AddWithValue("@date", offer.OfferDate);
                    command.Parameters.AddWithValue("@status", offer.Status.ToString());
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("DELETE FROM Offers WHERE Id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
