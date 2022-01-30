using System;
using static System.Console;

namespace Lesson_7
{
    struct Employee
    {
        int flag;
        public uint Id { get; set; }
        public DateTime CreatDate { get; set; }
        public string FullName { get; set; }
        public uint Age { get; set; }
        public uint Height { get; set; }
        public DateTime Birthbay { get; set; }
        public string BirthPlace { get; set; }

        public int Flag{
            get { return flag; }
            set { flag = value; }
        }

        private Employee(uint id, DateTime creatData, string fullName, uint age,
            uint height, DateTime birthbay, string birthPlace) : this()
        {
            Id = id;
            CreatDate = creatData;
            FullName = fullName;
            Age = age;
            Height = height;
            Birthbay = birthbay;
            BirthPlace = birthPlace;
        }

        public void Print()
        {
            WriteLine("{0} {1} {2} {3} {4} {5} {6}",
                Id,
                CreatDate,
                FullName,
                Age,
                Height,
                Birthbay,
                BirthPlace);
        }
    }
}
