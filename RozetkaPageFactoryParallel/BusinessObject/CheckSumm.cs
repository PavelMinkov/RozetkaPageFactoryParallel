using OpenQA.Selenium;
using RozetkaPageFactoryParallel.PageObjects;
using SeleniumExtras.PageObjects;

namespace RozetkaPageFactoryParallel.BusinessObject
{
    class CheckSumm : BasePage
    {
        public CheckSumm(IWebDriver driver) : base(driver)
        {
        }

        public int CheckSummProducts()
        {
            CartPage cartPage = new CartPage(driver);

            cartPage.ClickCart();
            return int.Parse(cartPage.GetCartSumm().Text);
        }

    }
}
