using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RozetkaPageFactory.TestDataAccess;
using RozetkaPageFactoryParallel.BusinessObject;
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
            ProperyReader propReader = new();
            Driver.Navigate().GoToUrl(propReader.GetURL());
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [Test]
        [TestCaseSource(typeof(DataProvider), nameof(DataProvider.TestData))]
        public void ExecuteTest(Filter filter)
        {
            ChooseCategory chooseCategory = new(Driver);
            chooseCategory.ChooseCategoryProduct(filter.categoryProducts, filter.nameProducts);

            OrderProduct orderProduct = new(Driver);
            orderProduct.ChooseProduct(filter.brand, filter.sort);
            orderProduct.BuyProduct(filter.numberProduct);

            CheckSumm checkSumm = new(Driver);
            Assert.That(checkSumm.CheckSummProducts(), Is.LessThan(filter.price));
        }

        [TearDown]
        public void CleanUp()
        {
            Driver.Quit();
        }
    }
}