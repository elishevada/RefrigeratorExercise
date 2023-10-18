using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeExercise
{
	internal class Shelf
	{
		public int ShelfID { get; set; }
		public int ShelfsFloor { get; set; }
		public double SpaceInShelf { get; set; }
		public List<Item> Items { get; set; }
	}
}
