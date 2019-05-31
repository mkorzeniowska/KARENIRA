using AutomationResources;
using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace CourseTest
{
    [TestClass]
    [TestCategory("Locating web elements")]
    public class WebElementsTest
    {
        public IWebDriver Driver { get; set; }

        [TestInitialize]
        public void RunBeforeEveryTests()
        {
            Driver = new WebDriverFactory().Create(BrowserType.Chrome);
        }
        [TestMethod]
        public void DifferentSeleniumLocations()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/simple-html-elements-for-automation/");
            HighligtElementUsingJavaScript(By.ClassName("buttonClass"));
            HighligtElementUsingJavaScript(By.Id("idExample"));
            HighligtElementUsingJavaScript(By.LinkText("Click me using this link text!"));
            HighligtElementUsingJavaScript(By.Name("button1"));
            HighligtElementUsingJavaScript(By.PartialLinkText("link text"));
            HighligtElementUsingJavaScript(By.TagName("div"));
            HighligtElementUsingJavaScript(By.CssSelector("#idExample"));
            HighligtElementUsingJavaScript(By.CssSelector(".buttonClass"));
            HighligtElementUsingJavaScript(By.XPath("//*[@id='idExample']"));
            HighligtElementUsingJavaScript(By.XPath("//*[@class='buttonClass']"));
        }
        [TestMethod]
        public void HighligtElementUsingJavaScript(By locationStrategy, int duration =2)
        {
            var element = Driver.FindElement(locationStrategy);
            var originalStyle = element.GetAttribute("style");
            IJavaScriptExecutor javaScriptExecutor = Driver as IJavaScriptExecutor;
            javaScriptExecutor.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])",
                 element,
                 "style",
                 "border: 7px solid yellow; border-style: dashed");

            if (duration <= 0) return;
            Thread.Sleep(TimeSpan.FromSeconds(duration));
            javaScriptExecutor.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])",
                element,
                "style",
                originalStyle);
        }
        [TestCleanup]
        public void CleanupAfterEveryTest()
        {
            Driver.Quit();
        }
    }
}
