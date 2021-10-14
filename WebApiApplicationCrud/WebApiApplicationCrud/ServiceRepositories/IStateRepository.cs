using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApiApplicationCrud.Models;

namespace WebApiApplicationCrud.ServiceRepositories
{
	public interface IStateRepository
	{
		Task<IEnumerable<State>> GetAllAsync();
		Task<State> GetAsync(int id);
		Task<bool> AddAsync(State Obj);
		Task<bool> RemoveAsync(State Obj);
		Task<bool> UpdateAsync(State ExistingObj, State UpdatedObj);
	}
}