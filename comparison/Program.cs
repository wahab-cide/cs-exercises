class Program
{
    static void Main(string[] args)
    {
        int[] data = new int[5] { 7, 28, 4, 7, 0 };
        BubbleSort(data);

        Console.WriteLine(String.Join(" ", data));
    }

    public static void BubbleSort<E>(E[] nums) where E : IComparable<E>
    {
        for (int numSorted = 0; numSorted < nums.Length; numSorted++)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1].CompareTo(nums[i]) > 0)
                {
                    Swap(nums, i, i - 1);
                }
            }
        }
    }

    public static void Swap<E>(E[] data, int i, int j)
    {
        E temp = data[i];
        data[i] = data[j];
        data[j] = temp;
    }

// Generic IList<E> BubbleSort
    public static void BubbleSortGeneric<E>(IList<E> data, IComparer<E> comparer)
    {
        for (int numSorted = 0; numSorted < data.Count; numSorted++)
            for (int i = 1; i < data.Count; i++)
                if (comparer.Compare(data[i - 1], data[i]) > 0)
                {
                    // Swap values at positions i and i-1
                    E temp = data[i];
                    data[i] = data[i - 1];
                    data[i - 1] = temp;
                }
    }

}


