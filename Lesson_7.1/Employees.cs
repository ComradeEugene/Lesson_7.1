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
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        if (Count >= list.Length)
                            Array.Resize(ref list, list.Length * 2);

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
            File.Delete(@"TestList");
            Count = 0;
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].Flag == 1)
	            {
                    str = $"{list[i].Id}#{list[i].CreatDate}#{list[i].FullName}#" +
                        $"{list[i].Age}#{list[i].Height}#{list[i].Birthbay}#" +
                        $"{list[i].BirthPlace}\n";
                    File.AppendAllText(@"TestList", str);
                    ++Count;
	            }
            }
        }
 
        public void AddElement()                                                // Метод добавления элемента
        {
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
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].Flag == 1)
                {
                    list[i].Print();
                }
            }
        }

        public void FindEmployee()                                              //поиск элемента
        {
            WriteLine("Введите ID(положительное число)");
            uint index = CheckParam();
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].Id == index)
                {
                    list[i].Print();
                    return;
                }
            }
            WriteLine("Запись с таким   ID не существует");
        }

        public void DelEmployee()                                               //удаление элемента
        {
            WriteLine("Введите ID(положительное число) удаляемого элемента");
            uint index = CheckParam();
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].Id == index)
                {
                    Array.Clear(list, i, 1);
                    ReWrite();
                    return;
                }
            }
            WriteLine("Запись с таким   ID не существует");
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
