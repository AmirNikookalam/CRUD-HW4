using HW4.Entities;
using HW4.Interfaces;
using HW4.Storage;
using static System.Reflection.Metadata.BlobBuilder;

namespace HW4.CRUD
{
    public class Crud
    {
        private IStorage _storage;
        private ScvServices scvService;
        public Crud(IStorage storage)
        {
            _storage = storage;
        }

        public bool CreateUser(User user)
        {
            try
            {
                _storage.AddUser(user);
                return true;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();

                return false;
            }
        }

        public void ShowUsersList()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            foreach (var user in _storage.GetAllUsers())
            {
                Console.WriteLine($"- User number {user.userID}:\n " +
                    $"\tuser name is {user.userName}\n " +
                    $"\t{user.userName}'s mobile number is {user.userMobileNumber},\n " +
                    $"\t{user.userName} born at {user.userBirthday}\n " +
                    $"\tand {user.userName} created his/her account in {user.userDateCreated}.\n ");
            }

            Console.ResetColor();
        }

        public bool DeleteUser(User user)
        {
            try
            {
                _storage.RemoveUser(user);
                return true;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();

                return false;
            }
        }

        public bool UpdateUser(User user) 
        {
            try
            {
                _storage.AddUser(user);
                return true;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();

                return false;
            }
        }
    }
}
