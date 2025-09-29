class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Tel { get; set; }
    public string Email { get; set; }

    public Student(int id, string name, string tel, string email)
    {
        Id = id;
        Name = name;
        Tel = tel;
        Email = email;
    }
}

internal class Program
{
    static int InputId(Student[] students, int n)
    {
        int id = int.Parse(Console.ReadLine());
        if (id < 23120000 || id > 23120999)
        {
            Console.Write("[!] Invalid Id. Please enter again: ");
            id = int.Parse(Console.ReadLine());
        }
        for(int i = 0; i < n; i++)
        {
            if(students[i] != null && students[i].Id == id)
            {
                Console.Write("[!] Id already exists. Please enter again: ");
                id = int.Parse(Console.ReadLine());
                i = -1;
            }
        }
        return id;
    }
    static string InputEmail()
    {
        string email = Console.ReadLine();
        if (!email.EndsWith("@gmail.com"))
        {
            Console.Write("[!] Invalid email. Please enter again: ");
            email = Console.ReadLine();
        }
        return email;
    }
    static void InputStudents(Student[] students, int n)
    {
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"- Student {i + 1}:");

            Console.Write("  Id: ");
            int id = InputId(students, n);
            Console.Write("  Name: ");
            string name = Console.ReadLine();
            Console.Write("  Tel: ");
            string tel = Console.ReadLine();
            Console.Write("  Email: ");
            string email = InputEmail();
            students[i] = new Student(id, name, tel, email);
        }
    }

    static void PrintStudents(Student[] students, int n)
    {
        Console.WriteLine("---------=STUDENTS=--------");
        for (int i = 0; i < n; i++)
        {
            if (students[i] != null)
            {
                Console.WriteLine($"Id: {students[i].Id}, Name: {students[i].Name}, Tel: {students[i].Tel}, Email: {students[i].Email}");
            }
        }
    }

    static void FindStudentById(Student[] students, int id)
    {
        bool found = false;
        for(int i = 0; i < students.Length; i++)
        {
            if (students[i] != null && students[i].Id == id)
            {
                Console.WriteLine("---------=RESULT=--------");
                Console.WriteLine($"Id: {students[i].Id}, Name: {students[i].Name}, Tel: {students[i].Tel}, Email: {students[i].Email}");
                found = true;
                break;
            }
        }
        if (!found)
        {
            Console.WriteLine("---------=RESULT=--------");
            Console.WriteLine("[!] Not found!");
        }
    }

    static void AddStudent(Student[] students, ref int n)
    {
        Console.WriteLine($"- Student {n + 1}:");
        Console.Write("  Id: ");
        int id = InputId(students, n);
        Console.Write("  Name: ");
        string name = Console.ReadLine();
        Console.Write("  Tel: ");
        string tel = Console.ReadLine();
        Console.Write("  Email: ");
        string email = InputEmail();
        students[n] = new Student(id, name, tel, email);
        n++;
        Console.WriteLine("---------=RESULT=--------");
        Console.WriteLine("[+] Student added successfully.");
    }

    enum SortBy
    {
        Id,
        Name
    }

    static void SortStudents(Student[] students, int n, SortBy sortBy)
    {

        Array.Sort(students, 0, n, Comparer<Student>.Create((s1, s2) =>
        {
            switch (sortBy)
            {
                case SortBy.Id:
                    return s1.Id.CompareTo(s2.Id);
                case SortBy.Name:
                    return string.Compare(s1.Name, s2.Name, StringComparison.OrdinalIgnoreCase);
                default:
                    return 0;
            }
        }));
        Console.WriteLine("---------=RESULT=--------");
        Console.WriteLine($"Students sorted by {sortBy}:");
        for(int i = 0; i < n; i++)
        {
            if (students[i] != null)
            {
                Console.WriteLine($"Id: {students[i].Id}, Name: {students[i].Name}, Tel: {students[i].Tel}, Email: {students[i].Email}");
            }
        }
    }

    static void ModifyStudentById(Student[] students, int n, int id)
    {
        bool found = false;
        for (int i = 0; i < n; i++)
        {
            if (students[i].Id == id)
            {
                Console.Write("Enter new Name: ");
                students[i].Name = Console.ReadLine();
                Console.Write("Enter new Tel: ");
                students[i].Tel = Console.ReadLine();
                Console.Write("Enter new Email: ");
                students[i].Email = InputEmail();
                found = true;
                break;
            }
        }
        if (found)
        {   
            Console.WriteLine("---------=RESULT=--------");
            Console.WriteLine("[+] Student modified successfully.");
        }
        else
        {
            Console.WriteLine("---------=RESULT=--------");
            Console.WriteLine("[!] Not found!");
        }
    }

    static void DeleteStudentById(Student[] students, int n, int id)
    {
        bool found = false;
        for (int i = 0; i < n; i++)
        {
            if (students[i].Id == id)
            {
                students[i] = null;
                found = true;
                break;
            }
        }
        if (found)
        {
            Console.WriteLine("---------=RESULT=--------");
            Console.WriteLine("[+] Student deleted successfully.");
        }
        else
        {
            Console.WriteLine("---------=RESULT=--------");
            Console.WriteLine("[!] Not found!");
        }
    }

    static void Main()
    {
        const int MAX_STUDENTS = 100;
        Student[] students = new Student[MAX_STUDENTS];
        int n;
        Console.Write("Enter number of students: ");
        n = int.Parse(Console.ReadLine());

        InputStudents(students, n);

        int choice;
        do
        {
            Console.WriteLine("----------=MENU=---------");
            Console.WriteLine("[1] Find student by Id");
            Console.WriteLine("[2] Add new student");
            Console.WriteLine("[3] Sort students by Id");
            Console.WriteLine("[4] Sort students by Name");
            Console.WriteLine("[5] Modify student by Id");
            Console.WriteLine("[6] Delete student by Id");
            Console.WriteLine("[7] Print all students");
            Console.WriteLine("[0] Exit");
            Console.WriteLine("-------------------------");
            Console.Write("Enter your choice: ");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write("Enter Id to find: ");
                    int findId = int.Parse(Console.ReadLine());
                    FindStudentById(students, findId);
                    break;
                case 2:
                    AddStudent(students, ref n);
                    break;
                case 3:
                    SortStudents(students, n, SortBy.Id);
                    break;
                case 4:
                    SortStudents(students, n, SortBy.Name);
                    break;
                case 5:
                    Console.Write("Enter Id to modify: ");
                    int modifyId = int.Parse(Console.ReadLine());
                    ModifyStudentById(students, n, modifyId);
                    break;
                case 6:
                    Console.Write("Enter Id to delete: ");
                    int deleteId = int.Parse(Console.ReadLine());
                    DeleteStudentById(students, n, deleteId);
                    break;
                case 7:
                    PrintStudents(students, n);
                    break;
                case 0:
                    Console.WriteLine("Exiting the program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("[!] Invalid choice. Please try again.");
                    break;
            }

        } while (choice != 0);
    }
}

