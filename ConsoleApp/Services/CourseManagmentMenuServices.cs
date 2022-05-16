using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp.Enum;
using ConsoleApp.Models;

namespace ConsoleApp.Services
{
    static class CourseManagmentMenuServices
    {
        public static CourseManagmentServices courseManagmentServices = new CourseManagmentServices();
        public static void CreatedGroupMenu()
        {
            Console.Write("Are group classes online? (please enter \"yes\" or \"no\"): ");
            bool answer = GetBoolAnswer(Console.ReadLine());
            Categories category = GetCategory();
            Console.WriteLine(courseManagmentServices.CreateGroup(category, answer));
        }

        public static void ShowAllGroupsMenu()
        {
            if (courseManagmentServices.Groups.Count == 0)
            {
                Console.WriteLine("\nNo group has been created yet.");
                return;
            }
            courseManagmentServices.ShowAllGroups();
        }

        public static void EditGroupMenu()
        {            
            if (courseManagmentServices.Groups.Count == 0)
            {
                Console.WriteLine("\nNo group has been created yet.");
                return;
            }

            Console.Write("Please enter Group no: ");
            uint oldNo = (uint)GetPositiveIntegerNumber(Console.ReadLine());
            Console.Write("Please enter new Group no: ");
            uint newNo = (uint)GetPositiveIntegerNumber(Console.ReadLine());

            Console.WriteLine(courseManagmentServices.EditGroup(oldNo, newNo, GetCategory()));
        }

        public static void ShowAllStudentByGroupMenu()
        {
            if (courseManagmentServices.Groups.Count == 0)
            {
                Console.WriteLine("\nNo group has been created yet.");
                return;
            }
            if (Student.CountOfStudents == 0)
            {
                Console.WriteLine("\nNo student has been created yet");
                return;
            }

            Console.Write("Please enter Group name: ");
            string answer = Console.ReadLine();
            courseManagmentServices.ShowAllStudentByGroup(answer);
        }

        public static void CreateStudentMenu()
        {
            if (courseManagmentServices.Groups.Count == 0)
            {
                Console.WriteLine("\nNo group has been created yet.");
                return;
            }

            Console.Write("Please enter Student name: ");
            string name = Console.ReadLine();
            Console.Write("Please enter Student surname: ");
            string surName = Console.ReadLine();
            Console.Write("Please enter Group name: ");
            string groupName = Console.ReadLine();
            Console.Write("Is the student guaranteed education? (please enter \"yes\" or \"no\": ");
            string answer = Console.ReadLine();

            Console.WriteLine(courseManagmentServices.CreateStudent(name, surName, groupName, GetBoolAnswer(answer)));
        }

        public static void RemoveStudentMenu()
        {
            if (courseManagmentServices.Groups.Count == 0)
            {
                Console.WriteLine("\nNo group has been created yet");
                return;
            }

            if (Student.CountOfStudents == 0)
            {
                Console.WriteLine("\nNo student has been created yet");
                return;
            }

            Console.Write("Please enter Group name: ");
            string groupName = Console.ReadLine();
            Console.Write("Please enter new Student id: ");
            uint id = (uint)GetPositiveIntegerNumber(Console.ReadLine());
            Console.WriteLine(courseManagmentServices.RemoveStudent(groupName, id));
        }

        public static Categories GetCategory()
        {
            Console.WriteLine("\nPlease enter a category that matches the options below: ");
            foreach (var item in System.Enum.GetValues(typeof(Categories)))
            {
                Console.WriteLine($"{(int)item}. {item}");
            }

            string answer;                      
            do
            {
                Console.Write("Please enter the correct selection: ");
                answer = Console.ReadLine();
                byte checkedNumber;                
                if (byte.TryParse(answer.Trim(), out checkedNumber))
                {
                    if (checkedNumber <= (byte)System.Enum.GetValues(typeof(Categories)).Length && checkedNumber > 0)
                        break;
                }
            } while (true);

            return (Categories)Convert.ToByte(answer);
            
        }

        public static bool GetBoolAnswer(string answer)
        {
            while (answer.ToLower().Trim() != "yes" && answer.ToLower().Trim() != "no")
            {
                Console.WriteLine("Please enter \"yes\" or \"no\": ");
                answer = Console.ReadLine();
            }

            if (answer.ToLower().Trim() == "yes")
                return true;
            else
                return false;
        }

        public static byte CheckSelection(string selection, byte number)
        {
            do
            {
                byte checkedNumber;
                if (byte.TryParse(selection.Trim(), out checkedNumber))
                {
                    for (byte i = 0; i <= number; i++)
                    {
                        if (checkedNumber == i)
                            return checkedNumber;
                    }
                }
                Console.Write("Please enter the correct selection: ");
                selection = Console.ReadLine();

            } while (true);
        }

        public static int GetPositiveIntegerNumber(string str)
        {
            int number;
            while (!int.TryParse(str.Trim(), out number) && number<0)
            {
                Console.Write("Please enter correct positive integer number: ");
                str = Console.ReadLine();
            }

            return Convert.ToInt32(number);

        }

    }
}
