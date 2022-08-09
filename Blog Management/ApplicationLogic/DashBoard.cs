using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog_Management.Services;

namespace Blog_Management.ApplicationLogic
{
    internal class DashBoard
    {
        public static void UserPanel()
        {
            Console.WriteLine("Hi , You are currently using the panel ,You Can Use /support Command for Get Information about panel !");
            while (true)
            {

                Console.Write("\nEnter panel command : ");
                string command = Console.ReadLine();

                if (command == "/update-user")
                {
                    DashBoardServices.Update();
                }
                else if (command == "/panel-help")
                {
                    DashBoardServices.Help();
                }
                else if (command == "/close")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Command not found!");
                }
            }
        }
        public static void AdminPanel()
        {
            Console.WriteLine("Hi dear Admin, You are currently using the panel ,You Can Use /support Command for Get Information about panel !");
            while (true)
            {

                Console.Write("\nEnter panel command : ");
                string command = Console.ReadLine();

                
                if (command == "/remove-user")
                {
                    DashBoardServices.RemoveUser(); 
                }
                else if (command == "/show-admins")
                {
                    DashBoardServices.ShowAdmins();
                }
                else if (command == "/update-admin")
                {
                    DashBoardServices.UpdateforAdmin();
                }
                else if (command == "/make-admin")
                {
                    DashBoardServices.AddAdmin();
                }
                else if (command == "/show-users")
                {
                    DashBoardServices.ShowUsers();
                }
                else if (command == "/panel-help")
                {
                    DashBoardServices.Help();
                }
                else if (command == "/close")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Command not found!");
                }
            }
        }
        
    }
}
