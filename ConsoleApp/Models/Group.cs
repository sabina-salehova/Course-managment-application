using ConsoleApp.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Models
{
    class Group
    {
        public static uint CountOfGroup;
        public uint No;
        public string Name;
        public Categories Category;
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
            No = CountOfGroup;
            Name = ReturnPrefixOfName(category) + No;
            Category = category;
            
        }

        public override string ToString()
        {
            return "Group Name: " + Name + ", Group category: " + Category + ", " + (IsOnline ? "Online" : "Offline") + ", Limit of student: " + Limit + ", Count of students available: " + StudentsOfGroup.Count;
        }

        public static string ReturnPrefixOfName(Categories category)
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
