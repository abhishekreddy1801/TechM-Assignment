using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechMAssignment.PageObjects
{
    public class OpenCartMapElements
    {
        IWebDriver driver;

        public OpenCartMapElements(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement OpenCartLogo => driver.FindElement(By.XPath("//*[@title='Your Store']"));

        public IWebElement SearchTextBox => driver.FindElement(By.XPath("//*[@name='search']"));

        public IWebElement SearchButton => driver.FindElement(By.XPath("//*[@name='search']//following-sibling::button"));

        public IWebElement FirstSearchResultItem => driver.FindElement(By.XPath("//*[@class='image']//a"));

        public IWebElement AddToCartButton => driver.FindElement(By.XPath("//*[@id='button-cart']"));

        public IWebElement ItemAddedToCartAlert => driver.FindElement(By.XPath("//div[@class='alert alert-success alert-dismissable']"));

        public IWebElement ShoppingCartButton => driver.FindElement(By.XPath("//*[text()='Shopping Cart']"));

        public IWebElement CheckoutButton => driver.FindElement(By.XPath("//*[text()='Checkout']"));

        public IWebElement OutOfStockAlert => driver.FindElement(By.XPath("//div[text() = ' Products marked with *** are not available in the desired quantity or not in stock! ']"));

        public IWebElement IPhoneCartItem => driver.FindElement(By.LinkText("//*[@class='text-danger']//preceding-sibling::a[text()='iPhone']"));

        public IWebElement IphoneCartWarningText => driver.FindElement(By.LinkText("//*[@class='text-danger'][1]"));

        public IWebElement IMacCartItem => driver.FindElement(By.XPath("//*[@class='text-danger']//preceding-sibling::a[text()='iMac']"));

        public IWebElement IMacCartWarningText => driver.FindElement(By.LinkText("//*[@class='text-danger'][2]"));

    }
}
