using HW4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace HW4.Interfaces
{
    public interface IStorage
    {
        List<User> GetAllUsers();

        void AddUser(User user);

        void RemoveUser(User user);

        public int Count();
    }
}
