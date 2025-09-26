using System;
using System.Text;

public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }


    public decimal GetTotalCost()
    {
        decimal shippingFee;
        if (_customer.IsInUSA())
        {
            shippingFee = 5;
        }
        else
        {
            shippingFee = 35;
        }

        decimal totalCost = 0;
        foreach (Product p in _products)
        {
            totalCost += p.GetTotalCost();
        }
        return totalCost + shippingFee;
    }

    public string GetShippingLabel()
    {
        return _customer.GetLabel();
    }


    public string GetPackingLabel()
    {
         var sb = new StringBuilder();

        foreach (Product product in _products)
        {
            sb.AppendLine(product.GetDisplay());
        }

        return sb.ToString();
    }
}