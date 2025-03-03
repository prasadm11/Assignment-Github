
namespace Task2.Model
{
    internal class Events
    {


        Dictionary<int, Student> WebDevelopmentWorkshop = new Dictionary<int, Student>();


        public void RegisterForWDWorkshop(int studentId, Student student)
        {
            try

            {

                if (!FindStudentIdFromWDW(studentId))
                {

                    WebDevelopmentWorkshop.Add(studentId, student);
                    Console.WriteLine($"Student ID:{studentId} succesfully Register for Web Development Workshop");
                    Console.WriteLine();

                }
                else
                {
                    throw new IdAlreadyRegistedException($"Student ID:{studentId} already Register for Web Development Workshop!!");
                }
            }
            catch (IdAlreadyRegistedException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public bool FindStudentIdFromWDW(int studentId)
        {
            return WebDevelopmentWorkshop.ContainsKey(studentId);
        }

        public void DisplayStudentListOfWDWorkshop()
        {
            Console.WriteLine();
            Console.WriteLine("Student List of Web Development Workshop:");
            foreach (KeyValuePair<int, Student> wDW in WebDevelopmentWorkshop)
            {
                Console.WriteLine($"StudentId:{wDW.Key}\tStudent Name:{wDW.Value.StudentName}\t{wDW.Value.StudentCourseName}");
            }
        }





        //--------------------UI_UX_Workshop---------------//


        Dictionary<int, Student> UI_UX_Workshop = new Dictionary<int, Student>();
        public void RegisterForUIUXWorkshop(int studentId, Student student)
        {
            try
            {
                if (!FindStudentIdFromUIUXW(studentId))
                {

                    UI_UX_Workshop.Add(studentId, student);
                    Console.WriteLine($"Student ID:{studentId} succesfully Register for UI/UX Workshop");
                    Console.WriteLine();

                }
                else
                {

                    throw new IdAlreadyRegistedException($"Student ID:{studentId} already Register for UI/UX Workshop!!");

                }

            }
            catch (IdAlreadyRegistedException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DisplayStudentListOfUIUXWorkshop()
        {
            Console.WriteLine();
            Console.WriteLine("Student List of UI/UX Workshop:");
            foreach (KeyValuePair<int, Student> uiUxW in UI_UX_Workshop)
            {
                Console.WriteLine($"StudentId:{uiUxW.Key}\tStudent Name:{uiUxW.Value.StudentName}\t{uiUxW.Value.StudentCourseName}");
            }
        }
        public bool FindStudentIdFromUIUXW(int studentId)
        {
            return UI_UX_Workshop.ContainsKey(studentId);
        }







        //--------------------Robotics Automation Workshop---------------//


        Dictionary<int, Student> RoboticsAutomationWorkshop = new Dictionary<int, Student>();

        public void RegisterForRoboticsAutomationWorkshop(int studentId, Student student)
        {
            try
            {
                if (!FindStudentIdFromRAW(studentId))
                {

                    RoboticsAutomationWorkshop.Add(studentId, student);
                    Console.WriteLine($"Student ID:{studentId} succesfully Register for Robotics Automation Workshop");
                    Console.WriteLine();
                }
                else
                {
                    throw new IdAlreadyRegistedException($"Student ID:{studentId} already Register for Robotics Automation Workshop!!");
                }
            }
            catch (IdAlreadyRegistedException e)
            {
                Console.WriteLine(e.Message);
            }
        }



        public void DisplayStudentListOfRoboticsAutomationWorkshop()
        {
            Console.WriteLine();
            Console.WriteLine("Student List of Robotics Automation Workshop:");
            foreach (KeyValuePair<int, Student> rAW in RoboticsAutomationWorkshop)
            {
                Console.WriteLine($"StudentId:{rAW.Key}\tStudent Name:{rAW.Value.StudentName}\t{rAW.Value.StudentCourseName}");
            }
        }

        public bool FindStudentIdFromRAW(int studentId)
        {
            return RoboticsAutomationWorkshop.ContainsKey(studentId);
        }
    }
}