using InsurancePolicyManagementApp.Interface;
using InsurancePolicyManagementApp.Model;
using InsurancePolicyManagementApp.Exceptions;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace InsurancePolicyManagementApp.Repository
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly string connectionString;

        public PolicyRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddPolicy(Policy policy)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var checkCmd = new SqlCommand(
                        "SELECT COUNT(*) FROM Policies WHERE PolicyID = @id",
                        connection);
                    checkCmd.Parameters.AddWithValue("@id", policy.PolicyID);

                    if ((int)checkCmd.ExecuteScalar() > 0)
                    {
                        throw new ArgumentException("Policy ID already exists.");
                    }

                    var insertCmd = new SqlCommand(
                        "INSERT INTO Policies (PolicyID, PolicyHolderName, PolicyType, StartDate, EndDate) " +
                        "VALUES (@id, @name, @type, @start, @end)",
                        connection);

                    insertCmd.Parameters.AddWithValue("@id", policy.PolicyID);
                    insertCmd.Parameters.AddWithValue("@name", policy.PolicyHolderName);
                    insertCmd.Parameters.AddWithValue("@type", policy.Type.ToString());
                    insertCmd.Parameters.AddWithValue("@start", policy.StartDate);
                    insertCmd.Parameters.AddWithValue("@end", policy.EndDate);

                    insertCmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Database error: " + ex.Message);
                }
            }
        }

        public List<Policy> GetAllPolicies()
        {
            var policies = new List<Policy>();
            using (var connection = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("SELECT * FROM Policies", connection);
                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        policies.Add(new Policy(
                            (int)reader["PolicyID"],
                            reader["PolicyHolderName"].ToString(),
                            (PolicyType)Enum.Parse(typeof(PolicyType), reader["PolicyType"].ToString()),
                            (DateTime)reader["StartDate"],
                            (DateTime)reader["EndDate"]
                        ));
                    }
                }
            }
            return policies;
        }

        public Policy GetPolicyById(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmd = new SqlCommand(
                    "SELECT * FROM Policies WHERE PolicyID = @id",
                    connection);
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Policy(
                            (int)reader["PolicyID"],
                            reader["PolicyHolderName"].ToString(),
                            (PolicyType)Enum.Parse(typeof(PolicyType), reader["PolicyType"].ToString()),
                            (DateTime)reader["StartDate"],
                            (DateTime)reader["EndDate"]
                        );
                    }
                }
            }
            throw new PolicyNotFoundException($"Policy with ID {id} not found.");
        }

        public void UpdatePolicy(Policy policy)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmd = new SqlCommand(
                    "UPDATE Policies SET " +
                    "PolicyHolderName = @name, " +
                    "PolicyType = @type, " +
                    "StartDate = @start, " +
                    "EndDate = @end " +
                    "WHERE PolicyID = @id",
                    connection);

                cmd.Parameters.AddWithValue("@name", policy.PolicyHolderName);
                cmd.Parameters.AddWithValue("@type", policy.Type.ToString());
                cmd.Parameters.AddWithValue("@start", policy.StartDate);
                cmd.Parameters.AddWithValue("@end", policy.EndDate);
                cmd.Parameters.AddWithValue("@id", policy.PolicyID);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new PolicyNotFoundException($"Policy with ID {policy.PolicyID} not found.");
                }
            }
        }

        public void DeletePolicy(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmd = new SqlCommand(
                    "DELETE FROM Policies WHERE PolicyID = @id",
                    connection);
                cmd.Parameters.AddWithValue("@id", id);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new PolicyNotFoundException($"Policy with ID {id} not found.");
                }
            }
        }
    }
}