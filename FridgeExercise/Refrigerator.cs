using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FridgeExercise
{
	internal class Refrigerator
	{
		public int RefrigeratorID { get; set; }
		private int CounterID = 1;
		public int Model { get; set; }
		public string Color { get; set; }
		public int NumberOfShelves { get; set; }
		public List<Shelf> Shelves { get; set; }


		public Refrigerator(int model, string color, int numberOfShelves, List<Shelf> shelves) {
			RefrigeratorID = CounterID;
			CounterID++;
			Model = model;
			Color = color;
			NumberOfShelves = numberOfShelves;
			Shelves = new List<Shelf>(shelves);

		}

		public override string ToString()
		{
			return "Refrigerator: Model:" + Model + "Color: " + Color+ "NumberOfShelves:"+ NumberOfShelves+"";
		}

	}
}
