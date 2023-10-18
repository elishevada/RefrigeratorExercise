using FridgeExercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator
{
	
	internal class Program
	{
		static void Main(string[] args)
		{
			Item item=new Item("milk",DateTime.Now,3,null,KosherType.Dairy,Type.Drink);
		}
	}
}