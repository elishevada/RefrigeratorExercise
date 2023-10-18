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
		private int CounterID = 1;
		public string Name { get; set; }
		public DateTime ExpiryDate { get; set; }
		public double SpaceItTakes { get; set; }
		public Shelf ItemBelongsToShelf { get; set; }
		//enum Type
		//{
		//	Food,
		//	Drink
		//}
		//enum KosherType
		//{
		//	Dairy,
		//	Meat,
		//	Parve
		//}
		public KosherType KosherType { get; set; }
		public Type Type { get; set; }

		public enum Type
		{
			Food,
			Drink
		}
		public enum KosherType
		{
			Dairy,
			Meat,
			Parve
		}
		public Item(string name, DateTime expiryDate, double spaceItTakes, Shelf itemBelongsToShelf, KosherType kosherType, Type type)
		{
			ItemID = CounterID;
			CounterID++;
			Name = name;
			ExpiryDate = expiryDate;
			SpaceItTakes = spaceItTakes;
			ItemBelongsToShelf = itemBelongsToShelf;
			KosherType = kosherType;
			Type = type;
		}
	}
}
