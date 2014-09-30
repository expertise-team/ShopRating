
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using ShopRating.Core;

namespace ShopRating
{
	public class ShopsToBeVisitedController : UITableViewController
	{
		readonly IVisitRepository visits;

		public ShopsToBeVisitedController (IVisitRepository visits) : base (UITableViewStyle.Grouped)
		{
			this.visits = visits;
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Register the TableView's data source
			TableView.Source = new ShopsToBeVisitedSource (visits.GetVisits ("meszarosl", "O"));
		}
	}
}

