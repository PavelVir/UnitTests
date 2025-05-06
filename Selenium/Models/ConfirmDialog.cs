using OpenQA.Selenium;

namespace USP_2022_UnitTests.Selenium.Models
{
    public class ConfirmDialog : BasePage
    {
        readonly By Button_Yes = By.XPath("//button[contains(@class, 'btn-default') and text()='OK']");
        readonly By Button_No = By.XPath("//button[contains(@class, 'btn-default') and text()='Скасувати']");

        public ConfirmDialog(IWebDriver driver) : base(driver)
        {
        }

        public void Button_Yes_click()
        {
            driver.FindElement(Button_Yes).Click();
        }
        
        public void Button_No_click()
        {
            driver.FindElement(Button_No).Click();
        }
    }
}