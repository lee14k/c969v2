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

    // Navigation property to link to Country
    public Country Country { get; set; }

    // Static list to store city records
    private static List<City> cities = new List<City>();

    // Method to add a new city
    public static void AddCity(City city)
    {
        cities.Add(city);
    }

    // Method to update an existing city
    public static void UpdateCity(int index, City city)
    {
        cities[index] = city;
    }

    // Method to delete a city
    public static void DeleteCity(int index)
    {
        cities.RemoveAt(index);
    }

    // Method to get all cities
    public static List<City> GetAllCities()
    {
        return cities;
    }
}