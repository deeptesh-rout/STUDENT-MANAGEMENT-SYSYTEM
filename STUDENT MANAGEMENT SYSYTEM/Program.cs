using System;
using System.Collections.Generic;

class Student
{
    public string Name { get; set; }
    public int RollNumber { get; set; }
    public int Age { get; set; }
    public double Grade { get; set; }

    public Student(string name, int rollNumber, int age, double grade)
    {
        Name = name;
        RollNumber = rollNumber;
        Age = age;
        Grade = grade;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Roll Number: {RollNumber}, Age: {Age}, Grade: {Grade}";
    }
}

class StudentManagementSystem
{
    private static List<Student> students = new List<Student>();

    static void Main(string[] args)
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\nStudent Management System");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Display Students");
            Console.WriteLine("3. Update Student");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("5. Calculate Average Grade");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddStudent();
                    break;
                case 2:
                    DisplayStudents();
                    break;
                case 3:
                    UpdateStudent();
                    break;
                case 4:
                    DeleteStudent();
                    break;
                case 5:
                    CalculateAverageGrade();
                    break;
                case 6:
                    isRunning = false;
                    Console.WriteLine("Thank you.. Exiting");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                    break;
            }
        }
    }

    private static void AddStudent()
    {
        Console.Write("Enter student name: ");
        string name = Console.ReadLine();
        Console.Write("Enter roll number: ");
        int rollNumber = int.Parse(Console.ReadLine());
        Console.Write("Enter age: ");
        int age = int.Parse(Console.ReadLine());
        Console.Write("Enter grade: ");
        double grade = double.Parse(Console.ReadLine());

        Student student = new Student(name, rollNumber, age, grade);
        students.Add(student);
        Console.WriteLine("Student added successfully!");
    }

    private static void DisplayStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students found.");
            return;
        }

        Console.WriteLine("\nStudents:");
        foreach (Student student in students)
        {
            Console.WriteLine(student);
        }
    }

    private static void UpdateStudent()
    {
        Console.Write("Enter roll number of student to update: ");
        int rollNumber = int.Parse(Console.ReadLine());

        Student student = students.Find(s => s.RollNumber == rollNumber);
        if (student != null)
        {
            Console.Write("Enter new name: ");
            student.Name = Console.ReadLine();
            Console.Write("Enter new age: ");
            student.Age = int.Parse(Console.ReadLine());
            Console.Write("Enter new grade: ");
            student.Grade = double.Parse(Console.ReadLine());

            Console.WriteLine("Student updated successfully!");
        }
        else
        {
            Console.WriteLine($"Student with roll number {rollNumber} not found.");
        }
    }

    private static void DeleteStudent()
    {
        Console.Write("Enter roll number of student to delete: ");
        int rollNumber = int.Parse(Console.ReadLine());

        Student student = students.Find(s => s.RollNumber == rollNumber);
        if (student != null)
        {
            students.Remove(student);
            Console.WriteLine("Student deleted successfully!");
        }
        else
        {
            Console.WriteLine($"Student with roll number {rollNumber} not found.");
        }
    }

    private static void CalculateAverageGrade()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students found.");
            return;
        }

        double totalGrade = 0;
        foreach (Student student in students)
        {
            totalGrade += student.Grade;
        }

        double averageGrade = totalGrade / students.Count;
        Console.WriteLine($"Average Grade: {averageGrade}");
    }
}
