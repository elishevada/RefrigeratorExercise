using FridgeExercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FridgeExercise.Item;

namespace FridgeExercise
{
	
	internal class Program
	{
		public void SortedRefrigerators(List<Refrigerator> AllRefrigerators)
		{
			AllRefrigerators.Sort((x, y) => y.SpaceIsLeftInTheFridge().CompareTo(x.SpaceIsLeftInTheFridge()));
			//to work on a copied list do orderbydescending
			foreach (Refrigerator refrigerator in AllRefrigerators)
			{
				Console.WriteLine(refrigerator.ToString());
			}
			
		}
		static void Main(string[] args)
		{
			List<Refrigerator> AllRefrigerators = new List<Refrigerator>();
			
			//Item item=new Item("milk",2023,10,15,3,KosherTypeEnum.Dairy,TypeEnum.Drink);
			//Console.WriteLine("{0}",item.ToString());

			Refrigerator refrigerator=new Refrigerator("samsung","gray",4);
			AllRefrigerators.Add(refrigerator);
			refrigerator.Shelves.Add(new Shelf(1, 30));
			refrigerator.Shelves.Add(new Shelf(2, 30));
			refrigerator.Shelves.Add(new Shelf(3, 30));
			refrigerator.Shelves.Add(new Shelf(4, 25));
			Item item1 = new Item("milk", 2023, 10, 15, 20,KosherTypeEnum.Dairy, TypeEnum.Drink);
			Item item2 = new Item("chily", 2023, 10, 22, 10,KosherTypeEnum.Parve, TypeEnum.Drink);
			Item item3 = new Item("meat", 2023, 10, 17, 30,KosherTypeEnum.Meat, TypeEnum.Food);
			Item item4= new Item("chocolate", 2023, 10, 20, 5,KosherTypeEnum.Dairy,TypeEnum.Drink);
			refrigerator.PutItemInTheFridge(item1);
			refrigerator.PutItemInTheFridge(item2);
			refrigerator.PutItemInTheFridge(item3);
			refrigerator.PutItemInTheFridge(item4);


			//print all about the fridge
			Console.WriteLine(refrigerator.ToString());
			foreach (Shelf shelf in refrigerator.Shelves)
			{
				Console.WriteLine(shelf.ToString());
				foreach(Item item in shelf.Items)
				{
					Console.WriteLine(item.ToString());
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