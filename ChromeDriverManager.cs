using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoLibreTests
{
    public sealed class ChromeDriverManager
    {
        private static ChromeDriver driverInstance;
        private static Actions actionsInstance;


        private ChromeDriverManager() { }

        public static ChromeDriver GetDriver()
        {
            if (driverInstance == null)
            {
                ChromeOptions options = new ChromeOptions();

                // Add any desired options to the options object here
                options.AddArguments("--start-maximized");
                driverInstance = new ChromeDriver(options);

            }
            return driverInstance;
        }

        public static Actions GetActions()
        {
            if (actionsInstance == null)
            {
                actionsInstance = new Actions(GetDriver());
            }
            return actionsInstance;
        }

    }

}