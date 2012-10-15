using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TeaStore.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<TeaDatabaseContext>
    {
        protected override void Seed(TeaDatabaseContext context)
        {
            var types = new List<Type>
            {
                new Type{Name = "Black tea"},
                new Type{Name = "Green tea"},
                new Type{Name = "Red tea"},
                new Type{Name = "Premium tea"}
            };

            new List<Tea>
            {
                new Tea { Title = "breakfast cream", Type = types.Single(t => t.Name == "Black tea"), Price = 1.99M, Description = "Breakfast tea."},
                new Tea { Title = "Morning lime", Type = types.Single(t => t.Name == "Green tea"), Price = 1.99M, Description = "Green cirtus tea."},
                new Tea { Title = "Roibus Fusion", Type = types.Single(t => t.Name == "Red tea"), Price = 1.99M, Description = "Red tea from china."},
                new Tea { Title = "Mountain dream", Type = types.Single(t => t.Name == "Premium tea"), Price = 2.99M, Description = "Special collection tea."}
            }.ForEach(t => context.Teas.Add(t));

        }

    }
}