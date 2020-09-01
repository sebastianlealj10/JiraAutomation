using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class DashboardPage
    {
        IWebDriver driver;
        IWebElement JiraLogo => driver.FindElement(By.Id("jira"));
        IWebElement CreateButton => driver.FindElement(By.Id("create_link"));
        IWebElement SummaryTextBox => driver.FindElement(By.Id("summary"));
        IWebElement SprintDropDown => driver.FindElement(By.Id("customfield_10100-field"));
        IWebElement SendFormButton => driver.FindElement(By.Id("create-issue-submit"));

        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool LogoDisplayed()
        {
            return JiraLogo.Displayed;
        }

        public DashboardPage ClickCreateButton()
        {
            CreateButton.Click();
            return this;
        }

        public DashboardPage FillSummaryField(string summary)
        {
            SummaryTextBox.SendKeys(summary);
            return this;
        }

        public DashboardPage ExpandSprintDropDown()
        {
            
            SprintDropDown.Click();
            Thread.Sleep(5000);
            SprintDropDown.SendKeys(Keys.Enter);
            return this;
        }

        public DashboardPage SenndIssueForm()
        {

            SendFormButton.Click();
            Thread.Sleep(5000);
            return this;
        }

    }
}
