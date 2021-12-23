using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RozetkaPageFactoryParallel.PageObjects;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

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
        SelectElement DropdownElement { get { return new SelectElement(elementSort); } }

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

        public IWebElement GetInputBrand() { return inputBrand; }
        public void TextBrand(string searchBrand) { inputBrand.SendKeys(searchBrand + "\n"); }
        public IWebElement GetBrand() { return brand; }
        public void ClickBrand() { brand.Click(); }
        public void SortProducts(int sort) { DropdownElement.SelectByIndex(sort); }
        public IWebElement GetListProducts(int number) { return listProducts[number]; }
        public void ClickListProducts(int number) { listProducts[number].Click(); }
        public IWebElement GetButtonBuy() { return moveToButtonBuy; }
        public void ClickButtonBuy() { elementButtonBuy.Click(); }
        public IWebElement GetCartClose() { return elementCartClose; }
        public void ClickCartClose() { elementCartClose.Click(); }
        public IWebElement GetLogo() { return elementLogo; }
        public void ClickLogo() { elementLogo.Click(); }
    }
}
