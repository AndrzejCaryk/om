using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseOmada.Locators
{
    class PressReleaseDetailPage
    {
        IWebDriver driver;
        public PressReleaseDetailPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement Text => driver.FindElement(By.XPath("//*[contains(@class, 'text__content')]"));
    }
}
