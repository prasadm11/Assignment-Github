using Task2.Model;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Events events = new Events();

            events.RegisterForWDWorkshop(1684, new Student("Pranit", "BE"));
            events.RegisterForWDWorkshop(1685, new Student("Krishna", "BE"));
            events.RegisterForWDWorkshop(1686, new Student("Prashant", "BE"));
            events.RegisterForWDWorkshop(1685, new Student("Sumit", "BE"));
            events.RegisterForWDWorkshop(1687, new Student("Kapil", "BE"));

            events.DisplayStudentListOfWDWorkshop();

            events.RegisterForUIUXWorkshop(1685, new Student("Sumit", "BE"));
            events.RegisterForUIUXWorkshop(1684, new Student("Pranit", "BE"));
            events.RegisterForUIUXWorkshop(1685, new Student("Krishna", "BE"));
            events.RegisterForUIUXWorkshop(1686, new Student("Prashant", "BE"));
            events.RegisterForUIUXWorkshop(1687, new Student("Kapil", "BE"));

            events.DisplayStudentListOfUIUXWorkshop();


            events.RegisterForRoboticsAutomationWorkshop(1687, new Student("Kapil", "BE"));
            events.RegisterForRoboticsAutomationWorkshop(1684, new Student("Pranit", "BE"));
            events.RegisterForRoboticsAutomationWorkshop(1685, new Student("Krishna", "BE"));
            events.RegisterForRoboticsAutomationWorkshop(1686, new Student("Prashant", "BE"));
            events.RegisterForRoboticsAutomationWorkshop(1685, new Student("Sumit", "BE"));

            events.DisplayStudentListOfRoboticsAutomationWorkshop();
        }
    }
}
