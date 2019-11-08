using NUnit.Framework;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;


namespace CliniSafePhoneApp.UITest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void WelcomeTextIsDisplayed()
        {
            AppResult[] results = app.WaitForElement(c => c.Marked("Welcome to Xamarin.Forms!"));
            app.Screenshot("Welcome screen.");

            Assert.IsTrue(results.Any());
        }

        [Test]
        public void LoginTextIsDisplayed()
        {
            AppResult[] results = app.WaitForElement(c => c.Marked("LogIn"));
            app.Screenshot("Login screen.");

            Assert.IsTrue(results.Any());
        }







        //public LogInPage EnterCredentials(string username, string password)
        //{
        //    //    App.WaitForElement(emailField);
        //    //    App.Tap(emailField);
        //    //    App.EnterText(username);
        //    //    App.DismissKeyboard();
        //    //    App.Tap(passwordField);
        //    //    App.EnterText(password);
        //    //    App.DismissKeyboard();
        //    //    App.Screenshot("Credentials Entered");
        //    //    return this;
        //    //}
        //    //public void SignIn()
        //    //{
        //    //    App.Tap(signInButton);
        //}

        [Test]
        public void LoginTextBoxedIsDisplayed()
        {
            // Arrange
            app.EnterText("usernameEntryAutomationId");
            app.EnterText("passwordEntryAutomationId");
            app.EnterText("authenticateButtonAutomationId");



            // Act


            //AppResult[] results = app.WaitForElement(c => c.Marked("Welcome to CliniSafe"));
            //app.Screenshot("Login screen.");

            //Assert.IsTrue(results.Any());



            // Assert
        }
    }
}
