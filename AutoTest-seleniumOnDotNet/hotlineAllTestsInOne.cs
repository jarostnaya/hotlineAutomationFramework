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
          driver.Quit();
        }

        [Test]
        public void allTestsInOne()
        {
            //check URL
            Assert.IsTrue(driver.Title.Contains("Hotline"));
       
            //change lang
            driver.FindElement(By.XPath("//*[@data-language=\"uk\"]")).Click();
            driver.FindElement(By.XPath("//*[@data-language=\"ru\"]")).Click();

                //check lang
                driver.FindElement(By.XPath("//*[@data-language=\"ru\"]")).Click();





            //select electro-guitars 
            driver.FindElement(By.XPath("//a[text()=\"Музыкальные инструменты\"]")).Click();
            driver.FindElement(By.XPath("//a[@data-eventlabel=\"Электрогитары\"]")).Click();

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


        // TEST if this works:
        // 1. new Actions(driver).pause(1000).perform();
        //
        // From: https://testerslittlehelper.wordpress.com/2016/07/10/real-xpath/
        // 2. XPATH: //div[@class=’buttons’ and contains(text(),’Save’)] 
        // 3. XPATH: //div[contains(@class,’intercomBtn’)]
        // 4. XPATH: //div[@class=’buttons’ and starts-with(text(),’Save’)]








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