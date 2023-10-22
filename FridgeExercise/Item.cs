﻿using System;
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
		public int SpaceItTakes { get; set; }
		public Shelf ItemBelongsToShelf { get; set; }
		
		public KosherTypeEnum KosherType { get; set; }
		public TypeEnum Type { get; set; }

		public enum TypeEnum
		{
			Food,
			Drink
		}
		public enum KosherTypeEnum
		{
			Dairy,
			Meat,
			Parve
		}
		public Item(string name, int year,int month,int day, int spaceItTakes, KosherTypeEnum kosherType, TypeEnum type)
		{
			ItemID = CounterID;
			CounterID++;
			Name = name;
			ExpiryDate = new DateTime(year, month, day); 
			SpaceItTakes = spaceItTakes;
			KosherType = kosherType;
			Type = type;
		}

		public override string ToString()
		{
			return "Item: Name:" + Name + "    ExpiryDate: " + ExpiryDate + "    SpaceItTakes:" + SpaceItTakes + "  KosherType:" + KosherType + "  Type:" + Type +" Foor:" + ItemBelongsToShelf.ShelfsFloor + "";
		}
	}
}
