using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApiApplicationCrud.Models;

namespace WebApiApplicationCrud.DatabaseContext
{
	public class DefaultDBContext: DbContext, IDisposable
	{
		public DefaultDBContext() : base("name = DefaultConnection")
		{

		}

		public virtual DbSet<Country> Countries { get; set; }
		public virtual DbSet<State> States { get; set; }
		public virtual DbSet<City> Cities { get; set; }
	}
}