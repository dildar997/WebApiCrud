using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApiApplicationCrud.DatabaseContext;
using WebApiApplicationCrud.Models;

namespace WebApiApplicationCrud.ServiceRepositories
{
	public class StateRepository :IStateRepository
	{
		private DefaultDBContext DbContext;
		public StateRepository()
		{
			if (DbContext == null)
			{
				DbContext = new DefaultDBContext();
			}
		}

		public async Task<bool> AddAsync(State Obj)
		{
			DbContext.States.Add(Obj);
			if (await DbContext.SaveChangesAsync() > 0)
			{
				return true;
			}
			else
			{
				return false;
			}

		}

		public async Task<State> GetAsync(int id)
		{
			return await DbContext.States.Include(c=> c.City).FirstOrDefaultAsync(c => c.StateId == id);
		}

		public async Task<IEnumerable<State>> GetAllAsync()
		{
			return await DbContext.States.Include(c => c.City).ToListAsync();

		}

		public async Task<bool> RemoveAsync(State Obj)
		{
			DbContext.States.Remove(Obj);
			if (await DbContext.SaveChangesAsync() > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public async Task<bool> UpdateAsync(State ExistingObj, State UpdatedObj)
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