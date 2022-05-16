using ConsoleApp.Interfaces;
using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp.Enum;

namespace ConsoleApp.Services
{
    class CourseManagmentServices : ICourseManagmentServices

    {
        List<Group> _groups = new List<Group>();
        public List<Group> Groups => _groups;       

        public string CreateGroup(Categories category, bool isOnline)
        {

            Group group = new Group(category,isOnline);


            if (findGroup(group.Name) != null)
            {
               group.No = findNo(group.Category);
               group.Name=Group.ReturnPrefixOfName(category)+group.No;
            }
            _groups.Add(group);
            return $"Group name: {group.Name} successfully created";      
         }

        public uint findNo(Categories category)
        {
            uint no = 1;
            bool result;
            do
            {
                foreach (Group item in findGroupsOfSameCategory(category))
                {
                    if (item.No == no)
                    {
                        result = false;
                        no++;
                    }
                    else
                        result = false;
                }

            } while (false);

            return no;
                     

        }

        public string CreateStudent(string name, string surname, string groupNameOfStudent, bool type)
        {
            Group group = findGroup(groupNameOfStudent);

            if (group == null)
            {
                return $"There is no group => {groupNameOfStudent}";
            }

            Student student = new Student(name, surname, groupNameOfStudent, type);
            group.StudentsOfGroup.Add(student);
            return $"{student.Fullname} successfully created";
        }

        public string EditGroup(uint oldGroupNo, uint newGroupNo, Categories category)
        {
            Group group = findGroup(category, oldGroupNo);
            if (group != null)
            {
                if (findGroup(category, newGroupNo) == null)
                {
                    group.No = newGroupNo;                    
                    group.Name = Group.ReturnPrefixOfName(category) + group.No;

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
                if (item.Category == category)
                    sameNoGroups.Add(item);
            }
            return sameNoGroups;
        }

        public Group findGroup(Categories category, uint no)
        {
            if (findGroupsOfSameCategory(category) != null)
            {
                foreach (Group item in findGroupsOfSameCategory(category))
                {
                    if (item.No == no)
                        return item;
                }
            }
            return null;
        }
               

        public string RemoveStudent(string groupName, uint id)
        {        
            Group group = findGroup(groupName);

            if (group == null)
            {
                return $"There is not group with this name => {groupName}";
            }

            if (group.StudentsOfGroup.Count == 0)
            {
                return "There are no students in the group.";
            }

            foreach (Student item in group.StudentsOfGroup)
            {
                if (item.Id == id)
                {
                    group.StudentsOfGroup.Remove(item);
                    return "The student has been successfully remove.";
                }
            }

            return $"There is not student with this id => {id}";

        }
        
        public void ShowAllGroups()
        {           
            foreach (Group item in Groups)
            {
                Console.WriteLine(item);
            }
        }

        public void ShowAllStudentByGroup(string groupName)
        {
            Group group = findGroup(groupName);

            if (group == null)
            {
                Console.WriteLine($"There is group with this name => {groupName}");
                return;
            }

            if (group.StudentsOfGroup.Count == 0)
            {
                Console.WriteLine($"There are no students in the group with this name => {groupName}");
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
             if (Groups.Count == 0)
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
