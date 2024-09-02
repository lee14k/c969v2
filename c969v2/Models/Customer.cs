using System.Collections.Generic;
using System;

public class Customer
{
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public int AddressId { get; set; }
    public bool Active { get; set; }
    public DateTime CreateDate { get; set; }
    public string CreatedBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public string LastUpdateBy { get; set; }

    // Navigation property to link to Address
    public Address Address { get; set; }

    // Static list to store customer records
    private static List<Customer> customers = new List<Customer>();

    // Method to add a new customer
    public static void AddCustomer(Customer customer)
    {
        ValidateCustomer(customer);
        customers.Add(customer);
    }

    // Method to update an existing customer
    public static void UpdateCustomer(int index, Customer customer)
    {
        ValidateCustomer(customer);
        customers[index] = customer;
    }

    // Method to delete a customer
    public static void DeleteCustomer(int index)
    {
        customers.RemoveAt(index);
    }

    // Method to validate customer data
    private static void ValidateCustomer(Customer customer)
    {
        if (string.IsNullOrWhiteSpace(customer.CustomerName))
        {
            throw new ArgumentException("Customer name cannot be empty.");
        }
    }

    // Method to get all customers
    public static List<Customer> GetAllCustomers()
    {
        return customers;
    }
}