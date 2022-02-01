using System;
using static System.Console;

namespace Lesson_7
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Employees emp = new Employees(10);
            emp.LoadText(@"TestList");
            do
            {
                WriteLine("1 для вывода данных на экран\n2 для " +
                            "добавления новой записи\n3 для выхода");
                string Str = ReadLine();
                switch (Str)
                {
                    case "1":
                        emp.Print();
                        break;
                    case "2":
                        emp.AddElement();
                        break;
                    default:
                        return;
                }
            } while (true);
        }
    }
}
