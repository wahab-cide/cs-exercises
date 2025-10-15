using System.Net;
using System.Reflection.Metadata;

class Student : IComparable<Student>
{
    public string Name { get; set; }
    public double GPA { get; set; }

    public Student(string name, double gpa)
    {
        Name = name;
        GPA = gpa;
    }

    public int CompareTo(Student? other)
    {
        if (other == null) return 1;
        return GPA.CompareTo(other.GPA);
    }

    public override string ToString()
    {
        return $"{Name} : {GPA}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Student> students = new List<Student>();

        Student s1 = new Student("Wahab", 4.0);
        Student s2 = new Student("Nimoh", 3.5);
        Student s3 = new Student("Abel", 3.1);

        students.Add(s1);
        students.Add(s2);
        students.Add(s3);

        foreach (Student s in students)
        {
            Console.WriteLine(s);
        }

        students.Sort();
        Console.WriteLine($"Highest GPA is {students[^1]} and lowest is {students[0]}");

    }
}