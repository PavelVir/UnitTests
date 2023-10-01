using OpenQA.Selenium;

namespace USP_2022_UnitTests.Selenium.Models
{
    public class ProjectDialog : BasePage
    {
        readonly By Button_append = By.XPath("//button[@test-id='button_append']");
        readonly By Project_Name  = By.XPath("//div[@test-id='Project_Name']/div/input");
        readonly By Project_FullName = By.XPath("//div[@test-id='Project_FullName']/div/input");
        readonly By Project_IsActive = By.XPath("//label[@test-id='Project_IsActive']/span");
        readonly By Button_SaveAndClose = By.XPath("//button[@test-id='SaveAndClose']");

        public ProjectDialog(IWebDriver driver) : base(driver)
        {
            /* if (!driver.Title.Equals("Головна"))
             {
                 throw new InvalidOperationException("This is not the Головна, current page is: " + driver.Url);
             }
            */
        }

        public void Button_append_click()
        {
            driver.FindElement(Button_append).Click();
        }   
        public void Project_IsActive_click()
        {
            driver.FindElement(Project_IsActive).Click();
        } 
        public void Button_SaveAndClose_click()
        {
            driver.FindElement(Button_SaveAndClose).Click();
        }

        public void Project_Name_SendKeys(string keys)
        {
            driver.FindElement(Project_Name).SendKeys(keys);
        }
        
        public void Project_FullName_SendKeys(string keys)
        {
            driver.FindElement(Project_FullName).SendKeys(keys);
        }


    }
}
