using System;
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

        public Employees(int size) : this()//конструктор
        {
            Size = size;
            Count = 0;
            list = new Employee[Size];
        }
 
        public Employee this[int index]//индексатор
        {
            get { return List[index]; }
            set { List[index] = value; }
        }
 
        public void AddElement()// Метод добавления элемента
        {
            if (Count >= list.Length)
            {
                Array.Resize(ref list, list.Length * 2);
            }
            List[Count] = new Employee();
            List[Count].Flag = 1;
            List[Count].CreatDate = DateTime.Today;

            WriteLine("ID");
            List[Count].Id = CheckParam();

            WriteLine("Ф.И.О.");
            List[Count].FullName = ReadLine();

            WriteLine("Возраст");
            List[Count].Age = CheckParam();

            WriteLine("Рост");
            List[Count].Height = CheckParam();

            WriteLine("Дата рождения в формате дд.мм.гггг");
            List[Count].Birthbay =CheckData(); 

            WriteLine("Место рождения");
            List[Count].BirthPlace = ReadLine();

            Count++;
        }

        public void Print()
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].Flag == 1)
                {
                    list[i].Print();
                }
            }
        }
 
        uint CheckParam()//проверка параметров
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

        DateTime CheckData()
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
