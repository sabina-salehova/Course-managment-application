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
            IsOnline = isOnline;
            CountOfGroup++;

            if (isOnline)
                _limit = 15;
            else
                _limit = 10;

            StudentsOfGroup = new List<Student>();

            No = ReturnPrefixOfNumber(category) + CountOfGroup;
            
        }

        public override string ToString()
        {
            return "Group No: " + No + ", Group category: " + category + ", " + (IsOnline ? "Online" : "Offline") + ", Limit of student: " + Limit + ", Count of students available: " + StudentsOfGroup.Count;
        }

        public static string ReturnPrefixOfNumber(Categories category)
        {
            string prefix;

            switch (category)
            {
                case Categories.Programming:
                    prefix = "P";
                    break;
                case Categories.Design:
                    prefix = "D";
                    break;
                default:
                    prefix = "SA";
                    break;                
             }

            return prefix;

        }
    }
    
}
