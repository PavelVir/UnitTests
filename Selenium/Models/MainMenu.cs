using OpenQA.Selenium;

namespace USP_2022_UnitTests.Selenium.Models
{
    public class MainMenu : BasePage
    {
        readonly By CatalogElementlink = By.XPath("//a[contains(@href, '/catalog')]");
        readonly By ProjectElementlink = By.XPath("//a[contains(@href, '/catalog/project')]");
        readonly By PriceTypesElementlink = By.XPath("//a[contains(@href, '/catalog/pricetype')]");

        public MainMenu(IWebDriver driver) : base(driver)
        {
            /* if (!driver.Title.Equals("Головна"))
             {
                 throw new InvalidOperationException("This is not the Головна, current page is: " + driver.Url);
             }
            */
        }

        public void Catalogs_click()
        {
            driver.FindElement(CatalogElementlink).Click();
        }

        public void Projects_click()
        {
            driver.FindElement(ProjectElementlink).Click();
        }

        public void PriceTypes_click()
        {
            driver.FindElement(PriceTypesElementlink).Click();
        }
    }
}