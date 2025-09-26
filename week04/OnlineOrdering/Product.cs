using System;

public class Product
{
    private string _name;
    private int _productId;
    private decimal _price;
    private int _quantity;

    public Product(string name, int id, decimal price, int qty)
    {
        _name = name;
        _productId = id;
        _price = price;
        _quantity = qty;
    }

    public string GetDisplay()
    {
        return $"\t{_productId}  -  {_name}";
    }

    public decimal GetTotalCost()
    {
        return _price * _quantity;
    }
}