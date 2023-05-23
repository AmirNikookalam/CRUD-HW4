using HW4.CRUD;
using HW4.Entities;
using HW4.Storage;
using System.Data;

namespace HW4.MainProgram
{
    public class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            DateTime userBirthday;
            Crud crud = new Crud(new ScvServices());
            ScvServices scvService = new ScvServices();

            int? userId = 0;
            string? userName = string.Empty;
            string? userMobileNumber = string.Empty;
            string? inputOption = string.Empty;
            bool flag = true;

            do
            {
                Console.Clear();
                //Showing list
                Console.WriteLine("--What do you want to do?" +
                    "\n 1.Create an account " +
                    "\n 2.Delete an account " +
                    "\n 3.Update an account " +
                    "\n 4.See list of users " +
                    "\n 5.Exit" +
                    "\n\n--Give me the number: ");

                //Getting input
                inputOption = Console.ReadLine();

                //try-catch
                try
                {
                    switch (inputOption)
                    {
                        //1.Create an account
                        case "1":
                            Console.Clear();
                            Console.WriteLine("--Creating Account\n");

                            //Getting username and mobile number and birthday from user
                            Console.WriteLine($"--Give your name:");
                            userName = Console.ReadLine();

                            Console.WriteLine($"-Give your number:");
                            userMobileNumber = Console.ReadLine();

                            Console.WriteLine($"-Give your birthday(YYYY/MM/DD):");
                            userBirthday = Convert.ToDateTime(Console.ReadLine());
                            //Getting username and mobile number and birthday from user (END)

                            user.userName = userName;
                            user.userBirthday = userBirthday;
                            user.userMobileNumber = userMobileNumber;
                            //user.userID = scvService.Count();
                            user.userDateCreated = DateTime.Now;

                            if(crud.CreateUser(user))
                                Console.WriteLine("--System message: Account created successfully\n");
                            else
                                Console.WriteLine("--Error: Couldn't create the account\n");

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

                            Console.WriteLine("Error: Please give a number between 1 and 5!");
                            flag = false;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (flag);

            Console.WriteLine("G00dBye;");
        }
    }
}