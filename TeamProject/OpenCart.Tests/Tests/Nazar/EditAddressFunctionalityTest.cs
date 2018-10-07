using NUnit.Framework;
using OpenCartTests.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Tests.Nazar
{
    [TestFixture]
    class EditAddressFunctionalityTest : NazarBaseTest
    {

        [Test]
        public void Edite_Address()
        {
            Driver.Navigate().GoToUrl("http://atqc-shop.epizy.com/index.php?route=account/address");

            string actual = Pages.AddressPage
                .EditRaw(2)
                .SuccessfullEditionAddress(users.Users[0])
                .GetSuccessfulMessage();

            string expected = "Your address has been successfully updated";

            NUnit.Framework.Assert.AreEqual(actual, expected, "Compare the text of the comunicat about edit");
        }

        [TestCase(1)]
        public void Edite_NewAddress_CompareInsertedInfo(int index)
        {
            User user = users.Users[2];
            Pages.AddressPage
               .EditRaw(index)
               .SuccessfullEditionAddress(user);

            string actual = Pages.AddressPage
                             .GetAddressIfno(index);


            string expected = user.firstName + " " + user.lastName + "\r\n" +
                              user.address_1 + "\r\n" +
                              user.city + " " + user.postCode + "\r\n" +
                              user.region + "\r\n" +
                              user.country;

            NUnit.Framework.Assert.AreEqual(actual, expected, "Compare ------");
        }
    }
}
