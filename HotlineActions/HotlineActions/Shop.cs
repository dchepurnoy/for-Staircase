using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotlineActions
{
    class Shop
    {
        private IWebDriver driver;

        public Shop(IWebDriver driver)
        {
            this.driver = driver;
        }


        public bool IsTextPresent(string text)
        {
            string textOnPage = driver.FindElement(By.TagName("html")).Text.ToLower();
            bool flag = textOnPage.Contains(text);
            return flag;
        }
    }
}
