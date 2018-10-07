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
            string expectedMessage = EditAccountInformationPage.ExpectedSuccessMessage;
 
            //go to My Accaunt page
            Pages.LoginPage.GoToLoginPage()
                        .SetLoginInputClear(user.email)
                        .SetPasswordInputClear(user.password)
                        .ClickSigninButton();
            
            //go to Edit account page
            Pages.AccountPage.ClickEditAccountInformation();

            //fill fields on Edit account page
            Pages.EditAccountInformationPage.SetFirstName(user.firstName);
            Pages.EditAccountInformationPage.SetLastName(user.lastName);
            Pages.EditAccountInformationPage.SetEmail(user.email);
            Pages.EditAccountInformationPage.SetTelephone(user.telephone);
            Pages.EditAccountInformationPage.SetFax(EditAccountInformationPage.DefaultFax);

            //click button Continue
            Pages.EditAccountInformationPage.ClickButtonContinue();
      
            string actualMessage = Pages.EditAccountInformationPage.SuccessMessage.Text;

            Assert.AreEqual(expectedMessage, actualMessage);
        }
    }
}
