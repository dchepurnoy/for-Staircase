using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotlineActions
{
    class PopupInnerContent
    {
        private const string CloseButtonXpathLocator = ".//*[@id='hl_gallery']/a";
        private const string PopupModeId = "mode-all";
        private IWebDriver driver;

        public PopupInnerContent(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement CloseButton
        {
            get { return driver.FindElement(By.XPath(CloseButtonXpathLocator)); }
        }

        public IWebElement ModeLabel
        {
            get { return driver.FindElement(By.Id(PopupModeId)); }
        }

        public bool CheckModeLabelEnabled()
        {
            return ModeLabel.Enabled;
        }

        public void ClosePopup()
        {
            CloseButton.Click();
        }
    }
}
