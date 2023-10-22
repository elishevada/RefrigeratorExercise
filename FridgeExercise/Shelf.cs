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
		public int SpaceInShelf { get; set; }
		public List<Item> Items { get; set; }
		public int CurrentSpaceInShelf { get; set; }

		public Shelf(int shelfsFloor,int spaceInShelf/*, List<Item> items*/) {
			ShelfID = CounterID;
			CounterID++;
			ShelfsFloor = shelfsFloor;
			SpaceInShelf = spaceInShelf;
			CurrentSpaceInShelf = spaceInShelf;
			Items = new List<Item>(/*items*/);

		}
		public override string ToString()
		{
			return" Shelf: shelfsFloor:" + ShelfsFloor +" SpaceInShelf: " + SpaceInShelf;
		}
	}
}
