using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MyUniversity
{
    class Program
    {
        private static readonly string _connectionString = @"Data Source=WIN-J8MCEPL7DG6;Initial Catalog=University;Integrated Security=True";
        static void Main( string[] args )
        {
            Console.WriteLine( $"Available commands: \n" +
                $"- AddStudent \n" +
                $"- AddGroupe \n" +
                $"- AddCurse \n" +
                $"- AddTeacher \n" +
                $"- AddStudentToGroup \n" +
                $"- AvaialbleTeacher \n" +
                $"- AvaialbleStudent \n" +
                $"- AvaialbleGroupe \n" +
                $"- ChangeTeacherOnACourse \n" +
                $"- AddAGroupToACourse \n" +
                $"- CoursesReport \n" +
                $"- GeneralReport \n" );
            string command = Console.ReadLine();
            while ( command != "exit" )
            {
                switch ( command )
                {
                    case "exit":
                        return;
                    case "AddStudent":
                        AddStudent();
                        command = Console.ReadLine();
                        break;
                    case "AddGroupe":
                        AddGroupe();
                        command = Console.ReadLine();
                        break;
                    case "AddTeacher":
                        AddTeacher();
                        command = Console.ReadLine();
                        break;
                    case "AddCurse":
                        AddCurse();
                        command = Console.ReadLine();
                        break;
                    case "AddStudentToGroup":
                        AddStudentToGroup();
                        command = Console.ReadLine();
                        break;
                    case "ChangeTeacherOnACourse":
                        ChangeTeacherOnACourse();
                        command = Console.ReadLine();
                        break;
                    case "AddAGroupToACourse":
                        AddAGroupToACourse();
                        command = Console.ReadLine();
                        break;
                    case "CoursesReport":
                        CoursesReport();
                        command = Console.ReadLine();
                        break;
                    case "GeneralReport":
                        GeneralReport();
                        command = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine( $"There is no such command." );
                        command = Console.ReadLine();
                        break;
                }
            }
        }

        private static void AddStudent()
        {
            Console.WriteLine( "Enter student name:" );
            string name = Console.ReadLine().ToLower().Trim();
            Console.WriteLine( "Enter student age:" );
            string ageString = Console.ReadLine();
            if ( !string.IsNullOrEmpty( name ) & int.TryParse( ageString, out int age ) )
            {
                using ( SqlConnection connection = new SqlConnection( _connectionString ) )
                {
                    connection.Open();
                    using ( SqlCommand command = connection.CreateCommand() )
                    {
                        command.CommandText = $"INSERT INTO [Students]([Name], [Age]) VALUES ({name}, {age})";
                    }
                }
                Console.WriteLine( "Success." );
            }
            else
            {
                Console.WriteLine( "Not successful." );
            }
        }
        private static void AddGroupe()
        {
            Console.WriteLine( "Enter groupe name:" );
            string name = Console.ReadLine().ToLower().Trim();
            if ( !string.IsNullOrEmpty( name ) )
            {
                using ( SqlConnection connection = new SqlConnection( _connectionString ) )
                {
                    connection.Open();
                    using ( SqlCommand command = connection.CreateCommand() )
                    {
                        command.CommandText = $"INSERT INTO [Groups]([Name]) VALUES ({name})";
                    }
                }
                Console.WriteLine( "Success." );
            }
            else
            {
                Console.WriteLine( "Not successful." );
            }
        }
        private static void AddTeacher()
        {
            Console.WriteLine( "Enter teacher name:" );
            string name = Console.ReadLine().ToLower().Trim();
            if ( !string.IsNullOrEmpty( name ) )
            {
                using ( SqlConnection connection = new SqlConnection( _connectionString ) )
                {
                    connection.Open();
                    using ( SqlCommand command = connection.CreateCommand() )
                    {
                        command.CommandText = $"INSERT INTO [Teachers]([Name]) VALUES ({name})";
                    }
                }
                Console.WriteLine( "Success." );
            }
            else
            {
                Console.WriteLine( "Not successful." );
            }
        }
        private static void AddCurse()
        {
            Console.WriteLine( "Enter course name:" );
            string name = Console.ReadLine().ToLower().Trim();
            Console.WriteLine( $"AvaialbleTeacher:" );
            AvaialbleTeacher();
            Console.WriteLine( "Enter teacher id:" );
            string idTeacherString = Console.ReadLine();
            if ( !string.IsNullOrEmpty( name ) & int.TryParse( idTeacherString, out int idTeacher ) )
            {
                using ( SqlConnection connection = new SqlConnection( _connectionString ) )
                {
                    connection.Open();
                    using ( SqlCommand command = connection.CreateCommand() )
                    {
                        command.CommandText = $"INSERT INTO [Curse]([TeacherId], [Name]) VALUES ({idTeacher}, {name})";
                    }
                }
                Console.WriteLine( "Success." );
            }
            else
            {
                Console.WriteLine( "Not successful." );
            }
        }
        private static void AddStudentToGroup()
        {

            Console.WriteLine( "Avaialble student:" );
            AvaialbleStudent();
            Console.WriteLine( "Avaialble groupe:" );
            AvaialbleGroupe();
            Console.WriteLine( "Enter student id:" );
            string stringIdStudent = Console.ReadLine().ToLower().Trim();
            Console.WriteLine( "Enter groupe id:" );
            string stringIdGroupe = Console.ReadLine().ToLower().Trim();
            if ( int.TryParse( stringIdStudent, out int IdStudent ) & int.TryParse( stringIdGroupe, out int IdGroupe ) )
            {
                using ( SqlConnection connection = new SqlConnection( _connectionString ) )
                {
                    connection.Open();
                    using ( SqlCommand command = connection.CreateCommand() )
                    {
                        command.CommandText = $"UPDATE [Student] SET [GroupeId] = {IdGroupe} WHERE [Id] = {IdStudent}";
                    }
                }
                Console.WriteLine( "Success." );
            }
            else
            {
                Console.WriteLine( "Not successful." );
            }
        }

        private static void ChangeTeacherOnACourse()
        {
            Console.WriteLine( "Avaialble course:" );
            AvaialbleCourse();
            Console.WriteLine( "Avaialble teacher:" );
            AvaialbleTeacher();
            Console.WriteLine( "Enter course id:" );
            string stringIdCourse = Console.ReadLine().ToLower().Trim();
            Console.WriteLine( "Enter techer id:" );
            string stringIdTeacher = Console.ReadLine().ToLower().Trim();
            if ( int.TryParse( stringIdTeacher, out int IdTeacher ) & int.TryParse( stringIdCourse, out int IdCourse ) )
            {
                using ( SqlConnection connection = new SqlConnection( _connectionString ) )
                {
                    connection.Open();
                    using ( SqlCommand command = connection.CreateCommand() )
                    {
                        command.CommandText = $"UPDATE [Course] SET [TeacherId] = {IdTeacher} WHERE [Id] = {IdCourse}";
                    }
                }
                Console.WriteLine( "Success." );
            }
            else
            {
                Console.WriteLine( "Not successful." );
            }
        }
        private static void AddAGroupToACourse()
        {
            Console.WriteLine( "Avaialble groupe:" );
            AvaialbleGroupe();
            Console.WriteLine( "Avaialble course:" );
            AvaialbleCourse();
            Console.WriteLine( "Enter groupe id:" );
            string stringIdGroupe = Console.ReadLine().ToLower().Trim();
            Console.WriteLine( "Enter course id:" );
            string stringIdCourse = Console.ReadLine().ToLower().Trim();
            if ( int.TryParse( stringIdCourse, out int IdCourse ) & int.TryParse( stringIdGroupe, out int IdGroupe ) )
            {
                using ( SqlConnection connection = new SqlConnection( _connectionString ) )
                {
                    connection.Open();
                    using ( SqlCommand command = connection.CreateCommand() )
                    {
                        command.CommandText = $"INSERT INTO [GroupAndCourse]([GroupId], [CourseId]) VALUES ({IdGroupe}, {IdCourse})";
                    }
                }
                Console.WriteLine( "Success." );
            }
            else
            {
                Console.WriteLine( "Not successful." );
            }
        }
        public static void CoursesReport()
        {
            using ( SqlConnection connection = new SqlConnection( _connectionString ) )
            {
                connection.Open();
                using ( SqlCommand command = new SqlCommand() )
                {
                    command.Connection = connection;
                    command.CommandText = $"SELECT Courses.Name AS Name, SUM(NumberOfStudents) AS NumberOfStudents \n" +
                        $"FROM [Groups] JOIN [GroupAndCourse] ON Groups.Id = GroupAndCourse.GroupId JOIN [Courses] ON Courses.Id = GroupAndCourse.CourseId \n" +
                        $"GROUP BY Courses.Name";
                    using ( SqlDataReader reader = command.ExecuteReader() )
                    {
                        Console.WriteLine( $"|   Name   |  NumberOfStudents" );
                        while ( reader.Read() )
                        {
                            var courseReport = new CourseReport
                            {
                                Name = Convert.ToString( reader[ "Name" ] ),
                                NumberOfStudent = Convert.ToInt32( reader[ "NumberOfStudents" ] )
                            };
                            Console.WriteLine( $"| {courseReport.Name} |  {courseReport.NumberOfStudent}" );
                        }
                    }

                }
            }
            Console.WriteLine( "Success." );
        }

        private static void AvaialbleGroupe()
        {
            Console.WriteLine( $"ID  | Name | NumberOfStudents" );
            using ( SqlConnection connection = new SqlConnection( _connectionString ) )
            {
                connection.Open();
                using ( SqlCommand command = connection.CreateCommand() )
                {
                    command.CommandText = $"SELECT * FROM [Groups]";
                    using ( SqlDataReader reader = command.ExecuteReader() )
                    {
                        while ( reader.Read() )
                        {
                            var groupe = new Group
                            {
                                Id = Convert.ToInt32( reader[ "Id" ] ),
                                NumberOfStudents = Convert.ToInt32( reader[ "NumberOfStudents" ] ),
                                Name = (string) reader[ "Name" ]
                            };
                            Console.WriteLine( $"{groupe.Id}  | {groupe.Name} |{groupe.NumberOfStudents}" );
                        }
                    }
                }
            }
        }
        private static void GeneralReport()
        {
            Console.WriteLine( $"NumberOfStudents | NumberOfTeachers | NumberOfCourses" );
            using ( SqlConnection connection = new SqlConnection( _connectionString ) )
            {
                connection.Open();
                using ( SqlCommand command = connection.CreateCommand() )
                {
                    command.CommandText = $"SELECT COUNT(Id) AS NumberOfStudents FROM [Students] \n" +
                        $"SELECT COUNT(Id) AS NumberOfTeachers FROM [Teachers] \n" +
                        $"SELECT COUNT(Id) AS NumberOfCourses FROM [Courses]";
                    using ( SqlDataReader reader = command.ExecuteReader() )
                    {
                        while ( reader.Read() )
                        {
                            int numberOfStudents = Convert.ToInt32( reader[ "NumberOfStudents" ] );
                            Console.Write( $"|   {numberOfStudents}   |   " );
                        }
                        reader.NextResult();
                        while ( reader.Read() )
                        {
                            int numberOfTeachers = Convert.ToInt32( reader[ "NumberOfTeachers" ] );
                            Console.Write( $"{numberOfTeachers}   |   " );
                        }
                        reader.NextResult();
                        while ( reader.Read() )
                        {
                            int numberOfCourses = Convert.ToInt32( reader[ "NumberOfCourses" ] );
                            Console.WriteLine( $"{numberOfCourses}" );
                        }
                    }
                }
            }
            Console.WriteLine( "Success." );
        }
        private static void AvaialbleStudent()
        {
            Console.WriteLine( $"ID  |   Name   | Age  " );
            using ( SqlConnection connection = new SqlConnection( _connectionString ) )
            {
                connection.Open();
                using ( SqlCommand command = connection.CreateCommand() )
                {
                    command.CommandText = $"SELECT [Id], [Name], [Age] FROM [Students] WHERE [GroupId] IS NULL";
                    using ( SqlDataReader reader = command.ExecuteReader() )
                    {
                        while ( reader.Read() )
                        {
                            var student = new Student
                            {
                                Id = Convert.ToInt32( reader[ "Id" ] ),
                                Name = (string) reader[ "Name" ],
                                Age = Convert.ToInt32( reader[ "Age" ] ),
                            };
                            Console.WriteLine( $"{student.Id}   |{student.Name}| {student.Age} " );
                        }
                    }
                }
            }
        }
        private static void AvaialbleTeacher()
        {
            Console.WriteLine( $"ID  | Name" );
            using ( SqlConnection connection = new SqlConnection( _connectionString ) )
            {
                connection.Open();
                using ( SqlCommand command = connection.CreateCommand() )
                {
                    command.CommandText = $"SELECT [Id], [Name] FROM [Teachers] WHERE [CourseId] IS NULL";
                    using ( SqlDataReader reader = command.ExecuteReader() )
                    {
                        while ( reader.Read() )
                        {
                            var teacher = new Teacher
                            {
                                Id = Convert.ToInt32( reader[ "Id" ] ),
                                Name = (string) reader[ "Name" ]
                            };
                            Console.WriteLine( $"{teacher.Id}   | {teacher.Name}" );
                        }
                    }
                }
            }
        }
        private static void AvaialbleCourse()
        {
            Console.WriteLine( $"ID  | TeacherId | Name" );
            using ( SqlConnection connection = new SqlConnection( _connectionString ) )
            {
                connection.Open();
                using ( SqlCommand command = connection.CreateCommand() )
                {
                    command.CommandText = $"SELECT [Id], [TeacherId], [Name] FROM [Courses]";
                    using ( SqlDataReader reader = command.ExecuteReader() )
                    {
                        while ( reader.Read() )
                        {
                            var course = new Course
                            {
                                Id = Convert.ToInt32( reader[ "Id" ] ),
                                TeacherId = Convert.ToInt32( reader[ "TeacherId" ] ),
                                Name = (string) reader[ "Name" ]
                            };
                            Console.WriteLine( $"{course.Id}   | {course.TeacherId} | {course.Name}" );
                        }
                    }
                }
            }
        }
    }
}

