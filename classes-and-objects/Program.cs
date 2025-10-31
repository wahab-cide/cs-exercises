using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class Student{
  public string? Name;
  public int StudentID;
  public int GraduationYear;

  public Student() {}

  public Student(string name, int id, int gradYear)
  {
    Name = name;
    StudentID = id;
    GraduationYear = gradYear;
  }

    public override bool Equals(object o)
    {
    if (o is Student s)
      {return this.StudentID == s.StudentID && this.Name == s.Name;}
    else return false;
    }
}
public class Program{
  public static void Main(string[] args){

    Student[] students = new Student[4];

    students[0] = new Student("Wahab", 2027, 3123629);
    students[1] = new Student("Wahab", 2027, 3123629);
    students[2] = new Student("Mesfin", 2027, 3123629);
    students[3] = new Student("Nimoh", 2027, 3123629);

  

    Console.WriteLine(students[0].Equals(students[1]));

  }
}
