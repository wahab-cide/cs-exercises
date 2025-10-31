// Practice Problem 1: Array Wrapper with Custom Iterator
public class EArray<T> : AbstractEnumerable<T>
{
    private T[] array;

    public EArray(T[] array)
    {
        this.array = array;
    }

    public override IEnumerator<T> GetEnumerator()
    {
        return new EArrayEnumerator(array);
    }

    private class EArrayEnumerator : AbstractEnumerator<T>
    {
        private T[] array;
        private int position = -1;

        public EArrayEnumerator(T[] array)
        {
            this.array = array;
        }

        public override T Current
        {
            get
            {
                if (position < 0 || position >= array.Length)
                    throw new InvalidOperationException();
                return array[position];
            }
        }

        public override bool MoveNext()
        {
            position++;
            return position < array.Length;
        }

        public override void Reset()
        {
            position = -1;
        }
    }
}

// Practice Problem 2: Infinite Iterator for Even Numbers
public class EvenNumbers : AbstractEnumerable<int>
{
    private int start;

    public EvenNumbers(int start = 0)
    {
        // Make sure we start with an even number
        this.start = start % 2 == 0 ? start : start + 1;
    }

    public override IEnumerator<int> GetEnumerator()
    {
        return new EvenNumbersEnumerator(start);
    }

    private class EvenNumbersEnumerator : AbstractEnumerator<int>
    {
        private int current;
        private int start;
        private bool started = false;

        public EvenNumbersEnumerator(int start)
        {
            this.start = start;
            this.current = start - 2; // Will be incremented on first MoveNext
        }

        public override int Current
        {
            get
            {
                if (!started)
                    throw new InvalidOperationException();
                return current;
            }
        }

        public override bool MoveNext()
        {
            current += 2;
            started = true;
            return true; // Infinite sequence!
        }

        public override void Reset()
        {
            current = start - 2;
            started = false;
        }
    }
}

// Practice Problem 3: Sieve of Eratosthenes - Infinite Prime Number Iterator
public class PrimeNumbers : AbstractEnumerable<int>
{
    public override IEnumerator<int> GetEnumerator()
    {
        return new PrimeNumbersEnumerator();
    }

    private class PrimeNumbersEnumerator : AbstractEnumerator<int>
    {
        private int current = 1;
        private List<int> primes = new List<int>();
        private bool started = false;

        public override int Current
        {
            get
            {
                if (!started)
                    throw new InvalidOperationException();
                return current;
            }
        }

        public override bool MoveNext()
        {
            current++;

            while (true)
            {
                bool isPrime = true;

                // Check if current is divisible by any previously found prime
                foreach (int prime in primes)
                {
                    // Optimization: only check up to sqrt(current)
                    if (prime * prime > current)
                        break;

                    if (current % prime == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    primes.Add(current);
                    started = true;
                    return true; // Infinite sequence!
                }

                current++;
            }
        }

        public override void Reset()
        {
            current = 1;
            primes.Clear();
            started = false;
        }
    }
}

// Practice Problem 4: Fibonacci Numbers Iterator
public class FibonacciNumbers : AbstractEnumerable<int>
{
    public override IEnumerator<int> GetEnumerator()
    {
        return new FibonacciEnumerator();
    }

    private class FibonacciEnumerator : AbstractEnumerator<int>
    {
        private int current = 0;
        private int previous = 1;
        private bool started = false;
        private bool firstCall = true;

        public override int Current
        {
            get
            {
                if (!started)
                    throw new InvalidOperationException();
                return current;
            }
        }

        public override bool MoveNext()
        {
            if (firstCall)
            {
                current = 0;
                firstCall = false;
            }
            else
            {
                int next = current + previous;
                previous = current;
                current = next;
            }

            started = true;
            return true; // Infinite sequence!
        }

        public override void Reset()
        {
            current = 0;
            previous = 1;
            started = false;
            firstCall = true;
        }
    }
}

public class Program
{
    // ========== STRING VOWEL PROBLEMS ==========

    // Check if two strings have same vowels in same order
    public static bool HaveSameVowels(string s1, string s2)
    {
        Vowels v1 = new Vowels(s1);
        IEnumerator<char> e1 = v1.GetEnumerator();

        Vowels v2 = new Vowels(s2);
        IEnumerator<char> e2 = v2.GetEnumerator();

        while (true)
        {
            bool has1 = e1.MoveNext();
            bool has2 = e2.MoveNext();

            if (has1 != has2) return false;
            if (!has1) return true;
            if (e1.Current != e2.Current) return false;
        }
    }

    // Alternate vowels from two strings
    public static string AlternateVowels(string s1, string s2)
    {
        Vowels v1 = new Vowels(s1);
        Vowels v2 = new Vowels(s2);
        IEnumerator<char> e1 = v1.GetEnumerator();
        IEnumerator<char> e2 = v2.GetEnumerator();

        string result = "";
        bool turn1 = true;

        while (true)
        {
            if (turn1)
            {
                if (e1.MoveNext())
                    result += e1.Current;
                else if (e2.MoveNext())
                    result += e2.Current;
                else
                    break;
            }
            else
            {
                if (e2.MoveNext())
                    result += e2.Current;
                else if (e1.MoveNext())
                    result += e1.Current;
                else
                    break;
            }
            turn1 = !turn1;
        }

        return result;
    }

