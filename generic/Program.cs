public class Tuple<T1, T2>
{
    T1 item1;
    T2 item2;

    public Tuple(T1 i1, T2 i2)
    {
        item1 = i1;
        item2 = i2;
    }
    public static Tuple<B, A> Swap<A, B>(Tuple<A, B> tup)
    {
        return new Tuple<B, A>(tup.item2, tup.item1);
    }

    public override string ToString()
    {
        return $"({item1}, {item2})";
    }
}

// recursive generic class 
public class N<T>
{
    public T value;
    public N<T> next;

    public N(T val, N<T> n)
    {
        value = val;
        next = n;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var tup1 = new Tuple<int, string>(24, "hi");
        Console.WriteLine(tup1);


        int[] arr = new int[5] { 1, 2, 3, 4, 5 };

        var tup2 = new Tuple<int[], string>(arr, "hello");
        Console.WriteLine(tup2);
        var tup3 = new Tuple<double, double>(3.4, 4.5);
        Console.WriteLine(tup3);


        var tup2R = Tuple<int[], string>.Swap(tup2);
        Console.WriteLine(tup2R);

    }
}