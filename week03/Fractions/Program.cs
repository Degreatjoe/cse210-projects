using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Fractions Project.");
        Fraction fractions1 = new Fraction();
        Console.WriteLine(fractions1.GetFractionString());
        Console.WriteLine(fractions1.GetTop());

        Fraction fractions2 = new Fraction(5);
        Console.WriteLine(fractions2.GetFractionString());
        Console.WriteLine(fractions2.GetTop());

        Fraction fractions3 = new Fraction();
        fractions3.SetTop(3);
        fractions3.SetBottom(4);
        Console.WriteLine(fractions3.GetFractionString());
        Console.WriteLine(fractions3.GetFractionDecimal());

        Fraction fractions4 = new Fraction(1, 3);
        Console.WriteLine(fractions4.GetFractionString());
        Console.WriteLine(fractions4.GetFractionDecimal());
    }
}