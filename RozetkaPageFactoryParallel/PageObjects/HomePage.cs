using OpenQA.Selenium;
using RozetkaPageFactoryParallel.PageObjects;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace RozetkaPageFactory.PageObjects
{
    class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//ul[contains(@class,'menu-categories_type_main')]/li[contains(@class,'menu-categories')]")]
        IList<IWebElement> listMenu;

        [FindsBy(How = How.CssSelector, Using = "input.search-form__input")]
        IWebElement choiseTitle;

        public IList<IWebElement> GetCategory() { return listMenu; }
        public void ClickListMenu(int category) { listMenu[category].Click(); }
        public IWebElement GetCategoryProducts() { return choiseTitle; }
        public void TextProduct(string search) { choiseTitle.SendKeys(search + "\n"); }
    }
}
