using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c969v2.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdatedBy { get; set; }

        // Static list to store country records
        private static List<Country> countries = new List<Country>();

        // Method to add a new country
        public static void AddCountry(Country country)
        {
            countries.Add(country);
        }

        // Method to update an existing country
        public static void UpdateCountry(int index, Country country)
        {
            countries[index] = country;
        }

        // Method to delete a country
        public static void DeleteCountry(int index)
        {
            countries.RemoveAt(index);
        }

        // Method to get all countries
        public static List<Country> GetAllCountries()
        {
            return countries;
        }
    }
}
