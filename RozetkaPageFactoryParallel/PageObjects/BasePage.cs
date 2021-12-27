using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace RozetkaPageFactoryParallel.PageObjects
{
    class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void waitForPageLoadComplete(long timeToWait)
        {
            new WebDriverWait(driver, System.TimeSpan.FromSeconds(timeToWait))
                .Until(webDriver => ((IJavaScriptExecutor)webDriver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void waitElementToBeClickable(long timeToWait, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(timeToWait));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }
        public void actionMoveToElement(IWebElement element)
        {
            Actions actionProvider = new Actions(driver);
            actionProvider.MoveToElement(element).Build().Perform();
        }

    }
}
