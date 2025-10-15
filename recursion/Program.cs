#nullable disable

public class BankAccount
{
  public string Owner;
  public double Balance;
  public static double InterestRate = 0.05;


  public void AddInterest()
  {
    Balance += Balance * InterestRate;
  }
    
    public static void ChangeInterestRate(double newRate)
    {
    InterestRate = newRate;
    }
}


public class Student
{
  // Static field shared across all students
  public static int Count = 0;

  // Instance field
  public string Name;

  // Constructor
  public Student(string name)
  {
    Name = name;
    Count++; // increments for all students
  }

  // Static method
  public static void DisplayCount()
  {
    Console.WriteLine($"Total Students: {Count}");
  }
  public void Introduce()
  {
    Console.WriteLine($" Hi, I'm {Name}");
  }
}



class Program
{
  static void Main(String[] args)
  {
    Student s1 = new Student("Wahab");
    s1.Introduce();
    Student.DisplayCount();


    BankAccount a1 = new BankAccount { Owner = "Andrew", Balance = 254.00 };
    BankAccount a2 = new BankAccount { Owner = "Wahab", Balance = 756.00 };
    
    a1.AddInterest();
    Console.WriteLine(a1.Balance);
    Console.WriteLine(BankAccount.InterestRate);

    BankAccount.ChangeInterestRate(0.08);

    Console.WriteLine($"New Interest Rate is: {BankAccount.InterestRate}");
    a1.AddInterest();
    Console.WriteLine(a1.Balance);


  }
}