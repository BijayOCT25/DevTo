using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework.Legacy;

namespace SeleniumTests
{
    [TestFixture]
    public class GoogleTests
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private IWebDriver driver;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        [OneTimeSetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("headless"); // Run in headless mode for CI
            options.AddArgument("disable-gpu");
            options.AddArgument("--window-size=1920,1080");
            driver = new ChromeDriver(options);
        }

        [Test, Order(1)]
        public void GoogleHomePageTest()
        {
            driver.Url = "https://google.com";
            string title = driver.Title;
            ClassicAssert.AreEqual("Google", title, "Title of the Google page should be 'Google'");
        }

        [Test, Order(2)]
        public void GmailLinkTest()
        {
            driver.FindElement(By.LinkText("Gmail")).Click();
            string title = driver.Title;
            ClassicAssert.IsTrue(title.Contains("Gmail"), "Title should contain 'Gmail'");
        }

        [Test, Order(3)]
        public void NavigationBackAndForwardTest()
        {
            driver.Navigate().Back();
            string backTitle = driver.Title;
            ClassicAssert.AreEqual("Google", backTitle, "Title should return to 'Google' after navigating back");

            driver.Navigate().Forward();
            string forwardTitle = driver.Title;
            ClassicAssert.IsTrue(forwardTitle.Contains("Gmail"), "Title should go back to Gmail page after forward navigation");
        }

        
        [OneTimeTearDown]
        public void Teardown()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}
