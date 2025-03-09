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

    static (int, double) FindAnswer(double[,] arr, int hight, int width)
    {
        double minn = Math.Abs(arr[0, 0]);
        double maxx = Math.Abs(arr[0, 0]);
        for (int i = 0; i < hight; ++i)
        {
            for (int j = 0; j < width; ++j)
            {
                if (minn > Math.Abs(arr[i, j]))
                    minn = Math.Abs(arr[i, j]);
                if (maxx< Math.Abs(arr[i, j]))
                    maxx = Math.Abs(arr[i, j]);
            }
        }

        int quantity = 0;
        double summ = 0;
        for (int i = 0; i < hight; ++i)
        {
            for (int j = 0; j < width; ++j)
            {
                if (arr[i, j] <= minn || arr[i, j] >= maxx)
                {
                    quantity++;
                    summ += arr[i, j];
                }
            }
        }

        return (quantity, summ);
    }
    
    static void Main()
    {
        int hight = 2;
        int width = 4;
        double[,] arr = EnterArray(hight, width);
        
        Console.WriteLine(FindAnswer(arr, hight,width));
    }
}
