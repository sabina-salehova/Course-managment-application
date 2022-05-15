using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp.Models;
using ConsoleApp.Enum;

namespace ConsoleApp.Interfaces
{
    interface ICourseManagmentServices
    {
        public List<Group> Groups {get;}
        public string CreateGroup(Categories category, bool isOnline);
        void ShowAllGroups();
        public string EditGroup(uint oldGroupNo, uint newGroupNo, Categories category);
        void ShowAllStudentByGroup(string no);
        void ShowAllStudents();
        public string CreateStudent(string name, string surname, string groupOfStudent, bool type);
        public string RemoveStudent(string no, uint id);
    }
}
