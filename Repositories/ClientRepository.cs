using RealEstateAgency.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RealEstateAgency.Repositories
{
    public class ClientRepository
    {
        private string _connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=RealEstateAgencyDB;Integrated Security=True";

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

        public List<Client> Search(string query)
        {
            var results = new List<Client>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(
                    "SELECT Id, LastName, FirstName, Phone, Email FROM Clients " +
                    "WHERE LastName LIKE @query OR FirstName LIKE @query OR Phone LIKE @query", connection))
                {
                    command.Parameters.AddWithValue("@query", "%" + query + "%");
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
    }
}
