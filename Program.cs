using System;

class Student
{
    private string indexNumber;
    private string name;
    private double gpa;
    private int admissionYear;
    private string nic;
    private Student next;

    public string IndexNumber { get => indexNumber; set => indexNumber = value; }
    public string Name { get => name; set => name = value; }
    public double GPA { get => gpa; set => gpa = value; }
    public int AdmissionYear { get => admissionYear; set => admissionYear = value; }
    public string NIC { get => nic; set => nic = value; }
    public Student Next { get => next; set => next = value; }

    public Student(string indexNumber, string name, double gpa, int admissionYear, string nic)
    {
        this.indexNumber = indexNumber;
        this.name = name;
        this.gpa = gpa;
        this.admissionYear = admissionYear;
        this.nic = nic;
        this.next = null;
    }
}


class StudentLinkedList
{
    private Student head;

    public void InsertStudent(Student newStudent)
    {
        if (SearchStudent(newStudent.IndexNumber) != null)
        {
            Console.WriteLine("Index number already exists. Insertion has been failed.");
            return;
        }

        if (head == null || string.Compare(newStudent.IndexNumber, head.IndexNumber) < 0)
        {
            newStudent.Next = head;
            head = newStudent;
            return;
        }

        Student current = head;
        while (current.Next != null && string.Compare(current.Next.IndexNumber, newStudent.IndexNumber) < 0)
        {
            current = current.Next;
        }

        newStudent.Next = current.Next;
        current.Next = newStudent;
    }

    public Student SearchStudent(string indexNumber)
    {
        Student current = head;
        while (current != null)
        {
            if (current.IndexNumber == indexNumber)
                return current;
            current = current.Next;
        }
        return null;
    }

    public bool DeleteStudent(string indexNumber)
    {
        if (head == null)
            return false;

        if (head.IndexNumber == indexNumber)
        {
            head = head.Next;
            return true;
        }

        Student current = head;
        while (current.Next != null && current.Next.IndexNumber != indexNumber)
        {
            current = current.Next;
        }

        if (current.Next == null)
            return false;

        current.Next = current.Next.Next;
        return true;
    }

    public void PrintAllStudent()
    {
        if (head == null)
        {
            Console.WriteLine("No students in the list.");
            return;
        }

        Student current = head;
        Console.WriteLine("Student List:");
        while (current != null)
        {
            Console.WriteLine($"Index: {current.IndexNumber}, Name: {current.Name}, GPA: {current.GPA}, Year: {current.AdmissionYear}, NIC: {current.NIC}");
            current = current.Next;
        }
    }
}


class Program
{
    static void Main(string[]args)
    {
        StudentLinkedList studentList = new StudentLinkedList();
        Console.WriteLine("\n Welcome to Student Management System \n");

        bool running = false;
        while (!running)
        {
            
            Console.WriteLine("\n1. Insert Student");
            Console.WriteLine("2. Delete Student");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Print All Students");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Enter Index Number (e.g., 2025123): ");
                string index = Console.ReadLine();
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter GPA: ");
                double gpa = double.Parse(Console.ReadLine());
                Console.Write("Enter Admission Year: ");
                int year = int.Parse(Console.ReadLine());
                Console.Write("Enter NIC: ");
                string nic = Console.ReadLine();

                Student newStudent = new Student(index, name, gpa, year, nic);
                studentList.InsertStudent(newStudent);
                Console.WriteLine("Student has been added sucessfully");
            }
            else if (choice == "2")
            {
                Console.Write("Enter Index Number to delete a student record: ");
                string deleteIndex = Console.ReadLine();
                if (studentList.DeleteStudent(deleteIndex))
                    Console.WriteLine("Student deleted");
                else
                    Console.WriteLine("Student not found");
            }
            else if (choice == "3")
            {
                Console.Write("Enter Index Number to find a student record: ");
                string searchIndex = Console.ReadLine();
                Student found = studentList.SearchStudent(searchIndex);
                if (found != null)
                {
                    Console.WriteLine($"{found.Name}, GPA: {found.GPA}, Year: {found.AdmissionYear}, NIC: {found.NIC}");
                }
                else
                {
                    Console.WriteLine("Student not found");
                }
            }
            else if (choice == "4")
            {
                studentList.PrintAllStudent();
            }
            else if (choice == "5")
            {
                running = true;
            }
            else
            {
                Console.WriteLine("Invalid option. Try again");
            }
        }

        Console.WriteLine("Thanks a lot for visiting us!!");
    }
}

