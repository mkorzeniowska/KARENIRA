using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace CourseTest
{
    [TestClass]
    public class ExamXPathTest
    {
        public IWebDriver Driver;

        [TestInitialize]
        public void CreateDriver()
        {
            Driver = GetChromeDriver();
        }
        public IWebDriver GetChromeDriver()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }
        [TestMethod]
        public void SeleniumElementLocations()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/simple-html-elements-for-automation/");
            ScrollToElementUsingJavaScript(By.XPath("//*[@type='radio']/../.."));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Driver.FindElement(By.XPath("//*[@type='radio'][@value='female']")).Click();
            Driver.FindElement(By.XPath("//*[@name='vehicle'][@value='Bike']")).Click();
            Driver.FindElement(By.XPath("//*[@value='audi']")).Click();
            var link = Driver.FindElement(By.XPath("//*[contains(text(),'Tab 2')]"));
            link.Click();
            string.Equals("Tab 2 content",link.Text);
            HighLightElementUsingJavaScript(By.XPath("//*[contains(text(),'$50,000+')]"));
        }
        

        [TestMethod]
        public void ScrollToElementUsingJavaScript(By locationStrategy)
        {
            var element = Driver.FindElement(locationStrategy);
            IJavaScriptExecutor javaScriptExecutor = Driver as IJavaScriptExecutor;
            javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView();", element);
        }
        [TestMethod]
        public void HighLightElementUsingJavaScript(By locationStrategy, int duration =2)
        {
            var element = Driver.FindElement(locationStrategy);
            var originalStyle = element.GetAttribute("style");
            IJavaScriptExecutor javaScriptExecutor = Driver as IJavaScriptExecutor;
            javaScriptExecutor.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])",
                element, "style", "border: 7px solid yellow; border-style: dashed");

            if (duration <= 0) return;
            Thread.Sleep(TimeSpan.FromSeconds(duration));
            javaScriptExecutor.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])", element, "style", originalStyle);

        }


    }
}
