using Collections_Hackathon.Exceptions;
using Collections_Hackathon.Models;
using Collections_Hackathon.Repository;

namespace Collections_Hackathon
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var policyRepo = new PolicyRepository();

            while (true)
            {
                Console.WriteLine("\n<<< Insurance Policy Management >>>");
                Console.WriteLine("1. Add policy");
                Console.WriteLine("2. View all policies");
                Console.WriteLine("3. Search policy by ID");
                Console.WriteLine("4. Update policy");
                Console.WriteLine("5. Delete policy");
                Console.WriteLine("6. View active policies");
                Console.WriteLine("7. Exit");

                Console.Write("Enter your choice: ");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                try
                {
                    switch (choice)
                    {
                        case 1: AddPolicy(policyRepo); break;
                        case 2: ViewAllPolicies(policyRepo); break;
                        case 3: SearchPolicyById(policyRepo); break;
                        case 4: UpdatePolicy(policyRepo); break;
                        case 5: DeletePolicy(policyRepo); break;
                        case 6: ViewActivePolicies(policyRepo); break;
                        case 7: Console.WriteLine("Exiting..."); return;
                        default: Console.WriteLine("Invalid choice, please try again."); break;
                    }
                }
                catch (DuplicatePolicyException ex) { Console.WriteLine($"Error: {ex.Message}"); }
                catch (InvalidPolicyDateException ex) { Console.WriteLine($"Error: {ex.Message}"); }
                catch (PolicyNotFoundException ex) { Console.WriteLine($"Error: {ex.Message}"); }
                catch (Exception ex) { Console.WriteLine($"Unexpected Error: {ex.Message}"); }
            }
        }

        static void AddPolicy(PolicyRepository repo)
        {
            Console.Write("Enter policy ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter policy holder name: ");
            string name = Console.ReadLine();

            Console.Write("Enter policy type (Life, Health, Vehicle, Property): ");
            if (!Enum.TryParse(Console.ReadLine(), out PolicyType type))
            {
                Console.WriteLine("Invalid policy Type.");
                return;
            }

            Console.Write("Enter start date (yyyy-MM-dd): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter end date (yyyy-MM-dd): ");
            DateTime endDate = DateTime.Parse(Console.ReadLine());

            if (endDate <= startDate)
            {
                Console.WriteLine("End date must be after Start date.");
                return;
            }

            repo.AddPolicy(new Policy(id, name, type, startDate, endDate));
        }

        static void ViewAllPolicies(PolicyRepository repo)
        {
            var policies = repo.GetAllPolicies();
            if (policies.Count == 0) Console.WriteLine("No policies available.");
            else policies.ForEach(Console.WriteLine);
        }

        static void SearchPolicyById(PolicyRepository repo)
        {
            Console.Write("Enter Policy ID to search: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(repo.GetPolicyById(id));
        }

        static void UpdatePolicy(PolicyRepository repo)
        {
            Console.Write("Enter Policy ID to update: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter New Policy Holder Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter New Policy Type: ");
            PolicyType type = (PolicyType)Enum.Parse(typeof(PolicyType), Console.ReadLine());

            Console.Write("Enter New Start Date (yyyy-MM-dd): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter New End Date (yyyy-MM-dd): ");
            DateTime endDate = DateTime.Parse(Console.ReadLine());

            repo.UpdatePolicy(id, name, type, startDate, endDate);
        }

        static void DeletePolicy(PolicyRepository repo)
        {
            Console.Write("Enter Policy ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            repo.DeletePolicy(id);
        }

        static void ViewActivePolicies(PolicyRepository repo) => repo.GetActivePolicies().ForEach(Console.WriteLine);
    }


}
