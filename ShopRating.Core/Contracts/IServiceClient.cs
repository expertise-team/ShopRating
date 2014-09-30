using System.Collections.Generic;
using ShopRating.Core.Models;
using System;

namespace ShopRating.Core.Contracts
{
	public interface IServiceClient
	{
		IList<Visit> GetVisitPlans (string salesRepresentative, string visitDate);
	}
}

