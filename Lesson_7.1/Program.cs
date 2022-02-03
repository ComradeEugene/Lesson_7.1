using System;
using static System.Console;

namespace Lesson_7
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Employees emp = new Employees(10);
			emp.LoadText(@"TestList");;
			do
			{
				Clear();
				WriteLine("1 вывод данных на экран\n" +
						  "2 добавить новую записи\n"+
						  "3 найти запись\n" +
						  "4 удалить запись\n" +
						  "5 редактирование запись\n" +
						  "6 поиск по диапозону дат\n" +
						  "7 сортировка по дате создания\n" +
						  "q для выхода");
				string Str = ReadLine();
				switch (Str)
				{
					case "1":
						emp.Print();
						break;
					case "2":
						emp.AddElement();
						break;
					case "3":
						emp.FindEmployee();
						break;
					case "4":
						emp.DelEmployee();
						break;
					case "5":
						emp.ChangeElement();
						break;
					case "6":
						emp.DateRange();
						break;
					case "7":
						emp.SortEmloyees();
						break;
					default:
						return;
				}
			} while (true);
		}
	}
}
