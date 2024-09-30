using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

class Program
{
    static void Main(string[] args)
    {
        IWebDriver driver = new ChromeDriver();
        //driver.Navigate().GoToUrl("https://google.com");
        driver.Url = "https://google.com";
        string title1 = driver.Title;
        Console.WriteLine("Title of Google page: " + title1);

        //Practice for Switch to and Windowhandles
        // IList<string> winddowsHandles = new List<string>(driver.WindowHandles);
        // driver.SwitchTo().NewWindow(WindowType.Tab);
        // driver.Url = "https://selenium.dev";
        // int count = winddowsHandles.Count();
        // driver.SwitchTo().Window(winddowsHandles[0]);
        // driver.SwitchTo().Window(winddowsHandles[1]);
        // Thread.Sleep(2000);

        //back
        driver.FindElement(By.LinkText("Gmail")).Click();
        string title2 = driver.Title;
        Console.WriteLine("Title of Gmail page: " + title2);
        driver.Navigate().Back();
        string title3 = driver.Title;
        Console.WriteLine("Title of Google page: " + title3);

        
        //Forward
        driver.Navigate().Forward();
        string title4 = driver.Title;
        Console.WriteLine("Title of Gmail page: " + title4);

        //Refresh
        driver.Navigate().Refresh();

        driver.Close();
        Thread.Sleep(2000);
        driver.Quit();

    }
}
