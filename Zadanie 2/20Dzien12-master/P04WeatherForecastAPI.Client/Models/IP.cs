using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.Models{
     public class IP
    {
        public int Version { get; set; }
        public required string Key { get; set; }
        public required string Type { get; set; }
        public required int Rank { get; set; }
        public required string LocalizedName { get; set; }
        public required string EnglishName { get; set; }
        public required string PrimaryPostalCode { get; set; }  
        public required Region Region {get; set;}
        public required Region Country { get; set; }
        public AdministrativeArea AdministrativeArea { get; set; }
        public required TimeZone TimeZone { get; set; }          
        public required GeoPosition GeoPosition { get; set; } 
        public required bool IsAlias { get; set; } 
        public required ParentCity ParentCity { get; set; }
        public required SupplementalAdminArea[] SupplementalAdminAreas { get; set;}
        public required string [] DataSets { get; set;}
    }
}