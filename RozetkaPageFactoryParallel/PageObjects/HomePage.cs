using OpenQA.Selenium;
using RozetkaPageFactoryParallel.PageObjects;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
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

        public ProductPage ChooseCategoryProduct(int category, string search)
        {
            listMenu[category].Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(choiseTitle));
            choiseTitle.SendKeys(search + "\n");
            return new ProductPage(driver);
        }

    }
}
