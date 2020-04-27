using Microsoft.VisualStudio.TestPlatform.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.IO;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace KeytorcTest
{
    abstract class MyVariable:INeedToFunctions
    {
        readonly IWebDriver driver = new ChromeDriver();
        private readonly String searchBoxId = "searchData";
        private readonly String emailId = "email";
        private readonly String passwordId = "password";
        private readonly String secondPageId = "//*[@id='contentListing']/div/div/div[2]/div[4]/a[2]";
        private readonly String favoriteId = "/html/body/div[1]/div[3]/div/div/div[2]/section[1]/div[2]/ul/li[2]/div/div[1]/span";
        private readonly String emailName = "zeynepdinc.23@gmail.com";
        private readonly String passwordName = "23N2020";
        private readonly String url = "http://www.n11.com";
       
        public IWebElement UserName()
        {
            return driver.FindElement(By.XPath("//*[@id='header']/div/div/div[2]/div[2]/div[2]/div[1]/a[2]"));
        }

        IWebElement SearchBox()
        {
            return driver.FindElement(By.Id(searchBoxId));
        }

        IWebElement Email()
        {
            return driver.FindElement(By.Id(emailId));
        }

        IWebElement Password()
        {
            return driver.FindElement(By.Id(passwordId));
        }
        
        IWebElement SecondPage()
        {
            return driver.FindElement(By.XPath(secondPageId));
        }

        IWebElement CloseAds()
        {
            return driver.FindElement(By.ClassName("btnHolder"));
        }
        
        public void BasicSettings()
        {
            driver.Navigate().GoToUrl(url);
            //driver.Manage().Cookies.DeleteAllCookies();
            CloseAds().Click();
            driver.Manage().Window.Maximize();
            driver.FindElement(By.ClassName("closeBtn")).Click();
            TakenScreenShot("Home");
        }

        public IWebElement Slogan()
        {
          return driver.FindElement(By.ClassName("hLogoT"));
        }

        void Wait(int time)
        {
            Thread.Sleep(time);
        }
        
        public IWebElement SignIn()
        {
            return driver.FindElement(By.ClassName("btnSignIn"));
        }
        
        public IWebElement LoginButton()
        {
            return driver.FindElement(By.Id("loginButton"));

        }
        
        public IWebElement Logo()
        {
            return driver.FindElement(By.ClassName("logo"));
        }
        
        public void LoginProcesses()
        {
            SignIn().Click();
            Wait(3000);
            Email().SendKeys(emailName);
            Wait(3000);
            Password().Click();
            Password().SendKeys(passwordName);
            Wait(3000);
            LoginButton().Click();
            Logo().Click();
            Wait(3000);
        }
        
        public IWebElement BreadCrumb()
        {
            return driver.FindElement(By.XPath("//*[@id='breadCrumb']/ul/li[2]/a"));
        }
        
        public void FileProcesses(String fileName,String message)
        {
            FileStream fileStream = new FileStream(CreateFileName() +fileName+ ".txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine(message+ streamWriter.NewLine);
            streamWriter.Flush();
            streamWriter.Close();
        }
      
        public void SearchProcesses()
        {
            Logo().Click();
            SearchBox().Click();
            SearchBox().SendKeys("Samsung"+Keys.Enter);
            Wait(3000);
            MoveToSelected(SearchBox());
            TakenScreenShot("Search");
        }
        
        IWebElement ElementOf3th()
        {
            return driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div/div[2]/section[1]/div[2]/ul/li[3]/div/div[1]/span"));
        }
        
        public void SelectProcesses()
        {
            MoveToSelected(SecondPage());
            SecondPage().Click();
            Wait(3000);
            MoveToSelected(SecondPage());
            TakenScreenShot("SecondPage");
            MoveToSelected(ElementOf3th());
            ElementOf3th().Click();
        }
        
        public IWebElement ContentMessage()
        {
            return driver.FindElement(By.ClassName("message"));
        }
        
        public void MoveToFavorite()
        {
            UserName().Click();
            driver.FindElement(By.XPath("//*[@id='myAccount']/div[1]/div[1]/div[2]/ul/li[5]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div[2]/div[3]/ul/li[1]/div/a/h4")).Click();
            MoveToSelected(SearchBox());
            driver.FindElement(By.ClassName("deleteProFromFavorites")).Click();
            Verify(ContentMessage(), "Ürününüz listeden silindi.", "Ürün silinemedi");
            Wait(3000);
            CloseAds();
            TakenScreenShot("movetoproduct");
        }

        public void CloseTest()
        {
            driver.Quit();
        }

        public void MoveToSelected(IWebElement element)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(element);
            action.Perform();
        }

        public void Verify(IWebElement element,String actually,String failValue)
        {
            Assert.IsTrue(element.Text.Equals(actually),failValue);
            if (element.Text.ToString() == actually)
            {
                String mesaj = element.Text.ToString() + " için yaptığınız kontrol işlemi başarılı.";
                Logger.LogMessage(mesaj);
                FileProcesses(element.Text.ToString(),mesaj);
            }
            else
            {
                String mesaj = element.Text.ToString() + " için yaptığınız kontrol işlemi başarısız. Olması gereken değer "+actually;
                Logger.LogMessage(mesaj);
                FileProcesses(element.Text.ToString(),mesaj);
            }  
        }
        
        String CreateFileName()
        {
            Directory.CreateDirectory((Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString() + "\\Screenshoots\\"));
            return (Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString() + "\\Screenshoots\\").ToString();
        }
       
        public void TakenScreenShot(String fileName)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot) driver;
            takesScreenshot.GetScreenshot().SaveAsFile(CreateFileName()+fileName+".png",ScreenshotImageFormat.Png);
           
        }

    }

}