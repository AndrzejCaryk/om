using ExerciseOmada.Locators;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExerciseOmada
{
    class TestCaseExecNo2
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IWebDriver driver;
        public TestCaseExecNo2(IWebDriver driver)
        {
            this.driver = driver;
        }
        public bool ExecuteSearch()
        {
            try
            {
                MainPage page = new MainPage(driver);
                page.SearchBox.SendKeys("GDPR");
                page.SearchBox.SendKeys(Keys.Enter);
                Assert.IsTrue(ExistMoreThanOneResault());
                
                return true;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("error: {0}", ex);
                throw ex;
            }
        }
        private bool ExistMoreThanOneResault()
        {
            try
            {
                SearchPage searchPage = new SearchPage(driver);

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(searchPage.ElementOnPage));

                log.DebugFormat("FoundElements: {0}", searchPage.FoundElements.Count);
                if (searchPage.FoundElements.Count >= 1)
                {
                    foreach (IWebElement element in searchPage.FoundElements)
                    {
                        Console.WriteLine(element.Text);
                        if(element.Text.Contains("Product Launch V14"))
                        {
                            element.Click();
                            return true;
                        }
                    }
                }
                else
                {
                    throw new Exception("search result is empty");
                }
                return false;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("ExistMoreThanOneResault error: {0}", ex);
                throw ex;
            }
        }
    }
}
