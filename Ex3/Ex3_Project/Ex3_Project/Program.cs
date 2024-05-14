// See https://aka.ms/new-console-template for more information
using System.Runtime.InteropServices;
using OOP;

class Program
{
    static void Main(string[] args)
    {
        LinkedList linkedList = new LinkedList();
        linkedList.Append(3);
        linkedList.Append(1);
        linkedList.Append(4);
        linkedList.Append(2);

        Console.WriteLine("Before sorting:");
        foreach (int value in linkedList.ToList())
        {
            Console.Write(value + " ");
        }
        Console.WriteLine();

        linkedList.Sort();

        Console.WriteLine("After sorting:");
        foreach (int value in linkedList.ToList())
        {
            Console.Write(value + " ");
        }
        Console.WriteLine();
        long number = -111999;
        NumericalExpression tryLo  = new NumericalExpression(number);
        Console.WriteLine($"{number} : {tryLo.ToString()}");
        Console.WriteLine("sum letters of 2:");
        Console.WriteLine($"{NumericalExpression.SumLetters(2)}");
        NumericalExpression new_number = new NumericalExpression(2);
        Console.WriteLine("sum letters of 2:");
        Console.WriteLine($"{NumericalExpression.SumLetters(new_number)}");

    }
}