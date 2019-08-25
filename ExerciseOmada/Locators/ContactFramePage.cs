using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseOmada.Locators
{
    class ContactFramePage
    {
        IWebDriver driver;
        public ContactFramePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public By FirstName => By.XPath("//*[@id='581103_111661pi_581103_111661']");

        public IWebElement LastName => driver.FindElement(By.XPath("//*[@id='581103_111663pi_581103_111663']"));
        public IWebElement Company => driver.FindElement(By.XPath("//*[@id='581103_111665pi_581103_111665']"));
        public IWebElement BusinessEmail => driver.FindElement(By.XPath("//*[@id='581103_111667pi_581103_111667']"));
        public IWebElement Country => driver.FindElement(By.XPath("//*[@id='581103_111669pi_581103_111669']"));
        public IWebElement PrivacyPolicy => driver.FindElement(By.XPath("//*[@id='581103_111679pi_581103_111679_1438859_1438859']"));
        public IWebElement Recaptcha => driver.FindElement(By.XPath("//*[contains(@class, 'recaptcha-checkbox-border')]"));
        public IWebElement SubmitBtn => driver.FindElement(By.XPath("//*[@type='submit']"));

    }
}
