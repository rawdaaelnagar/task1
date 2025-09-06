namespace task22
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Course> Courses { get; set; }

        public Student()
        {
            Courses = new List<Course>();
        }

        public bool Enroll(Course course)
        {
            if (course == null)
            {
                return false;
            }
            Courses.Add(course);
            return true;
        }

        public string PrintDetails()
        {
            return "ID: " + StudentId + ", Name: " + Name + ", Age: " + Age + ", Courses: " + Courses.Count;
        }
    }

    public class Instructor
    {
        public int InstructorId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }

        public string PrintDetails()
        {
            return "ID: " + InstructorId + ", Name: " + Name + ", Specialization: " + Specialization;
        }
    }

    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public Instructor Instructor { get; set; }

        public string PrintDetails()
        {
            string inst;
            if (Instructor != null)
            {
                inst = Instructor.Name;
            }
            else
            {
                inst = "No Instructor";
            }
            return "ID: " + CourseId + ", Title: " + Title + ", Instructor: " + inst;
        }
    }

    public class SchoolStudentManager
    {
        public List<Student> Students { get; set; }
        public List<Course> Courses { get; set; }
        public List<Instructor> Instructors { get; set; }

        public SchoolStudentManager()
        {
            Students = new List<Student>();
            Courses = new List<Course>();
            Instructors = new List<Instructor>();
        }

        public bool AddStudent(Student student)
        {
            if (student == null) return false;
            Students.Add(student);
            return true;
        }

        public bool AddCourse(Course course)
        {
            if (course == null) return false;
            Courses.Add(course);
            return true;
        }

        public bool AddInstructor(Instructor instructor)
        {
            if (instructor == null) return false;
            Instructors.Add(instructor);
            return true;
        }

        public Student FindStudent(int studentId)
        {
            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].StudentId == studentId)
                {
                    return Students[i];
                }
            }
            return null;
        }

        public Course FindCourse(int courseId)
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].CourseId == courseId)
                {
                    return Courses[i];
                }
            }
            return null;
        }

        public Instructor FindInstructor(int instructorId)
        {
            for (int i = 0; i < Instructors.Count; i++)
            {
                if (Instructors[i].InstructorId == instructorId)
                {
                    return Instructors[i];
                }
            }
            return null;
        }

        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            Student s = FindStudent(studentId);
            Course c = FindCourse(courseId);

            if (s == null || c == null)
            {
                return false;
            }

            return s.Enroll(c);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SchoolStudentManager manager = new SchoolStudentManager();
            bool running = true;

            while (running)
            {
                Console.WriteLine("---- Student Management System ----");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Instructor");
                Console.WriteLine("3. Add Course");
                Console.WriteLine("4. Enroll Student in Course");
                Console.WriteLine("5. Show All Students");
                Console.WriteLine("6. Show All Courses");
                Console.WriteLine("7. Show All Instructors");
                Console.WriteLine("8. Exit");
                Console.Write("Choose option: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Student s = new Student();
                    Console.Write("Enter Student ID: ");
                    s.StudentId = int.Parse(Console.ReadLine());
                    Console.Write("Enter Student Name: ");
                    s.Name = Console.ReadLine();
                    Console.Write("Enter Age: ");
                    s.Age = int.Parse(Console.ReadLine());

                    manager.AddStudent(s);
                    Console.WriteLine("Student added.\n");
                }
                else if (choice == "2")
                {
                    Instructor i = new Instructor();
                    Console.Write("Enter Instructor ID: ");
                    i.InstructorId = int.Parse(Console.ReadLine());
                    Console.Write("Enter Instructor Name: ");
                    i.Name = Console.ReadLine();
                    Console.Write("Enter Specialization: ");
                    i.Specialization = Console.ReadLine();

                    manager.AddInstructor(i);
                    Console.WriteLine("Instructor added.\n");
                }
                else if (choice == "3")
                {
                    Course c = new Course();
                    Console.Write("Enter Course ID: ");
                    c.CourseId = int.Parse(Console.ReadLine());
                    Console.Write("Enter Course Title: ");
                    c.Title = Console.ReadLine();

                    Console.Write("Enter Instructor ID for this course: ");
                    int iid = int.Parse(Console.ReadLine());
                    c.Instructor = manager.FindInstructor(iid);

                    manager.AddCourse(c);
                    Console.WriteLine("Course added.\n");
                }
                else if (choice == "4")
                {
                    Console.Write("Enter Student ID: ");
                    int sid = int.Parse(Console.ReadLine());
                    Console.Write("Enter Course ID: ");
                    int cid = int.Parse(Console.ReadLine());

                    if (manager.EnrollStudentInCourse(sid, cid))
                    {
                        Console.WriteLine("Student enrolled.\n");
                    }
                    else
                    {
                        Console.WriteLine("Enrollment failed.\n");
                    }
                }
                else if (choice == "5")
                {
                    Console.WriteLine("All Students:");
                    for (int i = 0; i < manager.Students.Count; i++)
                    {
                        Console.WriteLine(manager.Students[i].PrintDetails());
                    }
                    Console.WriteLine();
                }
                else if (choice == "6")
                {
                    Console.WriteLine("All Courses:");
                    for (int i = 0; i < manager.Courses.Count; i++)
                    {
                        Console.WriteLine(manager.Courses[i].PrintDetails());
                    }
                    Console.WriteLine();
                }
                else if (choice == "7")
                {
                    Console.WriteLine("All Instructors:");
                    for (int i = 0; i < manager.Instructors.Count; i++)
                    {
                        Console.WriteLine(manager.Instructors[i].PrintDetails());
                    }
                    Console.WriteLine();
                }
                else if (choice == "8")
                {
                    running = false;
                }
                else
                {
                    Console.WriteLine("Invalid choice.\n");
                }
            }
        }
    }
}
