using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using Settings;
using USP_2022_UnitTests.Selenium.Models;

namespace UnitTests.Selenium;

[TestFixture]
public class CatalogProjectTests
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
    public void CatalogProject01CreateNew()
    {
        Wait();
        driver.Navigate().GoToUrl(Params.Url);

        var MainMenu = new MainMenu(driver);
        var ProjectDialog = new ProjectDialog(driver);

        MainMenu.Catalogs_click();
        MainMenu.Projects_click();

        Wait();

        ProjectDialog.Filter_SendKeys("Test project");

        ProjectDialog.Button_append_click();
       
        ProjectDialog.Project_Name_SendKeys("Test project");
        ProjectDialog.Project_FullName_SendKeys("Test project");
        ProjectDialog.Project_IsActive_click();
        ProjectDialog.Button_SaveAndClose_click();

        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(8));
            wait.Until(driver => driver.FindElements(By.XPath("//span[contains(.,'Test project')]")).Count > 0);
        }
    }
    
    [Test, Order(2)]
    public void CatalogProject02Edit()
    {
        driver.Navigate().GoToUrl(Params.Url);

        var MainMenu = new MainMenu(driver);
        var ProjectDialog = new ProjectDialog(driver);

        // Navigate to Projects page
        MainMenu.Catalogs_click();
        MainMenu.Projects_click();

        Wait();


        ProjectDialog.Filter_SendKeys("Test project");

        // Find and click on the existing project
        var projectRow = driver.FindElement(By.XPath("//tr[.//span[contains(text(),'Test project')]]"));
        projectRow.Click();

        // Click the edit button
        ProjectDialog.Button_edit_click();
        
        // Update project details
        ProjectDialog.Project_Name_Clear();
        ProjectDialog.Project_Name_SendKeys("Edited project");
        
        ProjectDialog.Project_FullName_Clear();
        ProjectDialog.Project_FullName_SendKeys("Edited project full name");
        
        // Save the changes
        ProjectDialog.Button_SaveAndClose_click();

        ProjectDialog.Filter_SendKeys("Edited project");

        // Verify the project was updated
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.FindElements(By.XPath("//span[contains(.,'Edited project')]")).Count > 0);
        }
    }
    
    [Test, Order(3)]
    public void CatalogProject03Delete()
    {
        driver.Navigate().GoToUrl(Params.Url);

        var MainMenu = new MainMenu(driver);
        var ProjectDialog = new ProjectDialog(driver);

        // Navigate to Projects page
        MainMenu.Catalogs_click();
        MainMenu.Projects_click();

        Wait();

        ProjectDialog.Filter_SendKeys("Edited project");

        // Find and click on the existing project
        var projectRow = driver.FindElement(By.XPath("//tr[.//span[contains(text(),'Edited project')]]"));
        projectRow.Click();
        
        // Click the delete button
        ProjectDialog.Button_delete_click();
        
        // Confirm deletion in the confirmation dialog
        var confirmDialog = new ConfirmDialog(driver);
        confirmDialog.Button_Yes_click();

        // Verify the project was deleted
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.FindElements(By.XPath("//span[contains(.,'Edited project')]")).Count == 0);
        }
    }
    
    private void Wait()
    {
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }
}