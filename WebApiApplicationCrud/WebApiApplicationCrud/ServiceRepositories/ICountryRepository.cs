using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApiApplicationCrud.Models;

namespace WebApiApplicationCrud.ServiceRepositories
{
	public interface ICountryRepository
	{
		Task<IEnumerable<Country>> GetAllAsync();
		Task<Country> GetAsync(int id);
		Task<bool> AddAsync(Country Obj);
		Task<bool> RemoveAsync(Country Obj);
		Task<bool> UpdateAsync(Country ExistingObj, Country UpdatedObj);
	}
}