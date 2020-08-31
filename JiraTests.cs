using ClassLibrary1;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace JiraAutomationTests
{
    [TestFixture]
    public class JiraTests
    {
        ChromeDriver _driver;
        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver
            {
                Url = "http://localhost:8080/"
            };
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void JiraAllowsToTheUserLoginIn()
        {
            var loginPage = new LoginPage(_driver);
            loginPage
                .fillUsername("sebas.adm1n10")
                .fillPassword("sebas12")
                .ClickLogin();
            Thread.Sleep(5000);
            var jiraLogo = _driver.FindElementById("jira");
            Assert.IsTrue(jiraLogo.Displayed);
        }

        [Test]
        public void JiraAllowsToCreateANewStory()
        {
            var loginPage = new LoginPage(_driver);
            loginPage
                .fillUsername("sebas.adm1n10")
                .fillPassword("sebas12")
                .ClickLogin();
            Thread.Sleep(5000);
            var dashboardPage = new DashboardPage(_driver);
            Assert.IsTrue(dashboardPage.LogoDisplayed());
            dashboardPage.ClickCreateButton();
            Thread.Sleep(1000);
            dashboardPage.FillSummaryField("test");
            dashboardPage.ExpandSprintDropDown();
            Thread.Sleep(5000);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
        }
    }
}
