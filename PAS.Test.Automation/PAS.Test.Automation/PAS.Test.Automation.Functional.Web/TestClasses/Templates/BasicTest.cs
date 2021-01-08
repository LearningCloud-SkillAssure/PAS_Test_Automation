using log4net;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using PAS.Test.Automation.Functional.Web.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAS.Test.Automation.Functional.Web.TestClasses.Templates
{

    class BasicTest
    {
        protected IWebDriver driver;

        //[SetUp]
        //public void CommonTestSetUp()
        //{
        //    Console.WriteLine("Insie One Time Set Up of base class");
        //    driver.Manage().Window.Maximize();
        //}

              
        [TearDown]
        public void CloseTest()
        {
            Console.WriteLine("Inside Tear Down");
            driver.Close();
            driver.Quit();
        }
    }
}
