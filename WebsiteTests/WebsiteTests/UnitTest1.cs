using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace WebsiteTests
{
    public class Tests
    {
        private IWebDriver driver;
        String test_url = "https://www.demoblaze.com/index.html";
        private readonly Random _random = new();

        [SetUp]
        public void Start_browser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(test_url);
        }

        [Test]
        public void Test_AddProductToCart()
        {
            // lets first log in
            IWebElement loginButton = driver.FindElement(By.Id("login2"));
            loginButton.Click();
            Thread.Sleep(3000);

            IWebElement usernameField = driver.FindElement(By.Id("loginusername"));
            usernameField.SendKeys("test");

            IWebElement passwordField = driver.FindElement(By.Id("loginpassword"));
            passwordField.SendKeys("test");

            IWebElement LoginButton = driver.FindElement(By.XPath("//button[text()='Log in']"));
            LoginButton.Click();
            Thread.Sleep(3000);
            
            // accepts cookie policy, when it popsup
            try
            {
                IWebElement sButton2 = driver.FindElement(By.XPath("//button[@class='agree-button eu-cookie-compliance-secondary-button']"));
                sButton2.Click();
            }
            catch (NoSuchElementException)
            {
                // does nothing if cookies policy not found
            }

            // select product category, ill choose 'monitors' for this example
            IWebElement laptopsCategory = driver.FindElement(By.LinkText("Monitors"));
            laptopsCategory.Click();
            Thread.Sleep(4000);

            // select product
            IWebElement productLink = driver.FindElement(By.LinkText("Apple monitor 24"));
            productLink.Click();
            Thread.Sleep(4000);

            // clicks "add to cart" button
            IWebElement addToCartButton = driver.FindElement(By.XPath("//a[text()='Add to cart']"));
            addToCartButton.Click();
            Thread.Sleep(4000);

            // clicks OK on the confirmation alert
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
            }
            catch (NoAlertPresentException)
            { 
            
            }

            // navigates to Cart page and places the order, filling required forms 
            IWebElement cartLink = driver.FindElement(By.LinkText("Cart"));
            cartLink.Click();
            Thread.Sleep(3000);

            IWebElement placeorder = driver.FindElement(By.XPath("//button[text()='Place Order']"));
            placeorder.Click();
            Thread.Sleep(3000);

            //filling order with random values
            driver.FindElement(By.Id("name")).SendKeys("Anatoli Vanyamin");
            driver.FindElement(By.Id("country")).SendKeys("Ukraine");
            driver.FindElement(By.Id("city")).SendKeys("Austin");
            driver.FindElement(By.Id("card")).SendKeys("1234 5678 9876 5432");
            driver.FindElement(By.Id("month")).SendKeys("12");
            driver.FindElement(By.Id("year")).SendKeys("2025");

            IWebElement purchase = driver.FindElement(By.XPath("//button[text()='Purchase']"));
            purchase.Click();
            Thread.Sleep(3000);

            Assert.Pass("Product successfully bought");
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}
