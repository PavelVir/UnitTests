using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace USP_2022_UnitTests.Selenium.Models
{
    public abstract class BasePage
    {
        protected IWebDriver driver;
        public DefaultWait<IWebDriver> wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;

            DefaultWait<IWebDriver> wait = new(driver)
            {
                Timeout = TimeSpan.FromSeconds(10),
                PollingInterval = TimeSpan.FromMilliseconds(250),
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            if (wait is null) throw new ArgumentNullException(nameof(driver));
        }
    }
}