using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace USP_2022_UnitTests.Selenium.Models
{
    public sealed class WebDriverSinglton
    {
        private static IWebDriver instance = null;
        private WebDriverSinglton() { }
        public static IWebDriver GetInstance()
        {
            if (instance == null)
            {
                instance = new ChromeDriver();
            }

            return instance;
        }
    }
}
