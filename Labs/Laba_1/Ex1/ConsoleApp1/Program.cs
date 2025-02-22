using System;
using System.ComponentModel;

class Program
{

    static double EnterR()
    {
        while (true)
        {
            Console.WriteLine("Write radius of the sircle(R): ");
            string line = Console.ReadLine();
            if (double.TryParse(line, out double radius))
            {
                if (radius > 0)
                {
                    return radius;
                }
                else
                {
                    Console.WriteLine("\nYou entered not a positive number!\nTry again\n");
                }
            }
            else
            {
                Console.WriteLine("\nYou entered not a number!\nTry again\n");
            }
        }
    }

    static void EnterXAndY(out double x, out double y)
    {
        x = 0;
        y = 0;
        
        bool test = true;
        while (test)
        {
            Console.WriteLine("Enter coordinates of x and y:");
            string line = Console.ReadLine();
            string[] numbers = line.Split(' ');
            
            
            if (numbers.Length == 2)
            {
                for(int i = 0; i < 2; ++i)
                {
                    test = false;
                    if (double.TryParse(numbers[i], out double result))
                    {
                        switch (i)
                        {
                            case 0:
                            {
                                x = result;
                                break;
                            }
                            case 1:
                            {
                                y = result;
                                break;
                            }
                        }
                    }
                    else
                    {
                        test = true;
                        Console.WriteLine("\nYou entered not a number!\nTry again\n");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("\nYou entered too many variables!\nTry again\n");
            }
        }
    }

    static string FindResult(double R, double x, double y)
    {
        string result = "No answer";

        if (Math.Abs(x) > R || Math.Abs(y) > R)
            result = "No";
        else
            if ((x + R)*(x + R) + (y - R)*(y - R) < R*R || (x - R)*(x - R) + (y + R)*(y + R) < R*R)
                result = "No";
            else
                if ((x + R) * (x + R) + (y - R) * (y - R) == R * R ||
                    (x - R) * (x - R) + (y + R) * (y + R) == R * R)
                    result = "On the verge";
                else
                {
                    if (x == R || y == R)
                        result = "On the verge";
                    else
                        result = "Yes";
                }
        
        return result;
    }
    static void Main()
    {
        double radius = EnterR();

        EnterXAndY(out double x, out double y);
        
        Console.WriteLine(FindResult(radius, x, y));
    }
}

