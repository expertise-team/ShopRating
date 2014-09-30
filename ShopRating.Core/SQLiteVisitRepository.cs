using System;
using System.Collections.Generic;
using SQLite.Net;
using SQLite.Net.Interop;
using System.Linq;

namespace ShopRating.Core
{
	public class SQLiteVisitRepository: IVisitRepository
	{
		readonly SQLiteConnection db;

		public SQLiteVisitRepository (ISQLitePlatform sqliteplatform)
		{
			db = new SQLiteConnection (sqliteplatform, "shoprating.db3");
			db.CreateTable<Visit> ();
			if (db.Table<Visit> ().Count () == 0) {
				db.InsertAll (InMemoryDB.GetVisitTable ());
			}
		}

		#region IVisitRepository implementation

		public IDictionary<DateTime, List<Visit>> GetVisits (string username, string status)
		{
			var table = db.Table<Visit> ().Where (v => v.UserName == username && v.Status == status);
			var result = table
				.GroupBy (v => v.PlanDate)
				.OrderBy (p => p.Key)
				.ToDictionary (g => g.Key, g => g.ToList ());
			return result;
		}

		#endregion
	}
}

