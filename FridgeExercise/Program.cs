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
			AllRefrigerators.Sort((x, y) => y.SpaceIsLeftInTheFridge().CompareTo(x.SpaceIsLeftInTheFridge()));
			//to work on a copied list do orderbydescending
			foreach (Refrigerator refrigerator in AllRefrigerators)
			{
				Console.WriteLine(refrigerator.ToString());
			}
			
		}
		public void PrintAllInTheFridge(Refrigerator refrigerator)
		{
			Console.WriteLine(refrigerator.ToString());
			foreach (Shelf shelf in refrigerator.Shelves)
			{
				Console.WriteLine(shelf.ToString());
				foreach (Item item in shelf.Items)
				{
					Console.WriteLine(item.ToString());
				}
			}
		}
		static void Main(string[] args)
		{
			var ThisProgramObject = new Program();
			List<Refrigerator> AllRefrigerators = new List<Refrigerator>();

			Refrigerator refrigerator2 = new Refrigerator("Sharp", "write", 6);
			AllRefrigerators.Add(refrigerator2);
			refrigerator2.Shelves.Add(new Shelf(1, 30));
			refrigerator2.Shelves.Add(new Shelf(2, 30));
			refrigerator2.Shelves.Add(new Shelf(3, 30));
			refrigerator2.Shelves.Add(new Shelf(4, 25));
			refrigerator2.Shelves.Add(new Shelf(3, 10));
			refrigerator2.Shelves.Add(new Shelf(4, 17.5));
			Item item21 = new Item("milk", 2023, 10, 15, 20, KosherTypeEnum.Dairy, TypeEnum.Drink);
			Item item22 = new Item("chily", 2023, 10, 22, 10, KosherTypeEnum.Parve, TypeEnum.Drink);
			Item item23 = new Item("meat", 2023, 10, 17, 30, KosherTypeEnum.Meat, TypeEnum.Food);
			Item item24 = new Item("chocolate", 2023, 10, 20, 5, KosherTypeEnum.Dairy, TypeEnum.Drink);
			refrigerator2.PutItemInTheFridge(item21);
			refrigerator2.PutItemInTheFridge(item22);
			refrigerator2.PutItemInTheFridge(item23);
			refrigerator2.PutItemInTheFridge(item24);



			Refrigerator refrigerator=new Refrigerator("samsung","gray",4);
			AllRefrigerators.Add(refrigerator);
			refrigerator.Shelves.Add(new Shelf(1, 30));
			refrigerator.Shelves.Add(new Shelf(2, 30));
			refrigerator.Shelves.Add(new Shelf(3, 30));
			refrigerator.Shelves.Add(new Shelf(4, 25));
			//Item item1 = new Item("milk", 2023, 10, 15, 20,KosherTypeEnum.Dairy, TypeEnum.Drink);
			//Item item2 = new Item("chily", 2023, 10, 22, 10,KosherTypeEnum.Parve, TypeEnum.Drink);
			//Item item3 = new Item("meat", 2023, 10, 17, 30,KosherTypeEnum.Meat, TypeEnum.Food);
			//Item item4= new Item("chocolate", 2023, 10, 20, 5,KosherTypeEnum.Dairy,TypeEnum.Drink);
			//refrigerator.PutItemInTheFridge(item1);
			//refrigerator.PutItemInTheFridge(item2);
			//refrigerator.PutItemInTheFridge(item3);
			//refrigerator.PutItemInTheFridge(item4);


			int action=0,day=0,month=0,year=0;
			string name="",expireDate="",kosherType="",Type="", takeOutItemName="";
			double spaceItTakes=0;
			string[] dateSeperated= { "", "", "" };

			while (true)
			{
				Console.WriteLine("Press 1: the program will print all the items on the refrigerator and all its contents.");
				Console.WriteLine("Press 2: the program will print how much space is left in the fridge");
				Console.WriteLine("Press 3: The program will allow you to put an item in the fridge");
				Console.WriteLine("Press 4: The program will allow you to put an item in the fridge");
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
					action = int.Parse(Console.ReadLine());
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
						Console.WriteLine("There are  "+ refrigerator.SpaceIsLeftInTheFridge()+ " square meters");
						break;
					case 3:
						Console.WriteLine("Enter an Item:");
						Console.WriteLine("Name:");
						name = Console.ReadLine();
						Console.WriteLine("Expired date:in this tamplate:dd-mm-yyyy");
						expireDate = Console.ReadLine();
						dateSeperated = expireDate.Split('-');

						day = Int32.Parse(dateSeperated[0]);
						month = Int32.Parse(dateSeperated[1]);
						year = Int32.Parse(dateSeperated[2]);
						Console.WriteLine("How much room it takes in square meters ?:enter just a double number");
						spaceItTakes = double.Parse(Console.ReadLine());
						Console.WriteLine("Is it Dairy Parve Or Meat:notice that you spell it right");
						kosherType = Console.ReadLine();
						Console.WriteLine("Is it a Drink or Food:notice that you spell it right");
						Type = Console.ReadLine();
						break;
					case 4:
						takeOutItemName=Console.ReadLine();
						foreach(Shelf shelf in refrigerator.Shelves)
						{
							foreach(Item item in shelf.Items)
							{
								if(item.Name == takeOutItemName)
								{
									refrigerator.TakeOutItem(item.ItemID); break;//if there are 2
								}
							}
						}
						break;
					case 5:
						refrigerator.FridgeCleaning();//print all product had checked
						break;
					case 6:
						
						break;
					case 7:
						
						break;
					case 8:
						
						break;
					case 9:
						
						break;
					case 10:
						
						break;
					case 100:
						//ThisProgramObject.Exit();
						break;
					default:
						Console.WriteLine("You had not presses a number from the options");
						break;
				}
			}

			

			//// Declare two dates
			//var prevDate = new DateTime(2023, 10, 19); //15 July 2021
			//var today = DateTime.Now;

			////get difference of two dates
			//var diffOfDates = today - prevDate;
			//Console.WriteLine("Difference in Days: {0}", diffOfDates.Days);
			//Console.WriteLine();
		}
	}
}