using ClassLibrary1;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace JiraAutomationTests
{
    [TestFixture]
    public class JiraTests
    {
        [Test]
        public void TestMethod1()
        {
            var driver = new ChromeDriver
            {
                Url = "http://localhost:8080/"
            };
            driver.Manage().Window.Maximize();

            var loginPage = new LoginPage(driver);
            loginPage
                .fillUsername("sebas.adm1n10")
                .fillPassword("sebas12")
                .ClickLogin();
            Thread.Sleep(5000);
            var jiraLogo = driver.FindElementById("jira");
            Assert.IsTrue(jiraLogo.Displayed);

            ;
        }
    }
}
