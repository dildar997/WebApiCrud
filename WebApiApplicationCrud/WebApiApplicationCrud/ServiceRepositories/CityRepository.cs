using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;
using WebApiApplicationCrud.DatabaseContext;
using WebApiApplicationCrud.Models;

namespace WebApiApplicationCrud.ServiceRepositories
{
	public class CityRepository: ICityRepository
	{
		private DefaultDBContext DbContext;
		public CityRepository()
		{
			if (DbContext == null)
			{
				DbContext = new DefaultDBContext();
			}
		}

		public async Task<bool> AddAsync(City Obj)
		{
			DbContext.Cities.Add(Obj);
			if (await DbContext.SaveChangesAsync() > 0)
			{
				return true;
			}
			else
			{
				return false;
			}

		}

		public async Task<City> GetAsync(int id)
		{
			return await DbContext.Cities.FirstOrDefaultAsync(c => c.CityId == id);
		}

		public async Task<IEnumerable<City>> GetAllAsync()
		{
			return await DbContext.Cities.ToListAsync();

		}

		public async Task<bool> RemoveAsync(City Obj)
		{
			DbContext.Cities.Remove(Obj);
			if (await DbContext.SaveChangesAsync() > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public async Task<bool> UpdateAsync(City ExistingObj, City UpdatedObj)
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