using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace RozetkaPageFactoryParallel.Decor
{
    public static class ElementExtensions
    {
        public static void ClicList(this IWebElement element, int category, string elementName)
        {
            element.Click();
            Console.WriteLine("Clicked on {0} {1}.", category, elementName);
        }

        public static void ClickOnIt(this IWebElement element, string elementName)
        {
            element.Click();
            Console.WriteLine("Clicked on {0}.", elementName);
        }

        public static void EnterText(this IWebElement element, string text, string elementName)
        {

            element.Clear();
            element.SendKeys(text + "\n");
            Console.WriteLine("{0} entered in the {1} field.", text, elementName);
        }
        public static void SortProducts(this SelectElement element, int sort, string elementName)
        {
            element.SelectByIndex(sort);
            Console.WriteLine("Sort Products by {0}.", elementName);
        }
    }
}
