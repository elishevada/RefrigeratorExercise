using FridgeExercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FridgeExercise.Item;
using static System.Net.Mime.MediaTypeNames;

namespace FridgeExercise
{
	
	internal class Program
	{
		public void SortheRefrigerators(List<Refrigerator> AllRefrigerators)
		{
			AllRefrigerators.Sort((x, y) => y.SpaceIsLeftInTheFridge(y.Shelves).CompareTo(x.SpaceIsLeftInTheFridge(x.Shelves)));
			//to work on a copied list do orderbydescending
			foreach (Refrigerator refrigerator in AllRefrigerators)
			{
				Console.WriteLine(refrigerator.ToString(refrigerator));
			}
			
		}
		public void PrintAllInTheFridge(Refrigerator refrigerator)
		{
			Console.WriteLine(refrigerator.ToString(refrigerator));
			foreach (Shelf shelf in refrigerator.Shelves)
			{
				Console.WriteLine(shelf.ToString(shelf));
				foreach (Item item in shelf.Items)
				{
					Console.WriteLine(item.ToString(item));
				}
			}
		}
		public void CheckValidTypeItem(string KosherTypeToEat, string typeToEat,Refrigerator fridge)
		{
			if (typeToEat == "Food" || typeToEat == "Drink")
			{
				if (KosherTypeToEat == "Parve" || KosherTypeToEat == "Dairy" || KosherTypeToEat == "Meat")
					fridge.WhatDoIWantToEat(typeToEat, KosherTypeToEat, fridge.Shelves);
				else
					Console.WriteLine("There is no such a type:" + typeToEat);
			}
			else
				Console.WriteLine("There is no such a kosherType: " + KosherTypeToEat);

		}
		public void InsertItem(Refrigerator fridge)
		{
			int day = 0, month = 0, year = 0;
			Console.WriteLine("Insert an Item:");
			Console.WriteLine("Name:");
			string name = Console.ReadLine();
			Console.WriteLine("Expired date:in this tamplate:dd-mm-yyyy");
			string expireDate = Console.ReadLine();
			string[] dateSeperated = expireDate.Split('-');
			if (dateSeperated.Count() == 3)
			{
				try
				{
					var checkDate = new DateTime(Int32.Parse(dateSeperated[2]), Int32.Parse(dateSeperated[1]), Int32.Parse(dateSeperated[0]));
					day = Int32.Parse(dateSeperated[0]);
					month = Int32.Parse(dateSeperated[1]);
					year = Int32.Parse(dateSeperated[2]);
				}
				catch
				{
					Console.WriteLine("The date is not correct");
					return;
				}

			}
			Console.WriteLine("How much room it takes in square meters ?:enter just a double number");
			double spaceItTakes = double.Parse(Console.ReadLine());
			if (spaceItTakes > 0)
			{
				Console.WriteLine("Is it Dairy Parve Or Meat:notice that you spell it right");
				string kosherType = Console.ReadLine();
				Console.WriteLine("Is it a Drink or Food:notice that you spell it right");
				string type = Console.ReadLine();
				if (type == "Food" || type == "Drink")
				{
					if (kosherType == "Parve" || kosherType == "Dairy" || kosherType == "Meat")
					{
						Item itemToInsert = new Item(name, year, month, day, spaceItTakes, kosherType, type);
						fridge.PutItemInTheFridge(itemToInsert, fridge.Shelves);
					}
					else
						Console.WriteLine("There is no such a type:" + type);
				}
				else
					Console.WriteLine("There is no such a kosherType: " + kosherType);

			}

		}

