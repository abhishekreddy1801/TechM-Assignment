using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechMAssignment.PageObjects;

namespace TechMAssignment
{
    public class Tests
    {
        IWebDriver driver;
        OpenCartMapElements OpenCartMapElements;

        [OneTimeSetUp]
        public void Setup()
        {

            var options = new ChromeOptions();
            options.AddArgument("--disable-blink-features=AutomationControlled");
            options.AddArgument("--headless");
            options.AddExcludedArgument("enable-automation");
            //Launching the Chrome instance.
            driver = new ChromeDriver(options);

            //creating the map class element
            OpenCartMapElements = new OpenCartMapElements(driver);

            var js = (IJavaScriptExecutor) driver;


            //setting the implicit wait as 10 secs
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //setting the implicit page load time as 30 secs
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
        }

        [Test, Order(1)]
        public void Test1()
        {
            //Arranging 
            string url = "https://demo.opencart.com";

            //Act: navigating to 'https://demo.opencart.com'
            driver.Navigate().GoToUrl(url);

            //Assert: 
            Assert.IsTrue(OpenCartMapElements.OpenCartLogo.Displayed);
        }

        [Test, Order(2)]
        public void Test2()
        {
            //Arraging
            string searchItem = "iMac";

            //Act
            OpenCartMapElements.SearchTextBox.SendKeys(searchItem);
            OpenCartMapElements.SearchButton.Click();

            //Assert
            Assert.IsTrue(OpenCartMapElements.FirstSearchResultItem.Displayed);
        }

        [Test, Order(3)]
        public void Test3()
        {
            //Act
            OpenCartMapElements.FirstSearchResultItem.Click();
            OpenCartMapElements.AddToCartButton.Click();

            //Assert
            Assert.IsTrue(OpenCartMapElements.ItemAddedToCartAlert.Displayed);
        }

        [Test, Order(4)]
        public void Test4()
        {
            //Arraging
            string searchItem = "iPhone";

            //Act
            OpenCartMapElements.SearchTextBox.Clear();
            OpenCartMapElements.SearchTextBox.SendKeys(searchItem);
            OpenCartMapElements.SearchButton.Click();

            //Assert
            Assert.IsTrue(OpenCartMapElements.FirstSearchResultItem.Displayed);
        }

        [Test, Order(5)]
        public void Test5()
        {
            //Act
            OpenCartMapElements.FirstSearchResultItem.Click();
            OpenCartMapElements.AddToCartButton.Click();

            //Assert
            Assert.IsTrue(OpenCartMapElements.ItemAddedToCartAlert.Displayed);
        }

        [Test, Order(6)]
        public void Test6()
        {
            //Act
            OpenCartMapElements.ShoppingCartButton.Click();

            //Assert
            Assert.That(driver.Url, Is.EqualTo($"https://demo.opencart.com/en-gb?route=checkout/cart"));
        }

        [Test, Order(7)]
        public void Test7()
        {
            //Arrange
            Assert.IsTrue(OpenCartMapElements.IPhoneCartItem.Displayed);
            Assert.IsTrue(OpenCartMapElements.IMacCartItem.Displayed);
        }

        [Test, Order(8)]
        public void Test8()
        {
            //Act
            OpenCartMapElements.CheckoutButton.Click();

            //Assert
            Assert.That(driver.Url, Is.EqualTo($"https://demo.opencart.com/en-gb?route=checkout/cart"));
        }

        [Test, Order(9)]
        public void Test9()
        {
            //Assert
            Assert.IsTrue(OpenCartMapElements.OutOfStockAlert.Displayed);
        }

        [Test, Order(10)]
        public void Test10()
        {
            //Assert
            Assert.That(OpenCartMapElements.OutOfStockAlert.Text, Is.EqualTo(" Products marked with *** are not available in the desired quantity or not in stock! "));
        }

        [Test, Order(11)]
        public void Test11()
        {
            //Assert
            Assert.IsTrue(OpenCartMapElements.IphoneCartWarningText.Displayed);
            Assert.IsTrue(OpenCartMapElements.IMacCartWarningText.Displayed);
        }

        [OneTimeTearDown]
        public void TearDown() 
        { 
            driver.Dispose();
        }
    }
}