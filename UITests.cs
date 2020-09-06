using SolutionCore;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;

namespace JiraAutomationTests
{
    [TestFixture]
    public class JiraTests
    {
        ChromeDriver _driver;
        private WebDriverWait _wait;
        private readonly string BaseUrl = ConfigurationManager.AppSettings["BaseUrl"];

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver
            {
                Url = BaseUrl
            };
            _driver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
        }

        [Test]
        public void JiraAllowsToTheUserLoginIn()
        {
            var loginPage = new LoginPage(_driver);
            loginPage
                .fillUsername()
                .fillPassword()
                .ClickLogin();
            var jiraLogo = _driver.FindElementById("jira");
            Assert.IsTrue(jiraLogo.Displayed);
        }

        [Test]
        public void JiraAllowsToCreateANewStory()
        {
            var loginPage = new LoginPage(_driver);
            loginPage
                .fillUsername()
                .fillPassword()
                .ClickLogin();
            var dashboardPage = new DashboardPage(_driver, _wait);
            Assert.IsTrue(dashboardPage.LogoDisplayed());
            dashboardPage
                .ClickCreateButton()
                .FillSummaryField("test")
                .SenndIssueForm();
            Assert.IsTrue(dashboardPage.CreatedAlertDisplayed());
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
        }
    }
}
