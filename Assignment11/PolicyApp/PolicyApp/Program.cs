using System;
using System.Collections.Generic;
using InsurancePolicyManagementApp.Model;
using InsurancePolicyManagementApp.Interface;
using InsurancePolicyManagementApp.Repository;
using InsurancePolicyManagementApp.Exceptions;

namespace InsurancePolicyManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=DESKTOP-03V0C0B;Database=InsuranceDB;Trusted_Connection=True;TrustServerCertificate=True;";
            IPolicyRepository policyRepository = new PolicyRepository(connectionString);

            while (true)
            {
                Console.Clear();
                DisplayMenu();

                switch (Console.ReadLine())
                {
                    case "1":
                        AddPolicy(policyRepository);
                        break;
                    case "2":
                        ViewAllPolicies(policyRepository);
                        break;
                    case "3":
                        SearchPolicy(policyRepository);
                        break;
                    case "4":
                        UpdatePolicy(policyRepository);
                        break;
                    case "5":
                        DeletePolicy(policyRepository);
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("Insurance Policy Management System");
            Console.WriteLine("1. Add New Policy");
            Console.WriteLine("2. View All Policies");
            Console.WriteLine("3. Search Policy by ID");
            Console.WriteLine("4. Update Policy");
            Console.WriteLine("5. Delete Policy");
            Console.WriteLine("6. Exit");
            Console.Write("\nEnter your choice: ");
        }

        static void AddPolicy(IPolicyRepository repository)
        {
            try
            {
                Console.WriteLine("\n--- Add New Policy ---");
                Console.Write("Enter Policy ID: ");
                int id = int.Parse(Console.ReadLine() ?? string.Empty);

                Console.Write("Enter Policy Holder Name: ");
                string name = Console.ReadLine() ?? string.Empty;

                Console.Write("Enter Policy Type (Life/Health/Vehicle/Property): ");
                if (!Enum.TryParse(Console.ReadLine(), true, out PolicyType type))
                {
                    Console.WriteLine("Invalid Policy Type!");
                    return;
                }

                Console.Write("Enter Start Date (yyyy-MM-dd): ");
                DateTime startDate = DateTime.Parse(Console.ReadLine() ?? string.Empty);

                Console.Write("Enter End Date (yyyy-MM-dd): ");
                DateTime endDate = DateTime.Parse(Console.ReadLine() ?? string.Empty);

                if (endDate <= startDate)
                {
                    Console.WriteLine("End date must be after start date!");
                    return;
                }

                var policy = new Policy(id, name, type, startDate, endDate);
                repository.AddPolicy(policy);
                Console.WriteLine("Policy added successfully!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ViewAllPolicies(IPolicyRepository repository)
        {
            try
            {
                Console.WriteLine("\n--- All Policies ---");
                List<Policy> policies = repository.GetAllPolicies();
                foreach (var policy in policies)
                {
                    Console.WriteLine(policy);
                    Console.WriteLine("---------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void SearchPolicy(IPolicyRepository repository)
        {
            try
            {
                Console.WriteLine("\n--- Search Policy ---");
                Console.Write("Enter Policy ID: ");
                int id = int.Parse(Console.ReadLine() ?? string.Empty);

                Policy policy = repository.GetPolicyById(id);
                Console.WriteLine("\nPolicy Found:");
                Console.WriteLine(policy);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid ID format!");
            }
            catch (PolicyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void UpdatePolicy(IPolicyRepository repository)
        {
            try
            {
                Console.WriteLine("\n--- Update Policy ---");
                Console.Write("Enter Policy ID to update: ");
                int id = int.Parse(Console.ReadLine() ?? string.Empty);

                Policy existingPolicy = repository.GetPolicyById(id);
                Console.WriteLine("\nCurrent Policy Details:");
                Console.WriteLine(existingPolicy);

                Console.WriteLine("\nEnter new details:");
                Console.Write("Policy Holder Name: ");
                string newName = Console.ReadLine() ?? existingPolicy.PolicyHolderName;

                Console.Write("Policy Type (Life/Health/Vehicle/Property): ");
                if (!Enum.TryParse(Console.ReadLine(), true, out PolicyType newType))
                {
                    newType = existingPolicy.Type;
                }

                Console.Write("Start Date (yyyy-MM-dd): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime newStart))
                {
                    newStart = existingPolicy.StartDate;
                }

                Console.Write("End Date (yyyy-MM-dd): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime newEnd))
                {
                    newEnd = existingPolicy.EndDate;
                }

                if (newEnd <= newStart)
                {
                    Console.WriteLine("End date must be after start date!");
                    return;
                }

                Policy updatedPolicy = new Policy(id, newName, newType, newStart, newEnd);
                repository.UpdatePolicy(updatedPolicy);
                Console.WriteLine("Policy updated successfully!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format!");
            }
            catch (PolicyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void DeletePolicy(IPolicyRepository repository)
        {
            try
            {
                Console.WriteLine("\n--- Delete Policy ---");
                Console.Write("Enter Policy ID to delete: ");
                int id = int.Parse(Console.ReadLine() ?? string.Empty);

                Console.Write("Are you sure you want to delete this policy? (Y/N): ");
                if (Console.ReadLine()?.Trim().ToUpper() != "Y")
                {
                    Console.WriteLine("Deletion canceled.");
                    return;
                }

                repository.DeletePolicy(id);
                Console.WriteLine("Policy deleted successfully!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid ID format!");
            }
            catch (PolicyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}