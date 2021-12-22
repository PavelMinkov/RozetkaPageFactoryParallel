using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RozetkaPageFactory.PageObjects;
using RozetkaPageFactory.TestDataAccess;
using RozetkaPageFactoryParallel.PageObjects;
using RozetkaPageFactoryParallel.TestDataAccess;
using System;
using System.Collections.Concurrent;
using System.Linq;
[assembly: LevelOfParallelism(3)]


namespace RozetkaPageFactoryParallel
{
    [Parallelizable(scope: ParallelScope.All)]
    public class Tests
    {
        private static ConcurrentDictionary<string, IWebDriver> DriverCollection = new ConcurrentDictionary<string, IWebDriver>();

        public static IWebDriver Driver
        {
            get
            {
                return DriverCollection.First(pair => pair.Key == TestContext.CurrentContext.Test.ID).Value;
            }

            set => DriverCollection.TryAdd(TestContext.CurrentContext.Test.ID, value);
        }

        [SetUp]
        public void Initialize()
        {
            Driver = new ChromeDriver();
            ProperyReader propReader = new ProperyReader();
            Driver.Navigate().GoToUrl(propReader.GetURL());
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [Test]
        [TestCaseSource(typeof(DataProvider), nameof(DataProvider.TestData))]
        public void ExecuteTest(Filter filter)
        {
            HomePage homePage = new HomePage(Driver);
            ProductPage productPage = homePage.ChooseCategoryProduct(filter.categoryProducts, filter.nameProducts);
            productPage.ChooseProduct(filter.brand, filter.sort);
            productPage.BuyProduct(filter.numberProduct);

            CartPage cartPage = new CartPage(Driver);
            int summ = cartPage.CheckSummProducts();
            Console.WriteLine(summ);
            Assert.That(summ, Is.LessThan(filter.price));
        }

        [TearDown]
        public void CleanUp()
        {
            Driver.Quit();
        }
    }
}