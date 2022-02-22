using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;


namespace WebDriverConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string department = "Разработка продуктов";

            // Английский - 1
            // Русский - 2
            // Немецкий - 3
            int language = 1;

            WebDriverCore webDriverCore = new WebDriverCore(department, language);
            webDriverCore.TestProgram();            
        }
    }
}
