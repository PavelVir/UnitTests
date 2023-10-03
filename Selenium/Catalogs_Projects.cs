using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using Settings;
using USP_2022_UnitTests.Selenium.Models;

namespace UnitTests.Selenium;

[TestFixture]
public class CatalogProject01CreateNewTest
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
    [Test]
    public void CatalogProject01CreateNew()
    {
        driver.Navigate().GoToUrl(Params.Url);

        var MainMenu = new MainMenu(driver);
        var ProjectDialog = new ProjectDialog(driver);

        MainMenu.Catalogs_click();
        MainMenu.Projects_click();

        Wait();          

        ProjectDialog.Button_append_click();
       
        ProjectDialog.Project_Name_SendKeys("Test project");
        ProjectDialog.Project_FullName_SendKeys("Test project");
        ProjectDialog.Project_IsActive_click();
        ProjectDialog.Button_SaveAndClose_click();

        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.FindElements(By.XPath("//span[contains(.,'Test project')]")).Count > 0);
        }

        void Wait()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }
    }
}