using OpenQA.Selenium;

namespace USP_2022_UnitTests.Selenium.Models
{
    public class ProjectDialog : BasePage
    {
        readonly By Button_append = By.XPath("//button[@test-id='button_append']");
        readonly By Button_edit = By.XPath("//button[@test-id='button_edit']");
        readonly By Button_delete = By.XPath("//button[@test-id='button_delete']");
        readonly By Project_Name  = By.XPath("//div[@test-id='Project_Name']/div/input");
        readonly By Project_FullName = By.XPath("//div[@test-id='Project_FullName']/div/input");
        readonly By Project_IsActive = By.XPath("//label[@test-id='Project_IsActive']/span");
        readonly By Button_SaveAndClose = By.XPath("//button[@test-id='SaveAndClose']");
        readonly By Filter = By.XPath("//div[@test-id='Filter']/div/input");
        readonly By FilterLink = By.XPath("//div[@test-id='Filter']/div/a");
        readonly By Filterclear = By.XPath("//div[@test-id='Filter']/div/a[2]");

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
        
        public void Button_edit_click()
        {
            driver.FindElement(Button_edit).Click();
        }
        
        public void Button_delete_click()
        {
            driver.FindElement(Button_delete).Click();
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
        
        public void Filter_SendKeys(string keys)
        {
            try
            {
                // Try to click the clear button first if it exists
                var clearButton = driver.FindElements(Filterclear);
                if (clearButton.Count > 0 && clearButton[0].Displayed)
                {
                    clearButton[0].Click();
                }
            }
            catch (Exception)
            {
                // Ignore any exceptions if the clear button is not available
            }

            driver.FindElement(Filter).SendKeys(keys);
            driver.FindElement(FilterLink).Click();

        }
        
        public void Project_Name_Clear()
        {
            driver.FindElement(Project_Name).Clear();
        }
        
        public void Project_FullName_SendKeys(string keys)
        {
            driver.FindElement(Project_FullName).SendKeys(keys);
        }
        
        public void Project_FullName_Clear()
        {
            driver.FindElement(Project_FullName).Clear();
        }
    }
}