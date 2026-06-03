using RealEstateAgency.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace RealEstateAgency.Repositories
{
    public class RequestRepository
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["RealEstateAgencyDB"].ConnectionString;

        public List<Request> GetAll()
        {
            var results = new List<Request>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(
                    "SELECT r.Id, r.ClientId, r.PropertyType, r.TransactionType, r.MaxBudget, " +
                    "r.City, r.Status, r.RequestDate, " +
                    "c.LastName, c.FirstName, c.Phone, c.Email " +
                    "FROM Requests r " +
                    "INNER JOIN Clients c ON r.ClientId = c.Id", connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var request = new Request
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("Id")),
                            ClientId = reader.GetGuid(reader.GetOrdinal("ClientId")),
                            PropertyType = (PropertyType)Enum.Parse(typeof(PropertyType), reader.GetString(reader.GetOrdinal("PropertyType"))),
                            TransactionType = (TransactionType)Enum.Parse(typeof(TransactionType), reader.GetString(reader.GetOrdinal("TransactionType"))),
                            MaxBudget = reader.GetDecimal(reader.GetOrdinal("MaxBudget")),
                            City = reader.GetString(reader.GetOrdinal("City")),
                            Status = (RequestStatus)Enum.Parse(typeof(RequestStatus), reader.GetString(reader.GetOrdinal("Status"))),
                            RequestDate = reader.GetDateTime(reader.GetOrdinal("RequestDate"))
                        };
                        request.Client = new Client
                        {
                            Id = request.ClientId,
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            Phone = reader.GetString(reader.GetOrdinal("Phone")),
                            Email = reader.GetString(reader.GetOrdinal("Email"))
                        };
                        results.Add(request);
                    }
                }
            }
            return results;
        }

        public void Add(Request request)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(
                    "INSERT INTO Requests (Id, ClientId, PropertyType, TransactionType, MaxBudget, City, Status, RequestDate) " +
                    "VALUES (@id, @clientId, @propertyType, @transactionType, @maxBudget, @city, @status, @date)", connection))
                {
                    command.Parameters.AddWithValue("@id", request.Id);
                    command.Parameters.AddWithValue("@clientId", request.ClientId);
                    command.Parameters.AddWithValue("@propertyType", request.PropertyType.ToString());
                    command.Parameters.AddWithValue("@transactionType", request.TransactionType.ToString());
                    command.Parameters.AddWithValue("@maxBudget", request.MaxBudget);
                    command.Parameters.AddWithValue("@city", request.City);
                    command.Parameters.AddWithValue("@status", request.Status.ToString());
                    command.Parameters.AddWithValue("@date", request.RequestDate);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Request request)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(
                    "UPDATE Requests SET ClientId = @clientId, PropertyType = @propertyType, " +
                    "TransactionType = @transactionType, MaxBudget = @maxBudget, City = @city, " +
                    "Status = @status, RequestDate = @date WHERE Id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", request.Id);
                    command.Parameters.AddWithValue("@clientId", request.ClientId);
                    command.Parameters.AddWithValue("@propertyType", request.PropertyType.ToString());
                    command.Parameters.AddWithValue("@transactionType", request.TransactionType.ToString());
                    command.Parameters.AddWithValue("@maxBudget", request.MaxBudget);
                    command.Parameters.AddWithValue("@city", request.City);
                    command.Parameters.AddWithValue("@status", request.Status.ToString());
                    command.Parameters.AddWithValue("@date", request.RequestDate);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("DELETE FROM Requests WHERE Id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
