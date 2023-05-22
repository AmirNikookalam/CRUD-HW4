

using HW4.Entities;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace Program
{
    public class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User();
            DateTime userBirthday = new DateTime(2023 / 12 / 30);
            int userId = 0;
            string userName = string.Empty;
            string inputOption = string.Empty;
            bool flag = true;

            do
            {
                Console.WriteLine("--What do you want to do?" +
                    "\n 1.Create an account " +
                    "\n 2.Delete an account " +
                    "\n 3.Update an account " +
                    "\n 4.See list of users " +
                    "\n 5.Exit" +
                    "\n => ");
                inputOption = Console.ReadLine();


                switch (inputOption)
                {
                    //1.Create an account
                    case "1":
                        Console.Clear();

                        break;

                    //2.Delete an account
                    case "2":
                        Console.Clear();

                        break;
                    //3.Update an account
                    case "3":
                        Console.Clear();
                        break;

                    //4.See list of users
                    case "4":
                        Console.Clear();

                        break;
                    //5.Exit   
                    case "5":

                        flag = false;
                        break;

                    default:
                        Console.Clear();

                        Console.WriteLine("Error: Please give a number between 1 and 4!");
                        flag = false;
                        break;
                }
            } while (flag);

            Console.WriteLine("G00dBye;");
        }
    }
}