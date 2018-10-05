using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;

namespace OpenCartTests.Data
{
    public class ReaderUserData
    {
        private static ListUsers users;
       
        /// <summary>
        /// Private method for read data from file 'User.json' and return list of users
        /// </summary>
        /// <returns></returns>
        private static ListUsers ReadUsersData()
        {
            string folderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                        .Replace("\\bin\\Debug", "\\Data");
            string path = Path.Combine(folderPath, "Users.json");
            string userData;
            
            using (StreamReader reader = new StreamReader(path))
            {
                userData = reader.ReadToEnd();
            }

            try
            {
                users = JsonConvert.DeserializeObject<ListUsers>(userData);
            }
            catch (JsonException exception)
            {
                Console.WriteLine(exception.Message);
            }

            return users;
        }

        /// <summary>
        /// Method return list of users 
        /// </summary>
        /// <returns></returns>
        public static ListUsers GetUsers()
        {
            if (users.Users == null)
            {
              users = ReadUsersData();
            }

            return users;
        }

        /// <summary>
        /// Method return user from list of users by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static User GetUserByIndex(int index)
        {
            if (users.Users == null)
            {
                users = ReadUsersData();
            }

            if (users.Users.Length < index && index < 0)
            {
                throw new Exception("No user found.Check the index.");
            }

            return users.Users[index];
        }

    }

    public struct User
    {
        public string firstName;
        public string lastName;
        public string email;
        public string telephone;
        public string fax;

        public string company;
        public string address_1;
        public string address_2;
        public string city;
        public string postCode;
        public string country;
        public string region;
        public string password;

    }

    public struct ListUsers
    {
        public User[] Users { get; set; }
    }
}

