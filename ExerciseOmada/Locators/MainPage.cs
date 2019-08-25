using OpenQA.Selenium;

namespace ExerciseOmada
{
    class MainPage
    {
        IWebDriver driver;
        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
        }
       
        public IWebElement SearchBox => driver.FindElement(By.XPath("//*[@class='header__search']/input"));
        public IWebElement MenuMore => driver.FindElement(By.XPath("//*[contains(@class, 'header__menuitem--megamenu js-menuitem is-right-aligned has-submenu')]/a"));
        public IWebElement CompanyContact => driver.FindElement(By.XPath("//*[contains(@href, 'company/contact')]"));
        public IWebElement Cases => driver.FindElement(By.XPath("//li/a[contains(@href, 'customers/cases')]"));
        public IWebElement PrivacyStatement => driver.FindElement(By.XPath("//p/a[contains(@href, 'privacy-statement')]"));
        public IWebElement CookiebarButton => driver.FindElement(By.XPath("//*[contains(@class, 'cookiebar__button button')]"));
        public IWebElement CookiebarBrick => driver.FindElement(By.XPath("//*[contains(@class, 'brick cookiebar')]"));

        public By ByFooter => By.ClassName("footer__navigation");
        public By PressRelease => By.XPath("//*[contains(@href, 'press-releases')]");




    }
}
