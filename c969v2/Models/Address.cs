using System.Collections.Generic;
using System;

public class Address
{
    public int AddressId { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; } = "";
    public int CityId { get; set; }
    public string PostalCode { get; set; }
    public string Phone { get; set; }
    public DateTime CreateDate { get; set; }
    public string CreatedBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public string LastUpdateBy { get; set; }
    public void ValidateFields()
    {
        if (string.IsNullOrWhiteSpace(AddressLine1))
        {
            throw new Exception("Please fill out the first address line.");
        }
        if (AddressLine1.Length>50)
        {
            throw new Exception("Address line 1 cannot exceed 50 characters.");
        }
        if (AddressLine2.Length > 50)
        {
            throw new Exception("Address line 2 cannot exceed 50 characters.");
        }
        if (PostalCode.Length > 10)
        {
            throw new Exception("Postal code cannot exceed 10 characters.");
        }
        if (Phone.Length > 20)
        {
            throw new Exception("Phone number cannot exceed 20 characters.");
        }
    }
}