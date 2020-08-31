using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class DashboardPage
    {
        IWebDriver driver;
        IWebElement jiraLogo => driver.FindElement(By.Id("jira"));
        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool LogoDisplayed()
        {
            return jiraLogo.Displayed;
        }

    }
}
