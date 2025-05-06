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
        protected void SafeClick(By locator, int maxAttempts = 3)
        {
            for (int i = 0; i < maxAttempts; i++)
            {
                try
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    var element = wait.Until(driver =>
                    {
                        try
                        {
                            var elem = driver.FindElement(locator);
                            return elem.Displayed && elem.Enabled ? elem : null;
                        }
                        catch (StaleElementReferenceException)
                        {
                            return null;
                        }
                    });

                    if (element != null)
                    {
                        element.Click();
                        return;
                    }

                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    if (i == maxAttempts - 1)
                        throw new Exception($"Failed to click element after {maxAttempts} attempts", ex);
                    Thread.Sleep(1000);
                }
            }
        }
    }
}