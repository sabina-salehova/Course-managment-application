using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp.Interfaces
{
    interface ICourseManagmentServices
    {
        public List<Group> Groups {get;}
        void CreateGroup();
        void ShowAllGroups();
        void EditGroup();
        void ShowAllStudentByGroup();
        void ShowAllStudents();
        void CreateStudent();
        void RemoveStudent();
    }
}
