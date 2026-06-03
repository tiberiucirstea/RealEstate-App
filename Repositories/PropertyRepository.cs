using RealEstateAgency.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace RealEstateAgency.Repositories
{
    public class PropertyRepository
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["RealEstateAgencyDB"].ConnectionString;

        public List<Property> GetAll()
        {
            var results = new List<Property>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(
                    "SELECT Id, Type, Address, City, Area, Price, TransactionType, Status FROM Properties", connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        results.Add(new Property
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("Id")),
                            Type = (PropertyType)Enum.Parse(typeof(PropertyType), reader.GetString(reader.GetOrdinal("Type"))),
                            Address = reader.GetString(reader.GetOrdinal("Address")),
                            City = reader.GetString(reader.GetOrdinal("City")),
                            Area = reader.GetDouble(reader.GetOrdinal("Area")),
                            Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                            TransactionType = (TransactionType)Enum.Parse(typeof(TransactionType), reader.GetString(reader.GetOrdinal("TransactionType"))),
                            Status = (PropertyStatus)Enum.Parse(typeof(PropertyStatus), reader.GetString(reader.GetOrdinal("Status")))
                        });
                    }
                }
            }
            return results;
        }

        public void Add(Property property)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(
                    "INSERT INTO Properties (Id, Type, Address, City, Area, Price, TransactionType, Status) " +
                    "VALUES (@id, @type, @address, @city, @area, @price, @transactionType, @status)", connection))
                {
                    command.Parameters.AddWithValue("@id", property.Id);
                    command.Parameters.AddWithValue("@type", property.Type.ToString());
                    command.Parameters.AddWithValue("@address", property.Address);
                    command.Parameters.AddWithValue("@city", property.City);
                    command.Parameters.AddWithValue("@area", property.Area);
                    command.Parameters.AddWithValue("@price", property.Price);
                    command.Parameters.AddWithValue("@transactionType", property.TransactionType.ToString());
                    command.Parameters.AddWithValue("@status", property.Status.ToString());
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Property property)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(
                    "UPDATE Properties SET Type = @type, Address = @address, City = @city, " +
                    "Area = @area, Price = @price, TransactionType = @transactionType, Status = @status " +
                    "WHERE Id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", property.Id);
                    command.Parameters.AddWithValue("@type", property.Type.ToString());
                    command.Parameters.AddWithValue("@address", property.Address);
                    command.Parameters.AddWithValue("@city", property.City);
                    command.Parameters.AddWithValue("@area", property.Area);
                    command.Parameters.AddWithValue("@price", property.Price);
                    command.Parameters.AddWithValue("@transactionType", property.TransactionType.ToString());
                    command.Parameters.AddWithValue("@status", property.Status.ToString());
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateStatus(Guid id, PropertyStatus status)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("UPDATE Properties SET Status = @status WHERE Id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@status", status.ToString());
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("DELETE FROM Properties WHERE Id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
