using System;
using System.IO;
using static System.Console;

namespace Lesson_7
{
	struct Employees
	{
		Employee[] list;
		int size;
 
		public int Count { get; set; }
		public int Size
		{
			get { return size;
		}
			set
			{
				if (value < 0)
				{
					size = 0;
				}
				else
				{
					size = value;
				}
			}
		}

		internal Employee[] List { get => list; set => list = value; }

		public Employees(int size) : this()                                     
		{
			Size = size;
			Count = 0;
			list = new Employee[Size];
		}
 
		public Employee this[int index]                                         //индексатор
		{
			get { return List[index]; }
			set { List[index] = value; }
		}

		public void LoadText(string path)                                       //загрузка из файла
		{
			if (File.Exists(path))
			{
				Count = 0;
				list = new Employee[File.ReadAllLines(@"TestList").Length * 2];
				using (StreamReader sr = new StreamReader(path))
				{
					while (!sr.EndOfStream)
					{
						string[] arr = sr.ReadLine().Split('#');
						list[Count] = new Employee(uint.Parse(arr[0]),
							DateTime.Parse(arr[1]), arr[2], uint.Parse(arr[3]),
							uint.Parse(arr[4]), DateTime.Parse(arr[5]), arr[6]);

						list[Count].Flag = 1;
						++Count;
					}
				}
			}
		}

		void ReWrite()                                                          //перезапись 
		{
			string str = string.Empty;
			using(StreamWriter sw = new StreamWriter(@"TestList"))
			{ 
				for (int i = 0; i < list.Length; i++)
				{
					if (list[i].Flag == 1)
					{
						str = $"{list[i].Id}#{list[i].CreatDate}#{list[i].FullName}#" +
							$"{list[i].Age}#{list[i].Height}#{list[i].Birthbay}#" +
							$"{list[i].BirthPlace}";
						sw.WriteLine(str);
					}
				}
			}
		}
 
		public void AddElement()                                                //добавление элемента
		{
			Clear();
			if (Count >= list.Length)
			{
				Array.Resize(ref list, list.Length * 2);
			}
			string str = string.Empty; 
			List[Count] = new Employee();
			List[Count].Flag = 1;
			List[Count].CreatDate = DateTime.Today;

			WriteLine("ID");
			list[Count].Id = CheckParam();
			str += list[Count].Id + "#" + list[Count].CreatDate + "#";

			WriteLine("Ф.И.О.");
			list[Count].FullName = ReadLine();
			str += list[Count].FullName + "#";

			WriteLine("Возраст");
			list[Count].Age = CheckParam();
			str += list[Count].Age + "#";

			WriteLine("Рост");
			list[Count].Height = CheckParam();
			str += list[Count].Height + "#";

			WriteLine("Дата рождения в формате дд.мм.гггг");
			list[Count].Birthbay = CheckData();
			str += list[Count].Birthbay.ToString("dd.MM.yyyy") + "#";

			WriteLine("Место рождения");
			list[Count].BirthPlace = ReadLine();
			str += list[Count].BirthPlace + "\n";

			File.AppendAllText(@"TestList", str);
			++Count;
		}

		public void Print()                                                     //печать списка
		{
			Clear();
			for (int i = 0; i < list.Length; i++)
			{
				if (list[i].Flag == 1)
				{
					list[i].Print();
				}
			}
			ReadKey();
		}

		public void FindEmployee()                                              //поиск элемента
		{
			Clear();
			WriteLine("Введите ID(положительное число)");
			uint index = CheckParam();
			for (int i = 0; i < list.Length; i++)
			{
				if (list[i].Id == index)
				{
					Clear();
					list[i].Print();
					ReadKey();
					return;
				}
			}
			Clear();
			WriteLine("Запись с таким   ID не существует");
			ReadKey();
		}

		public void ChangeElement()												//редактировать элемент
		{
			Clear();
			WriteLine("Введите ID(положительное число)");
			uint index = CheckParam();
			for (int i = 0; i < list.Length; i++)
			{
				if (list[i].Id == index)
				{
					WriteLine("ID");
					list[i].Id = CheckParam();

					WriteLine("Ф.И.О.");
					list[i].FullName = ReadLine();

					WriteLine("Возраст");
					list[i].Age = CheckParam();

					WriteLine("Рост");
					list[i].Height = CheckParam();

					WriteLine("Дата рождения в формате дд.мм.гггг");
					list[i].Birthbay = CheckData();

					WriteLine("Место рождения");
					list[i].BirthPlace = ReadLine();
					ReWrite();
					return;
				}
			}
			Clear();
			WriteLine("Запись с таким   ID не существует");
			ReadKey();
		}

		public void DelEmployee()                                               //удаление элемента
		{
			Clear();
			WriteLine("Введите ID(положительное число) удаляемого элемента");
			uint index = CheckParam();
			for (int i = 0; i < list.Length; i++)
			{
				if (list[i].Id == index)
				{
					Array.Clear(list, i, 1);
					ReWrite();
					LoadText(@"TestList");
					return;
				}
			}
			Clear();
			WriteLine("Запись с таким   ID не существует");
			ReadKey();
		}

		public void DateRange()													//поиск по диапозону дат
		{ 
			Clear();
			WriteLine("Введите диапозон дат");
			WriteLine("дат 1:");
			DateTime date1 = CheckData();
			WriteLine("дат 2:");
			DateTime date2 = CheckData();
			for (int i = 0; i < list.Length; i++)
			{
				if (date1 <= list[i].CreatDate && date2 >= list[i].CreatDate)
				{
					list[i].Print();
				}
			}
			ReadKey();
		}

		public void SortEmloyees()												//сортировки
		{ 
			WriteLine("1 по возрастанию\n2 по убыванию");
			string str = ReadLine();
			Employee temp = new Employee();
			bool isSorted = false;
			if (str == "1")
			{ 
				while (isSorted == false)
				{ 
					isSorted = true;
					for (int i = 1; i < list.Length; i++)
					{
						if (list[i].CreatDate < list[i - 1].CreatDate) 
						{
							temp = list[i];
							list[i] = list[i -1];
							list[i - 1] = temp;
							isSorted = false;
						}
					}
				}
			}
			else if (str == "2")
			{
				while (isSorted == false)
				{ 
					isSorted = true;
					for (int i = 1; i < list.Length; i++)
					{
						if (list[i].CreatDate > list[i - 1].CreatDate) 
						{
							temp = list[i];
							list[i] = list[i -1];
							list[i - 1] = temp;
							isSorted = false;
						}
					}
				}
			}
		}
 
		uint CheckParam()                                                       //проверка параметров
		{
			uint param;
			while (true)
			{
				if (uint.TryParse(ReadLine(), out param))
				{
					return param;
				}
				else
				{
					WriteLine("Не корректное значение");
				}
			}
		}

		DateTime CheckData()                                                    //проверка даты
		{
			DateTime date;
			while (true)
			{
				if (DateTime.TryParse(ReadLine(), out date))
				{
					return date;
				}
				else
				{
					WriteLine("Не корректное значение");
				}
			}
		}
	}
}
