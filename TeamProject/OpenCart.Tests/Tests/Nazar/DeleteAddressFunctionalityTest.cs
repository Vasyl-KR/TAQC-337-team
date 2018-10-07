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
        public void Delete_Address(int index)
        {
            Driver.Navigate().GoToUrl("http://atqc-shop.epizy.com/index.php?route=account/address");

            string actual = Pages.AddressPage
                            .DeleteRaw(index)
                            .GetSuccessfulMessage();

            string expected = "Your address has been successfully deleted";
            NUnit.Framework.Assert.AreEqual(expected, actual, "Compare the text of the comunicat about delite");
        }


        [TestCase(2)]
        public void Delete_NewAddress(int index)
        {

            int ListSizeBeforeAdding = Pages.AddressPage
                                        .ListAddresses
                                        .Count();

            int ListSizeAfterAdding = Pages.AddressPage
                            .DeleteRaw(index)
                            .ListAddresses.Count;

            NUnit.Framework.Assert.AreEqual(ListSizeBeforeAdding - 1, ListSizeAfterAdding, "Compare list size after adding new address" + ListSizeBeforeAdding + " == " + ListSizeAfterAdding);
        }

        [TestCase(1)]
        public void Delete_Address1(int index)
        {
            Driver.Navigate().GoToUrl("http://atqc-shop.epizy.com/index.php?route=account/address");

            string actual =
            Pages.AddressPage
                            .DeleteRaw(index)
                            .GetUnsuccessfulMessage();

            string expected = "Warning: You can not delete your default address!";
            NUnit.Framework.Assert.AreEqual(expected, actual, "Compare the text of the comunicat about delite");
        }
    }
}
