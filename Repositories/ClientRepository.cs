using RealEstateAgency.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace RealEstateAgency.Repositories
{
    public class ClientRepository
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["RealEstateAgencyDB"].ConnectionString;

        public List<Client> GetAll()
        {
            var results = new List<Client>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT Id, LastName, FirstName, Phone, Email FROM Clients", connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        results.Add(new Client
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("Id")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            Phone = reader.GetString(reader.GetOrdinal("Phone")),
                            Email = reader.GetString(reader.GetOrdinal("Email"))
                        });
                    }
                }
            }
            return results;
        }

        public bool ExistsByEmailOrPhone(string email, string phone, Guid? excludeId = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT COUNT(*) FROM Clients WHERE (Email = @email OR Phone = @phone)";
                if (excludeId.HasValue)
                    query += " AND Id != @excludeId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@phone", phone);
                    if (excludeId.HasValue)
                        command.Parameters.AddWithValue("@excludeId", excludeId.Value);
                    return (int)command.ExecuteScalar() > 0;
                }
            }
        }

        public void Add(Client client)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(
                    "INSERT INTO Clients (Id, LastName, FirstName, Phone, Email) " +
                    "VALUES (@id, @lastName, @firstName, @phone, @email)", connection))
                {
                    command.Parameters.AddWithValue("@id", client.Id);
                    command.Parameters.AddWithValue("@lastName", client.LastName);
                    command.Parameters.AddWithValue("@firstName", client.FirstName);
                    command.Parameters.AddWithValue("@phone", client.Phone);
                    command.Parameters.AddWithValue("@email", client.Email);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Client client)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(
                    "UPDATE Clients SET LastName = @lastName, FirstName = @firstName, " +
                    "Phone = @phone, Email = @email WHERE Id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", client.Id);
                    command.Parameters.AddWithValue("@lastName", client.LastName);
                    command.Parameters.AddWithValue("@firstName", client.FirstName);
                    command.Parameters.AddWithValue("@phone", client.Phone);
                    command.Parameters.AddWithValue("@email", client.Email);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("DELETE FROM Clients WHERE Id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteWithRelatedData(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (var command = new SqlCommand(
                            "UPDATE Properties SET Status = @availableStatus " +
                            "WHERE Id IN (SELECT PropertyId FROM Offers WHERE ClientId = @id AND Status = @acceptedStatus)",
                            connection,
                            transaction))
                        {
                            command.Parameters.AddWithValue("@id", id);
                            command.Parameters.AddWithValue("@availableStatus", PropertyStatus.Available.ToString());
                            command.Parameters.AddWithValue("@acceptedStatus", OfferStatus.Accepted.ToString());
                            command.ExecuteNonQuery();
                        }

                        using (var command = new SqlCommand("DELETE FROM Offers WHERE ClientId = @id", connection, transaction))
                        {
                            command.Parameters.AddWithValue("@id", id);
                            command.ExecuteNonQuery();
                        }

                        using (var command = new SqlCommand("DELETE FROM Requests WHERE ClientId = @id", connection, transaction))
                        {
                            command.Parameters.AddWithValue("@id", id);
                            command.ExecuteNonQuery();
                        }

                        using (var command = new SqlCommand("DELETE FROM Clients WHERE Id = @id", connection, transaction))
                        {
                            command.Parameters.AddWithValue("@id", id);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
