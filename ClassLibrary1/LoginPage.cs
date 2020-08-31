using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class LoginPage
    {
        IWebDriver driver;
        private IWebElement Username => driver.FindElement(By.Id("login-form-username"));
        private IWebElement Password => driver.FindElement(By.Id("login-form-password"));

        private IWebElement LoguinButton => driver.FindElement(By.Id("login"));
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void fillUsername(string username)
        {
            Username.SendKeys(username);
        }

        public void fillPassword(string password)
        {
            Password.SendKeys(password);
        }

        public void ClickLogin()
        {
            LoguinButton.Click();
        }


    }
}
