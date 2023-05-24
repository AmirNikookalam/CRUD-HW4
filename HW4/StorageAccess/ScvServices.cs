using CsvHelper;
using HW4.Entities;
using HW4.Interfaces;
using System.Globalization;

namespace HW4.Storage
{
    public class ScvServices : IStorage
    {
        static string? solutionFolderPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.FullName;
        static string dataFolderPath = Path.Combine(solutionFolderPath, "Data");
        static string storagePath = Path.Combine(dataFolderPath, "FileDataStorage.csv");

        public void AddUser(User user)
        {
            List<User> persons = GetAllUsers();
            persons.Add(user);

            using (var writer = new StreamWriter(storagePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(persons);
            }
        }

        public List<User> GetAllUsers()
        {
            using var streamReader = File.OpenText(storagePath);
            using var csvReader = new CsvReader(streamReader, CultureInfo.CurrentCulture);

            var users = csvReader.GetRecords<User>();

            return users.ToList<User>();
        }

        public void RemoveUser(User user)
        {
            List<User> persons = GetAllUsers();
            persons.Remove(user);

            using (var writer = new StreamWriter(storagePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(persons);
            }
        }

        public int Count()
        {
            return GetAllUsers().Count;      
        }
    }
}
