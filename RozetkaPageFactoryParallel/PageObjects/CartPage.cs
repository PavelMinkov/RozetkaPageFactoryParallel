using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace RozetkaPageFactoryParallel.PageObjects
{
    class CartPage : BasePage
    {
        public CartPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//li[contains(@class,'cart')]")]
        IWebElement cart;

        [FindsBy(How = How.XPath, Using = "//div[@class='cart-receipt__sum-price']/span[1]")]
        IWebElement cartSumm;

        public IWebElement GetCart() { return cart; }
        public void ClickCart() { cart.Click(); }
        public IWebElement GetCartSumm() { return cartSumm; }
    }
}
