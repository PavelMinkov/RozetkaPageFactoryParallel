using OpenQA.Selenium;
using RozetkaPageFactoryParallel.PageObjects;

namespace RozetkaPageFactoryParallel.BusinessObject
{
    class CheckSumm
    {
        public int CheckSummProducts(IWebDriver driver)
        {
            CartPage cartPage = new CartPage(driver);

            cartPage.ClickCart();
            return int.Parse(cartPage.GetCartSumm().Text);
        }

    }
}
