using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Models
{
     class Student
    {
        public static uint CountOfStudents;
        uint _id;
        public uint Id => _id; 
        public string Name;
        public string Surname;
        public string Fullname => Name + " " + Surname;
        public string GroupOfStudent;
        public bool Type;   //(guaranteed, not guaranteed)

        static Student()
        {
            CountOfStudents = default(uint);
        }
        public Student(string name, string surname, string groupOfStudent, bool type)
        {
            Name = name;
            Surname = surname;
            GroupOfStudent = groupOfStudent;
            Type = type;
            CountOfStudents++;
            _id = CountOfStudents;
        }


        public override string ToString()
        {
            return "Fullname: "+Fullname + ", The group of student: "+GroupOfStudent+", Type: "+Type;
        }


    }
}
