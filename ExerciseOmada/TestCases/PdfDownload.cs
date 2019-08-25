using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using System.Net;
using System.IO;
using NUnit.Framework;
using System.Threading;
using ExerciseOmada.Locators;
using log4net;

namespace ExerciseOmada
{
    class PdfDownload
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        IWebDriver driver;
        public PdfDownload(IWebDriver driver)
        {
            this.driver = driver;
        }
        public bool TestCaseExec()
        {
            try
            {
                new MainPage(driver).Cases.Click();
                new CasesPage(driver).FirstCaseFromList.Click();
                
                driver.Url = driver.FindElement(By.TagName("iframe")).GetAttribute("src");

                ContactFramePage contactFramePage = new ContactFramePage(driver);

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(contactFramePage.FirstName)).SendKeys("Janusz");
                contactFramePage.LastName.SendKeys("Testów");
                contactFramePage.Company.SendKeys("Janusz&Grażynka sp. z o.o.");
                contactFramePage.BusinessEmail.SendKeys("janusztestow@itk.pl");
                new SelectElement(contactFramePage.Country).SelectByText("Poland");
                contactFramePage.PrivacyPolicy.Click();
                
                try
                {
                    //clicking in Recaptcha (sometime is on site, some time not ;)
                    string frameName = driver.FindElement(By.TagName("iframe")).GetAttribute("name");
                    driver.SwitchTo().Frame(frameName);
                    contactFramePage.Recaptcha.Click();
                    Thread.Sleep(3000);
                    driver.SwitchTo().DefaultContent();
                }
                catch (Exception) { }

                contactFramePage.SubmitBtn.Click();

                var link = new PdfPage(driver).Link.GetAttribute("href");
                log.DebugFormat("link: {0}", link);
                String filePath = @"C:/AndrzejCarykZadanieRekrutacyjne/test-pdf-download.pdf";
                using (WebClient wc = new WebClient())
                {
                    wc.DownloadFile(link, filePath);
                    Assert.IsTrue(File.Exists(filePath));
                }
                return true;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("error: {0}", ex);
                throw ex;
            }
        }
    }
}
