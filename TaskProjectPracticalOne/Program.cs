using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TaskProjectPracticalOne.Model;

namespace TaskProjectPracticalOne
{
	public class Program 
	{
		static void Main(string[] args)
		{

			List<FirstModel> list1 = new List<FirstModel>()
			{
				new FirstModel{Id=1,Name="Faisal"},
				new FirstModel{Id=2,Name="Parth"},
				new FirstModel{Id=3,Name="Deep"},
				new FirstModel{Id=4,Name="Anas"},
				new FirstModel{Id=5,Name="Karan"}
			};

			List<SecondModel> list2 = new List<SecondModel>()
			{
				new SecondModel{Id=4,Name="Faisal"},
				new SecondModel{Id=5,Name="Soumy"},
				new SecondModel{Id=7,Name="Deep"},
				new SecondModel{Id=8,Name="Hammad"},
				new SecondModel{Id=9,Name="Karan"},
			};

			foreach (var model in list1)
			{
				Console.WriteLine(model);
			}

			// need to select which column we need to concat.
			var result = list1.Select(x=>x.Name).Concat(list2.Select(x=>x.Name)).ToList();
			foreach(var r in result)
			{
				Console.WriteLine(r);
			}


			Console.WriteLine("------------list1 which do not have value of list2--------");

			// showing list1 whoch do not have value of list2
			var output = from field in list1.Select(x=>x.Name) where !list2.Any(x=>x.Name == field) select field;
			foreach(var res in output)
			{
				Console.WriteLine(res);
			}

			Console.WriteLine("------------list2 which do not have value of list1--------");

			var ouputTwo = from secondField in list2.Select(x=>x.Name) where ! list1.Any(x=>x.Name == secondField) select secondField;
			foreach(var secondOutput in ouputTwo)
			{
				Console.WriteLine(secondOutput);
			}

			Console.WriteLine("----------------common fields of two list------------------------");

			//var outputThird = list1.Select(x => x.Name).Intersect(list2.Select(x => x.Name)).Distinct();
			//var outputThird = from thirdField in list1.Select(x => x.Name) where !list2.Contains(list1.Select(x => x.Name).ToList());
			//var outputThird = list1.Select(x => x.Name).Intersect(list2.Select(x=>x.Name));
			var outputThird = (from thirdField in list2.Select(x => x.Name) where list1.Any(x => x.Name == thirdField) select thirdField)
				.Concat(list2.Select(x => x.Name));
			//var outputThird = from thirdField in list2 group thirdField by thirdField.Name into newGroup orderby newGroup.Select(x=>x.Name) select newGroup;
			foreach (var thirdOutput in outputThird)
			{
				Console.WriteLine(outputThird);
			}

			Console.ReadLine();
		}
		
	}
}
