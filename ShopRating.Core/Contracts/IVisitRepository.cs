using System;
using System.Collections.Generic;
using ShopRating.Core.Models;
using System.Threading.Tasks;

namespace ShopRating.Core.Contracts
{
	public interface IVisitRepository
	{
		Task<IDictionary<DateTime, List<Visit>>> GetVisitsAsync (string username, string status);
	}
}

