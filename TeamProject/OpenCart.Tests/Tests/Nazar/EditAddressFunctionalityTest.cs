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
        public void EditeAddress_CompareMessage()
        {
            Driver.Navigate().GoToUrl(URL_AddressPage);

            string actualMessage = Pages.AddressPage
                .EditRaw(2)
                .SuccessfullEditionAddress(users.Users[0])
                .GetSuccessfulMessage();

            string expectedMessage = "Your address has been successfully updated";

            NUnit.Framework.Assert.AreEqual(actualMessage, expectedMessage, "Compare the text of the comunicat about edit");
        }

        [TestCase(1)]
        public void EditeNewAddress_CompareInsertedInfo(int index)
        {
            Driver.Navigate().GoToUrl(URL_AddressPage);
            User user = users.Users[2];
            Pages.AddressPage
               .EditRaw(index)
               .SuccessfullEditionAddress(user);

            string actualAddressInfo = Pages.AddressPage
                             .GetAddressIfno(index);


            string expectedAddressInfo = user.firstName + " " + user.lastName + "\r\n" +
                              user.address_1 + "\r\n" +
                              user.city + " " + user.postCode + "\r\n" +
                              user.region + "\r\n" +
                              user.country;

            NUnit.Framework.Assert.AreEqual(actualAddressInfo, expectedAddressInfo, "Compare Address Info");
        }
    }
}
