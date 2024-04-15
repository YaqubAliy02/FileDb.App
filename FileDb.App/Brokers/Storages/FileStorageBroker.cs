using FileDb.App.Models.Users;

namespace FileDb.App.Brokers.Storages
{
    internal class FileStorageBroker : IStorageBroker
    {
        private const string FilePath = "../../../Assets/Users.txt";
        public FileStorageBroker()
        {
            EnsureFileExists();
        }

        public User AddUser(User user)
        {
            string userLine = $"{user.Id}*{user.Name}\n";
            File.AppendAllText(FilePath, userLine);

            return user;
        }


        public List<User> ReadAllUsers()
        {
            string[] userLines = File.ReadAllLines(FilePath);
            List<User> users = new List<User>();

            foreach (string userLine in userLines)
            {
                string[] userProperties = userLine.Split("*");
                User user = new User
                {
                    Id = Convert.ToInt32(userProperties[0]),
                    Name = userProperties[1],
                };
                users.Add(user);
            }

            return users;
        }

    

        private void EnsureFileExists()
        {
            bool fileExists = File.Exists(FilePath);

            if (fileExists is false)
            {
                File.Create(FilePath).Close();
            }
        }
    }
}
