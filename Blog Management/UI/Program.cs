using System;
using Blog_Management.ApplicationLogic;

namespace Blog_Management.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi , You Can Use /help Command for Get Information about Commads !\n");
            Authentication.Help();
            while (true)
            {

                Console.Write("\nEnter command : ");
                string command = Console.ReadLine();

                if (command == "/register")
                {
                    Authentication.Register();
                }               
                else if (command == "/login")
                {
                    Authentication.Login();
                }

                else if (command == "/logout")
                {
                    Authentication.Logout();
                }

                else if (command == "/panel")
                {
                    Authentication.OpenPanel();
                }

                else if (command == "/accountinfo")
                {
                    Authentication.AccountInfo();
                }

                else if (command == "/help")
                {
                    Authentication.Help();
                }

                else if (command == "/exit")
                {
                    Console.WriteLine("May the Force be with you");
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
