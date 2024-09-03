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

        public void ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(CountryName))
            {
                throw new Exception("Please fill out the country name.");
            }
            if (CountryName.Length > 45)
            {
                throw new Exception("Country name cannot exceed 45 characters.");
            }
        }

    }
}
