using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace WebDriverConsoleApp
{
    class WebDriverCore
    {
        private string department;
        private int language;

        private ChromeDriver ChromeSession()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());

            var driver = new ChromeDriver();

            return driver;
        }

        public WebDriverCore(string dep, int lang)
        {
            department = dep;
            language = lang;
        }

        public void TestProgram()
        {
            var driver = ChromeSession();

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://careers.veeam.ru/vacancies");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            // Закрытие всплывающего окна
            driver.FindElement(By.XPath("//*[@id='cookiescript_close']")).Click();

            Thread.Sleep(1000);
            // Открытие меню выбора отдела
            driver.FindElement(By.XPath("//*[@id='sl']")).Click();

            // Выравнивание высоты экрана по меню
            IJavaScriptExecutor javaScript = (IJavaScriptExecutor)driver;
            var elementOne = driver.FindElement(By.XPath("//*[@id='root']/div/div[1]/div/div[2]"));
            javaScript.ExecuteScript("arguments[0].scrollIntoView();", elementOne);

            Thread.Sleep(1000);
            // Выбор отдела
            driver.FindElement(By.LinkText(department)).Click();

            Thread.Sleep(1000);
            // Открытие меню выбора языка
            driver.FindElement(By.XPath("//*[@id='root']/div/div[1]/div/div[2]/div[1]/div/div[3]/div/div")).Click();

            Thread.Sleep(1000);
            // Выбор языка
            driver.FindElement(By.XPath($"//*[@id='root']/div/div[1]/div/div[2]/div[1]/div/div[3]/div/div/div/div[{language}]/label")).Click();

            Thread.Sleep(1000);
            // Подсчет вакансий
            int vacanciesCount = driver.FindElement(By.XPath("//*[@id='root']/div/div[1]/div/div[2]/div[2]/div")).FindElements(By.XPath("//*[@id='root']/div/div[1]/div/div[2]/div[2]/div/a")).Count;

            Console.WriteLine($"Vacancies: {vacanciesCount}");

            Console.ReadLine();

            driver.Quit();
        }
    }
}
