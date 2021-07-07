using System;

namespace MyUniversity
{
    class Program
    {
        static void Main( string[] args )
        {
            Console.WriteLine( $"Available commands: \n" +
                $"- AddStudent \n" +
                $"- AddGroupe \n" +
                $"- AddCurse \n" +
                $"- AddTeacher \n" +
                $"- AddStudentToGroup \n" + 
                $"- ChangeTeacherOnACourse \n" +
                $"- AddAGroupToACourse \n" +
                $"- CoursesReport \n" +
                $"- GeneralReport \n" +
                $"- Exit");
            string command = Console.ReadLine().ToLower();
            while ( command != "exit" )
            {
                switch ( command )
                {
                    case "exit":
                        return;
                    case "addstudent":
                        Command.AddStudent();
                        command = Console.ReadLine().ToLower();
                        break;
                    case "addgroupe":
                        Command.AddGroupe();
                        command = Console.ReadLine().ToLower();
                        break;
                    case "addteacher":
                        Command.AddTeacher();
                        command = Console.ReadLine().ToLower();
                        break;
                    case "addcurse":
                        Command.AddCurse();
                        command = Console.ReadLine().ToLower();
                        break;
                    case "addstudenttogroup":
                        Command.AddStudentToGroup();
                        command = Console.ReadLine().ToLower();
                        break;
                    case "changeteacheronacourse":
                        Command.ChangeTeacherOnACourse();
                        command = Console.ReadLine().ToLower();
                        break;
                    case "addagrouptoacourse":
                        Command.AddAGroupToACourse();
                        command = Console.ReadLine().ToLower();
                        break;
                    case "coursesreport":
                        Command.CoursesReport();
                        command = Console.ReadLine().ToLower();
                        break;
                    case "generalreport":
                        Command.GeneralReport();
                        command = Console.ReadLine().ToLower();
                        break;
                    default:
                        Console.WriteLine( $"There is no such command." );
                        command = Console.ReadLine().ToLower();
                        break;
                }
            }
        }
    }
}

