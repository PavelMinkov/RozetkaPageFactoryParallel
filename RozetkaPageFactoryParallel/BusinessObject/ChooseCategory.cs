using OpenQA.Selenium;
using RozetkaPageFactory.PageObjects;

namespace RozetkaPageFactoryParallel.BusinessObject
{
    class ChooseCategory
    {

        public void ChooseCategoryProduct(IWebDriver driver, int category, string search)
        {
            HomePage homePage = new HomePage(driver);

            homePage.ClickListMenu(category);
            homePage.waitElementToBeClickable(90, homePage.GetCategoryProducts());
            homePage.TextProduct(search);
        }

    }
}
