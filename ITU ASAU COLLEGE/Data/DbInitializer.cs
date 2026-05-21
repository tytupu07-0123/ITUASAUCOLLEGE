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
               new Student{FirstName="John",LastName="Doe",Gender="Male",DateOfEnrollment=DateTime.Parse("2020-09-01"),ClassCode=9,CourseId=1,DateOfBirth=DateTime.Parse("2005-05-15")},
               new Student{FirstName="Emma",LastName="Johnson",Gender="Female",DateOfEnrollment=DateTime.Parse("2021-02-10"),ClassCode=10,CourseId=2,DateOfBirth=DateTime.Parse("2006-03-15")},
               new Student{FirstName="Liam",LastName="Williams",Gender="Male",DateOfEnrollment=DateTime.Parse("2020-01-20"),ClassCode=11,CourseId=3,DateOfBirth=DateTime.Parse("2005-07-22")},
               new Student{FirstName="Olivia",LastName="Brown",Gender="Female",DateOfEnrollment=DateTime.Parse("2019-09-01"),ClassCode=12,CourseId=4,DateOfBirth=DateTime.Parse("2004-11-05")},
               new Student{FirstName="Noah",LastName="Jones",Gender="Male",DateOfEnrollment=DateTime.Parse("2022-04-12"),ClassCode=9,CourseId=1,DateOfBirth=DateTime.Parse("2007-06-18")},
               new Student{FirstName="Ava",LastName="Garcia",Gender="Female",DateOfEnrollment=DateTime.Parse("2021-07-30"),ClassCode=10,CourseId=2,DateOfBirth=DateTime.Parse("2006-09-09")},
               new Student{FirstName="Elijah",LastName="Miller",Gender="Male",DateOfEnrollment=DateTime.Parse("2020-03-14"),ClassCode=11,CourseId=3,DateOfBirth=DateTime.Parse("2005-12-01")},
               new Student{FirstName="Sophia",LastName="Davis",Gender="Female",DateOfEnrollment=DateTime.Parse("2019-11-25"),ClassCode=12,CourseId=4,DateOfBirth=DateTime.Parse("2004-08-19")},
               new Student{FirstName="James",LastName="Rodriguez",Gender="Male",DateOfEnrollment=DateTime.Parse("2022-01-05"),ClassCode=9,CourseId=1,DateOfBirth=DateTime.Parse("2007-02-11")},
               new Student{FirstName="Isabella",LastName="Martinez",Gender="Female",DateOfEnrollment=DateTime.Parse("2021-05-17"),ClassCode=10,CourseId=2,DateOfBirth=DateTime.Parse("2006-10-23")},
               new Student{FirstName="Benjamin",LastName="Hernandez",Gender="Male",DateOfEnrollment=DateTime.Parse("2020-08-09"),ClassCode=11,CourseId=3,DateOfBirth=DateTime.Parse("2005-04-30")},
               new Student{FirstName="Mia",LastName="Lopez",Gender="Female",DateOfEnrollment=DateTime.Parse("2019-02-27"),ClassCode=12,CourseId=4,DateOfBirth=DateTime.Parse("2004-01-14")},
               new Student{FirstName="Lucas",LastName="Gonzalez",Gender="Male",DateOfEnrollment=DateTime.Parse("2022-06-21"),ClassCode=9,CourseId=1,DateOfBirth=DateTime.Parse("2007-07-07")},
               new Student{FirstName="Charlotte",LastName="Wilson",Gender="Female",DateOfEnrollment=DateTime.Parse("2021-03-03"),ClassCode=10,CourseId=2,DateOfBirth=DateTime.Parse("2006-05-29")},
               new Student{FirstName="Henry",LastName="Anderson",Gender="Male",DateOfEnrollment=DateTime.Parse("2020-10-15"),ClassCode=11,CourseId=3,DateOfBirth=DateTime.Parse("2005-09-12")},
               new Student{FirstName="Amelia",LastName="Thomas",Gender="Female",DateOfEnrollment=DateTime.Parse("2019-06-08"),ClassCode=12,CourseId=4,DateOfBirth=DateTime.Parse("2004-03-03")},
               new Student{FirstName="Alexander",LastName="Taylor",Gender="Male",DateOfEnrollment=DateTime.Parse("2022-09-01"),ClassCode=9,CourseId=1,DateOfBirth=DateTime.Parse("2007-11-20")},
               new Student{FirstName="Harper",LastName="Moore",Gender="Female",DateOfEnrollment=DateTime.Parse("2021-12-11"),ClassCode=10,CourseId=2,DateOfBirth=DateTime.Parse("2006-06-16")},
               new Student{FirstName="Daniel",LastName="Jackson",Gender="Male",DateOfEnrollment=DateTime.Parse("2020-05-19"),ClassCode=11,CourseId=3,DateOfBirth=DateTime.Parse("2005-02-25")},
               new Student{FirstName="Evelyn",LastName="Martin",Gender="Female",DateOfEnrollment=DateTime.Parse("2019-08-23"),ClassCode=12,CourseId=4,DateOfBirth=DateTime.Parse("2004-12-10")},
               new Student{FirstName="Matthew",LastName="Lee",Gender="Male",DateOfEnrollment=DateTime.Parse("2022-02-14"),ClassCode=9,CourseId=1,DateOfBirth=DateTime.Parse("2007-04-04")}

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
                new Course{CourseId=11,Title="Art",Credits=2},
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
                new Enrollment{EnrollmentDate=DateTime.Parse("2007-09-01"),CourseName="English",StudentName="John Doe",DateOfBirth=DateTime.Parse("2005-05-15"),Class=9},
                new Enrollment{EnrollmentDate=DateTime.Parse("2008-02-15"),CourseName="Mathematics",StudentName="Emma Johnson",DateOfBirth=DateTime.Parse("2006-03-15"),Class=10},
                new Enrollment{EnrollmentDate=DateTime.Parse("2007-01-20"),CourseName="Science",StudentName="Liam Williams",DateOfBirth=DateTime.Parse("2005-07-22"),Class=11},
                new Enrollment{EnrollmentDate=DateTime.Parse("2006-09-01"),CourseName="History",StudentName="Olivia Brown",DateOfBirth=DateTime.Parse("2004-11-05"),Class=12},
                new Enrollment{EnrollmentDate=DateTime.Parse("2009-04-12"),CourseName="English",StudentName="Noah Jones",DateOfBirth=DateTime.Parse("2007-06-18"),Class=9},
                new Enrollment{EnrollmentDate=DateTime.Parse("2008-07-30"),CourseName="Geography",StudentName="Ava Garcia",DateOfBirth=DateTime.Parse("2006-09-09"),Class=10},
                new Enrollment{EnrollmentDate=DateTime.Parse("2007-03-14"),CourseName="Physics",StudentName="Elijah Miller",DateOfBirth=DateTime.Parse("2005-12-01"),Class=11},
                new Enrollment{EnrollmentDate=DateTime.Parse("2006-11-25"),CourseName="Chemistry",StudentName="Sophia Davis",DateOfBirth=DateTime.Parse("2004-08-19"),Class=12},
                new Enrollment{EnrollmentDate=DateTime.Parse("2009-01-05"),CourseName="Biology",StudentName="James Rodriguez",DateOfBirth=DateTime.Parse("2007-02-11"),Class=9},
                new Enrollment{EnrollmentDate=DateTime.Parse("2008-05-17"),CourseName="Computer Science",StudentName="Isabella Martinez",DateOfBirth=DateTime.Parse("2006-10-23"),Class=10},
                new Enrollment{EnrollmentDate=DateTime.Parse("2007-08-09"),CourseName="Physical Education",StudentName="Benjamin Hernandez",DateOfBirth=DateTime.Parse("2005-04-30"),Class=11},
                new Enrollment{EnrollmentDate=DateTime.Parse("2006-02-27"),CourseName="Art",StudentName="Mia Lopez",DateOfBirth=DateTime.Parse("2004-01-14"),Class=12},
                new Enrollment{EnrollmentDate=DateTime.Parse("2009-06-21"),CourseName="Music",StudentName="Lucas Gonzalez",DateOfBirth=DateTime.Parse("2007-07-07"),Class=9},
                new Enrollment{EnrollmentDate=DateTime.Parse("2008-03-03"),CourseName="Economics",StudentName="Charlotte Wilson",DateOfBirth=DateTime.Parse("2006-05-29"),Class=10},
                new Enrollment{EnrollmentDate=DateTime.Parse("2007-10-15"),CourseName="Business Studies",StudentName="Henry Anderson",DateOfBirth=DateTime.Parse("2005-09-12"),Class=11},
                new Enrollment{EnrollmentDate=DateTime.Parse("2006-06-08"),CourseName="Accounting",StudentName="Amelia Thomas",DateOfBirth=DateTime.Parse("2004-03-03"),Class=12},
                new Enrollment{EnrollmentDate=DateTime.Parse("2009-09-01"),CourseName="Statistics",StudentName="Alexander Taylor",DateOfBirth=DateTime.Parse("2007-11-20"),Class=9},
                new Enrollment{EnrollmentDate=DateTime.Parse("2008-12-11"),CourseName="Philosophy",StudentName="Harper Moore",DateOfBirth=DateTime.Parse("2006-06-16"),Class=10},
                new Enrollment{EnrollmentDate=DateTime.Parse("2007-05-19"),CourseName="Psychology",StudentName="Daniel Jackson",DateOfBirth=DateTime.Parse("2005-02-25"),Class=11},
                new Enrollment{EnrollmentDate=DateTime.Parse("2006-08-23"),CourseName="Sociology",StudentName="Evelyn Martin",DateOfBirth=DateTime.Parse("2004-12-10"),Class=12},
                new Enrollment{EnrollmentDate=DateTime.Parse("2009-02-14"),CourseName="Literature",StudentName="Matthew Lee",DateOfBirth=DateTime.Parse("2007-04-04"),Class=9}
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
