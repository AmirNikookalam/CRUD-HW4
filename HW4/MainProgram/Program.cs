﻿using HW4.CRUD;
using HW4.Entities;
using HW4.Storage;

namespace HW4.MainProgram
{
    public class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            User? targetUser = new User();
            User? updateUser = new User();
            DateTime userBirthday;
            Crud crud = new Crud(new ScvServices());
            ScvServices scvService = new ScvServices();

            string? userName = string.Empty;
            string? userMobileNumber = string.Empty;
            string? inputOption = string.Empty;
            int userNumber = 0;
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
                    "\n\n--Give me the option number: ");

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
                            Console.WriteLine($"-Give your name:");
                            userName = Console.ReadLine();

                            Console.WriteLine($"-Give your mobile number:");
                            userMobileNumber = Console.ReadLine();

                            //Validate userMobileNumber is 11 gigits or not
                            if (user.MobileNumberIsValid(userMobileNumber))
                            {
                                Console.WriteLine($"-Give your birthday(YYYY/MM/DD):");
                                userBirthday = Convert.ToDateTime(Console.ReadLine());

                                //Validate userBirthday is earlier than Now or not
                                if (user.DateTimeIsValid(userBirthday))
                                {
                                    //Fill the user object properties
                                    user.userName = userName;
                                    user.userBirthday = userBirthday;
                                    user.userMobileNumber = userMobileNumber;
                                    user.userID = scvService.Count() + 1;
                                    user.userDateCreated = DateTime.Now;

                                    //Checking if we could create the new user successfully or not
                                    if (crud.CreateUser(user))
                                        Console.WriteLine("--Account created successfully\n");
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("--Error: Couldn't create the account\n");
                                        Console.ResetColor();
                                    }
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("--Error: Don't give your birthday in the future \n");
                                    Console.ResetColor();
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("--Error: Please give a 11 digits mobile number\n");
                                Console.ResetColor();
                            }

                            break;

                        //2.Delete an account
                        case "2":
                            Console.Clear();
                            Console.WriteLine("--Showing the List of users\n");

                            //Showing users list
                            crud.ShowUsersList();

                            Console.WriteLine("--Deleting Account\n");
                            Console.WriteLine("-Give me the number of user you want to remove:");
                            userNumber = Convert.ToInt32(Console.ReadLine());

                            //Check if given user exist
                            targetUser = scvService.GetAllUsers().Find(user => user.userID == userNumber);
                            if (targetUser != null)
                            {
                                //check if we could remove the user account successfully
                                if (crud.DeleteUser(targetUser))
                                    Console.WriteLine("--Account removed successfully\n");
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("--Error: Couldn't remove the account\n");
                                    Console.ResetColor();
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error: We don't have any user with that user number");
                                Console.ResetColor();

                                flag = false;
                            }
                            //Showing users list again after change
                            crud.ShowUsersList();

                            break;

                        //3.Update an account
                        case "3":
                            Console.Clear();
                            Console.WriteLine("--Showing the List of users\n");

                            //Showing users list
                            crud.ShowUsersList();

                            Console.WriteLine("--Updating Account\n");
                            Console.WriteLine("-Give me the number of user you want to update:");
                            userNumber = Convert.ToInt32(Console.ReadLine());

                            //Check if given user exist
                            targetUser = scvService.GetAllUsers().Find(user => user.userID == userNumber);
                            if (targetUser != null)
                            {
                                crud.DeleteUser(targetUser);

                                //Give updateUser properties
                                Console.WriteLine($"-Give your new name:");
                                userName = Console.ReadLine();

                                Console.WriteLine($"-Give your new mobile number:");
                                userMobileNumber = Console.ReadLine();

                                //Validate userMobileNumber is 11 gigits or not
                                if (updateUser.MobileNumberIsValid(userMobileNumber))
                                {
                                    Console.WriteLine($"-Give your new birthday(YYYY/MM/DD):");
                                    userBirthday = Convert.ToDateTime(Console.ReadLine());

                                    //Validate userBirthday is earlier than Now or not
                                    if (updateUser.DateTimeIsValid(userBirthday))
                                    {
                                        updateUser.userName = userName;
                                        updateUser.userBirthday = userBirthday;
                                        updateUser.userMobileNumber = userMobileNumber;
                                        updateUser.userID = scvService.Count() + 1;

                                        //check if we could update the user account successfully
                                        if (crud.UpdateUser(updateUser))
                                            Console.WriteLine("--Account updated successfully\n");
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("--Error: Couldn't update the account\n");
                                            Console.ResetColor();
                                        }
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("--Error: Don't give your birthday in the future\n");
                                        Console.ResetColor();
                                    }
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("--Error: Please give a 11 digits mobile number\n");
                                    Console.ResetColor();
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error: We don't have any user with that user number");
                                Console.ResetColor();

                                flag = false;
                            }
                            //Showing users list again after change
                            crud.ShowUsersList();

                            break;

                        //4.See list of users
                        case "4":
                            Console.Clear();
                            Console.WriteLine("--Showing the List of users\n");

                            //Showing users list
                            crud.ShowUsersList();

                            break;
                        //5.Exit   
                        case "5":

                            flag = false;
                            break;

                        default:
                            Console.Clear();

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: Please give a number between 1 and 5!");
                            Console.ResetColor();

                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }

                //Continue
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            } while (flag);

            Console.WriteLine("G00dBye;");
            Console.ReadKey();
        }
    }
}