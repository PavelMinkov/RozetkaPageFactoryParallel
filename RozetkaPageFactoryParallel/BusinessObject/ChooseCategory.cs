﻿using OpenQA.Selenium;
using RozetkaPageFactory.PageObjects;
using RozetkaPageFactoryParallel.PageObjects;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozetkaPageFactoryParallel.BusinessObject
{
    class ChooseCategory : BasePage
    {
        public ChooseCategory(IWebDriver driver) : base(driver)
        {
        }

        public void ChooseCategoryProduct(int category, string search)
        {
            HomePage homePage = new HomePage(driver);

            homePage.ClickListMenu(category);
            homePage.waitElementToBeClickable(90, homePage.GetCategoryProducts());
            homePage.TextProduct(search);
        }

    }
}
