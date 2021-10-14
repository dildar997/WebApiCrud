using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApiApplicationCrud.Models;

namespace WebApiApplicationCrud.ServiceRepositories
{
	public interface ICityRepository
	{
		Task<IEnumerable<City>> GetAllAsync();
		Task<City> GetAsync(int id);
		Task<bool> AddAsync(City Obj);
		Task<bool> RemoveAsync(City Obj);
		Task<bool> UpdateAsync(City ExistingObj, City UpdatedObj);
	}
}