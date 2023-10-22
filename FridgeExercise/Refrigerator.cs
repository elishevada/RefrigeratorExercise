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
		public string Model { get; set; }
		public string Color { get; set; }
		public int NumberOfShelves { get; set; }
		public List<Shelf> Shelves { get; set; }


		public Refrigerator(string model, string color, int numberOfShelves/*, List<Shelf> shelves*/) {
			RefrigeratorID = CounterID;
			CounterID++;
			Model = model;
			Color = color;
			NumberOfShelves = numberOfShelves;
			Shelves = new List<Shelf>(/*shelves*/);

		}

		public override string ToString()
		{
			return "Refrigerator: Model:" + Model + "Color: " + Color+ "NumberOfShelves:"+ NumberOfShelves+"";
		}

		public int SpaceIsLeftInTheFridge()
		{
			int currentSpace = 0;
			foreach (Shelf shelf in Shelves)
			{
				currentSpace += shelf.CurrentSpaceInShelf;
			}
			return currentSpace;
		}
		public void PutItemInTheFridge(Item item)
		{
			foreach (Shelf shelf in Shelves)
			{
				if (shelf.CurrentSpaceInShelf - item.SpaceItTakes >= 0)
				{

					shelf.CurrentSpaceInShelf -= item.SpaceItTakes;
					shelf.Items.Add(item);
					item.ItemBelongsToShelf = shelf;
					return;
				}
			}
		}
		public string TakeOutItem(int ItemId)
		{
			Item tempItem=null;
			foreach(Shelf shelf in Shelves)
			{
				foreach(Item item in shelf.Items)
				{
					if(item.ItemID == ItemId)
					{
						tempItem = item;
						shelf.CurrentSpaceInShelf+=item.SpaceItTakes;
						shelf.Items.Remove(item);
					}
				}
			}
			if (tempItem == null)

				return "tempItem in TakeOutItem function is null ";

			else
				return tempItem.ToString();
		}
		public void FridgeCleaning()
		{
			foreach(Shelf shelf in Shelves)
			{
				foreach(Item item in shelf.Items)
				{
					if (DateTime.Compare(DateTime.Now, item.ExpiryDate) > 0)
					{
						shelf.CurrentSpaceInShelf -= item.SpaceItTakes;
						shelf.Items.Remove(item);
					}
				}
			}
		}
		public void WhatDoIWantToEat(string type,string kosherType)
		{
			foreach (Shelf shelf in Shelves)
			{
				foreach (Item item in shelf.Items)
				{
					if (item.Type.ToString()==type && item.KosherType.ToString()==kosherType&& DateTime.Compare(DateTime.Now, item.ExpiryDate)<= 0)
					{
						Console.WriteLine(item.ToString());
					}
				}
			}
		}
		public void SortItems()
		{
			List<Item> AllItems= new List<Item>();
			foreach (Shelf shelf in Shelves)
			{
				AllItems.AddRange(shelf.Items);
				//shelf.Items = (List<Item>)(from i in shelf.Items
				//			  orderby i.ExpiryDate
				//			  select i);
				//shelf.Items.ForEach(i => Console.WriteLine(i.ToString()));

				//shelf.Items.Sort((x, y) => DateTime.Compare(x.ExpiryDate, y.ExpiryDate));
				//shelf.Items = shelf.Items.OrderBy(x => x.ExpiryDate).ToList();

			}

			AllItems.Sort((x, y) => DateTime.Compare(x.ExpiryDate, y.ExpiryDate));
			foreach (Item item in AllItems)
			{
				Console.WriteLine(item.ToString());
			}
		}
		public void SortShelves()
		{
			List<Shelf> sortedShelvesList= Shelves.OrderByDescending(x => x.CurrentSpaceInShelf).ToList();
			//Shelves.Sort((x, y) => y.CurrentSpaceInShelf.CompareTo(x.CurrentSpaceInShelf));
			foreach (Shelf shelf in sortedShelvesList)
			{
				Console.WriteLine(shelf.ToString());
			}
		}

		public void GoingShopping()
		{
			List<Item> AllItemsToThrow = new List<Item>();
			if (SpaceIsLeftInTheFridge() >= 20)
			{
				Console.WriteLine("There is enough space in the fridge for shopping");
				return;
			}
			else//expired items
			{
				FridgeCleaning();
				if (SpaceIsLeftInTheFridge() >= 20)
				{
					Console.WriteLine("There is enough space in the fridge for shopping");
					return;
				}
				else//dairy less than 3 days
				{
					foreach (Shelf shelf in Shelves)
					{
						foreach (Item item in shelf.Items)
						{
							if (item.KosherType.ToString() == "Dairy" && (DateTime.Now - item.ExpiryDate).Days < 3)
							{
								AllItemsToThrow.Add(item);
								shelf.Items.Remove(item);
								shelf.CurrentSpaceInShelf -= item.SpaceItTakes;

							}
						}
					}
					if (SpaceIsLeftInTheFridge() >= 20) {
						
						
						
						
						Console.WriteLine("There is enough space in the fridge for shopping, the dairy items that will expire in less than 3 days");
						return;
					}
					else//meat less than 7 days
					{
						foreach (Shelf shelf in Shelves)
						{
							foreach (Item item in shelf.Items)
							{
								if (item.KosherType.ToString() == "Meat" && (DateTime.Now - item.ExpiryDate).Days < 7)
								{
									AllItemsToThrow.Add(item);
									shelf.Items.Remove(item);
									shelf.CurrentSpaceInShelf -= item.SpaceItTakes;

								}
							}
						}
						if (SpaceIsLeftInTheFridge() >= 20)
						{
							
							Console.WriteLine("There is enough space in the fridge for shopping, the meat items that will expire in less than a week and the dairy less than 3 days");
							return;
						}
						else
						{
							foreach (Shelf shelf in Shelves)
							{
								foreach (Item item in shelf.Items)
								{
									if (item.KosherType.ToString() == "Parve" && (DateTime.Now - item.ExpiryDate).Days < 1)
									{
										AllItemsToThrow.Add(item);
										shelf.Items.Remove(item);
										shelf.CurrentSpaceInShelf -= item.SpaceItTakes;

									}
								}
							}
							if (SpaceIsLeftInTheFridge() >= 20)
							{
								Console.WriteLine("There is enough space in the fridge for shopping,we threw away the parve items that will expire in less than a day,the dairy less than 3 days andthe meat less than aweek");
								return;
							}
							else
							{
								foreach(Item item in AllItemsToThrow)
								{
									item.ItemBelongsToShelf.Items.Add(item);
								}
								Console.WriteLine("There is no space in the fridge you can't go shopping");


							}
						}
					}
				}
			}
				
		}




	}
}
