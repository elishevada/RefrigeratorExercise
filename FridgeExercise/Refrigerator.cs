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


		public Refrigerator(string model, string color, int numberOfShelves) {
			RefrigeratorID = CounterID;
			CounterID++;
			Model = model;
			Color = color;
			NumberOfShelves = numberOfShelves;
			Shelves = new List<Shelf>();

		}

		public string ToString(Refrigerator refrigerator)
		{
			return "Refrigerator: Model:  " + refrigerator.Model + "  Color: " + refrigerator.Color + "  NumberOfShelves:  "+ refrigerator.NumberOfShelves + "";
		}

		public double SpaceIsLeftInTheFridge(List<Shelf> shelves)
		{
			double currentSpace = 0;
			foreach (Shelf shelf in shelves)
			{
				currentSpace += shelf.CurrentSpaceInShelf;
			}
			return currentSpace;
		}
		public void PutItemInTheFridge(Item item, List<Shelf> shelves)
		{
			foreach (Shelf shelf in shelves)
			{
				if (shelf.CurrentSpaceInShelf - item.SpaceItTakes >= 0)
				{

					shelf.CurrentSpaceInShelf -= item.SpaceItTakes;
					shelf.Items.Add(item);
					item.ItemBelongsToShelf = shelf;
					return;
				}
			}
			Console.WriteLine("There is no  space for this item");
		}
		public string TakeOutItem(int ItemId, List<Shelf> shelves)
		{
			Item tempItem=null;
			foreach(Shelf shelf in shelves)
			{
				foreach(Item item in shelf.Items.ToList())
				{
					if(item.ItemID == ItemId)
					{
						tempItem = item;
						shelf.CurrentSpaceInShelf+=item.SpaceItTakes;
						shelf.Items.Remove(item);
						break;
					}
				}
			}
			if (tempItem == null)

				return "tempItem in TakeOutItem function is null ";

			else
				return tempItem.ToString(tempItem);
		}
		public void FridgeCleaning(List<Shelf> shelves)
		{
			foreach (Shelf shelf in shelves)
			{
				foreach(Item item in shelf.Items.ToList())
				{
					Console.WriteLine(item.ToString(item));
					if (DateTime.Compare(DateTime.Now, item.ExpiryDate) > 0)
					{
						shelf.CurrentSpaceInShelf += item.SpaceItTakes;
						shelf.Items.Remove(item);
					}
				}
			}
			

		}
		public void WhatDoIWantToEat(string type,string kosherType, List<Shelf> shelves)
		{
			foreach (Shelf shelf in shelves)
			{
				foreach (Item item in shelf.Items)
				{
					if (item.Type.ToString()==type && item.KosherType.ToString()==kosherType&& DateTime.Compare(DateTime.Now, item.ExpiryDate)<= 0)
					{
						Console.WriteLine(item.ToString(item));
					}
				}
			}
		}
		public void SortItemsByDate(List<Shelf> shelves)
		{
			List<Item> AllItems= new List<Item>();
			foreach (Shelf shelf in shelves)
			{
				AllItems.AddRange(shelf.Items);
				
			}

			AllItems.Sort((x, y) => DateTime.Compare(x.ExpiryDate, y.ExpiryDate));
			foreach (Item item in AllItems)
			{
				Console.WriteLine(item.ToString(item));
			}
		}
		public void SortShelvesBySpace(List<Shelf> shelves)
		{
			List<Shelf> sortedShelvesList= shelves.OrderByDescending(x => x.CurrentSpaceInShelf).ToList();
			foreach (Shelf shelf in sortedShelvesList)
			{
				Console.WriteLine(shelf.ToString(shelf));
			}
		}

		public void GoingShopping(List<Shelf> shelves)
		{
			List<Item> AllItemsToThrow = new List<Item>();
			if (SpaceIsLeftInTheFridge(shelves) >= 20)
			{
				Console.WriteLine("There is enough space in the fridge for shopping");
				return;
			}
			else//expired items
			{

				foreach (Shelf shelf in shelves)
				{
					foreach (Item item in shelf.Items.ToList())
					{
						if (DateTime.Compare(DateTime.Now, item.ExpiryDate) > 0)
						{
							shelf.CurrentSpaceInShelf += item.SpaceItTakes;
							shelf.Items.Remove(item);
						}
					}
				}

				if (SpaceIsLeftInTheFridge(shelves) >= 20)
				{
					Console.WriteLine("There is enough space in the fridge for shopping");
					return;
				}
				else//dairy less than 3 days
				{
					foreach (Shelf shelf in shelves)
					{
						foreach (Item item in shelf.Items.ToList())
						{
							if (item.KosherType.ToString() == "Dairy" && Math.Abs((DateTime.Now - item.ExpiryDate).Days) < 3)
							{
								AllItemsToThrow.Add(item);
								shelf.Items.Remove(item);
								shelf.CurrentSpaceInShelf += item.SpaceItTakes;

							}
						}
					}
					if (SpaceIsLeftInTheFridge(shelves) >= 20) {
						
						Console.WriteLine("There is enough space in the fridge for shopping,we threw away the dairy items that will expire in less than 3 days");
						return;
					}
					else//meat less than 7 days
					{
						foreach (Shelf shelf in shelves)
						{
							foreach (Item item in shelf.Items.ToList())
							{
								if (item.KosherType.ToString() == "Meat" && Math.Abs((DateTime.Now - item.ExpiryDate).Days) < 7)
								{
									AllItemsToThrow.Add(item);
									shelf.Items.Remove(item);
									shelf.CurrentSpaceInShelf += item.SpaceItTakes;

								}
							}
						}
						if (SpaceIsLeftInTheFridge(shelves) >= 20)
						{
							
							Console.WriteLine("There is enough space in the fridge for shopping,we threw away the meat items that will expire in less than a week and the dairy less than 3 days");
							return;
						}
						else
						{
							foreach (Shelf shelf in shelves)
							{
								foreach (Item item in shelf.Items.ToList())
								{
									if (item.KosherType.ToString() == "Parve" && Math.Abs((DateTime.Now - item.ExpiryDate).Days) < 1)
									{
										AllItemsToThrow.Add(item);
										shelf.Items.Remove(item);
										shelf.CurrentSpaceInShelf += item.SpaceItTakes;

									}
								}
							}
							if (SpaceIsLeftInTheFridge(shelves) >= 20)
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
