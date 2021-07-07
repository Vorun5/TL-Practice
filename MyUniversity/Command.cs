using System;

namespace MyUniversity
{
    class Command
    {
        public static void AddStudent()
        {
            Console.WriteLine( "Enter student name:" );
            string name = Console.ReadLine().Trim();
            Console.WriteLine( "Enter student age:" );
            string ageString = Console.ReadLine();
            if ( !string.IsNullOrEmpty( name ) & int.TryParse( ageString, out int age ) )
            {
                Methods.AddStudent(name, age);
                Console.WriteLine( "Success." );
            }
            else
            {
                Console.WriteLine( "Not successful." );
            }
        }
        public static void AddGroupe()
        {
            Console.WriteLine( "Enter groupe name:" );
            string name = Console.ReadLine().Trim();
            if ( !string.IsNullOrEmpty( name ) )
            {
                Methods.AddGroupe( name );
                Console.WriteLine( "Success." );
            }
            else
            {
                Console.WriteLine( "Not successful." );
            }
        }
        public static void AddTeacher()
        {
            Console.WriteLine( "Enter teacher name:" );
            string name = Console.ReadLine().Trim();
            if ( !string.IsNullOrEmpty( name ) )
            {
                Methods.AddTeacher( name );
                Console.WriteLine( "Success." );
            }
            else
            {
                Console.WriteLine( "Not successful." );
            }
        }
        public static void AddCurse()
        {
            Console.WriteLine( "Enter course name:" );
            string name = Console.ReadLine().Trim();
            Console.WriteLine( $"AvaialbleTeacher:" );
            Methods.AvaialbleTeacherWithoutCourse();
            Console.WriteLine( "Enter teacher id:" );
            string idTeacherString = Console.ReadLine();
            if ( !string.IsNullOrEmpty( name ) & int.TryParse( idTeacherString, out int idTeacher ) )
            {
                Methods.AddCurse( name, idTeacher );
                Console.WriteLine( "Success." );
            }
            else
            {
                Console.WriteLine( "Not successful." );
            }
        }
        public static void AddStudentToGroup()
        {

            Console.WriteLine( "Avaialble student:" );
            Methods.AvaialbleStudentWithoutGroup();
            Console.WriteLine( "Avaialble groupe:" );
            Methods.AvaialbleGroupe();
            Console.WriteLine( "Enter student id:" );
            string stringIdStudent = Console.ReadLine().Trim();
            Console.WriteLine( "Enter groupe id:" );
            string stringIdGroupe = Console.ReadLine().Trim();
            if ( int.TryParse( stringIdStudent, out int IdStudent ) & int.TryParse( stringIdGroupe, out int IdGroupe ) )
            {
                Methods.AddStudentToGroup( IdGroupe , IdStudent);
                Console.WriteLine( "Success." );
            }
            else
            {
                Console.WriteLine( "Not successful." );
            }
        }

        public static void ChangeTeacherOnACourse()
        {
            Console.WriteLine( "Avaialble course:" );
            Methods.AvaialbleCourse();
            Console.WriteLine( "Avaialble teacher:" );
            Methods.AvaialbleTeacherWithoutCourse();
            Console.WriteLine( "Enter course id:" );
            string stringIdCourse = Console.ReadLine().Trim();
            Console.WriteLine( "Enter techer id:" );
            string stringIdTeacher = Console.ReadLine().Trim();
            if ( int.TryParse( stringIdTeacher, out int IdTeacher ) & int.TryParse( stringIdCourse, out int IdCourse ) )
            {
                Methods.ChangeTeacherOnACourse( IdTeacher, IdCourse );
                Console.WriteLine( "Success." );
            }
            else
            {
                Console.WriteLine( "Not successful." );
            }
        }
        public static void AddAGroupToACourse()
        {
            Console.WriteLine( "Avaialble groupe:" );
            Methods.AvaialbleGroupe();
            Console.WriteLine( "Avaialble course:" );
            Methods.AvaialbleCourse();
            Console.WriteLine( "Enter groupe id:" );
            string stringIdGroupe = Console.ReadLine().ToLower().Trim();
            Console.WriteLine( "Enter course id:" );
            string stringIdCourse = Console.ReadLine().ToLower().Trim();
            if ( int.TryParse( stringIdCourse, out int IdCourse ) & int.TryParse( stringIdGroupe, out int IdGroupe ) )
            {
                Methods.AddAGroupToACourse( IdGroupe, IdCourse );
                Console.WriteLine( "Success." );
            }
            else
            {
                Console.WriteLine( "Not successful." );
            }
        }
        public static void CoursesReport()
        {
            Methods.NumberOfStudentsOnTheCourses();
            Console.WriteLine( "Success." );
        }

        public static void GeneralReport()
        {
            Methods.NumberOfTeachersStudentsCourses();
            Console.WriteLine( "Success." );
        }
    }
}
