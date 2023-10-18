using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeExercise
{
	internal class Item
	{
		public int ItemID { get; set; }
		public int Name { get; set; }
		public DateTime ExpiryDate { get; set; }
		public double SpaceItTakes { get; set; }
		public Shelf ItemBelongsToShelf { get; set; }
		enum Type
		{
			Food,
			Drink
		}
		enum KosherType
		{
			Dairy,
			Meat,
			Parve
		}
	}
}
