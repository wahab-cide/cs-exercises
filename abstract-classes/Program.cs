public abstract class Honkable
{
    public virtual string Honk()
    {
        return "honk!!!";
    }
}

public class Goose : Honkable
{
    public override string Honk()
    {
        return "annoying HONK";
    }
}

public class Car : Honkable { }
public class Clown : Honkable
{
    public override string Honk()
    {
        return "squeky noise";
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        Honkable goose = new Goose();
        Honkable car = new Car();
        var clown = new Clown();

        Console.WriteLine(goose.Honk());
        Console.WriteLine(car.Honk());
        Console.WriteLine(clown.Honk());
    }
}