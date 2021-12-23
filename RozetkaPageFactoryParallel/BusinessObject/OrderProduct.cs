using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using RozetkaPageFactory.PageObjects;
using RozetkaPageFactoryParallel.PageObjects;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System.Threading;

namespace RozetkaPageFactoryParallel.BusinessObject
{
    class OrderProduct : BasePage
    {
        public OrderProduct(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void ChooseProduct(string searchBrand, int sort)
        {
            ProductPage productPage = new ProductPage(driver);

            wait.Until(ExpectedConditions.ElementToBeClickable(productPage.GetInputBrand()));
            productPage.TextBrand(searchBrand);
            Thread.Sleep(2000);
            wait.Until(ExpectedConditions.ElementToBeClickable(productPage.GetBrand()));
            productPage.ClickBrand();
            productPage.SortProducts(sort);
            driver.Navigate().Refresh();
        }

        public void BuyProduct(int number)
        {
            ProductPage productPage = new ProductPage(driver);

            Actions actionProvider = new Actions(driver);
            Thread.Sleep(2000);
            wait.Until(ExpectedConditions.ElementToBeClickable(productPage.GetListProducts(number)));
            productPage.ClickListProducts(number);
            actionProvider.MoveToElement(wait.Until(ExpectedConditions.ElementToBeClickable(productPage.GetButtonBuy()))).Build().Perform();
            productPage.ClickButtonBuy();
            actionProvider.MoveToElement(wait.Until(ExpectedConditions.ElementToBeClickable(productPage.GetCartClose())));
            productPage.ClickCartClose();
            actionProvider.MoveToElement(wait.Until(ExpectedConditions.ElementToBeClickable(productPage.GetLogo())));
            productPage.ClickLogo();
        }

    }
}
