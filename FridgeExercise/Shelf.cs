﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeExercise
{
	internal class Shelf
	{
		public int ShelfID { get; set; }
		private int CounterID = 1;
		public int ShelfsFloor { get; set; }
		public double SpaceInShelf { get; set; }
		public List<Item> Items { get; set; }

		public Shelf(int shelfsFloor,double spaceInShelf, List<Item> items) {
			ShelfID = CounterID;
			CounterID++;
			ShelfsFloor = shelfsFloor;
			SpaceInShelf = spaceInShelf;
			Items = new List<Item>(items);

		}
	}
}
