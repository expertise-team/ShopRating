using System;
using System.Collections.Generic;
using System.Linq;
using ShopRating.Core.Models;

namespace ShopRating.Core
{
	public static class InMemoryDB
	{
		public static IList<Visit> GetVisitTable (string username, string status)
		{
			var result = InMemoryDB.GetVisitTable ();
			return result.Where ((v => v.Status == status && v.UserName == username)).ToList ();
		}

		public static IList<Visit> GetVisitTable ()
		{
			var result = new List<Visit> ();
			result.Add (new Visit{ PlanDate = DateTime.Now.Date, Status = "O", ShopName = "Shop 1", UserName = "meszarosl" });
			result.Add (new Visit{ PlanDate = DateTime.Now.Date, Status = "O", ShopName = "Shop 2", UserName = "meszarosl" });
			result.Add (new Visit{ PlanDate = DateTime.Now.Date, Status = "O", ShopName = "Shop 3", UserName = "meszarosl" });
			result.Add (new Visit{ PlanDate = DateTime.Now.Date, Status = "O", ShopName = "Shop 4", UserName = "meszarosl" });

			result.Add (new Visit {
				PlanDate = DateTime.Now.Date.AddDays (-1),
				Status = "O",
				ShopName = "Shop 1",
				UserName = "meszarosl"
			});

			result.Add (new Visit {
				PlanDate = DateTime.Now.Date.AddDays (-1),
				Status = "O",
				ShopName = "Shop 2",
				UserName = "gonczya"
			});

			result.Add (new Visit {
				PlanDate = DateTime.Now.Date.AddDays (-1),
				Status = "C",
				ShopName = "Shop 7",
				UserName = "meszarosl"
			});
			result.Add (new Visit {
				PlanDate = DateTime.Now.Date.AddDays (-1),
				Status = "C",
				ShopName = "Shop 5",
				UserName = "meszarosl"
			});

			return result;

		}
	}
}

