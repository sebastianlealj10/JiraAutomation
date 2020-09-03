using ClassLibrary1;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Threading;

namespace JiraAutomationTests
{
    [TestFixture]
    public class JiraTests
    {
        ChromeDriver _driver;
        private WebDriverWait _wait;
        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver
            {
                Url = "http://localhost:8080/"
            };
            _driver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
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
            var dashboardPage = new DashboardPage(_driver, _wait);
            Assert.IsTrue(dashboardPage.LogoDisplayed());
            dashboardPage
                .ClickCreateButton()
                .FillSummaryField("test")
                .ExpandSprintDropDown()
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
