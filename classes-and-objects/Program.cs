using System.Collections.Generic;

public class Student{
  public string? Name;
  public int StudentID;
  public int GraduationYear;

  public Student() {}

  public Student(string name, int id, int gradYear){
    Name = name;
    StudentID = id;
    GraduationYear = gradYear;
  }
}
public class Program{
  public static void Main(string[] args){

    Student[] students = new Student[4];
    int count = 4;

    for (int i = 0; i < count; i++){
      Console.WriteLine($"Enter details for student {i + 1}");

      Console.Write("Name: ");
      string name = Console.ReadLine() ?? string.Empty;

      Console.Write("Student ID: ");
      int id = int.Parse(Console.ReadLine() ?? "11111");

      Console.Write("Graduation Year: ");
      int gradyear = int.Parse(Console.ReadLine() ?? "2027");

      Student s = new Student(name, id, gradyear);
      students[i] = s;
    }
    Console.WriteLine("\n--- Students List ---");
    foreach (Student s in students){

      Console.WriteLine($"Name: {s.Name}, Student ID: {s.StudentID}, Graduation Year: {s.GraduationYear}");
    }

  }
}
