using ConsoleApp.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Models
{
    class Group
    {
        public static uint CountOfGroup;
        public string No;
        public Categories category;
        public bool IsOnline;
        byte _limit;
        public byte Limit => _limit;
        public List<Student> StudentsOfGroup;

        static Group()
        {
            CountOfGroup = default(uint);
        }

        public Group(Categories category, bool isOnline)
        {

            CountOfGroup++;

            if (isOnline)
                _limit = 15;
            else
                _limit = 10;

            StudentsOfGroup = new List<Student>();

            switch (category)
            {
                case Categories.Programming:
                    No = "P" + CountOfGroup;
                    break;
                case Categories.Design:
                    No = "D" + CountOfGroup;
                    break;
                case Categories.SystemAdministration:
                    No = "SA" + CountOfGroup;
                    break;
            }
        }



    }
}
