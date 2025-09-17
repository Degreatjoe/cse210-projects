using System;
/**
 * Fraction - This is a class for instantiating
 * and working with a fraction.
 *
*/
public class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
        /**
         * Fraction - A constructor
        */
        _top = 1;
        _bottom = 1;
    }
    public Fraction(int top)
    {
        /**
         * Fraction - Overloading constructor
        */
        _top = top;
        _bottom = 1;
    }
    public Fraction(int top, int bottom)
    {
        /**
         * Fraction - Another overloading Constructor
        */
        _top = top;
        _bottom = bottom;
    }

    public int GetTop()
    {
        /**
         * GetTop - getter for the numerator
         * Return: the numerator of the fraction
        */
        return _top;
    }

    public int GetBottom()
    {
        /**
         * GetBottom - getter for the denominator
         * Return: the denominator of the fraction
        */
        return _bottom;
    }

    public void SetTop(int value)
    {
        /**
         * SetTop - setter for the numerator
         * Return: void
        */
        _top = value;
    }

    public void SetBottom(int value)
    {
        /**
         * SetBottom - setter for the denominator
         * Return: void
        */
        _bottom = value;
    }

    public string GetFractionString()
    {
        /**
         * GetFractionString - to get the fraction in a string representation eg 3/4
         * Return: a string representation of the fraction
        */
        return $"{_top}/{_bottom}";
    }

    public double GetFractionDecimal()
    {
        /**
         * GetFractionDecimal - convert a fraction to its decimal equivalent
         * Return: a decimal value of type double
        */
        double res;
        res = (double)_top / _bottom;
        return res;
    }
}