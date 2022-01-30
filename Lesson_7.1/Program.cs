using System;
using static System.Console;

namespace Lesson_7
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Employees e = new Employees(1);
            e.AddElement();
            e.AddElement();
            e.Print();
            //do
            //{
            //    WriteLine("1 для вывода данных на экран\n2 для " +
            //                "добавления новой записи\n3 для выхода");
            //    string Str = ReadLine();
            //    Clear();
            //    if (Str == "1")
            //    {
            //        ReadText(@"TestList");
            //        ReadKey();
            //    }
            //    else if (Str == "2")
            //    {
            //        AddText(@"TestList");
            //    }
            //    else if (Str == "3")
            //    {
            //        break;
            //    }
            //    Clear();
            //} while (true);
        }
    }
}
