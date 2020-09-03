using OpenQA.Selenium;

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

        public LoginPage fillUsername(string username)
        {
            Username.SendKeys(username);
            return this;
        }

        public LoginPage fillPassword(string password)
        {
            Password.SendKeys(password);
            return this;
        }

        public LoginPage ClickLogin()
        {
            LoguinButton.Click();
            return this;
        }


    }
}
