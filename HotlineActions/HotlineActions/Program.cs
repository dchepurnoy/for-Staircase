using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotlineActions
{
    class Program
    {
        private const string Item = "macbook";
        private const int SelectedItem = 2;
        private const int min = 0;
        

        static void Main(string[] args)
        {

        }

        [Test]
        public void TestFindItemOnPage()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            StartPage startpage = new StartPage(driver);
            startpage.OpenUrl();
            SearchResultPage searchResultPage = startpage.SearchItem(Item);
            Assert.IsTrue(searchResultPage.CheckSearchResultPageLabelEnabled());

            driver.Quit();
        }


        [Test]
        public void TestViewReviews()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            StartPage startpage = new StartPage(driver);
            startpage.OpenUrl();
            SearchResultPage searchResultPage = startpage.SearchItem(Item);
            SelectedItemPage selectedItemPage = searchResultPage.OpenSelectedItem(SelectedItem);
            PopupInnerContent popupInnerContent = selectedItemPage.OpenViews();
            Thread.Sleep(2000);
            Assert.IsTrue(popupInnerContent.CheckModeLabelEnabled());

            driver.Quit();
        }


        [Test]
        public void TestOpenShorWithMinPrice()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            StartPage startpage = new StartPage(driver);
            startpage.OpenUrl();
            SearchResultPage searchResultPage = startpage.SearchItem(Item);
            SelectedItemPage selectedItemPage = searchResultPage.OpenSelectedItem(SelectedItem);
            selectedItemPage.OpenAllPropositions();
            selectedItemPage.GetAllPrices();
            selectedItemPage.ToSortByPrice();
            Thread.Sleep(2000);
            Shop shop = selectedItemPage.OpenMinPriceShop(min);
            Assert.IsTrue(shop.IsTextPresent(Item));

            driver.Quit();
        }

    }
}
