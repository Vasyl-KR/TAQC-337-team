using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace OpenCartTests.Data
{
    public class ReaderUserData
    {
        private static ListUsers users;
        private static ListUsers unregisteredUsers;
        private static string userFile = "Users.json";
        private static string unregisterUserFile = "UnregisteredUser.json";

        /// <summary>
        /// Private method for read data from file 'User.json' and return list of users
        /// </summary>
        /// <returns></returns>
        private static ListUsers ReadUsersData(string fileName)
        {
            string folderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                        .Replace("\\bin\\Debug", "\\Data");
            string path = Path.Combine(folderPath, fileName);
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
                users = ReadUsersData(userFile);
            }

            return users;
        }

        /// <summary>
        /// Method return list of unregistered users 
        /// </summary>
        /// <returns></returns>
        public static ListUsers GetUnregisteUsers()
        {
            if (unregisteredUsers.Users == null)
            {
                unregisteredUsers = ReadUsersData(unregisterUserFile);
            }

            return users;
        }

        public static IEnumerable<User> GetUserData()
        {
            foreach (User user in GetUsers().Users)
            {
                yield return user;
            }
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

