using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;


namespace Test
{
    [TestFixture]
    public class AutomationCore
    {
        IWebDriver driver;

        // Our Core Test Automation class
        [OneTimeSetUp]
        public void startTest() // This method will be fired at the start of the test
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://hotline.ua/";
        }

        [OneTimeTearDown]
        public void endTest() // This method will be fired at the end of the test
        {
          // driver.Quit();
        }

        [Test]
        public void allTestsInOne()
        {
            //check URL
            Assert.IsTrue(driver.Title.Contains("Hotline"));
       
            //change lang
            driver.FindElement(By.XPath("//*[@data-language=\"uk\"]")).Click();
            driver.FindElement(By.XPath("//*[@data-language=\"ru\"]")).Click();
        
            //select electro-guitars 
            //TODO: fix XPATH to one string or make it shorter
            driver.FindElement(By.XPath("//*[@id=\"page-index\"]/div[1]/div[1]/div[2]/aside/nav/ul/li[11]/a")).Click();
            driver.FindElement(By.XPath("//div[1]/div[1]/div[3]/div[2]/ul/li[5]/div/a")).Click();
            //driver.FindElement(By.XPath("//img[@alt='Электрогитары']/..")).Click();
        
            //filter 6-strings guitars
            driver.FindElement(By.XPath("//a[@href=\"/musical_instruments/elektrogitary/30957/\"]")).Click();

            //filter by max price=5000
            IWebElement maxPrice = driver.FindElement(By.XPath("//input[@data-price-max=\"\"]"));
            maxPrice.Click();
            maxPrice.SendKeys(Keys.Control + "a");
            maxPrice.SendKeys(Keys.Delete);
            maxPrice.SendKeys("5000");

            driver.FindElement(By.XPath("//input[@value='OK']")).Click();

        }


    //public void urlTest()
    //public void switchLangTest()
    //public void selectCategoryGuitarsTest()
    //public void filterGuitarsByStringsTest()
        //[Test]
        //public void filterGuitarsByMaxPriceTest()
        //{
        //    //
        //}

    //[Test]
    //public void selectCategorySmartfhones()
    //{
    //    //
    //}

    //[Test]
    //public void sortProductsByPrice()
    //{
    //    //
    //}


    //[Test]
    //public void switchLangTest()
    //{
    //    driver.newLanguage("").click();
    //    string newLanguage = driver.FindElement(By.XPath(//*[@data-language="uk"]));
    //    Assert.IsTrue(driver.newLanguage.Contains("uk"));
    //}
}
}