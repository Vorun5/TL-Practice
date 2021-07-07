using System;
using System.Data.SqlClient;

namespace MyUniversity
{
    class Methods
    {
        private static readonly string _connectionString = @"Data Source=WIN-J8MCEPL7DG6;Initial Catalog=University;Integrated Security=True";
        public static void AddStudent(string name, int age)
        {
            using ( SqlConnection connection = new SqlConnection( _connectionString ) )
            {
                connection.Open();
                using ( SqlCommand command = connection.CreateCommand() )
                {
                    command.CommandText = $"INSERT INTO [Students]([Name], [Age]) VALUES ({name}, {age})";
                }
            }
        }
        public static void AddGroupe( string name )
        {
            using ( SqlConnection connection = new SqlConnection( _connectionString ) )
            {
                connection.Open();
                using ( SqlCommand command = connection.CreateCommand() )
                {
                    command.CommandText = $"INSERT INTO [Groups]([Name]) VALUES ({name})";
                }
            }
        }
        public static void AddTeacher( string name )
        {
            using ( SqlConnection connection = new SqlConnection( _connectionString ) )
            {
                connection.Open();
                using ( SqlCommand command = connection.CreateCommand() )
                {
                    command.CommandText = $"INSERT INTO [Teachers]([Name]) VALUES ({name})";
                }
            }

        }
        public static void AddCurse( string name, int idTeacher )
        {
            using ( SqlConnection connection = new SqlConnection( _connectionString ) )
            {
                connection.Open();
                using ( SqlCommand command = connection.CreateCommand() )
                {
                    command.CommandText = $"INSERT INTO [Curse]([TeacherId], [Name]) VALUES ({idTeacher}, {name})";
                }
            }
        }
        public static void AddStudentToGroup( int IdGroupe, int IdStudent )
        {
            using ( SqlConnection connection = new SqlConnection( _connectionString ) )
            {
                connection.Open();
                using ( SqlCommand command = connection.CreateCommand() )
                {
                    command.CommandText = $"UPDATE [Student] SET [GroupeId] = {IdGroupe} WHERE [Id] = {IdStudent}";
                }
            }

        }
        public static void ChangeTeacherOnACourse( int IdTeacher, int IdCourse )
        {
            using ( SqlConnection connection = new SqlConnection( _connectionString ) )
            {
                connection.Open();
                using ( SqlCommand command = connection.CreateCommand() )
                {
                    command.CommandText = $"UPDATE [Course] SET [TeacherId] = {IdTeacher} WHERE [Id] = {IdCourse}";
                }
            }
        }
        public static void AddAGroupToACourse(int IdGroupe, int IdCourse )
        {
            using ( SqlConnection connection = new SqlConnection( _connectionString ) )
            {
                connection.Open();
                using ( SqlCommand command = connection.CreateCommand() )
                {
                    command.CommandText = $"INSERT INTO [GroupAndCourse]([GroupId], [CourseId]) VALUES ({IdGroupe}, {IdCourse})";
                }
            }
        }
        public static void NumberOfStudentsOnTheCourses()
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
        }
        public static void NumberOfTeachersStudentsCourses()
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
        }

        public static void AvaialbleGroupe()
        {
            Console.WriteLine( $"ID |  Name | NumberOfStudents" );
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
                            Console.WriteLine( $"{groupe.Id}   | {groupe.Name} | {groupe.NumberOfStudents}" );
                        }
                    }
                }
            }
        }
        public static void AvaialbleStudentWithoutGroup()
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
        public static void AvaialbleTeacherWithoutCourse()
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
        public static void AvaialbleCourse()
        {
            Console.WriteLine( $"ID  | TeacherId | Name" );
            using ( SqlConnection connection = new SqlConnection( _connectionString ) )
            {
                connection.Open();
                using ( SqlCommand command = connection.CreateCommand() )
                {
                    command.CommandText = $"SELECT * FROM [Courses]";
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