		static void Main(string[] args)
		{
			var ThisProgramObject = new Program();
			List<Refrigerator> allRefrigerators = new List<Refrigerator>();

			Refrigerator refrigerator2 = new Refrigerator("Sharp", "write", 6);
			allRefrigerators.Add(refrigerator2);
			refrigerator2.Shelves.Add(new Shelf(1, 30));
			refrigerator2.Shelves.Add(new Shelf(2, 30));
			refrigerator2.Shelves.Add(new Shelf(3, 30));
			refrigerator2.Shelves.Add(new Shelf(4, 25));
			refrigerator2.Shelves.Add(new Shelf(3, 10));
			refrigerator2.Shelves.Add(new Shelf(4, 17.5));
			Item item21 = new Item("milk", 2023, 10, 15, 20, "Dairy", "Drink");
			Item item22 = new Item("chily", 2023, 10, 22, 10, "Parve", "Drink");
			Item item23 = new Item("meat", 2023, 10, 17, 30, "Meat", "Food");
			Item item24 = new Item("chocolate", 2023, 10, 20, 5, "Dairy", "Drink");
			refrigerator2.PutItemInTheFridge(item21, refrigerator2.Shelves);
			refrigerator2.PutItemInTheFridge(item22, refrigerator2.Shelves);
			refrigerator2.PutItemInTheFridge(item23, refrigerator2.Shelves);
			refrigerator2.PutItemInTheFridge(item24, refrigerator2.Shelves);



			Refrigerator refrigerator=new Refrigerator("samsung","gray",4);
			allRefrigerators.Add(refrigerator);
			refrigerator.Shelves.Add(new Shelf(1, 10));
			refrigerator.Shelves.Add(new Shelf(2, 10));
			refrigerator.Shelves.Add(new Shelf(3, 10));
			refrigerator.Shelves.Add(new Shelf(4, 10));
			//refrigerator.PutItemInTheFridge(new Item("milk2", 2023, 10, 30, 2, "Dairy", "Drink"), refrigerator.Shelves);
			//refrigerator.PutItemInTheFridge(new Item("chily0", 2023, 10, 22, 4, "Parve", "Drink"), refrigerator.Shelves);
			////refrigerator.PutItemInTheFridge(new Item("meat0", 2023, 10, 17, 10, "Meat", "Food"), refrigerator.Shelves);
			////refrigerator.PutItemInTheFridge(new Item("chocolate", 2024, 10, 20, 5, "Dairy", "Drink"), refrigerator.Shelves);
			//refrigerator.PutItemInTheFridge(new Item("milk", 2023, 10, 25, 10, "Dairy", "Drink"), refrigerator.Shelves);
			////refrigerator.PutItemInTheFridge(new Item("meat", 2023, 10, 27, 15, "Meat", "Drink"), refrigerator.Shelves);
			//refrigerator.PutItemInTheFridge(new Item("meat2", 2023, 10, 31, 2, "Meat", "Drink"), refrigerator.Shelves);
			//refrigerator.PutItemInTheFridge(new Item("chily1", 2023, 10, 24, 10, "Parve", "Drink"), refrigerator.Shelves);
			////refrigerator.PutItemInTheFridge(new Item("milk0", 2023, 10, 20, 19, "Dairy", "Drink"), refrigerator.Shelves);
			//refrigerator.PutItemInTheFridge(new Item("chily2", 2023, 10, 30, 10, "Parve", "Drink"), refrigerator.Shelves);
			//refrigerator.PutItemInTheFridge(new Item("meat3", 2023, 11, 01, 1, "Meat", "Drink"), refrigerator.Shelves);


			int action =0;
			string takeOutItemName="",typeToEat="",KosherTypeToEat="";
			

			while (true)
			{
				Console.WriteLine("Press 1: the program will print all the items on the refrigerator and all its contents.");
				Console.WriteLine("Press 2: the program will print how much space is left in the fridge");
				Console.WriteLine("Press 3: The program will allow you to put an item in the fridge");
				Console.WriteLine("Press 4: The program will allow you to take out an item from the fridge");
				Console.WriteLine("Press 5: the program will clean the refrigerator and print all the checked items .");
				Console.WriteLine("Press 6: the program will ask you: What do you want to eat?; And the program will bring the product.");
				Console.WriteLine("Press 7: the program will print all the products sorted by their expiration date.");
				Console.WriteLine("Press 8: the program will print all the shelves arranged according to the free space left on them.");
				Console.WriteLine("Press 9: the program will print all the refrigerators arranged according to the free space left in them");
				Console.WriteLine("Press 10: The program will prepare the refrigerator for shopping");
				Console.WriteLine("Press 100: system shutdown.");

				action = 0;

				try
				{
					action = Int32.Parse(Console.ReadLine());
				}
				catch
				{
					Console.WriteLine("Please press a number below");
					continue;
				}
				
				switch (action)
				{
					case 1:
						ThisProgramObject.PrintAllInTheFridge(refrigerator);
						break;
					case 2:
						Console.WriteLine("There are  "+ refrigerator.SpaceIsLeftInTheFridge(refrigerator.Shelves) + " square meters");
						break;
					case 3:
						ThisProgramObject.InsertItem(refrigerator);
						
						break;
					case 4:
						var temp = 0;
						Console.WriteLine("What is the item name that you want to take out");
						takeOutItemName=Console.ReadLine();
						foreach(Shelf shelf in refrigerator.Shelves)
						{
							foreach(Item item in shelf.Items)
							{
								if(item.Name == takeOutItemName)
								{
									temp = 1;
									refrigerator.TakeOutItem(item.ItemID, refrigerator.Shelves);
									Console.WriteLine("Succed to remove the item");
									break;//if there are 2 or more dont break
								}
							}
						}
						if(temp==0)
							Console.WriteLine("The item dont exist");//both 
						break;
					case 5:
						refrigerator.FridgeCleaning(refrigerator.Shelves);//print all product had checked
						break;
					case 6:
						Console.WriteLine("What do you want to eat:Food or Drink and Meat Dairy or Parve");
						typeToEat=Console.ReadLine();
						KosherTypeToEat=Console.ReadLine();
						ThisProgramObject.CheckValidTypeItem(KosherTypeToEat, typeToEat,refrigerator);
						
						break;
					case 7:
						refrigerator.SortItemsByDate(refrigerator.Shelves);
						break;
					case 8:
						refrigerator.SortShelvesBySpace(refrigerator.Shelves);
						break;
					case 9:
						ThisProgramObject.SortheRefrigerators(allRefrigerators);
						break;
					case 10:
						refrigerator.GoingShopping(refrigerator.Shelves);
						break;
					case 100:
						System.Environment.Exit(0);
						return;
						
					default:
						Console.WriteLine("You had not presses a number from the options");
						break;
				}
			}

			

			
		}
	}
}