using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;


namespace Test
{
    [TestFixture]
    public class AutomationCore
    {
        public string googleURL;
        public string hotlineURL;
        public string websiteName;

        IWebDriver driver;

        [OneTimeSetUp]
        public void startTest() // This method will be fired at the start of the test
        {
            
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            
        }

        [OneTimeTearDown]
        public void endTest() // This method will be fired at the end of the test
        {
            driver.Quit();
        }

        [Test]
        //TODO: split test by atoms, data, locators and methods

        public void allTestsInOne()
        {
            hotlineURL = "https://hotline.ua/";
            googleURL = "https://google.com";

            websiteName = "hotline";

            
            // [Test] 
            //
            // As a user I want to open google, find hotline.ua then to navigate to the hotline home page
            

            // Navigate to google page
            driver.Navigate().GoToUrl(googleURL);

            // Locate google search input
            IWebElement googleSearchInput = driver.FindElement(By.Name("q"));

            // Run search request
            googleSearchInput.SendKeys(websiteName);
            googleSearchInput.SendKeys(Keys.Enter);

            // Navigate to hotline.ua from google search results page
            driver.FindElement(By.XPath("//a[text()[contains(.,\"Hotline - сравнить цены в интернет-магазинах Украины\")]]")).Click();

            // Check URL is correct
            Assert.AreEqual(driver.Url, hotlineURL);
            



            // [Test] 
            //
            // As a user I want to switch from Russian to Ukrainian then observe the home page in Ukrainian
            // TODO: Develop assert

            //change lang to UA
            IWebElement langUA = driver.FindElement(By.XPath("//*[@data-language=\"uk\"]"));
            langUA.Click();
            
            //var languageClass = langUA.GetAttribute("className");
            //var activeLanguage = driver.FindElement(By.XPath("//span[className()[contains(.,\"active\")]]"));
            //Assert.AreSame(languageClass,activeLanguage);
           


            // [Test] 
            //
            // As a user I want to navigate to electric guitars section then observe products

            // Switch back to Russian
            IWebElement langRU = driver.FindElement(By.XPath("//*[@data-language=\"ru\"]"));
            langRU.Click();
          
            // Navigate to electric guitars sub-catalog
            driver.FindElement(By.XPath("//a[text()=\"Музыкальные инструменты\"]")).Click();
            driver.FindElement(By.XPath("//a[@data-eventlabel=\"Электрогитары\"]")).Click();

            // Check if sub-catalog is correct
            Assert.IsTrue(driver.Title.Contains("Электрогитары"));



            // [Test] 
            //
            // As a user I want to aply filter to observe 6-strings electric guitars with the price below 5000 UAH
            // TODO: Develop assert

            // Filter 6-strings guitars
            driver.FindElement(By.XPath("//a[@href=\"/musical_instruments/elektrogitary/30957/\"]")).Click();
           

            // Filter by max price=5000
            IWebElement maxPrice = driver.FindElement(By.XPath("//input[@data-price-max=\"\"]"));
            maxPrice.Click();
            maxPrice.SendKeys(Keys.Control + "a");
            maxPrice.SendKeys(Keys.Delete);
            maxPrice.SendKeys("5000");

            driver.FindElement(By.XPath("//input[@value='OK']")).Click();

        }

       
        // TODO: Add test cases about mobile phones from __OUTPUTKatalon/hotline_TestSuite_v5.html









        // TEST if this works:
        // 1. new Actions(driver).pause(1000).perform();
        //
        // XPATH From: https://testerslittlehelper.wordpress.com/2016/07/10/real-xpath/
        // 2. XPATH: //div[@class=’buttons’ and contains(text(),’Save’)] 
        // 3. XPATH: //div[contains(@class,’intercomBtn’)]
        // 4. XPATH: //div[@class=’buttons’ and starts-with(text(),’Save’)]
    }
}