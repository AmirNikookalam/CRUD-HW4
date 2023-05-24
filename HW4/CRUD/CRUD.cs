using HW4.Entities;
using HW4.Interfaces;

namespace HW4.CRUD
{
    public class Crud
    {
        private IStorage _storage;
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
    }
}
