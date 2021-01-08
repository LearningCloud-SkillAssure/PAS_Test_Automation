using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using PAS.Test.Automation.Functional.Web.Components;
using PAS.Test.Automation.Functional.Web.TestClasses.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PAS.Test.Automation.Functional.Web.TestClasses
{
    [Parallelizable]
    [AllureNUnit]
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(FirefoxDriver))]
    class TestGoogleHome<someDriver>:BasicTest where someDriver:IWebDriver,new()
    {
        [SetUp]
        public void SetUp()
        {
            Console.WriteLine("Inside Set Up");
            driver = new someDriver();    
            Console.WriteLine("After One Time Set Up");
        }

        [Test]
        public void searchGoogleByText()
        {
            Console.WriteLine("Inside Test Method");
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.FindElement(By.Name("q")).SendKeys("Hariharan"+Keys.Enter);
            Console.WriteLine("Finished Test Method");
            ScreenShotManager.TakeScreenshot(driver);
            Log4NetHelper.GetLogger("Hariharan").Debug("hariharan");
        }


        //Test Comment for git commit


    }
}
