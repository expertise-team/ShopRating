
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using ShopRating.Core;

namespace ShopRating
{
	public class ShopsToBeVisitedCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("ShopsToBeVisitedCell");

		public ShopsToBeVisitedCell (Visit visit) : base (UITableViewCellStyle.Default, Key)
		{
			// TODO: add subviews to the ContentView, set various colors, etc.
			TextLabel.Text = visit.ShopName;
			Accessory = visit.Status == "O" ? UITableViewCellAccessory.DisclosureIndicator : UITableViewCellAccessory.Checkmark;

		}
	}
}

