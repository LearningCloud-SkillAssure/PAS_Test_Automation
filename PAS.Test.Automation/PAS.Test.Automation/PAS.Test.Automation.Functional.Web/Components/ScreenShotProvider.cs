﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAS.Test.Automation.Functional.Web.Components
{
    public static class ScreenShotManager
    {
        public static void TakeScreenshot(IWebDriver driver)
        {
            //((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(ConfigurationManager.AppSettings["ScreenshotPath"]+"/"+"Shot",ScreenshotImageFormat.Png);
            ((ITakesScreenshot)driver)
                .GetScreenshot()
            //    .SaveAsFile(ConfigurationManager.AppSettings["ScreenshotPath"]+"/"+"Shot",ScreenshotImageFormat.Png);
            .SaveAsFile((Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\", ConfigurationManager.AppSettings["ScreenShotPath"]))) + "\\"+"Shot.png", ScreenshotImageFormat.Png);
            //.SaveAsFile(@"Resources/Screenshots" + "/" + "Shot", ScreenshotImageFormat.Png);
        }
    }
}
