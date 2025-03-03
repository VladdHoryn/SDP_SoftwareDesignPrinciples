using System;
using System.ComponentModel;
using System.Runtime.InteropServices.JavaScript;

class Program
{
    static double[,] EnterArray(int hight, int width)
    {
        double[,] result = new double[hight, width];
        for (int i = 0; i < hight; ++i)
        {
            bool test = true;
            while (test)
            {
                Console.WriteLine("Enter " + width + " elements of array: ");
                string line = Console.ReadLine();
                string[] number = line.Split(' ');
                if (number.Length == width)
                {
                    test = false;
                    for (int j = 0; j < width; ++j)
                    {
                        if (!double.TryParse(number[j], out double resultt))
                        {
                            Console.WriteLine("\nNot whole input consist of numbers\nTry again");
                            test = true;
                        }
                        else
                        {
                            result[i, j] = resultt;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\nTher are not " + width + " elements\n Try again");
                }
            }
        }

        return result;
    }

    static double[] FindAnswer(double[,] arr, int hight, int width)
    {
        double[] result = new double[width];
        for (int i = 0; i < width; ++i)
            result[i] = 0;
        for (int i = 0; i < width; ++i)
        {
            for (int j = 0; j < hight; ++j)
            {
                if (arr[j, i] < 0)
                    result[i] += arr[j, i];
            }
        }

        return result;
    }
    
    static void Main()
    {
        int hight = 2;
        int width = 4;
        double[,] arr = EnterArray(hight, width);

        double[] result = FindAnswer(arr, hight, width);

        foreach (var i in result)
        {
            Console.Write(i + " ");
        }
        
    }
}
