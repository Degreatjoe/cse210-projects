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
        _top = 1;
        _bottom = 1;
    }
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    public int getTop()
    {
        return _top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetTop(int value)
    {
        _top = value;
    }

    public void SetBottom(int value)
    {
        _bottom = value;
    }

    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    public double GetFractionDecimal()
    {
        double res;
        res = (double)_top / _bottom;
        return res;
    }
}