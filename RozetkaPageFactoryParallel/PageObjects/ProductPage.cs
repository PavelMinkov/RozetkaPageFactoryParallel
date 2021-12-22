using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using RozetkaPageFactoryParallel.PageObjects;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using System.Threading;

namespace RozetkaPageFactory.PageObjects
{
    class ProductPage : BasePage
    {
        public ProductPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@data-filter-name='producer']//input[@name='searchline']")]
        IWebElement inputBrand;

        [FindsBy(How = How.XPath, Using = "//div[@data-filter-name='producer']//input[@class='custom-checkbox']/parent::*")]
        IWebElement brand;

        [FindsBy(How = How.CssSelector, Using = "select[class*='select']")]
        IWebElement elementSort;
        SelectElement DropdownElement
        {
            get { return new SelectElement(elementSort); }
        }

        [FindsBy(How = How.CssSelector, Using = "span.goods-tile__title")]
        IList<IWebElement> listProducts;

        [FindsBy(How = How.CssSelector, Using = "p[class*='product-prices']")]
        IWebElement moveToButtonBuy;

        [FindsBy(How = How.XPath, Using = "//ul[@class='product-buttons']//span[contains(@class,'buy-button')]")]
        IWebElement elementButtonBuy;

        [FindsBy(How = How.CssSelector, Using = "div.modal__header button[class*='close']")]
        IWebElement elementCartClose;

        [FindsBy(How = How.CssSelector, Using = "a.header__logo")]
        IWebElement elementLogo;

        public void ChooseProduct(string searchBrand, int sort)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(inputBrand));
            inputBrand.SendKeys(searchBrand);
            Thread.Sleep(2000);
            wait.Until(ExpectedConditions.ElementToBeClickable(brand));
            brand.Click();
            DropdownElement.SelectByIndex(sort);
            driver.Navigate().Refresh();
        }
        public void BuyProduct(int number)
        {
            Actions actionProvider = new Actions(driver);
            wait.Until(ExpectedConditions.ElementToBeClickable(listProducts[number]));
            listProducts[number].Click();
            actionProvider.MoveToElement(wait.Until(ExpectedConditions.ElementToBeClickable(moveToButtonBuy))).Build().Perform();
            elementButtonBuy.Click();
            elementCartClose.Click();
            actionProvider.MoveToElement(wait.Until(ExpectedConditions.ElementToBeClickable(elementLogo)));
            elementLogo.Click();
        }

    }
}
