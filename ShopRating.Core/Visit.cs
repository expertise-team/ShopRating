using System;
using SQLite.Net.Attributes;

namespace ShopRating.Core
{

	public class Visit
	{
		[PrimaryKey, AutoIncrement]
		public int Id{ get; set; }

		[Indexed]
		public string UserName { get; set; }

		public string ShopName { get; set; }

		[Indexed]
		public DateTime PlanDate { get; set; }

		[Indexed]
		public string Status { get; set; }
	}
}

