using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp.Models;

namespace ConsoleApp.Interfaces
{
    interface ICourseManagmentServices
    {
        public List<Group> Groups {get;}
        void CreateGroup();
        void ShowAllGroups();
        void EditGroup();
        void ShowAllStudentByGroup(string no);
        void ShowAllStudents();
        void CreateStudent();
        void RemoveStudent(string no, uint id);
    }
}
