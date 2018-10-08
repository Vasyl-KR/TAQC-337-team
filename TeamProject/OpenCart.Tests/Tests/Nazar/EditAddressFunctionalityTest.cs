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
            //Act
            Driver.Navigate().GoToUrl(URL_AddressPage);
            string actualMessage = Pages.AddressPage
                .EditRaw(2)
                .SuccessfullEditionAddress(users.Users[0])
                .GetSuccessfulMessage();

            //Arrange 
            string expectedMessage = "Your address has been successfully updated";

            //Assert
            NUnit.Framework.Assert.AreEqual(actualMessage, expectedMessage, "Compare the text of the comunicat about edit");
        }

        [TestCase(1)]
        public void EditeAddress_CompareInsertedInfo(int index)
        {
            //Act
            Driver.Navigate().GoToUrl(URL_AddressPage);
            User user = users.Users[2];

            string actualAddressInfo =  Pages.AddressPage
               .EditRaw(index)
               .SuccessfullEditionAddress(user)
               .GetAddressIfno(index);

            //Arrange 
            string expectedAddressInfo = user.firstName + " " + user.lastName + "\r\n" +
                              user.address_1 + "\r\n" +
                              user.city + " " + user.postCode + "\r\n" +
                              user.region + "\r\n" +
                              user.country;

            //Assert
            NUnit.Framework.Assert.AreEqual(actualAddressInfo, expectedAddressInfo, "Compare Address Info");
        }
    }
}
