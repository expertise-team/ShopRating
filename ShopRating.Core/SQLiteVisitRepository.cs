using System;
using System.Collections.Generic;
using SQLite.Net;
using SQLite.Net.Interop;
using System.Linq;
using ShopRating.Core.Contracts;
using ShopRating.Core.Models;
using System.Threading.Tasks;
using SQLite.Net.Async;

namespace ShopRating.Core
{
	public class SQLiteVisitRepository: IVisitRepository
	{
		readonly SQLiteConnectionWithLock connection;

		public SQLiteVisitRepository (ISQLitePlatform sqliteplatform)
		{
			connection = new SQLiteConnectionWithLock (sqliteplatform, new SQLiteConnectionString ("shoprating.db3", false));
		}

		#region IVisitRepository implementation

		public async Task<IDictionary<DateTime, List<Visit>>> GetVisitsAsync (string username, string status)
		{
			IDictionary<DateTime, List<Visit>> result;

			var db = new SQLiteAsyncConnection (() => connection);

			await db.CreateTableAsync<Visit> ();

			// for demo
			if (await db.Table<Visit> ().CountAsync () == 0) {
				await db.InsertAllAsync (InMemoryDB.GetVisitTable ());
			}

			var table = await db.Table<Visit> ().Where (v => v.UserName == username && v.Status == status).ToListAsync ();

			result = table
				.GroupBy (v => v.PlanDate)
				.OrderBy (p => p.Key)
				.ToDictionary (g => g.Key, g => g.ToList ());

			return result;
		}

		#endregion
	}
}