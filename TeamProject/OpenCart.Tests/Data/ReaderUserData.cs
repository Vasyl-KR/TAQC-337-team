using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Data
{
    public enum MyAccount
    {
        Login,
        Register,
        MyAccount,
        OrderHistory,
        Transactions,
        Downloads,
        Logout
    }
    class ReaderUserData
    {
        // method read users data from file 'User.json' and return list of users
        public static ListUsers GetUsersData()
        {
            string folderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace("\\bin\\Debug", "\\Data");
            string path = Path.Combine(folderPath, "Users1.json");
            string userData;

            using (StreamReader reader = new StreamReader(path))
            {
                userData = reader.ReadToEnd();
            }

            ListUsers users = JsonConvert.DeserializeObject<ListUsers>(userData);
            return users;
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