    // Get the Nth vowel (0-indexed)
    public static char? GetNthVowel(string s, int n)
    {
        Vowels v = new Vowels(s);
        IEnumerator<char> e = v.GetEnumerator();

        for (int i = 0; i <= n; i++)
        {
            if (!e.MoveNext())
                return null;
        }

        return e.Current;
    }

    // Skip every other vowel
    public static string SkipEveryOther(string s)
    {
        Vowels v = new Vowels(s);
        IEnumerator<char> e = v.GetEnumerator();

        string result = "";
        bool take = true;

        while (e.MoveNext())
        {
            if (take)
                result += e.Current;
            take = !take;
        }

        return result;
    }

    // Zip vowels into pairs
    public static string ZipVowels(string s1, string s2)
    {
        Vowels v1 = new Vowels(s1);
        Vowels v2 = new Vowels(s2);
        IEnumerator<char> e1 = v1.GetEnumerator();
        IEnumerator<char> e2 = v2.GetEnumerator();

        string result = "";

        while (e1.MoveNext() && e2.MoveNext())
        {
            if (result.Length > 0) result += "-";
            result += $"{e1.Current}{e2.Current}";
        }

        return result;
    }

    public static void Main()
    {
        Console.WriteLine("=== ITERATOR PRACTICE PROBLEMS ===\n");

        // Test 1: EArray wrapper
        Console.WriteLine("Problem 1: EArray<T> wrapper");
        int[] numbers = { 10, 20, 30, 40, 50 };
        EArray<int> earray = new EArray<int>(numbers);

        Console.Write("  Array contents: ");
        foreach (int n in earray)
        {
            Console.Write($"{n} ");
        }
        Console.WriteLine();

        string[] words = { "Hello", "World", "Iterator" };
        EArray<string> ewords = new EArray<string>(words);
        Console.Write("  String array: ");
        foreach (string w in ewords)
        {
            Console.Write($"{w} ");
        }
        Console.WriteLine("\n");

        // Test 2: Even Numbers (infinite!)
        Console.WriteLine("Problem 2: Even Numbers (infinite iterator)");
        EvenNumbers evens = new EvenNumbers(0);
        Console.Write("  First 10 evens: ");
        int count = 0;
        foreach (int n in evens)
        {
            Console.Write($"{n} ");
            count++;
            if (count >= 10) break;
        }
        Console.WriteLine();

        EvenNumbers evensFrom100 = new EvenNumbers(100);
        Console.Write("  10 evens from 100: ");
        count = 0;
        foreach (int n in evensFrom100)
        {
            Console.Write($"{n} ");
            count++;
            if (count >= 10) break;
        }
        Console.WriteLine("\n");

        // Test 3: Prime Numbers (infinite!)
        Console.WriteLine("Problem 3: Prime Numbers - Sieve of Eratosthenes");
        PrimeNumbers primes = new PrimeNumbers();
        Console.Write("  First 15 primes: ");
        count = 0;
        foreach (int p in primes)
        {
            Console.Write($"{p} ");
            count++;
            if (count >= 15) break;
        }
        Console.WriteLine("\n");

        // Test 4: Fibonacci Numbers (infinite!)
        Console.WriteLine("Problem 4: Fibonacci Numbers");
        FibonacciNumbers fib = new FibonacciNumbers();
        Console.Write("  First 12 Fibonacci: ");
        count = 0;
        foreach (int f in fib)
        {
            Console.Write($"{f} ");
            count++;
            if (count >= 12) break;
        }
        Console.WriteLine("\n");

        // Test 5: Manual enumeration with Reset
        Console.WriteLine("Problem 5: Using Reset on EArray");
        EArray<int> arr = new EArray<int>(new int[] { 1, 2, 3 });
        IEnumerator<int> e = arr.GetEnumerator();

        Console.Write("  First iteration: ");
        while (e.MoveNext())
        {
            Console.Write($"{e.Current} ");
        }
        Console.WriteLine();

        e.Reset();
        Console.Write("  After Reset: ");
        while (e.MoveNext())
        {
            Console.Write($"{e.Current} ");
        }
        Console.WriteLine("\n");

        // Test 6: Combining iterators
        Console.WriteLine("Problem 6: Combining iterators");
        EvenNumbers e1 = new EvenNumbers(0);
        PrimeNumbers p1 = new PrimeNumbers();

        Console.Write("  First 5 evens: ");
        count = 0;
        foreach (int n in e1)
        {
            Console.Write($"{n} ");
            if (++count >= 5) break;
        }
        Console.WriteLine();

        Console.Write("  First 5 primes: ");
        count = 0;
        foreach (int n in p1)
        {
            Console.Write($"{n} ");
            if (++count >= 5) break;
        }
    }
}