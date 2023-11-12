using System;

class Program
{
    static void Main()
    {
        Console.Write("Введіть кількість рядків масиву: ");
        int n = GetValidInput();

        Console.Write("Введіть кількість стовпців масиву: ");
        int m = GetValidInput();

        double[,] array = new double[n, m];
        Random r = new Random();

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                double randomNumber = Math.Round((r.NextDouble() * (7.03 + 42.31) - 42.31), 2);
                array[i, j] = randomNumber;
            }
        }

        Console.WriteLine("\nПочатковий масив:");
        PrintArray(array);

        int rowsWithoutNegative = CountRowsWithoutNegative(array);
        Console.WriteLine($"\nКількість рядків без від'ємних елементів: {rowsWithoutNegative}");

        ReverseColumns(array);

        Console.WriteLine("\nМасив після виконання операцій:");
        PrintArray(array);
    }

    static int GetValidInput()
    {
        int value;
        while (!int.TryParse(Console.ReadLine(), out value) || value <= 0)
        {
            Console.WriteLine("Будь ласка, введіть коректне ціле додатне число.");
        }
        return value;
    }

    static void PrintArray(double[,] arr)
    {
        int rows = arr.GetLength(0);
        int cols = arr.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(arr[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    static int CountRowsWithoutNegative(double[,] arr)
    {
        int rows = arr.GetLength(0);
        int cols = arr.GetLength(1);
        int count = 0;

        for (int i = 0; i < rows; i++)
        {
            bool hasNegative = false;
            for (int j = 0; j < cols; j++)
            {
                if (arr[i, j] < 0)
                {
                    hasNegative = true;
                    break;
                }
            }
            if (!hasNegative)
            {
                count++;
            }
        }

        return count;
    }

    static void ReverseColumns(double[,] arr)
    {
        int rows = arr.GetLength(0);
        int cols = arr.GetLength(1);

        for (int j = 0; j < cols; j++)
        {
            for (int i = 0; i < rows / 2; i++)
            {
                double temp = arr[i, j];
                arr[i, j] = arr[rows - i - 1, j];
                arr[rows - i - 1, j] = temp;
            }
        }
    }
}
