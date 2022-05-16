using System;
using System.Collections.Generic;
using ConsoleApp.Services;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" ---   WELCOME TO COURSE APPLICATION   --- ");
            byte selection;
            do
            {
                Console.WriteLine("\n Please enter the appropriate number according to the following options: ");
                Console.WriteLine("1. Create Group");
                Console.WriteLine("2. Show All Groups");
                Console.WriteLine("3. Edit Group");
                Console.WriteLine("4. Show All Student By Group name");
                Console.WriteLine("5. Create Student");
                Console.WriteLine("6. Remove Student");
                Console.WriteLine("0. Exit");
                selection = CourseManagmentMenuServices.CheckSelection(Console.ReadLine(),6);
                Console.Clear();

                switch (selection)
                {
                    case 1:
                        CourseManagmentMenuServices.CreatedGroupMenu();
                        break;
                    case 2:
                        CourseManagmentMenuServices.ShowAllGroupsMenu();
                        break;
                    case 3:
                        CourseManagmentMenuServices.EditGroupMenu();
                        break;
                    case 4:
                        CourseManagmentMenuServices.ShowAllStudentByGroupMenu();
                        break;
                    case 5:
                        CourseManagmentMenuServices.CreateStudentMenu();
                        break;
                    case 6:
                        CourseManagmentMenuServices.RemoveStudentMenu();
                        break;                    
                }
            } while (selection != 0);
        }

        
    }
}
