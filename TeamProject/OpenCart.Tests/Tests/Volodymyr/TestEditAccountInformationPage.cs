using NUnit.Framework;
using OpenCartTests.Data;
using OpenCartTests.Pages;

namespace OpenCartTests.Tests.Volodymyr
{
    [TestFixture]
    public class TestEditAccountInformationPage: BaseTest
    {     
        [Test]
        public void Test_Edit_Account_Information_Page()
        {
            // create test data
            User user = ReaderUserData.GetUserByIndex(1);

            Pages.LoginPage.GoToLoginPage()
                        .SetLoginInputClear(user.email)
                        .SetPasswordInputClear(user.password)
                        .ClickSigninButton();
            
            Pages.AccountPage.ClickEditAccountInformation();

            //fill fields
            Pages.EditAccountInformationPage.SetFirstName(user.firstName);
            Pages.EditAccountInformationPage.SetLastName(user.lastName);
            Pages.EditAccountInformationPage.SetEmail(user.email);
            Pages.EditAccountInformationPage.SetTelephone(user.telephone);
            Pages.EditAccountInformationPage.SetFax("0000099900");

            Pages.EditAccountInformationPage.ClickButtonContinue();

            string expectedMessage = EditAccountInformationPage.ExpectedSuccessMessage;
            string actualMessage = Pages.EditAccountInformationPage.SuccessMessage.Text;

            Assert.AreEqual(expectedMessage, actualMessage);
        }
    }
}
