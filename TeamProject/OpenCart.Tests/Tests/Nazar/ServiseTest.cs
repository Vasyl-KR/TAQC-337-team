using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Tests.Nazar
{
    [TestFixture]
    public class ServiseTest
    {
        public string token;
        string URL = "http://localhost:8080/";

        [OneTimeSetUp]
        public void BeforeAll_getToken()
        { 
            var client = new RestClient(URL);
            var request = new RestRequest("/login",Method.POST);
            request.AddParameter("multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW",
                "------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"name\"\r\n\r\nadmin\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"password\"\r\n\r\nqwerty\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW--",
                ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            try
            {
                token = content.Substring(content.IndexOf(":\"") + 2);
                token = token.Substring(0, token.Length - 2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("token->" + token);
            Assert.AreEqual(token.Length , 32);
        }

        [Test]
        public void GetItems()
        {
            var client = new RestClient(URL);
            var request = new RestRequest("/items", Method.GET);
            request.AddParameter("token", token);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            Console.WriteLine("content -> " + content);
            Assert.AreEqual(token.Length, 32);
        }

        [Test]
        public void GetUsers()
        {
            var client = new RestClient(URL);
            var request = new RestRequest("/users", Method.GET);
            request.AddParameter("adminToken", token);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            Console.WriteLine("users -> " + content);
            Assert.AreEqual(token.Length, 32);
        }


        [Test]
        public void AddItem()
        {
            var client = new RestClient(URL);
            var request = new RestRequest("/item/3", Method.POST);
            request.AddParameter("token", token);
            request.AddParameter("item", "ball");
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            Console.WriteLine("users -> " + content);
            Assert.AreEqual(token.Length, 32);
        }

        //[Test]
        //public void ChangeItem()
        //{
        //    var client = new RestClient(URL);
        //    var request = new RestRequest("/item/3", Method.PUT);
        //    request.AddParameter("token", token);
        //    request.AddParameter("item", "ball");
        //    IRestResponse response = client.Execute(request);
        //    var content = response.Content;
        //    Console.WriteLine("users -> " + content);
        //    Assert.AreEqual(token.Length, 32);
        //}

    }
}
