using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApiApplicationCrud.DatabaseContext;
using WebApiApplicationCrud.Models;

using System.Data.Entity;

namespace WebApiApplicationCrud.ServiceRepositories
{
	public class CountryRepository : ICountryRepository
	{
		private DefaultDBContext DbContext;
		public CountryRepository()
		{
			if (DbContext == null)
			{
				DbContext = new DefaultDBContext();
			}
		}

		public async Task<bool> AddAsync(Country Obj)
		{
			DbContext.Countries.Add(Obj);
			if (await DbContext.SaveChangesAsync() > 0)
			{
				return true;
			}
			else
			{
				return false;
			}

		}

		public async Task<Country> GetAsync(int id)
		{
			return await DbContext.Countries.Include(c => c.State.Select(y => y.City)).FirstOrDefaultAsync(c => c.CountryId == id);
		}

		public async Task<IEnumerable<Country>> GetAllAsync()
		{
			return await DbContext.Countries.Include(c => c.State.Select(y => y.City)).ToListAsync();

		}

		public async Task<bool> RemoveAsync(Country Obj)
		{
			DbContext.Countries.Remove(Obj);
			if (await DbContext.SaveChangesAsync() > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public async Task<bool> UpdateAsync(Country ExistingObj, Country UpdatedObj)
		{
			DbContext.Entry(ExistingObj).CurrentValues.SetValues(UpdatedObj);
			if (await DbContext.SaveChangesAsync() > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}