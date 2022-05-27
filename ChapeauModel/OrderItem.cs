using System;

namespace ChapeauModel
{
	public class OrderItem
	{
		public MenuItem menuItem { get; set; }
		public Order Order { get; set; }
		public int Amount { get; set; }

	}
}

