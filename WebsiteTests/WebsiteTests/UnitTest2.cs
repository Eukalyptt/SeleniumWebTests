using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace WebsiteTests
{
    internal class UnitTest2
    {
        private IWebDriver driver;
        String test_url = "https://demoqa.com";
        private readonly Random _ranodm = new Random();

        [SetUp]
        public void Start_browser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(test_url);
        }

        [Test]
        public void FillForm()
        {
            // opens Forms -> Practice Form
            IWebElement formLink = driver.FindElement(By.XPath("//h5[text()='Forms']"));
            formLink.Click();
            Thread.Sleep(3000);

            IWebElement practiceformLink = driver.FindElement(By.XPath("//span[text()='Practice Form']"));
            practiceformLink.Click();
            Thread.Sleep(3000);

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", practiceformLink);
            Thread.Sleep(1500);

            js.ExecuteScript("window.scrollBy(0,100);");
            Thread.Sleep(1500);

            // fill forms top -> bottom
            driver.FindElement(By.Id("firstName")).SendKeys("Simon");
            driver.FindElement(By.Id("lastName")).SendKeys("Riley");
            driver.FindElement(By.Id("userEmail")).SendKeys("Simon.Riley@example.com");

            driver.FindElement(By.XPath("//label[text()='Male']")).Click();

            driver.FindElement(By.Id("userNumber")).SendKeys("9875558922");

            driver.FindElement(By.Id("dateOfBirthInput")).Click();
            Thread.Sleep(2000);

            var month = driver.FindElement(By.ClassName("react-datepicker__month-select"));
            month.Click();
            month.SendKeys("May");
            month.SendKeys(Keys.Enter);
            Thread.Sleep(4000);

            var year = driver.FindElement(By.ClassName("react-datepicker__year-select"));
            year.Click();
            year.SendKeys("1984");
            year.SendKeys(Keys.Enter);
            Thread.Sleep(4000);

            driver.FindElement(By.XPath("//div[contains(@class,'react-datepicker__day') and text()='17']")).Click();

            IWebElement subject = driver.FindElement(By.Id("subjectsInput"));
            subject.SendKeys("Physics");
            Thread.Sleep(1500);

            IWebElement physicsOption = driver.FindElement(By.XPath("//div[contains(@class, 'subjects-auto-complete__option') and text()='Physics']"));
            physicsOption.Click();
            Thread.Sleep(1000);

            IWebElement Label = driver.FindElement(By.XPath("//label[text()='Sports']"));
            Label.Click();
            Thread.Sleep(1500);

            driver.FindElement(By.Id("currentAddress")).SendKeys("2222 Mountain St, Manchester, United Kingdom");
            Thread.Sleep(8000);

            IWebElement state = driver.FindElement(By.Id("react-select-3-input"));
            state.SendKeys("NCR");
            state.SendKeys(Keys.Enter);
            Thread.Sleep(1000);

            IWebElement city = driver.FindElement(By.Id("react-select-4-input"));
            city.SendKeys("Delhi");
            city.SendKeys(Keys.Enter);
            Thread.Sleep(1000);


            driver.FindElement(By.Id("submit")).Click();
            Thread.Sleep(3000);

            Assert.Pass("Töötab siiani");
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