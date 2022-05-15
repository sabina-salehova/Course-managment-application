using ConsoleApp.Interfaces;
using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp.Enum;

namespace ConsoleApp.Services
{
    class CourseManagmentService : ICourseManagmentServices

    {
        List<Group> _groups = new List<Group>();
        public List<Group> Groups => _groups;       

        public string CreateGroup(Categories category, bool isOnline)
        {
            Group group = new Group(category,isOnline);             
             _groups.Add(group);
            return $"{group.Name} successfully created";      
         }

        public string CreateStudent(string name, string surname, string groupNoOfStudent, bool type)
        {
            if (_groups.Count == 0)
            {
                return "No group has been created yet";
            }

            Group group = findGroup(groupNoOfStudent);

            if (group == null)
            {
                return $"There is no group => {groupNoOfStudent}";
            }

            Student student = new Student(name, surname, groupNoOfStudent,type);
            group.StudentsOfGroup.Add(student);
            return $"{student.Fullname} successfully created";
        }

        public string EditGroup(uint oldGroupNo, uint newGroupNo, Categories category)
        {
            if (_groups.Count == 0)
            {
                return "No group has been created yet";
            }

            if (findGroup(category,oldGroupNo) == null)
            {
                if (findGroup(category, newGroupNo) != null)
                {
                    findGroup(category, oldGroupNo).No = newGroupNo;
                    return "The change was successfully implemented";
                }
                else
                    return $"There is group with this no => {newGroupNo.ToString()}";
            } else
                return $"There is no group with this no => {oldGroupNo.ToString()}";
        }
        
        public List<Group> findGroupsOfSameCategory(Categories category)
        {
            List<Group> sameNoGroups = new List<Group>();
            foreach (Group item in Groups)
            {
                if (item.category == category)
                    sameNoGroups.Add(item);
            }
            return sameNoGroups;
        }

        public Group findGroup(Categories category, uint no)
        {
            foreach (Group item in findGroupsOfSameCategory(category))
            {
                if (item.No == no)
                    return item;
            }

            return null;
        }

        public string RemoveStudent(string name, uint id)
        {
            if (_groups.Count == 0)
            {
                return "No group has been created yet";
            }

            if (Student.CountOfStudents == 0)
            {
                return "No student has been created yet";
            }
            
            Group group = findGroup(name);

            if (group == null)
            {
                return $"There is group with this name => {name}";
            }
            
            
            foreach (Student item in group.StudentsOfGroup)
            {
                if (item.Id == id)
                {
                    group.StudentsOfGroup.Remove(item);
                    return "This student has been succesfully reserved";
                }
            }

            return $"There is student with this id => {id}";

        }
        
        public void ShowAllGroups()
        {
            if (_groups.Count == 0)
            {
                Console.WriteLine("No group has been created yet");
                return;
            }
            foreach (Group item in Groups)
            {
                Console.WriteLine(item);
            }

        }

        public void ShowAllStudentByGroup(string name)
        {
            if (_groups.Count == 0)
            {
                Console.WriteLine("No group has been created yet");
                return;
            }

            Group group = findGroup(name);

            if (group == null)
            {
                Console.WriteLine($"There is group with this name => {name}");
                return;
            }

            if (group.StudentsOfGroup.Count == 0)
            {
                Console.WriteLine($"There are no students in the group with this name => {name}");
                return;
            }

            foreach (Student item in group.StudentsOfGroup)
            {
                Console.WriteLine(item);
            }
            
        }

        public Group findGroup(string name)
        {
            foreach (Group item in Groups)
            {
                if (item.Name.ToLower() == name.ToLower().Trim())
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
                Console.WriteLine("No group has been created yet");
                return;
            }

            if (Student.CountOfStudents == 0)
            {
                Console.WriteLine("No student has been created yet");
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
                Console.WriteLine("No students have been added to any group yet.");
            }

        }

       
    }
}
