using System.Text.Json;
using FileDb.App.Models.Users;

namespace FileDb.App.Brokers.Storages
{
    internal class JsonStorageBroker : IStorageBroker
    {
        private const string FILEPATH = "../../../Users.json";

        public JsonStorageBroker()
        {
            EnsureFileExists();
        }

        public User AddUser(User user)
        {
            string usersString = File.ReadAllText(FILEPATH);
            List<User> users = JsonSerializer.Deserialize<List<User>>(usersString);
            users.Add(user);
            string serializedUsers = JsonSerializer.Serialize(users);
            File.WriteAllText(FILEPATH, serializedUsers);

            return user;
        }

        public void DeleteUser(int id)
        {
            string usersString = File.ReadAllText(FILEPATH);
            List<User> users = JsonSerializer.Deserialize<List<User>>(usersString);
            User user = users.FirstOrDefault(u => u.Id == id);
            users.Remove(user);
            string serializedUsers = JsonSerializer.Serialize(users);
            File.WriteAllText(FILEPATH, serializedUsers);
        }

        public List<User> ReadAllUsers()
        {
            string usersString = File.ReadAllText(FILEPATH);
            List<User> users = JsonSerializer.Deserialize<List<User>>(usersString);

            return users;
        }

        public void UpdateUser(User user)
        {
            string usersString = File.ReadAllText(FILEPATH);
            List<User> users = JsonSerializer.Deserialize<List<User>>(usersString);
            User updatedUser = users.FirstOrDefault(u => u.Id == user.Id);
            updatedUser.Name = user.Name;
            string serializedUsers = JsonSerializer.Serialize(users);
            File.WriteAllText(FILEPATH, serializedUsers);
        }

        private void EnsureFileExists()
        {
            bool fileExists = File.Exists(FILEPATH);
            if (fileExists is false)
            {
                File.Create(FILEPATH).Close();
            }
        }
    }
}