using System.Collections.Generic;
using System;

public class Address
{
    public int AddressId { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public int CityId { get; set; }
    public string PostalCode { get; set; }
    public string Phone { get; set; }
    public DateTime CreateDate { get; set; }
    public string CreatedBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public string LastUpdateBy { get; set; }

    // Navigation property to link to City
    public City City { get; set; }

    // Static list to store address records
    private static List<Address> addresses = new List<Address>();

    // Method to add a new address
    public static void AddAddress(Address address)
    {
        addresses.Add(address);
    }

    // Method to update an existing address
    public static void UpdateAddress(int index, Address address)
    {
        addresses[index] = address;
    }

    // Method to delete an address
    public static void DeleteAddress(int index)
    {
        addresses.RemoveAt(index);
    }

    // Method to get all addresses
    public static List<Address> GetAllAddresses()
    {
        return addresses;
    }
}