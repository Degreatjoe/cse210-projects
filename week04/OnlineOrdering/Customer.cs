using System;
using System.Text;

public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }

    public string GetLabel()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"\tRecipient: {_name}");
        sb.AppendLine($"\tAddress: {_address.GetFullAddress()}");
        return sb.ToString();
    }
}