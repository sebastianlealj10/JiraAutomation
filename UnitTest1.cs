using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace JiraAutomationTests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            var driver = new ChromeDriver
            {
                Url = "http://localhost:8080/"
            };

            driver.Manage().Window.Maximize();
            var username = driver.FindElementById("login-form-username");
            username.SendKeys("sebas.adm1n10");
            var password = driver.FindElementById("login-form-password");
            password.SendKeys("Demo1234");
            var loguinButton = driver.FindElementById("login");
            loguinButton.Click();
            Thread.Sleep(5000);
        }
    }
}
