
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections;
using ShopRating.Core;
using System.Collections.Generic;
using System.Linq;

namespace ShopRating
{
	public class ShopsToBeVisitedSource : UITableViewSource
	{
		readonly IDictionary<DateTime, List<Visit>> visits;

		public ShopsToBeVisitedSource (IDictionary<DateTime, List<Visit>> visits)
		{
			this.visits = visits;
		}

		public override int NumberOfSections (UITableView tableView)
		{
			// TODO: return the actual number of sections
			return visits.Keys.Count;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			// TODO: return the actual number of items in the section
			return visits [visits.Keys.ElementAt (section)].Count ();
		}

		public override string TitleForHeader (UITableView tableView, int section)
		{
			return  visits.Keys.ElementAt (section).ToShortDateString ();
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (ShopsToBeVisitedCell.Key) as ShopsToBeVisitedCell;
			if (cell == null)
				cell = new ShopsToBeVisitedCell (visits [visits.Keys.ElementAt (indexPath.Section)].ElementAt (indexPath.Row));
			
			// TODO: populate the cell with the appropriate data based on the indexPath

			
			return cell;
		}
	}
}

