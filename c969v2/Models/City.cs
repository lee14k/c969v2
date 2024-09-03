using c969v2.Models;
using System.Collections.Generic;
using System;

public class City
{
    public int CityId { get; set; }
    public string CityName { get; set; }
    public int CountryId { get; set; }
    public DateTime CreateDate { get; set; }
    public string CreatedBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public string LastUpdateBy { get; set; }
    public Country Country { get; set; }

    public void ValidateFields()
    {
        if (string.IsNullOrWhiteSpace(CityName))
        {
            throw new Exception("Please fill out the city name.");
        }
        if (CityName.Length>45)
        {
            throw new Exception("City name cannot exceed 45 characters.");
        }
    }

}