using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using Settings;
using USP_2022_UnitTests.Selenium.Models;

namespace UnitTests.Selenium;

[TestFixture]
public class CatalogPriceTypesTests
{
    private IWebDriver driver;

    [OneTimeSetUp]
    public void SetUp()
    {
        driver = WebDriverSinglton.GetInstance();
    }
    
    [OneTimeTearDown]
    protected void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }
    
    [Test, Order(1)]
    public void PriceType01CreateBasicType()
    {
        driver.Navigate().GoToUrl(Params.Url);

        var MainMenu = new MainMenu(driver);
        var PriceTypeDialog = new PriceTypeDialog(driver);

        // Navigate to Price Types page
        MainMenu.Catalogs_click();
        MainMenu.PriceTypes_click();

        Wait();

        // Create a new basic price type
        PriceTypeDialog.Button_append_click();
       
        PriceTypeDialog.PriceType_Name_SendKeys("Base Price");
        PriceTypeDialog.PriceType_IsCalculated_Uncheck(); // Ensure it's not calculated
        PriceTypeDialog.Button_SaveAndClose_click();

        // Verify the price type was created
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.FindElements(By.XPath("//span[contains(.,'Base Price')]")).Count > 0);
        }
    }
    
    [Test, Order(2)]
    public void PriceType02CreateCalculatedType()
    {
        driver.Navigate().GoToUrl(Params.Url);

        var MainMenu = new MainMenu(driver);
        var PriceTypeDialog = new PriceTypeDialog(driver);

        // Navigate to Price Types page
        MainMenu.Catalogs_click();
        MainMenu.PriceTypes_click();

        Wait();          

        // Create a new calculated price type
        PriceTypeDialog.Button_append_click();
       
        PriceTypeDialog.PriceType_Name_SendKeys("Retail Price");
        
        // Set as calculated
        PriceTypeDialog.PriceType_IsCalculated_Check();
        
        // Select base price type
        PriceTypeDialog.PriceType_DependsOn_SelectByText("Base Price");
        
        // Set markup percentage
        PriceTypeDialog.PriceType_MarkupPercentage_Clear();
        PriceTypeDialog.PriceType_MarkupPercentage_SendKeys("15.5");
        
        PriceTypeDialog.Button_SaveAndClose_click();

        // Verify the price type was created
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.FindElements(By.XPath("//span[contains(.,'Retail Price')]")).Count > 0);
        }
    }
    
    [Test, Order(3)]
    public void PriceType03EditCalculatedType()
    {
        driver.Navigate().GoToUrl(Params.Url);

        var MainMenu = new MainMenu(driver);
        var PriceTypeDialog = new PriceTypeDialog(driver);

        // Navigate to Price Types page
        MainMenu.Catalogs_click();
        MainMenu.PriceTypes_click();

        Wait();          

        // Find and select the Retail Price
        var priceTypeRow = driver.FindElement(By.XPath("//tr[.//span[contains(text(),'Retail Price')]]"));
        priceTypeRow.Click();
        
        // Edit the price type
        PriceTypeDialog.Button_edit_click();
        
        // Change markup percentage
        PriceTypeDialog.PriceType_MarkupPercentage_Clear();
        PriceTypeDialog.PriceType_MarkupPercentage_SendKeys("20.0");
        
        PriceTypeDialog.Button_SaveAndClose_click();

        // Verify the price type was updated
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.FindElements(By.XPath("//tr[.//span[contains(text(),'Retail Price')]]//td[4]/span[contains(text(),'20')]")).Count > 0);
        }
    }
    
    [Test, Order(4)]
    public void PriceType04DeleteCalculatedType()
    {
        driver.Navigate().GoToUrl(Params.Url);

        var MainMenu = new MainMenu(driver);
        var PriceTypeDialog = new PriceTypeDialog(driver);

        // Navigate to Price Types page
        MainMenu.Catalogs_click();
        MainMenu.PriceTypes_click();

        Wait();          

        // Find and select the Retail Price
        var priceTypeRow = driver.FindElement(By.XPath("//tr[.//span[contains(text(),'Retail Price')]]"));
        priceTypeRow.Click();
        
        // Delete the price type
        PriceTypeDialog.Button_delete_click();
        
        // Confirm deletion in the confirmation dialog
        var confirmDialog = new ConfirmDialog(driver);
        confirmDialog.Button_Yes_click();

        // Verify the price type was deleted
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.FindElements(By.XPath("//span[contains(.,'Retail Price')]")).Count == 0);
        }
    }
    
    [Test, Order(5)]
    public void PriceType05DeleteBasicType()
    {
        driver.Navigate().GoToUrl(Params.Url);

        var MainMenu = new MainMenu(driver);
        var PriceTypeDialog = new PriceTypeDialog(driver);

        // Navigate to Price Types page
        MainMenu.Catalogs_click();
        MainMenu.PriceTypes_click();

        Wait();          

        // Find and select the Base Price
        var priceTypeRow = driver.FindElement(By.XPath("//tr[.//span[contains(text(),'Base Price')]]"));
        priceTypeRow.Click();
        
        // Delete the price type
        PriceTypeDialog.Button_delete_click();
        
        // Confirm deletion in the confirmation dialog
        var confirmDialog = new ConfirmDialog(driver);
        confirmDialog.Button_Yes_click();

        // Verify the price type was deleted
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.FindElements(By.XPath("//span[contains(.,'Base Price')]")).Count == 0);
        }
    }
    
    private void Wait()
    {
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }
}