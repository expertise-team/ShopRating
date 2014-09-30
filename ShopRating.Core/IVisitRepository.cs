using System;
using System.Collections.Generic;

namespace ShopRating.Core
{
	public interface IVisitRepository
	{
		IDictionary<DateTime, List<Visit>> GetVisits (string username, string status);
	}
}

