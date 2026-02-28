using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechMAssignment.PageObjects;

namespace TechMAssignment
{
    public class OpenCartTests
    {
        private IWebDriver driver;
        private OpenCartMapElements OpenCartMapElements;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddExcludedArgument("enable-automation");
            options.AddArgument("--start-maximized");

            driver = new ChromeDriver(options);

            OpenCartMapElements = new OpenCartMapElements(driver);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
        }

        [Test]
        public void EndToEnd_OpenCart_Workflow_Test()
        {
            // =============================
            // Step 1: Launch Application
            // =============================
            string url = "https://demo.opencart.com";
            driver.Navigate().GoToUrl(url);

            OpenCartMapElements.OpenCartLogo.Displayed
                .Should().BeTrue("OpenCart logo should be visible on homepage");

            // =============================
            // Step 2: Search iMac
            // =============================
            OpenCartMapElements.SearchTextBox.SendKeys("iMac");
            OpenCartMapElements.SearchButton.Click();

            OpenCartMapElements.FirstSearchResultItem.Displayed
                .Should().BeTrue("Search results for iMac should be displayed");

            // =============================
            // Step 3: Add iMac to Cart
            // =============================
            OpenCartMapElements.FirstSearchResultItem.Click();
            OpenCartMapElements.AddToCartButton.Click();

            OpenCartMapElements.ItemAddedToCartAlert.Displayed
                .Should().BeTrue("Success alert should appear after adding iMac");

            // =============================
            // Step 4: Search iPhone
            // =============================
            OpenCartMapElements.SearchTextBox.Clear();
            OpenCartMapElements.SearchTextBox.SendKeys("iPhone");
            OpenCartMapElements.SearchButton.Click();

            OpenCartMapElements.FirstSearchResultItem.Displayed
                .Should().BeTrue("Search results for iPhone should be displayed");

            // =============================
            // Step 5: Add iPhone to Cart
            // =============================
            OpenCartMapElements.FirstSearchResultItem.Click();
            OpenCartMapElements.AddToCartButton.Click();

            OpenCartMapElements.ItemAddedToCartAlert.Displayed
                .Should().BeTrue("Success alert should appear after adding iPhone");

            // =============================
            // Step 6: Navigate to Cart
            // =============================
            OpenCartMapElements.ShoppingCartButton.Click();

            driver.Url.Should().Be(
                "https://demo.opencart.com/en-gb?route=checkout/cart",
                "User should be navigated to cart page");

            // =============================
            // Step 7: Verify Cart Items
            // =============================
            OpenCartMapElements.IPhoneCartItem.Displayed
                .Should().BeTrue("iPhone should be present in cart");

            OpenCartMapElements.IMacCartItem.Displayed
                .Should().BeTrue("iMac should be present in cart");

            // =============================
            // Step 8: Click Checkout
            // =============================
            OpenCartMapElements.CheckoutButton.Click();

            driver.Url.Should().Be(
                "https://demo.opencart.com/en-gb?route=checkout/cart",
                "Checkout should not proceed due to out-of-stock items");

            // =============================
            // Step 9: Verify Out Of Stock Alert
            // =============================
            OpenCartMapElements.OutOfStockAlert.Displayed
                .Should().BeTrue("Out-of-stock warning should be displayed");

            // =============================
            // Step 10: Validate Alert Message
            // =============================
            OpenCartMapElements.OutOfStockAlert.Text
                .Should().Contain("not available",
                "Proper out-of-stock message should be shown");

            // =============================
            // Step 11: Verify Warning Messages
            // =============================
            OpenCartMapElements.IphoneCartWarningText.Displayed
                .Should().BeTrue("iPhone warning text should be displayed");

            OpenCartMapElements.IMacCartWarningText.Displayed
                .Should().BeTrue("iMac warning text should be displayed");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
