using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseOmada.Locators
{
    class PdfPage
    {
        IWebDriver driver;
        public PdfPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement Link => driver.FindElement(By.XPath("//*[@class='text__text']/p[1]/a"));
    }
}
