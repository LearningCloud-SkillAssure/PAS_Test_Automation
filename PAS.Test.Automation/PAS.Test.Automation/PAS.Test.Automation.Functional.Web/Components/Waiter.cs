using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAS.Test.Automation.Functional.Web.Components
{
    public class Waiter
    {
        public WebDriverWait explicitWait;
        public DefaultWait<IWebDriver> fluentWait;

        public Waiter(IWebDriver driver)
        {
            explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            fluentWait = new DefaultWait<IWebDriver>(driver);

            ConfigureExplicitWait(TimeSpan.FromSeconds(3));
            ConfigureFluentWait();
        }


        public void ConfigureExplicitWait(TimeSpan timeOut)
        {
            explicitWait.Timeout = timeOut;
        }

        public void ConfigureFluentWait()
        {
            fluentWait.Timeout = TimeSpan.FromSeconds(3);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        }
        public void ConfigureFluentWait(TimeSpan timeOut)
        {
            fluentWait.Timeout = timeOut;
        }
        public void ConfigureFluentWait(TimeSpan timeOut,Type[] ignoreExceptionTypes)
        {
            fluentWait.Timeout = timeOut;
            fluentWait.IgnoreExceptionTypes(ignoreExceptionTypes);
        }
    }
}
