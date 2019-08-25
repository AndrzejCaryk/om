using System;
using System.IO;
using System.Threading;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace ExerciseOmada
{
    [TestFixture,
    Author("Andrzej Caryk")]
    public class UnitTest1
    {
        IWebDriver driver;
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        ExerciseLogger logger;

        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            log4net.Config.XmlConfigurator.Configure();
            logger = new ExerciseLogger();
            try
            {
                Directory.CreateDirectory(@"C:/AndrzejCarykZadanieRekrutacyjne"); //please ensure this directory was created (may requires admin mode)
            }
            catch (Exception) {}
        }

        [SetUp]
        public void Setup()
        {
            string typeName = "OpenQA.Selenium.Chrome.ChromeDriver, WebDriver, Version = 3.141.0.0, Culture = neutral, PublicKeyToken = null";
            //string typeName = "OpenQA.Selenium.Firefox.FirefoxDriver, WebDriver, Version=3.141.0.0, Culture=neutral, PublicKeyToken=null";
            Type T = Type.GetType(typeName);
            
            driver = (IWebDriver)Activator.CreateInstance(T); //to provide more generic solution I used Activator class. To switch driver comment/uncomment typeName string
            driver.Navigate().GoToUrl("http://www.omada.net/");
            driver.Manage().Window.Maximize();
        }

        [Test, Order(1), TestCase(Description = "1.	Open /“omada.net/” Make sure the page is loaded properly (1 - 2 checks of your choice)")]
        public void VaryfiLoadedPage()
        {
            PageLoad pageLoad = new PageLoad(driver);
            bool result = pageLoad.TestCaseExec();
            Assert.IsTrue(result);
        }

        [Test, Order(2), TestCase(Description = "2.	Execute search for “gartner” (using search box in the top right corner of the front page) " +
            "Verify that the search gives more than 1 result and that there is “There is Safety in Numbers” among those")]
        public void Search()
        {
            driver.Manage().Cookies.AddCookie(new Cookie("cookie-notice", "understood")); 

            TestCaseExecNo2 testCase = new TestCaseExecNo2(driver);
            bool result = testCase.ExecuteSearch();
            Assert.IsTrue(result);
        }

        [Test, Order(3), TestCase(Description = "Click on the link “Product Launch V14” " +
            "And check you’re redirected to the particular article and that the page is loaded properly (1 - 2 checks of your choice)" +
            "Navigate to News" +
            "More… > News & Events > News" +
            "Verify that the same article is present there.")]
        public void ProductLaunchIsPresent()
        {
            ProductLaunch productLaunch = new ProductLaunch(driver);
            bool result = productLaunch.TestCaseExec();
            Assert.IsTrue(result);

        }

        [Test, Order(4), TestCase(Description = "Go to the home page " +
            "Click on Contact.On opened page click U.S West and check if there is class change on this element (take a screenshot of that)" +
            "On this same page do a mouse hover on different location (take a screenshot before and after performing the action)")]
        public void Contact()
        {
            Contact contact = new Contact(driver);
            bool result = contact.TestCaseExec();
            Assert.IsTrue(result);

        }

        [Test, Order(5), TestCase(Description = "Open Read Privacy Policy in another tab. Check if it is opened and loaded properly (1-2 checks of your choice)" +
            "Click on Close button for Privacy Policy on previous tab and close tab with displayed Privacy Policy.Check if Privacy Policy will be not shown anymore on the site.")]
        public void OpenInNewTab()
        {
            NewTab newTab = new NewTab(driver);
            bool result = newTab.TestCaseExec();
            Assert.IsTrue(result);

        }

        [Test, Order(6), TestCase(Description = "From the bottom of the Home page choose Cases link. On new open click Download PDF button. Fill necessary data to download PDF file. After downloading file, check if it is downloaded to you local machine.")]
        public void Cases()
        {
            driver.Manage().Cookies.AddCookie(new Cookie("cookie-notice", "understood"));
            driver.Navigate().Refresh();

            PdfDownload pdf = new PdfDownload(driver);
            bool result = pdf.TestCaseExec();
            Assert.IsTrue(result);
        }
        
        [TearDown]
        public void Cleanup()
        {
            logger.CreateTestLogs(TestContext.CurrentContext);
            driver.Quit();
        }

        [OneTimeTearDown]
        public void CleanupAllTests()
        {
            driver.Quit();
        }
    }
}
