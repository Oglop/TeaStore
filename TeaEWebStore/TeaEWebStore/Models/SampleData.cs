using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TeaEWebStore.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<DatabaseAdapter>
    {
        protected override void Seed(DatabaseAdapter context)
        {
            var teatypes = new List<TeaType>
            {
                new TeaType{ Name = "GreenTea" },
                new TeaType{ Name = "BlackTea" },
                new TeaType{ Name = "RedTea" },
                new TeaType{ Name = "PremiumTea" }
            };

            var countries = new List<Country>
            {
                new Country { Name = "China" },
                new Country { Name = "Japan" },
                new Country { Name = "India" }
            };

            new List<Tea>{
                new Tea{ Title = "Morning Prime", TeaType = teatypes.Single(t => t.Name == "BlackTea"), Price=0.5M, Country = countries.Single(c => c.Name == "Japan"), TeaArtUrl = "/Content/Images/placeholder.gif" },
                new Tea{ Title = "Chai Masala", TeaType = teatypes.Single(t => t.Name == "BlackTea"), Price=0.6M, Country = countries.Single(c => c.Name == "India"), TeaArtUrl = "/Content/Images/placeholder.gif" },
                new Tea{ Title = "Breakfast Cream", TeaType = teatypes.Single(t => t.Name == "GreenTea"), Price=0.4M, Country = countries.Single(c => c.Name == "China"), TeaArtUrl = "/Content/Images/placeholder.gif" },
                new Tea{ Title = "Green Citrus", TeaType = teatypes.Single(t => t.Name == "GreenTea"), Price=1.2M, Country = countries.Single(c => c.Name == "Japan"), TeaArtUrl = "/Content/Images/placeholder.gif" },
                new Tea{ Title = "Roibus Fusion", TeaType = teatypes.Single(t => t.Name == "RedTea"), Price=0.5M, Country = countries.Single(c => c.Name == "China"), TeaArtUrl = "/Content/Images/placeholder.gif" },
                new Tea{ Title = "Sunset Mango", TeaType = teatypes.Single(t => t.Name == "BlackTea"), Price=1.5M, Country = countries.Single(c => c.Name == "China"), TeaArtUrl = "/Content/Images/placeholder.gif" },
                new Tea{ Title = "Blueberry Tea", TeaType = teatypes.Single(t => t.Name == "PremiumTea"), Price=2.3M, Country = countries.Single(c => c.Name == "Japan"), TeaArtUrl = "/Content/Images/placeholder.gif" },
                new Tea{ Title = "Orient Express", TeaType = teatypes.Single(t => t.Name == "PremiumTea"), Price=2.5M, Country = countries.Single(c => c.Name == "India"), TeaArtUrl = "/Content/Images/placeholder.gif" },
            }.ForEach(t => context.Teas.Add(t));
        }

    }
}