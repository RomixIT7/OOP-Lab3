using System;

class Program
{
    static void Main()
    {
        Console.Write("Введіть кількість елементів масиву: ");
        int n = Convert.ToInt32(Console.ReadLine());

        double[] array = new double[n];
        Random r = new Random();

        for (int i = 0; i < n; i++)
        {
            double randomNumber = Math.Round((r.NextDouble() * (3.59 + 7.51) - 7.51), 2);
            array[i] = randomNumber;
        }

        Console.WriteLine("Початковий масив:");
        PrintArray(array);

        double sumOfMods = 0;
        foreach (var element in array)
        {
            if (Math.Abs(element % 1) < 0.5)
            {
                sumOfMods += Math.Abs(element);
            }
        }

        Console.WriteLine($"\nСума модулів елементів з дробовою частиною менше 0.5: {sumOfMods}");

        int minIndex = Array.IndexOf(array, array.Min());

        Array.Sort(array, minIndex + 1, array.Length - minIndex - 1);
        Array.Reverse(array, minIndex + 1, array.Length - minIndex - 1);

        Console.WriteLine("\nМасив після виконання операцій:");
        PrintArray(array);
    }

    static void PrintArray(double[] arr)
    {
        foreach (var element in arr)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }
}
