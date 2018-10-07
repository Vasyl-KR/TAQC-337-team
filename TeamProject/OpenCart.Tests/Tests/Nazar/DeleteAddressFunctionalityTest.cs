using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenCartTests.Tests.Nazar
{
    [TestFixture]
    class DeleteAddressFunctionalityTest : NazarBaseTest
    {
        [TestCase(2)]
        public void DeleteAddress_VerifyMessage_Positive(int index)
        {
            Driver.Navigate().GoToUrl(URL_AddressPage);

            string actualMessage = Pages.AddressPage
                            .DeleteRaw(index)
                            .GetSuccessfulMessage();

            string expectedMessage = "Your address has been successfully deleted";
            NUnit.Framework.Assert.AreEqual(expectedMessage, actualMessage, "Compare the text of the message");
        }


        [TestCase(2)]
        public void DeleteAddress_CompareListSize(int index)
        {
            Driver.Navigate().GoToUrl(URL_AddressPage);

            int ListSizeBeforeAdding = Pages.AddressPage
                                        .ListAddresses
                                        .Count();

            int ListSizeAfterAdding = Pages.AddressPage
                            .DeleteRaw(index)
                            .ListAddresses.Count;

            NUnit.Framework.Assert.AreEqual(ListSizeBeforeAdding - 1, ListSizeAfterAdding, "Compare list size after delete" + ListSizeBeforeAdding + " == " + ListSizeAfterAdding);
        }

        [TestCase(1)]
        public void DeleteAddress_VerifyMessage_Negative(int index)
        {
            Driver.Navigate().GoToUrl(URL_AddressPage);

            string actualMessage =
                            Pages.AddressPage
                            .DeleteRaw(index)
                            .GetUnsuccessfulMessage();

            string expectedMessage = "Warning: You can not delete your default address!";
            NUnit.Framework.Assert.AreEqual(expectedMessage, actualMessage, "Compare the text of the message");
        }
    }
}
