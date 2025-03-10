using System;
using System.ComponentModel;
using System.Runtime.InteropServices.JavaScript;

class Program
{
    static double[,] EnterArray(int hight)
    {
        double[,] result = new double[hight+1, hight+1];

        for (int i = 1; i <= hight; ++i)
        {
            for (int j = 1; j <= hight; ++j)
            {
                result[i, j] = 0;
            }
        }
        
        for (int i = 1; i <= hight; ++i)
        {
            bool test = true;
            while (test)
            {
                Console.WriteLine("Enter " + i + " elements of array: ");
                string line = Console.ReadLine();
                string[] number = line.Split(' ');
                if (number.Length == i)
                {
                    test = false;
                    for (int j = 0; j < i; ++j)
                    {
                        if (!double.TryParse(number[j], out double resultt))
                        {
                            Console.WriteLine("\nNot whole input consist of numbers\nTry again");
                            test = true;
                        }
                        else
                        {
                            result[i, j+1] = resultt;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\nTher are not " + i + " elements\n Try again");
                }
            }
        }

        return result;
    }

    static double[] FindAnswer(double[,] arr, int hight)
    {
        double[] result = new double[hight+1];
        for (int i = 1; i <= hight; ++i)
            result[i] = 0;
        
        for (int i = 1; i <= hight; ++i)
        {
            for (int j = 1; j <= hight; ++j)
            {
                if (arr[j, i] < 0)
                    result[i] += arr[j, i];
            }
        }

        return result;
    }
    
    static void Main()
    {
        int hight = 5;
        double[,] arr = EnterArray(hight);

        double[] result = FindAnswer(arr, hight);

        
        for(int i = 1; i <= hight; ++i)
            Console.Write(result[i] + " ");
    }
}
