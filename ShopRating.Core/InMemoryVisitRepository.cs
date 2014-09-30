using System;
using System.Collections.Generic;
using System.Linq;
using ShopRating.Core.Contracts;
using ShopRating.Core.Models;
using System.Threading.Tasks;

namespace ShopRating.Core
{
	public class InMemoryVisitRepository: IVisitRepository
	{

		#region IVisitRepository implementation

		public async Task<IDictionary<DateTime, List<Visit>>> GetVisitsAsync (string username, string status)
		{
			IDictionary<DateTime, List<Visit>> result = null;

			await Task.Run (() => {
				result = InMemoryDB.GetVisitTable (username, status)
					.GroupBy (v => v.PlanDate)
					.OrderBy (p => p.Key)
					.ToDictionary (g => g.Key, g => g.ToList ());
			});
				
			return result;
		}

		#endregion
	}
}