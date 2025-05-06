using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace USP_2022_UnitTests.Selenium.Models
{
    public class PriceTypeDialog : BasePage
    {
        readonly By Button_append = By.XPath("//button[@test-id='button_append']");
        readonly By Button_edit = By.XPath("//button[@test-id='button_edit']");
        readonly By Button_delete = By.XPath("//button[@test-id='button_delete']");
        readonly By PriceType_Name = By.XPath("//div[@test-id='PriceType_Name']/div/input");
        readonly By PriceType_IsCalculated = By.XPath("//label[@test-id='PriceType_IsCalculated']/span");
        readonly By PriceType_DependsOn = By.XPath("//div[@test-id='PriceType_DependsOn']/div/select");
        readonly By PriceType_MarkupPercentage = By.XPath("//div[@test-id='PriceType_MarkupPercentage']/div/input");
        readonly By Button_SaveAndClose = By.XPath("//button[@test-id='SaveAndClose']");

        public PriceTypeDialog(IWebDriver driver) : base(driver)
        {
        }

        public void Button_append_click()
        {
            SafeClick(Button_append);
        }

        public void Button_edit_click()
        {
            driver.FindElement(Button_edit).Click();
        }
        
        public void Button_delete_click()
        {
            driver.FindElement(Button_delete).Click();
        }
        
        public void Button_SaveAndClose_click()
        {
            driver.FindElement(Button_SaveAndClose).Click();
        }
        
        public void PriceType_Name_SendKeys(string keys)
        {
            driver.FindElement(PriceType_Name).SendKeys(keys);
        }
        
        public void PriceType_Name_Clear()
        {
            driver.FindElement(PriceType_Name).Clear();
        }
        
        public void PriceType_IsCalculated_Check()
        {
            var element = driver.FindElement(PriceType_IsCalculated);
            if (!element.Selected)
            {
                element.Click();
            }
        }
        
        public void PriceType_IsCalculated_Uncheck()
        {
            var element = driver.FindElement(PriceType_IsCalculated);
            if (element.Selected)
            {
                element.Click();
            }
        }
        
        public void PriceType_DependsOn_SelectByText(string text)
        {
            var selectElement = new SelectElement(driver.FindElement(PriceType_DependsOn));
            selectElement.SelectByText(text);
        }
        
        public void PriceType_MarkupPercentage_SendKeys(string keys)
        {
            driver.FindElement(PriceType_MarkupPercentage).SendKeys(keys);
        }
        
        public void PriceType_MarkupPercentage_Clear()
        {
            driver.FindElement(PriceType_MarkupPercentage).Clear();
        }


       

       
    }
}