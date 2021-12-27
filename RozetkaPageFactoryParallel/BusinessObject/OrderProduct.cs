using OpenQA.Selenium;
using RozetkaPageFactory.PageObjects;
using System.Threading;

namespace RozetkaPageFactoryParallel.BusinessObject
{
    class OrderProduct
    {
        public void ChooseProduct(IWebDriver driver, string searchBrand, int sort)
        {
            ProductPage productPage = new ProductPage(driver);

            productPage.waitElementToBeClickable(90, productPage.GetInputBrand());
            productPage.TextBrand(searchBrand);
            Thread.Sleep(2000);
            productPage.waitElementToBeClickable(90, productPage.GetBrand());
            productPage.ClickBrand();
            productPage.SortProducts(sort);
            driver.Navigate().Refresh();
        }

        public void BuyProduct(IWebDriver driver, int number)
        {
            ProductPage productPage = new ProductPage(driver);

            productPage.waitForPageLoadComplete(90);
            productPage.waitElementToBeClickable(90, productPage.GetListProducts(number));
            productPage.ClickListProducts(number);
            productPage.actionMoveToElement(productPage.GetButtonBuy());
            productPage.ClickButtonBuy();
            productPage.actionMoveToElement(productPage.GetCartClose());
            productPage.ClickCartClose();
            productPage.actionMoveToElement(productPage.GetLogo());
            productPage.ClickLogo();
        }

    }
}
