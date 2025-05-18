using System;
using System.Diagnostics;
using System.Linq;

public static class BubbleSort
{
    public static void Sort(int[] array)
    {
        int n = array.Length;
        bool swapped;
        do
        {
            swapped = false;
            for (int i = 1; i < n; i++)
            {
                if (array[i - 1] > array[i])
                {
                    (array[i - 1], array[i]) = (array[i], array[i - 1]);
                    swapped = true;
                }
            }
            n--;
        } while (swapped);
    }
}

public static class CocktailSort
{
    public static void Sort(int[] array)
    {
        bool swapped = true;
        int start = 0;
        int end = array.Length - 1;

        while (swapped)
        {
            swapped = false;

            for (int i = start; i < end; i++)
            {
                if (array[i] > array[i + 1])
                {
                    (array[i], array[i + 1]) = (array[i + 1], array[i]);
                    swapped = true;
                }
            }

            if (!swapped) break;

            swapped = false;
            end--;

            for (int i = end - 1; i >= start; i--)
            {
                if (array[i] > array[i + 1])
                {
                    (array[i], array[i + 1]) = (array[i + 1], array[i]);
                    swapped = true;
                }
            }
            start++;
        }
    }
}

public static class InsertionSort
{
    public static void Sort(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            int key = array[i];
            int j = i - 1;
            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = key;
        }
    }
}

public static class SelectionSort
{
    public static void Sort(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[minIndex])
                    minIndex = j;
            }
            (array[i], array[minIndex]) = (array[minIndex], array[i]);
        }
    }
}

public static class ShellSort
{
    public static void Sort(int[] array)
    {
        int n = array.Length;
        for (int gap = n / 2; gap > 0; gap /= 2)
        {
            for (int i = gap; i < n; i++)
            {
                int temp = array[i];
                int j = i;
                while (j >= gap && array[j - gap] > temp)
                {
                    array[j] = array[j - gap];
                    j -= gap;
                }
                array[j] = temp;
            }
        }
    }
}

public static class QuickSort
{
    public static void Sort(int[] array)
    {
        Sort(array, 0, array.Length - 1);
    }

    private static void Sort(int[] array, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(array, low, high);
            Sort(array, low, pivotIndex - 1);
            Sort(array, pivotIndex + 1, high);
        }
    }

    private static int Partition(int[] array, int low, int high)
    {
        int pivot = array[high];
        int i = low - 1;
        for (int j = low; j < high; j++)
        {
            if (array[j] <= pivot)
            {
                i++;
                (array[i], array[j]) = (array[j], array[i]);
            }
        }
        (array[i + 1], array[high]) = (array[high], array[i + 1]);
        return i + 1;
    }
}

public static class HeapSort
{
    public static void Sort(int[] array)
    {
        int n = array.Length;

        for (int i = n / 2 - 1; i >= 0; i--)
            Heapify(array, n, i);

        for (int i = n - 1; i >= 0; i--)
        {
            (array[0], array[i]) = (array[i], array[0]);
            Heapify(array, i, 0);
        }
    }

    private static void Heapify(int[] array, int n, int i)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n && array[left] > array[largest]) largest = left;
        if (right < n && array[right] > array[largest]) largest = right;

        if (largest != i)
        {
            (array[i], array[largest]) = (array[largest], array[i]);
            Heapify(array, n, largest);
        }
    }
}

public static class SortTimer
{
    public static TimeSpan Measure(Action sortFunction)
    {
        var stopwatch = Stopwatch.StartNew();
        sortFunction();
        stopwatch.Stop();
        return stopwatch.Elapsed;
    }
}

class Program
{
    static void Main(string[] args)
    {
        TestSort("Bubble Sort", BubbleSort.Sort);
        TestSort("Cocktail Sort", CocktailSort.Sort);
        TestSort("Insertion Sort", InsertionSort.Sort);
        TestSort("Selection Sort", SelectionSort.Sort);
        TestSort("Shell Sort", ShellSort.Sort);
        TestSort("Quick Sort", QuickSort.Sort);
        TestSort("Heap Sort", HeapSort.Sort);
    }

    static void TestSort(string name, Action<int[]> sortFunction)
    {
        int[] small = { 5, 2, 9, 1, 5, 6 };
        int[] large = Enumerable.Range(0, 10000).OrderBy(_ => Guid.NewGuid()).ToArray();

        Console.WriteLine($"--- {name} ---");

        int[] testSmall = (int[])small.Clone();
        var timeSmall = SortTimer.Measure(() => sortFunction(testSmall));
        Console.WriteLine($"Small array: {timeSmall.TotalMilliseconds} ms");

        int[] testLarge = (int[])large.Clone();
        var timeLarge = SortTimer.Measure(() => sortFunction(testLarge));
        Console.WriteLine($"Large array: {timeLarge.TotalMilliseconds} ms");

        Console.WriteLine();
    }
}