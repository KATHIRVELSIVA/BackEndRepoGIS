using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace SeleniumTest
{
    public class MicroProject
    {
        private IWebDriver driver;
        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
        }

        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Login()
        {
            driver.Navigate().GoToUrl("http://localhost:3000/");
            driver.Manage().Window.Size = new System.Drawing.Size(1361, 737);
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.CssSelector(".mb-3:nth-child(2) > .form-control")).Click();
            driver.FindElement(By.CssSelector(".mb-3:nth-child(2) > .form-control")).SendKeys("kathir@gmail.com");
            driver.FindElement(By.CssSelector(".mb-3:nth-child(3) > .form-control")).SendKeys("Password@12345");
            driver.FindElement(By.CssSelector(".btn")).Click();
            Thread.Sleep(1000);
            Assert.That(driver.SwitchTo().Alert().Text, Is.EqualTo("User Logged in successfully.."));
        }
        [Test]
        public void SignUp()
        {
            Random rnd = new Random();
            string email = "Kathir" + rnd.Next(1,1000) + "@gmail.com";
            driver.Navigate().GoToUrl("http://localhost:3000/");
            driver.Manage().Window.Size = new System.Drawing.Size(1361, 737);
            driver.FindElement(By.LinkText("SignUp")).Click();
            driver.FindElement(By.CssSelector(".mb-3:nth-child(2) > .form-control")).Click();
            driver.FindElement(By.CssSelector(".mb-3:nth-child(2) > .form-control")).SendKeys("Kathirvel");
            driver.FindElement(By.CssSelector(".mb-3:nth-child(3) > .form-control")).SendKeys(email);
            driver.FindElement(By.CssSelector(".mb-3:nth-child(4) > .form-control")).SendKeys("1234567891");
            driver.FindElement(By.CssSelector(".mb-3:nth-child(5) > .form-control")).SendKeys("123454678890");
            driver.FindElement(By.Id("password")).SendKeys("Password@12345");
            driver.FindElement(By.CssSelector(".btn")).Click();
            Thread.Sleep(1000);
            Assert.That(driver.SwitchTo().Alert().Text, Is.EqualTo("User registered successfully.."));

        }

        [Test]
        public void VehicleRegister()
        {
            driver.Navigate().GoToUrl("http://localhost:3000/");
            driver.Manage().Window.Size = new System.Drawing.Size(1361, 737);
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.CssSelector(".mb-3:nth-child(2) > .form-control")).Click();
            driver.FindElement(By.CssSelector(".mb-3:nth-child(2) > .form-control")).SendKeys("kathir@gmail.com");
            driver.FindElement(By.CssSelector(".mb-3:nth-child(3) > .form-control")).SendKeys("Password@12345");
            driver.FindElement(By.CssSelector(".btn")).Click();
            Thread.Sleep(1000);
            driver.SwitchTo().Alert().Accept();
            //Assert.That(driver.SwitchTo().Alert().Text, Is.EqualTo("User Logged in successfully.."));
            Thread.Sleep(1000);
            driver.FindElement(By.LinkText("Add Vehicle+")).Click();
            driver.FindElement(By.CssSelector(".text-uppercase:nth-child(2)")).Click();
            driver.FindElement(By.CssSelector(".text-uppercase:nth-child(2)")).SendKeys("tn72ad4754");
            {
                var dropdown = driver.FindElement(By.CssSelector(".mb-3:nth-child(3) > .form-select"));
                dropdown.FindElement(By.XPath("//option[. = 'Tata Punch']")).Click();
            }
            driver.FindElement(By.CssSelector(".mb-3:nth-child(4) > .form-select")).Click();
            {
                var dropdown = driver.FindElement(By.CssSelector(".mb-3:nth-child(4) > .form-select"));
                dropdown.FindElement(By.XPath("//option[. = 'Petrol']")).Click();
            }
            driver.FindElement(By.CssSelector(".mb-3:nth-child(5) > .form-control")).Click();
            driver.FindElement(By.CssSelector(".mb-3:nth-child(5) > .form-control")).SendKeys("Tenkasi");
            {
                var dropdown = driver.FindElement(By.CssSelector(".form-select:nth-child(7)"));
                dropdown.FindElement(By.XPath("//option[. = '2000']")).Click();
            }
            driver.FindElement(By.CssSelector(".btn-primary")).Click();
            Thread.Sleep(1000);
            Assert.That(driver.SwitchTo().Alert().Text, Is.EqualTo("car registered successfully.."));
            Thread.Sleep(1000);
        }

        [Test]
        public void TestCaseforupdatingthedetails()
        {
            driver.Navigate().GoToUrl("http://localhost:3000/");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.CssSelector(".mb-3:nth-child(2) > .form-control")).Click();
            driver.FindElement(By.CssSelector(".mb-3:nth-child(2) > .form-control")).SendKeys("kathir@gmail.com");
            driver.FindElement(By.CssSelector(".mb-3:nth-child(3) > .form-control")).SendKeys("Password@12345");
            driver.FindElement(By.CssSelector(".btn")).Click();
            Thread.Sleep(1000);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(1000);
            driver.FindElement(By.LinkText("Edit")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(".mb-3:nth-child(6) > .form-control")).Clear();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(".mb-3:nth-child(6) > .form-control")).SendKeys("1983");
            driver.FindElement(By.CssSelector(".mb-3:nth-child(5) > .form-control")).Clear();
            driver.FindElement(By.CssSelector(".mb-3:nth-child(5) > .form-control")).SendKeys("Kassi");
            Thread.Sleep(1000);
            js.ExecuteScript("window.scrollTo(1000, 1000)");
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(".btn-primary")).Click();
            Thread.Sleep(1000);
            Assert.That(driver.SwitchTo().Alert().Text, Is.EqualTo("car details updated successfully.."));
        }

    }
}