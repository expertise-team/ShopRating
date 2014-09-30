using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopRating.Core
{
	public class InMemoryVisitRepository: IVisitRepository
	{

		#region IVisitRepository implementation

		public IDictionary<DateTime, List<Visit>> GetVisits (string username, string status)
		{

			var result = InMemoryDB.GetVisitTable (username, status)
				.GroupBy (v => v.PlanDate)
				.OrderBy (p => p.Key)
				.ToDictionary (g => g.Key, g => g.ToList ());
			return result;
		}

		#endregion
	}
}

