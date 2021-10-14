namespace WebApiApplicationCrud.Migrations
{
    using System;
	using System.Collections.Generic;
	using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
	using WebApiApplicationCrud.Models;

	internal sealed class Configuration : DbMigrationsConfiguration<WebApiApplicationCrud.DatabaseContext.DefaultDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApiApplicationCrud.DatabaseContext.DefaultDBContext context)
        {
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method
			//  to avoid creating duplicate seed data.
			var cityInPunjab = new List<City> {
				new City {Name="Islamabad" },
				new City {Name= "Rawalpindi" }
			};
			var cityInKPK = new List<City> {
				new City {Name="Peshawer" },
				new City {Name="Nowshera" }
			};
			var cityInSindh = new List<City> {
				new City {Name="Karachi" },
				new City {Name="Hyderabad" }
			};
			var cityInBalochistan = new List<City> {
				new City {Name="Ghuzdar" },
				new City {Name="Gawadar" }
			};

			var stateInPakistan = new List<State> {
				new State { Name="Punjab",  City=cityInPunjab },
				new State { Name="KPK", City=cityInKPK},
				new State { Name="Balochistan", City=cityInBalochistan},
				new State { Name="Sindh",   City=cityInSindh}
			};

			Country country = new Country
			{
				Name = "Pakistan",
				State = stateInPakistan
			};
			context.Countries.Add(country);
			context.SaveChanges();
		}
    }
}
