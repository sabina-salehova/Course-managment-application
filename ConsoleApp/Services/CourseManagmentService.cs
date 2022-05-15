using ConsoleApp.Interfaces;
using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Services
{
    class CourseManagmentService : ICourseManagmentServices

    {
        List<Group> _groups = new List<Group>();
        public List<Group> Groups => _groups;       

        public void CreateGroup()
        {
            
        }

        public void CreateStudent()
        {
            
        }

        public void EditGroup()
        {
            
        }

        public void RemoveStudent(string no, uint id)
        {
            if (_groups.Count == 0)
            {
                Console.WriteLine("hele hecbir qrup yaradilmayib");
                return;
            }

            if (Student.CountOfStudents == 0)
            {
                Console.WriteLine("Hele hec bir telebe yaradilmayib");
                return;
            }
            Group group = findGroup(no);
            if (group == null)
            {
                Console.WriteLine("bele adli qrup yoxdur");
                return;
            }
            
            foreach (Student item in group.StudentsOfGroup)
            {
                if (item.Id == id)
                {
                    group.StudentsOfGroup.Remove(item);
                    Console.WriteLine("telebe silindi");
                    return;
                }
            }

            Console.WriteLine("bu id-e mexsus telebe yoxdur");


        }
        
        public void ShowAllGroups()
        {
            if (_groups.Count == 0)
            {
                Console.WriteLine("hele hecbir qrup yaradilmayib");
                return;
            }
            foreach (Group item in Groups)
            {
                Console.WriteLine(item);
            }

        }

        public void ShowAllStudentByGroup(string no)
        {
            if (_groups.Count == 0)
            {
                Console.WriteLine("hele hecbir qrup yaradilmayib");
                return;
            }

            Group group = findGroup(no);

            if (group == null)
            {
                Console.WriteLine("Daxil edilmiw nomreli qrup movcud deyil");
                return;
            }

            if (group.StudentsOfGroup.Count == 0)
            {
                Console.WriteLine("daxil edilmiw nomreli qrupda telebe movcud deyil");
                return;
            }

            foreach (Student item in group.StudentsOfGroup)
            {
                Console.WriteLine(item);
            }
            
        }

        public Group findGroup(string no)
        {
            foreach (Group item in Groups)
            {
                if (item.No.ToLower() == no.ToLower().Trim())
                {
                    return item;
                }
            }
            return null;
        }

        public void ShowAllStudents()
        {
             if (_groups.Count == 0)
            {
                Console.WriteLine("hele hecbir qrup yaradilmayib");
                return;
            }

            if (Student.CountOfStudents == 0)
            {
                Console.WriteLine("Hele hec bir telebe yaradilmayib");
                return;
            }

            bool result;
            foreach (Group item in Groups)
            {
                if (item.StudentsOfGroup.Count!=0)
                {
                    foreach (Student stu in item.StudentsOfGroup)
                    {
                        Console.WriteLine(stu);
                    }
                    result = false;
                }                
            }

            if (result = true)
            {
                Console.WriteLine("hele grup daxili telebe yaradilmayib");
            }

        }

       
    }
}
