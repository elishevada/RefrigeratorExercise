using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
		public double CurrentSpaceInShelf { get; set; }

		public Shelf(int shelfsFloor, double spaceInShelf) {
			ShelfID = CounterID;
			CounterID++;
			ShelfsFloor = shelfsFloor;
			SpaceInShelf = spaceInShelf;
			CurrentSpaceInShelf = spaceInShelf;
			Items = new List<Item>();

		}
		public string ToString(Shelf shelf)
		{
			return" Shelf: shelfsFloor:" + shelf.ShelfsFloor + " SpaceInShelf: " + shelf.SpaceInShelf+ " CurrentSpaceInShelf: " + shelf.CurrentSpaceInShelf;
		}
	}
}
