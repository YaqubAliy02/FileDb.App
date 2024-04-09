using System.Text.Json;
using System.Text.Json.Serialization;
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
            List<User> users = JsonSerializer.Deserialize<List<User>>(FILEPATH);
            User user = users.FirstOrDefault(u => u.Id == id);
            users.Remove(user);
            JsonSerializer.Serialize(users);
        }

        public List<User> ReadAllUsers() =>
            JsonSerializer.Deserialize<List<User>>(FILEPATH);

        public void UpdateUser(User user)
        {
            List<User> users = JsonSerializer.Deserialize<List<User>>(FILEPATH);
            User updatedUser = users.FirstOrDefault(u => u.Id == user.Id);
            updatedUser.Name = user.Name;
            JsonSerializer.Serialize(users);
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