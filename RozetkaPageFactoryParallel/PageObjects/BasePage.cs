using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace RozetkaPageFactoryParallel.PageObjects
{
    class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

    }
}
