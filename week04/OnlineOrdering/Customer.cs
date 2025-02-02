using System;

public class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    public string GetCustomerName()
    {
        return name;
    }

    public string GetAddress()
    {
        return address.GetFullAddress();
    }
}