using System;
using ITU_ASAU_COLLEGE.Areas.Identity.Data;
using ITU_ASAU_COLLEGE.Models;
using Microsoft.EntityFrameworkCore;

namespace ITU_ASAU_COLLEGE.Data
{
    public class DbInitializer : DropCreatedDatabaseIfModelChanges<ITU_ASAU_COLLEGEContext>
    {
        public static void Initialize(ITU_ASAU_COLLEGEContext context)
        {
            context.Database.Migrate();

            //Look for any students.
            if (context.Student.Any())
            {
                return; //DB has been seeded

            }

            var students = new Student[]
            {
               new Student{FirstName="John",LastName="Doe",Gender="Male",ClassCode=(ClassCode)9,DateOfBirth=DateTime.Parse("2005-05-15")},
               new Student{FirstName="Emma",LastName="Johnson",Gender="Female",ClassCode=(ClassCode)10,DateOfBirth=DateTime.Parse("2006-03-15")},
               new Student{FirstName="Liam",LastName="Williams",Gender="Male",ClassCode=(ClassCode)11,DateOfBirth=DateTime.Parse("2005-07-22")},
               new Student{FirstName="Olivia",LastName="Brown",Gender="Female",ClassCode=(ClassCode)12,DateOfBirth=DateTime.Parse("2004-11-05")},
               new Student{FirstName="Noah",LastName="Jones",Gender="Male",ClassCode=(ClassCode)9,DateOfBirth=DateTime.Parse("2007-06-18")},
               new Student{FirstName="Ava",LastName="Garcia",Gender="Female",ClassCode=(ClassCode)10,DateOfBirth=DateTime.Parse("2006-09-09")},
               new Student{FirstName="Elijah",LastName="Miller",Gender="Male",ClassCode=(ClassCode)11,DateOfBirth=DateTime.Parse("2005-12-01")},
               new Student{FirstName="Sophia",LastName="Davis",Gender="Female",ClassCode=(ClassCode)12,DateOfBirth=DateTime.Parse("2004-08-19")},
               new Student{FirstName="James",LastName="Rodriguez",Gender="Male",ClassCode=(ClassCode)9,DateOfBirth=DateTime.Parse("2007-02-11")},
               new Student{FirstName="Isabella",LastName="Martinez",Gender="Female",ClassCode=(ClassCode)10,DateOfBirth=DateTime.Parse("2006-10-23")},
               new Student{FirstName="Benjamin",LastName="Hernandez",Gender="Male",ClassCode=(ClassCode)11,DateOfBirth=DateTime.Parse("2005-04-30")},
               new Student{FirstName="Mia",LastName="Lopez",Gender="Female",ClassCode=(ClassCode)12,DateOfBirth=DateTime.Parse("2004-01-14")},
               new Student{FirstName="Lucas",LastName="Gonzalez",Gender="Male",ClassCode=(ClassCode)9,DateOfBirth=DateTime.Parse("2007-07-07")},
               new Student{FirstName="Charlotte",LastName="Wilson",Gender="Female",ClassCode=(ClassCode)10,DateOfBirth=DateTime.Parse("2006-05-29")},
               new Student{FirstName="Henry",LastName="Anderson",Gender="Male",ClassCode=(ClassCode)11,DateOfBirth=DateTime.Parse("2005-09-12")},
               new Student{FirstName="Amelia",LastName="Thomas",Gender="Female",ClassCode=(ClassCode)12,DateOfBirth=DateTime.Parse("2004-03-03")},
               new Student{FirstName="Alexander",LastName="Taylor",Gender="Male",ClassCode=(ClassCode)9,DateOfBirth=DateTime.Parse("2007-11-20")},
               new Student{FirstName="Harper",LastName="Moore",Gender="Female",ClassCode=(ClassCode)10,DateOfBirth=DateTime.Parse("2006-06-16")},
               new Student{FirstName="Daniel",LastName="Jackson",Gender="Male",ClassCode=(ClassCode)11,DateOfBirth=DateTime.Parse("2005-02-25")},
               new Student{FirstName="Evelyn",LastName="Martin",Gender="Female",ClassCode=(ClassCode)12,DateOfBirth=DateTime.Parse("2004-12-10")},
               new Student{FirstName="Matthew",LastName="Lee",Gender="Male",ClassCode=(ClassCode)9,DateOfBirth=DateTime.Parse("2007-04-04")}

            };
            foreach (Student s in students)
            {
                context.Student.Add(s);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course{CourseId=1,Title="English",Credits=3},
                new Course{CourseId=2,Title="Mathematics",Credits=4},
                new Course{CourseId=3,Title="Science",Credits=4},
                new Course{CourseId=4,Title="History",Credits=3},
                new Course{CourseId=5,Title="Geography",Credits=3},
                new Course{CourseId=6,Title="Physics",Credits=4},
                new Course{CourseId=7,Title="Chemistry",Credits=4},
                new Course{CourseId=8,Title="Biology",Credits=4},
                new Course{CourseId=9,Title="Computer Science",Credits=5},
                new Course{CourseId=10,Title="Physical Education",Credits=2},
                new Course{CourseId=11,Title="Visual Art",Credits=2},
                new Course{CourseId=12,Title="Music",Credits=2},
                new Course{CourseId=13,Title="Economics",Credits=3},
                new Course{CourseId=14,Title="Business Studies",Credits=3},
                new Course{CourseId=15,Title="Accounting",Credits=3},
                new Course{CourseId=16,Title="Statistics",Credits=4},
                new Course{CourseId=17,Title="Philosophy",Credits=3},
                new Course{CourseId=18,Title="Psychology",Credits=3},
                new Course{CourseId=19,Title="Sociology",Credits=3},
                new Course{CourseId=20,Title="Literature",Credits=3},
                new Course{CourseId=21,Title="Drama",Credits=2}
            };
            foreach (Course c in courses)
            {
                context.Course.Add(c);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment{EnrollmentDate=DateTime.Parse("2008-02-15"),CourseName=(CourseName)1},
                new Enrollment{EnrollmentDate=DateTime.Parse("2007-01-20"),CourseName=(CourseName)2},
                new Enrollment{EnrollmentDate=DateTime.Parse("2006-09-01"),CourseName=(CourseName)3},
                new Enrollment{EnrollmentDate=DateTime.Parse("2009-04-12"),CourseName=(CourseName)4},
                new Enrollment{EnrollmentDate=DateTime.Parse("2008-07-30"),CourseName=(CourseName)5},
                new Enrollment{EnrollmentDate=DateTime.Parse("2007-03-14"),CourseName=(CourseName)6},
                new Enrollment{EnrollmentDate=DateTime.Parse("2006-11-25"),CourseName=(CourseName)7},
                new Enrollment{EnrollmentDate=DateTime.Parse("2009-01-05"),CourseName=(CourseName)8},
                new Enrollment{EnrollmentDate= DateTime.Parse("2008-05-17"),CourseName=(CourseName)9},
                new Enrollment{EnrollmentDate= DateTime.Parse("2007-08-09"),CourseName=(CourseName)10},
                new Enrollment{EnrollmentDate=DateTime.Parse("2006-02-27"),CourseName=(CourseName)11},
                new Enrollment{EnrollmentDate=DateTime.Parse("2009-06-21"),CourseName=(CourseName)12},
                new Enrollment{EnrollmentDate=DateTime.Parse("2008-03-03"),CourseName=(CourseName)13},
                new Enrollment{EnrollmentDate=DateTime.Parse("2007-10-15"),CourseName=(CourseName)14},
                new Enrollment{EnrollmentDate=DateTime.Parse("2006-06-08"),CourseName=(CourseName)15},
                new Enrollment{EnrollmentDate= DateTime.Parse("2009-09-01"),CourseName=(CourseName)16},
                new Enrollment{EnrollmentDate=DateTime.Parse("2008-12-11"),CourseName=(CourseName)17},
                new Enrollment{EnrollmentDate= DateTime.Parse("2007-05-19"),CourseName=(CourseName)18},
                new Enrollment{EnrollmentDate=DateTime.Parse("2006-08-23"),CourseName=(CourseName)19},
                new Enrollment{EnrollmentDate=DateTime.Parse("2009-02-14"),CourseName=(CourseName)20},
            };
            foreach (Enrollment e in enrollments)
            {
                context.Enrollment.Add(e);
            }
            context.SaveChanges();

            var department = new Department[]
            {
                new Department{Name="Science",CourseId="1,2,3,4,5,6,7,8,9",HeadOfDepartment="Dr. Smith",NumberOfTeachers=10,NumberOfStudents=200},
                new Department{Name="Mathematics",CourseId="10,11,12,13,14",HeadOfDepartment="Dr. Johnson",NumberOfTeachers=8,NumberOfStudents=150},
                new Department{Name="English",CourseId="15,16,17,18",HeadOfDepartment="Dr. Williams",NumberOfTeachers=7,NumberOfStudents=140},
                new Department{Name="History",CourseId="19,20,21",HeadOfDepartment="Dr. Brown",NumberOfTeachers=6,NumberOfStudents=120},
                new Department{Name="Geography",CourseId="22,23,24",HeadOfDepartment="Dr. Jones",NumberOfTeachers=5,NumberOfStudents=100},
                new Department{Name="Physics",CourseId="25,26,27,28",HeadOfDepartment="Dr. Garcia",NumberOfTeachers=9,NumberOfStudents=130},
                new Department{Name="Chemistry",CourseId="29,30,31,32",HeadOfDepartment="Dr. Miller",NumberOfTeachers=8,NumberOfStudents=125},
                new Department{Name="Biology",CourseId="33,34,35,36",HeadOfDepartment="Dr. Davis",NumberOfTeachers=10,NumberOfStudents=180},
                new Department{Name="Computer Science",CourseId="37,38,39,40,41",HeadOfDepartment="Dr. Rodriguez",NumberOfTeachers=12,NumberOfStudents=220},
                new Department{Name="Economics",CourseId="42,43,44",HeadOfDepartment="Dr. Martinez",NumberOfTeachers=6,NumberOfStudents=110},
                new Department{Name="Business Studies",CourseId="45,46,47,48",HeadOfDepartment="Dr. Hernandez",NumberOfTeachers=9,NumberOfStudents=170},
                new Department{Name="Accounting",CourseId="49,50,51",HeadOfDepartment="Dr. Lopez",NumberOfTeachers=5,NumberOfStudents=90},
                new Department{Name="Art",CourseId="52,53,54",HeadOfDepartment="Dr. Gonzalez",NumberOfTeachers=4,NumberOfStudents=80},
                new Department{Name="Music",CourseId="55,56,57",HeadOfDepartment="Dr. Wilson",NumberOfTeachers=3,NumberOfStudents=70},
                new Department{Name="Physical Education",CourseId="58,59,60",HeadOfDepartment="Dr. Anderson",NumberOfTeachers=6,NumberOfStudents=200},
                new Department{Name="Philosophy",CourseId="61,62",HeadOfDepartment="Dr. Thomas",NumberOfTeachers=3,NumberOfStudents=60},
                new Department{Name="Sociology",CourseId="63,64,65",HeadOfDepartment="Dr. Taylor",NumberOfTeachers=5,NumberOfStudents=100},
                new Department{Name="Psychology",CourseId="66,67,68",HeadOfDepartment="Dr. Moore",NumberOfTeachers=7,NumberOfStudents=130},
                new Department{Name="Political Science",CourseId="69,70,71",HeadOfDepartment="Dr. Jackson",NumberOfTeachers=4,NumberOfStudents=85},
                new Department{Name="Environmental Science",CourseId="72,73,74,75",HeadOfDepartment="Dr. Martin",NumberOfTeachers=6,NumberOfStudents=115},
                new Department{Name="Engineering",CourseId="76,77,78,79,80",HeadOfDepartment="Dr. Lee",NumberOfTeachers=11,NumberOfStudents=210},
            };
            foreach (Department d in department)
            {
                context.Department.Add(d);
            }
            context.SaveChanges();
        }
    }

    public class DropCreatedDatabaseIfModelChanges<T>
    {
    }
}
